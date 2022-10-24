using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Controllers;
using WSB_rent_car_app.Models;
using WSB_rent_car_app.Service;
using Xamarin.Forms;

namespace WSB_rent_car_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if (AreLoginsFieldsNotEmpty())
            { 
                UserDetails user = await CheckUserCredentials();
                if ((bool)user.isLoginDataCorrect) 
                {
                    MainApplicationWindow page = new MainApplicationWindow();
                    UserDataModel userDataModel = new UserDataModel();
                    userDataModel.UserDetails = user;
                    page.BindingContext = user;
                    await Navigation.PushAsync(page);
                    ClearAllFields();
                }
            }
        }

        private bool AreLoginsFieldsNotEmpty()
        {
            bool isLoginEmpty = string.IsNullOrEmpty(entryUserName.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(entryPassword.Text);
            if (isLoginEmpty)
            {
                labelMessage.Text = "Please type user name.";
                return false;
            }
            else if (isPasswordEmpty)
            {
                labelMessage.Text = "Please type password.";
                return false;
            }
            else 
            {
                return true;
            }
        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccount());
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            var allEntryFields = LoginStack.Children.ToList();

            foreach (var field in allEntryFields)
            {
                if (field is Entry myField)
                {
                    myField.Text = string.Empty;
                }
            }
            labelMessage.Text = "";
        }
        private async Task<UserDetails> CheckUserCredentials() 
        {
            UserRepository userRepository = new UserRepository();
            UserDetails userData = await userRepository.GetUserData(entryUserName.Text);
            if (userData == null)
            {
                userData.isLoginDataCorrect = false;
                labelMessage.Text = "User or passowrd are incorrect. Please try agian.";
                return userData;
            }
            else
            {
                UserController userController = new UserController();
                if (userController.ArePassowordsMatch(entryPassword.Text,userData.Password))
                {
                    userData.isLoginDataCorrect = true;
                    return userData;
                }
                else
                {
                    userData.isLoginDataCorrect = false;
                    labelMessage.Text = "User or passowrd are incorrect. Please try agian.";
                    return userData;
                }
            }      
        }
    }
}
