using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Model.Repository
{
   public interface IUserRepository
   {
      bool UserExist(long? id);
      IEnumerable<User> All();
      User Find(long? id);
      void Insert(User user);
      void Update(User user);
      void Delete(long? id);
      User FindByUserName(string UserName);
   }
}
