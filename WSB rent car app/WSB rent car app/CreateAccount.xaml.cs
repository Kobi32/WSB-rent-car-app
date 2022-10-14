using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (HasAllFieldsValue())
                {
                    UserRepository userRepository = new UserRepository();
                    if (await userRepository.IsLoginNameUnique(entryUserName.Text))
                    {
                        User user = new User
                        {
                            Login = entryUserName.Text,
                            FirstName = entryUserFirstName.Text,
                            LastName = entryLastName.Text,
                            City = entryCity.Text,
                            Street = entryStreet.Text,
                            Password = entryPassword.Text
                        };

                        var isSaved = await userRepository.AddUser(user);
                        if (isSaved)
                        {
                            ClearAllFields();
                            labelMessage.IsVisible = true;
                            labelMessage.TextColor = Color.Black;
                            labelMessage.Text = "New user added. You can sign in.";
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
                labelMessage.Text = "string.Format(\"Error occuerd. Please try agian later.{0}\", err)";
            }
        }

        private bool HasAllFieldsValue()
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

            if(!ArePassowrdsMatch())
            {
                labelMessage.IsVisible = true;
                labelMessage.Text = String.Format("Passwords are not the same.");
                return false;
            }
            return true;
        }

        private bool ArePassowrdsMatch() 
        {
            string password = entryPassword.Text;
            string passwordConfirmation = entryPasswordConfirmation.Text;

            if (string.Equals(password, passwordConfirmation))
            {
                return true;
            }
            else 
            {
                return false;
            }  
        }

        private void ClearAllFields()
        {
            var allEntryFields = RegisterStack.Children.ToList();

            foreach (var field in allEntryFields)
            {
                if (field is Entry myField)
                {
                    myField.Text = null;
                }
            }
        }
    }
}