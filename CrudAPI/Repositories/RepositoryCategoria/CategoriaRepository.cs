using CrudAPI.Data;
using CrudAPI.Model;
using CrudAPI.Model.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Services
{
   public class CategoriaRepository : ICategoriaRepository
   {
      private readonly APIContext _context;

      public CategoriaRepository(APIContext context)
      {
         _context = context;
      }
      public IEnumerable<Categoria> All()
      {
         return _context.Categorias;
      }

      public void Delete(long? id)
      {
         Categoria cat = _context.Categorias.SingleOrDefault(x => x.CategoriaID == id);
         _context.Remove(cat);
         _context.SaveChanges();

      }

      public Categoria Find(long? id)
      {
         Categoria cat = _context.Categorias.SingleOrDefault(x => x.CategoriaID == id);
         return cat;
      }

      public void Insert(Categoria categoria)
      {
         _context.Categorias.Add(categoria);
         _context.SaveChanges();
      }

      public bool CategoriaExist(long? id)
      {
         Categoria categoria = _context.Categorias.SingleOrDefault(x => x.CategoriaID == id);
         return (categoria != null);
      }

      public void Update(Categoria categoria)
      {
         _context.Categorias.Update(categoria);
         _context.SaveChanges();
      }
   }
}
