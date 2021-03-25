using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLogin.Services;

namespace WebApiLogin.Controllers
{
    public class ControllerPai : Controller
    {
        internal void Autenticar()
        {
            var autenticacao = SecurityService.IsAutenticated(HttpContext);

            ViewBag.usuario = autenticacao == "" ? "Não Logado" : autenticacao;
            ViewBag.autenticado = autenticacao == "" ? false : true;
        }
    }
}
