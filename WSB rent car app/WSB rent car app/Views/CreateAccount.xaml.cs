using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Controllers;
using WSB_rent_car_app.Models;
using WSB_rent_car_app.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private async void ButtonCreateAccount_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (HasAllFieldsProperValue())
                {
                    UserRepository userRepository = new UserRepository();
                    var userData= await userRepository.GetUserData(entryUserName.Text);
                    if (userData==null)
                    {
                        User newUser = new User
                        {
                            Login = entryUserName.Text,
                            FirstName = entryUserFirstName.Text,
                            LastName = entryLastName.Text,
                            Email = entryEmail.Text,
                            City = entryCity.Text,
                            Street = entryStreet.Text,
                            Password = entryPassword.Text
                        };

                        var isSaved = await userRepository.AddUser(newUser);
                        if (isSaved)
                        {
                            ClearAllFields();
                            labelMessage.IsVisible = true;
                            labelMessage.Text = "Your account has been created. You can sign in.";
                        }
                        else
                        {
                            labelMessage.IsVisible = true;
                            labelMessage.Text = "Unable to register new user. Please try agian later.";
                        }

                    }
                    else 
                    {
                        labelMessage.IsVisible = true;
                        labelMessage.Text = "Unable to create account. This user name already exists.";
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("{0} Exception caught.", err);
                labelMessage.IsVisible = true;
                labelMessage.Text = "Error occuerd. Please try agian later.";
            }
        }

        private bool HasAllFieldsProperValue()
        { 
            var allEntryFields = RegisterStack.Children.ToList();

            foreach (var field in allEntryFields)
            {
                if (field is Entry myField)
                {
                    if (string.IsNullOrEmpty(myField.Text))
                    {
                        labelMessage.IsVisible = true;
                        labelMessage.Text = String.Format("All above fields are required. Please type {0}." , myField.Placeholder);
                        return false;
                    }
                }
            }

            UserController userController = new UserController();

            if(!userController.IsValidEmail(entryEmail.Text))
            {
                labelMessage.IsVisible = true;
                labelMessage.Text = "Your email looks incorrect. Please validate.";
                return false;
            }

            if (!userController.ArePassowrdsMatch(entryPassword.Text, entryPasswordConfirmation.Text))
            {
                labelMessage.IsVisible = true;
                labelMessage.Text = "Passwords are not the same.";
                return false;
            }
            return true;
        }

        private void ClearAllFields()
        {
            var allEntryFields = RegisterStack.Children.ToList();

            foreach (var field in allEntryFields)
            {
                if (field is Entry myField)
                {
                    myField.Text = string.Empty;
                }
            }
        }
    }
}