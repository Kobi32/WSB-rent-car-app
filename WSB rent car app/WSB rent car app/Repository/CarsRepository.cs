using Firebase.Database;
using Newtonsoft.Json;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Models;

namespace WSB_rent_car_app.Repository
{
    internal class CarsRepository
    {
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://wsbrentcarapp-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<List<Cars>> GetCarsData(string city)
        {
            var carsData = (await firebaseClient.Child("Cars").Child(city).OnceAsync<Cars>()).Select(item => new Cars
            {
                CarName = item.Key,
            }).ToList();

            return carsData;
        }
    }
}
