
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public async Task<bool> IsLoginNameUnique(string loginName)
        {
            var data = await firebaseClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(loginName));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
    }
}
