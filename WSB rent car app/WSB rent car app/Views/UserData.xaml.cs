using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Navigation.PushAsync(new EditUserName());
        }

        private void ButtonEditEmail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditEmail());
        }

        private void ButtonEditAddress_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditAddress());
        }

        private void ButtonEditPhone_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditPhone());
        }

        private void ButtonEditCreditCard_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCreditCard());
        }
    }
}