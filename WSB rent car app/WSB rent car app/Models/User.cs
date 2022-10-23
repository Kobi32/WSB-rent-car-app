using System;
using System.Collections.Generic;
using System.Text;
using WSB_rent_car_app.Interfaces;

namespace WSB_rent_car_app.Models
{
    public class User : IUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}
