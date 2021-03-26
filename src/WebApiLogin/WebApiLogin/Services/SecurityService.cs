using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public static string Criptografar(string senha)
        {
            // Cria uma nova intância do objeto que implementa o algoritmo para
            // criptografia MD5
            MD5 md5Hasher = MD5.Create();

            // Criptografa o valor passado
            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(senha));

            // Cria um StringBuilder para passarmos os bytes gerados para ele
            StringBuilder strBuilder = new StringBuilder();

            // Converte cada byte em um valor hexadecimal e adiciona ao
            // string builder
            // and format each one as a hexadecimal string.
            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }

            // retorna o valor criptografado como string
            return strBuilder.ToString();
        }
    }
}
