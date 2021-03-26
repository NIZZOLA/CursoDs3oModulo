using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLogin.Models;
using WebApiLogin.Services;

namespace WebApiLogin.ExtensionMethos
{
    public static class ExtensionMethods
    {
        public static void Autenticar(this Controller controller)
        {
            var autenticacao = SecurityService.IsAutenticated( controller.HttpContext );

            UsuarioLogado.NomeDoUsuario = autenticacao == "" ? "Não Logado" : autenticacao;
        }
    }
}
