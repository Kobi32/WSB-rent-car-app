﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCreditCard : ContentPage
    {
        public EditCreditCard(string id)
        {
            InitializeComponent();
        }
        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}