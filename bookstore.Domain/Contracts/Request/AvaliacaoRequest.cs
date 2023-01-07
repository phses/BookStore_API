using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Contracts.Request
{
    public class AvaliacaoRequest
    {
        [Required(ErrorMessage = "A nota da avaliacao e necessaria")]
        [Range(0, 5, ErrorMessage ="A nota precisa estar entre 0 e 5")]
        public int Nota { get; set; }

        [Required(ErrorMessage = "O Id do usuario que faz a avaliacao e necessario")]
        public int UsuarioId { get; set; }

        //Fazer a relacao automaticamente
        [Required(ErrorMessage = "O Id do livro relacionado a avaliacao e necessario")]
        public int LivroId { get; set; }
    }
}
