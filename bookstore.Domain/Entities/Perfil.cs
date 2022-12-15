using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Entities
{
    public class Perfil
    {
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
