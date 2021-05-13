using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Model
{
   public class User
   {
      [Key]
      public int UserId { get; set; } 
      public string Username { get; set; }
      public string Password { get; set; }
      public string Role { get; set; }
   }
}
