using CrudAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Data
{
   public class APIContext : DbContext
   {
      public APIContext(DbContextOptions<APIContext> options) : base(options)
      {

      }

      public DbSet<Categoria> Categorias { get; set; } 
      public DbSet<Produto> Produtos { get; set; }
      public DbSet<User> Users { get; set; }
   }
}
