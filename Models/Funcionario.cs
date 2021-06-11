using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoDaniel02.Models
{
    public class Funcionario
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(80, ErrorMessage = "Nome não pode exceder 80 caracteres")]
        public string Nome { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Email com formato inválido")]
        [Required]
        public string Email { get; set; }
    }
}
