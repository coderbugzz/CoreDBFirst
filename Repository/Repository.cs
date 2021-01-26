using System;
using System.Collections.Generic;
using System.Linq;
using CoreDBFirst.Models;

namespace CoreDBFirst.Repository
{
    public class Repository : IRepository
    {
        private readonly UserDBContext _dbContext;
        public Repository(UserDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Response<User> GetUserById(int id)
        {
            Response<User> result = new Response<User>();
            result.Data = _dbContext.Users.Find(id);
            return result;
        }

        public Response<List<User>> GetUsers()
        {
            Response<List<User>> result = new Response<List<User>>();
            result.Data = _dbContext.Users.ToList(); 
            return result;
        }
        public Response<string> Delete(int id)
        {
            Response<string> result = new Response<string>();
            try
            {
                    User data = _dbContext.Users.FirstOrDefault(u => u.Id == id);
                    _dbContext.Users.Remove(data);
                    var res =  _dbContext.SaveChanges();
                    if (res == 1)
                    {
                        result.message = "Success";
                    }
                    else
                    {
                        result.message = "Failed";
                    }
                
            }
            catch (Exception ex)
            {
                result.message = ex.Message;

            }
            return result;
        }

        public Response<string> UpdateUser(User user)
        {
            Response<string> result = new Response<string>();
            try
            {
               
                    User data = _dbContext.Users.FirstOrDefault(d => d.Id == user.Id);

                    data.FirstName = user.FirstName;
                    data.LastName = user.LastName;
                    data.MiddleName = user.MiddleName;
                    data.Contact = user.Contact;

                    var res = _dbContext.SaveChanges();
                    if (res == 1)
                    {
                        result.Data = "Success";
                    }
                    else
                    {
                        result.Data = "Failed";
                    }
               
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
            }
            return result;
        }

        public Response<string> Insert_data(User _user)
        {
            Response<string> result = new Response<string>();
            try
            {
                
                    var user = _dbContext.Users.FirstOrDefault(d => d.FirstName == _user.FirstName && d.LastName == _user.LastName);
                    if (user != null) //if name exist update data
                    {
                        result.Data = "User already Exists!";
                    }
                    else
                    {
                        _dbContext.Users.Add(_user);
                        var res = _dbContext.SaveChanges();
                        if (res == 1)
                        {
                            result.Data = "Success";
                        }
                        else
                        {
                            result.Data = "Failed"; 
                        }

                    }
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;

            }
            return result;
        }
    }
}