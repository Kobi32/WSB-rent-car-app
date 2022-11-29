using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPhone : ContentPage
    {
        readonly string _id;
        public EditPhone(string id, string phone)
        {
            InitializeComponent();
            _id = id;
            entryPhone.Text = phone;
        }
        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            UpdateData();
            Navigation.PopAsync();

        }
        private async void UpdateData()
        {
            UserRepository user = new UserRepository();
            await user.EditUserProperty(_id, "Phone", entryPhone.Text);
        }
    }
}