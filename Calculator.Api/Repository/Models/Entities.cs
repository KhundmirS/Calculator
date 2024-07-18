using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class User : IdentityUser
    {
        public string emailAddress { get; set; }
    }
    public class Calculation
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
    }
    public class CalculationResponse
    {
        public string Id { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class RequestExpression
    {
        public string Expression { get; set; }
    }
}
