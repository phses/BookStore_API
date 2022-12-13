using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Entities
{
    public class LivroAvaliacao
    {
        public int AvaliacaoId { get; set; }
        public Avaliacao Avaliacao { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
