using System.Collections.Generic;
using CoreDBFirst.Models;

namespace CoreDBFirst.Repository
{
    public interface IRepository
    {
       Response<User>  GetUserById(int id);
       Response<List<User>> GetUsers(); 
       Response<string> Delete(int id);

       Response<string> UpdateUser(User user);
       Response<string> Insert_data(User _user);
    }
}