using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_rent_car_app.Models;
using WSB_rent_car_app.Repository;
using WSB_rent_car_app.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarSearch : ContentPage
    {
        public CarSearch()
        {
            InitializeComponent();
            DateLabelDays.Text = PickerDateUP.Date.Date.ToString("dd");
            DateLabelMonthYear.Text = PickerDateUP.Date.Date.ToString("MMM") + " | " + PickerDateUP.Date.Date.ToString("yyyy");
            DateLabelDaysOff.Text = PickerDateOFF.Date.Date.ToString("dd");
            DateLabelMonthYearOff.Text = PickerDateOFF.Date.Date.ToString("MMM") + " | " + PickerDateOFF.Date.Date.ToString("yyyy");
        }
        private void ButtonSearch_Clicked(object sender, EventArgs e)
        {
            GetCarsData();
        }

        private async void GetCarsData()
        {
            CarsRepository carsRepository = new CarsRepository();
            var cars = await carsRepository.GetCarsData(entrySearchLocation.Text);
            carView.ItemsSource = cars;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PickerDateUP.Focus();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            PickerDateOFF.Focus();
        }

        private void PickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabelDays.Text = PickerDateUP.Date.Date.ToString("dd");
            DateLabelMonthYear.Text = PickerDateUP.Date.Date.ToString("MMM") + " | " + PickerDateUP.Date.Date.ToString("yyyy");    
        }

        private void PickerDateOFF_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabelDaysOff.Text = PickerDateOFF.Date.Date.ToString("dd");
            DateLabelMonthYearOff.Text = PickerDateOFF.Date.Date.ToString("MMM") + " | " + PickerDateOFF.Date.Date.ToString("yyyy");
        }
    }
}