using bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Contracts.Request
{
    public class LivroRequest
    {
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public double Valor { get; set; }

        public double? Desconto { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 50)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Editora { get; set; }

        public string? Imagem { get; set; }

        public string? ImagemUpload { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public int FornecedorId { get; set; }
    }
}
