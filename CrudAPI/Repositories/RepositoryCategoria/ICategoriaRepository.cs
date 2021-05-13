using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Model.Repository
{
   public interface ICategoriaRepository
   {
      bool CategoriaExist(long? id);
      IEnumerable<Categoria> All();
      Categoria Find(long? id);
      void Insert(Categoria categoria);
      void Update(Categoria categoria);
      void Delete(long? id);
   }
}
