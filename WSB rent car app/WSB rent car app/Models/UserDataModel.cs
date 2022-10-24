using System;
using System.Collections.Generic;
using System.Text;

namespace WSB_rent_car_app.Models
{
    public class UserDataModel
    {
        public UserDetails UserDetails { set; get; }
        public UserDetails UserHistory { set; get; }

        public UserDataModel()
        {
            UserDetails = new UserDetails();
            UserHistory = new UserDetails();
        }
    }
}

