using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudAPI.Model
{
   public class Categoria
   {

      [Key]
      public long CategoriaID { get; set; }

      [Required]
      [DataType("Text")]
      public string Descricao { get; set; }

   }
}
