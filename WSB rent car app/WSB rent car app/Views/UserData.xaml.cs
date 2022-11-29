using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Models;
using WSB_rent_car_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserData : ContentPage
    {
        public UserData()
        {
            InitializeComponent();
        }

        private void ButtonEditUserName_Clicked(object sender, EventArgs e)
        {
            var id = labelUserLogin.AutomationId;
            var firstName = dataUserFirstName.Text;
            var lastName = dataUserLastName.Text;
            Navigation.PushAsync(new EditUserName(id, firstName, lastName));
        }

        private void ButtonEditEmail_Clicked(object sender, EventArgs e)
        {
            var id = labelUserLogin.AutomationId;
            var userEmail = dataUserEmail.Text;
            Navigation.PushAsync(new EditEmail(id, userEmail));
        }

        private void ButtonEditAddress_Clicked(object sender, EventArgs e)
        {
            var id = labelUserLogin.AutomationId;
            var street = dataStreet.Text;
            var city = dataCity.Text;
            Navigation.PushAsync(new EditAddress(id,street,city));
        }

        private void ButtonEditPhone_Clicked(object sender, EventArgs e)
        {
            var id = labelUserLogin.AutomationId;
            var phone = dataPhone.Text;
            Navigation.PushAsync(new EditPhone(id, phone));
        }

        private void ButtonEditCreditCard_Clicked(object sender, EventArgs e)
        {
            var id = labelUserLogin.AutomationId;
            Navigation.PushAsync(new EditCreditCard(id));
        }
    }
}