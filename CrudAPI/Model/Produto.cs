using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Model
{
   public class Produto
   {
      [Key]
      public long ProdutoID { get; set; }
      public string Descricao { get; set; }
      public string Sobre { get; set; }

      [ForeignKey("Categoria")]
      public long CategoriaID { get; set; }
      public Categoria Categoria { get; set; }
   }
}
