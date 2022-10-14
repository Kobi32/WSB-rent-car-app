using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace WSB_rent_car_app.Controllers
{
    public class UserController
    {
        public bool IsValidEmail(string email)
        {
            {
                var valid = true;

                try
                {
                    var emailAddress = new MailAddress(email);
                }
                catch
                {
                    valid = false;
                }

                return valid;
            }
        }

        public bool ArePassowrdsMatch(string password, string passwordConfirmation)
        {
            if (string.Equals(password, passwordConfirmation))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
