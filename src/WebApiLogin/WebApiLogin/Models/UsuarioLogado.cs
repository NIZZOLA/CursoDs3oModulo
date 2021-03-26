using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLogin.Models
{
    public static class UsuarioLogado
    {
        public static string NomeDoUsuario { get; set; }

        public static bool Autenticado()
        {
            if (UsuarioLogado.NomeDoUsuario == "")
                return false;

            return true;
        }
    }
}
