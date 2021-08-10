using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DataAccess.Dtos.User
{
    public class UserSignUpDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
