using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAddress : ContentPage
    {
        readonly string _id;
        public EditAddress(string id , string street, string city)
        {
            InitializeComponent();
            _id = id;
            entryStreet.Text = street;
            entryCity.Text = city;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            UpdateData();
            Navigation.PopAsync();
        }

        private async void UpdateData()
        {
            UserRepository user = new UserRepository();
            await user.EditUserProperty(_id, "Street", entryStreet.Text, "City", entryCity.Text);
        }
    }
}