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
   public class UserRepository : IUserRepository
   {
      private readonly APIContext _context;

      public UserRepository(APIContext context)
      {
         _context = context;
      }
      public IEnumerable<User> All()
      {
         return _context.Users;
      }

      public bool Delete(long? id)
      {
         User user = _context.Users.SingleOrDefault(x => x.UserId == id);
         _context.Remove(user);
         return _context.SaveChanges() > -1;

      }

      public User Find(long? id)
      {
         User user = _context.Users.SingleOrDefault(x => x.UserId == id);
         return user;
      }

      public bool Insert(User user)
      {
         _context.Users.AddAsync(user);
         return _context.SaveChanges() > -1;
      }

      public bool UserExist(long? id)
      {
         User user = _context.Users.SingleOrDefault(x => x.UserId == id);
         return (user != null);
      }

      public bool Update(User user)
      {
         _context.Users.Update(user);
         return _context.SaveChanges() > -1;
      }

      public User FindByUserName(string UserName)
      {
         User user = _context.Users.SingleOrDefaultAsync(x => x.Username == UserName).Result;
         return user;
      }

      public bool VerificarLogin(string UserName, string Password, User user)
      {
         bool isValido = false;
         if (user.Username.Equals(UserName))
         {
            if (user.Password.Equals(Password))
            {
               isValido = true;
            }
         }

         return isValido;
      }
   }
}
