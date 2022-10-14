using System;
using System.Collections.Generic;
using System.Text;

namespace WSB_rent_car_app.Interfaces
{
    interface IUser
    {
        string Login { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string Password { get; set; }
    }
}
