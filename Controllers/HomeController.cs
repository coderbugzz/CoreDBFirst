using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreDBFirst.Models;
using CoreDBFirst.Repository;

namespace CoreDBFirst.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;

        }
        /*   
          Display all users from the UserDB Table
         */
        public IActionResult Index() //list of user
        {
           
            var users =  _repository.GetUsers();
            return View(users.Data);
        }

        /*
          Display Register form
        */
       public IActionResult RegisterUser() //register New User
        {
            return View();
        }

         /*
           Register User to the table
        */
      [HttpPost]
     public IActionResult RegisterUser(User user) //register New User
        {
            if(ModelState.IsValid)
            {
                var result = _repository.Insert_data(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }


         /*
           Display Edit User form
         */
        public IActionResult UpdateUser(int Id) //Edit User
        {
              var result = _repository.GetUserById(Id);   

            return View(result.Data);
        }

        /*
           Update User info in the DB
         */
        [HttpPost]
        public IActionResult UpdateUser(User user) //Edit User
        {
             if(ModelState.IsValid)
                {
                        var result = _repository.UpdateUser(user);
                        return RedirectToAction("Index");
                }

            return View(user);
        }

        public IActionResult DeleteUser(int Id)
        {
            var result = _repository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
