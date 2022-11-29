using System;
using System.Collections.Generic;
using System.Text;
using WSB_rent_car_app.Interfaces;

namespace WSB_rent_car_app.Models
{
    public class Cars : ICars
    {
        public string CarName { get; set; }
    }
}
