using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Contracts.Request
{
    public class NotaRequest
    {
        [Required(ErrorMessage = "E necessario especificar a nova nota")]
        [Range(0, 5, ErrorMessage = "A nota precisa estar entre 0 e 5")]
        public int Nota { get; set; }
    }
}
