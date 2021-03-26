﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiLogin.Models;
using WebApiLogin.Services;
using WebApiLogin.ViewModels;

namespace WebApiLogin.Controllers
{
    public class UsuarioController : ControllerPai
    {
        private readonly ApiLoginContext _context;
        private readonly WebsiteEmailSettings _emailSettings;

        public UsuarioController(ApiLoginContext context, IOptions<WebsiteEmailSettings> emailSettings)
        {
            _context = context;
            _emailSettings = emailSettings.Value;
        }

        // GET: Usuario
        [Authorize]
        public async Task<IActionResult> Index()
        {
            this.Autenticar();
            return View(await _context.UsuarioModel.ToListAsync());
        }

        // GET: Usuario/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            Autenticar();

            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUsuario,Senha,Email")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.Senha = SecurityService.Criptografar(usuarioModel.Senha);
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUsuario,Senha,Email")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.Id == id);
        }

        // GET: Usuario/Create
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        // GET: Usuario/Create
        public IActionResult Login(UsuarioModel user)
        {
            Autenticar();

            ModelState["Id"].Errors.Clear();

            // verificar se existe o usuário e a senha é igual
            var usuarioModel = _context.UsuarioModel.Where(a => a.NomeUsuario == user.NomeUsuario).FirstOrDefault();
            if (usuarioModel == null)
            {
                // ViewData["Message"] = "O Usuário não foi encontrado.";
                ModelState.AddModelError("Nome", "Nome não encontrado !");
                return View(user);
            }

            if( usuarioModel.Senha != SecurityService.Criptografar(user.Senha))
            {
                // ViewData["Message"] = "Senha inválida.";
                ModelState.AddModelError("Senha", "Senha inválida !");
                return View(user);
            }

            /* criar cookies */
            var userClaims = new List<Claim>()
                {
                    //define o cookie
                    new Claim(ClaimTypes.Name, user.NomeUsuario),
                    new Claim(ClaimTypes.Email, "marcio@teste.com"),
                };
            
            var minhaIdentity = new ClaimsIdentity(userClaims, "Usuario");
            var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
            //cria o cookie
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Usuario" );
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            Autenticar();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout(UsuarioModel usuarioTeste)
        {
            Autenticar();

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Forget()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forget(UsuarioRecuperarSenha data)
        {
            if (data.Email == null)
                return BadRequest();

            var usuarioModel =  _context.UsuarioModel.Where(a => a.Email == data.Email).FirstOrDefault();
            if (usuarioModel == null)
            {
                return NotFound();
            }

            // enviar o e-mail 
            var emailService = new EmailService(_emailSettings);
            if (emailService.SendEmail("marcio.nizzola@etec.sp.gov.br", "Mensagem de Recuperação do seu Email", "the book is on the table "))
                return RedirectToAction("EmailDeRecuperacaoEnviado", "Usuario");

            // falta tratar o erro
            return View(usuarioModel);
        }

        public async Task<IActionResult> EmailDeRecuperacaoEnviado()
        {
            return View();
        }
    }
}
