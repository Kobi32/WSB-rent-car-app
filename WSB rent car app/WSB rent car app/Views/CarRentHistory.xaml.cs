using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarRentHistory : ContentPage
    {
        public CarRentHistory()
        {
            InitializeComponent();
            ObservableCollection<MyItem> MyItems = new ObservableCollection<MyItem>();
            MyItems.Add(new MyItem() { Switch = "VW Golf", Addend1 = "Gdańsk", Addend2 = "250 PLN" , Addend3 = "3" });
            MyItems.Add(new MyItem() { Switch = "VW Polo", Addend1 = "Opole", Addend2 = "150 PLN", Addend3 = "1" });
            MyItems.Add(new MyItem() { Switch = "Opel Corsa", Addend1 = "Warszawa", Addend2 = "550 PLN", Addend3 = "3" });
            MyItems.Add(new MyItem() { Switch = "Fiat Tipo", Addend1 = "Gdańsk", Addend2 = "225 PLN", Addend3 = "3" });
            listHistory.ItemsSource = MyItems;
        }

        public class MyItem : INotifyPropertyChanged
        {

            public string Switch { get; set; }


            public string Addend1 { get; set; }

            public string Addend2 { get; set; }

            public string Addend3 { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}