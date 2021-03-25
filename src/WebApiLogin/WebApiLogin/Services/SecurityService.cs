using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLogin.Services
{
    public static class SecurityService
    {
        public static string IsAutenticated(HttpContext contexto )
        {
            var usuario = "";
            if (contexto.User.Identity.IsAuthenticated)
            {
                usuario = contexto.User.Identity.Name;
            }
           
            return usuario;
        }

    }
}
