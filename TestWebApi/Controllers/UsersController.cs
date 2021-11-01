using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.BLL;
using TestWebApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestWebApi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("api/user/addUser")]
        public IActionResult AddUser(Users user) ///User user
        {

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
            {
                return new JsonResult("firstName, lastName, email can not be an empty or null")
                {
                    StatusCode = 400  
                };
            }

            if (user.Phone.ToString().Length != 12)
            {
                return new JsonResult("Incorrect format for number pfone. Please input 380......")
                {
                    StatusCode = 400
                };
            }

            ///need add checking for email

            var user1 = new UserDataBaseProvider().UserAdd(user.FirstName, user.LastName, user.Phone, user.Email, user.RoleId = 2);

            return new JsonResult(user1)
            {
                StatusCode = 200,
                Value = user1
            };
        }

        [HttpDelete]
        [Route("api/user/remove/{id}")]
        public IActionResult RemoveUser(int id)
        {
            bool status = new UserDataBaseProvider().UserRemove(id);

            if (!status)
            {
                return new JsonResult(status)
                {
                    StatusCode = 400,
                    Value = status
                };
            }

            return new JsonResult(status)
            {
                StatusCode = 200,
                Value = status
            };
        }
    }
}
