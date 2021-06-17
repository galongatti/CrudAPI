using CrudAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Repositories.RepositoryProduto
{
   public interface IProdutoRepository
   {      
      IEnumerable<Produto> All();
      Produto Find(long? id);
      bool Insert(Produto produto);
      bool Update(Produto produto);
      bool Delete(long? id);
      bool ProdutoExist(long? id);
   }
}
