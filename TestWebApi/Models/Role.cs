using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
        public DateTime Data { get; set; }
    }
}
