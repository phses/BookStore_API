
using bookstore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace bookstore.Domain.Contracts.Request
{
    public class FornecedorRequest
    {
        [Required(ErrorMessage ="O campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public TipoFornecedor Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public EnderecoRequest Endereco { get; set; }

        //public IEnumerable<int> LivrosId { get; set; }
    }
}
