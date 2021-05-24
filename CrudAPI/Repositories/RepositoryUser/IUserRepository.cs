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
      bool Insert(User user);
      bool Update(User user);
      bool Delete(long? id);
      User FindByUserName(string UserName);
   }
}
