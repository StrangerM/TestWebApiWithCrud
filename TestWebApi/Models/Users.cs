using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
   
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
