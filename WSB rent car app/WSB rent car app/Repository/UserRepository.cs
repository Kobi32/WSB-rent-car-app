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

        public async Task<bool> AddUser(User user)
        {
            var data = await firebaseClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(user));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        public async Task<User> GetUserData(string loginName)
        {
            var userData = (await firebaseClient.Child(nameof(User)).OnceAsync<User>()).Select(item => new User 
            {
                Login = item.Object.Login,
                FirstName = item.Object.FirstName,
                LastName = item.Object.LastName,
                Email = item.Object.Email,
                Street = item.Object.Street,
                City = item.Object.City,
                Password = item.Object.Password,
            }).ToList();

            var user =  userData.Where(x => x.Login == loginName).FirstOrDefault();
            return user;
        }
     }
}
