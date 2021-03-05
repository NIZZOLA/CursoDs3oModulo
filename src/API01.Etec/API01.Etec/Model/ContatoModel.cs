using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Model
{
    public class ContatoModel
    {
        [Key]
        [Column("Codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        public DateTime Nascimento { get; set; }
    }
}
