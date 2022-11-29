using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Models;
using WSB_rent_car_app.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserName : ContentPage
    {
        readonly string _id;

        public EditUserName(string id, string firstName, string lastName)
        {
            InitializeComponent();
            _id = id;
            entryUserFirstName.Text = firstName;
            entryLastName.Text = lastName;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            UpdateData();
            Navigation.PopAsync();
        }

        private async void UpdateData()
        {
            UserRepository user = new UserRepository();
            await user.EditUserProperty(_id, "FirstName" ,entryUserFirstName.Text, "LastName", entryLastName.Text);
        }
    }
}