using CrudAPI.Data;
using CrudAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Repositories.RepositoryProduto
{
   public class ProdutoRepository : IProdutoRepository
   {
      private readonly APIContext _context;

      public ProdutoRepository(APIContext apiContext)
      {
         _context = apiContext;
      }

      public IEnumerable<Produto> All()
      {
         return _context.Produtos.Include(x => x.Categoria);
      }

      public bool Delete(long? id)
      {
         Produto produto = _context.Produtos.Where(x => x.ProdutoID == id).FirstOrDefault();
         _context.Produtos.Remove(produto);
         return _context.SaveChanges() > 1;
      }

      public Produto Find(long? id)
      {
         Produto produto = _context.Produtos.Where(x => x.ProdutoID == id).FirstOrDefault();
         return produto;
      }

      public bool Insert(Produto produto)
      {
         _context.Produtos.Add(produto);
         return _context.SaveChanges() > 1;
      }

      public bool ProdutoExist(long? id)
      {
         Produto produto = _context.Produtos.Where(x => x.ProdutoID == id).FirstOrDefault();
         return produto != null;
      }

      public bool Update(Produto produto)
      {
         _context.Produtos.Update(produto);
         return _context.SaveChanges() > 1;

      }
   }
}
