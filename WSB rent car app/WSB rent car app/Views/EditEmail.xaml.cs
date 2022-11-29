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
    public partial class EditEmail : ContentPage
    {
        readonly string _id;
        public EditEmail(string id,string userEmail)
        {
            InitializeComponent();
            _id = id;
            entryEmail.Text = userEmail;
        }
        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            UpdateData();
            Navigation.PopAsync();
        }

        private async void UpdateData()
        {
            UserRepository user = new UserRepository();
            await user.EditUserProperty(_id, "Email", entryEmail.Text);
        }
    }
}