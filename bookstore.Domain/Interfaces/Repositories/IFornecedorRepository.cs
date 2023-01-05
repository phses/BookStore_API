using bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
       Task<Fornecedor> FindFornecedorEnderecoAsync(Expression<Func<Fornecedor, bool>> expression);
    }
}
