using Firebase.Database;
using Newtonsoft.Json;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Models;

namespace WSB_rent_car_app.Service
{
    public class UserRepository
    {
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://wsbrentcarapp-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<bool> AddUser(UserDetails user)
        {
            var data = await firebaseClient.Child(nameof(UserDetails)).PostAsync(JsonConvert.SerializeObject(user));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        public async Task<UserDetails> GetUserData(string loginName)
        {
            var userData = (await firebaseClient.Child(nameof(UserDetails)).OnceAsync<UserDetails>()).Select(item => new UserDetails 
            {
                Login = item.Object.Login,
                FirstName = item.Object.FirstName,
                LastName = item.Object.LastName,
                Email = item.Object.Email,
                Street = item.Object.Street,
                City = item.Object.City,
                Password = item.Object.Password,
                Phone = item.Object.Phone
            }).ToList();

            var user =  userData.Where(x => x.Login == loginName).FirstOrDefault();
            return user;
        }
     }
}
