using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WSB_rent_car_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void buttonLogin_Clicked(object sender, EventArgs e)
        {
            if (AreLoginsFieldsNotEmpty())
            {
                Navigation.PushAsync(new MainApplicationWindow());
            }
            else 
            {
                // dont navigate 
            }
        }

        private bool AreLoginsFieldsNotEmpty()
        {
            bool isLoginEmpty = string.IsNullOrEmpty(entryUserName.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(entryPassword.Text);
            if (isLoginEmpty || isPasswordEmpty)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}
