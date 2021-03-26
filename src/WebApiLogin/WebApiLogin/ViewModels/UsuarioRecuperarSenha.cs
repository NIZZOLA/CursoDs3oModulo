using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLogin.ViewModels
{
    public class UsuarioRecuperarSenha
    {
        [MaxLength(80, ErrorMessage = "O campo só permite até {0} caracteres ")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [Display(Name = "Endereço de Email")]
        public string Email { get; set; }
    }
}
