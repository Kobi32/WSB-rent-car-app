using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSB_rent_car_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Message : ContentPage
    {
        public Message()
        {
            InitializeComponent();
            ObservableCollection<MyItem> MyItems = new ObservableCollection<MyItem>();
            MyItems.Add(new MyItem() { Switch = "WSB CARS", Addend1 = "Welcome", Addend2 = "28-11-2022" });
            MyItems.Add(new MyItem() { Switch = "WSB CARS", Addend1 = "Your last activites", Addend2 = "28-11-2022" });
            MyItems.Add(new MyItem() { Switch = "WSB CARS", Addend1 = "Summer discounts", Addend2 = "28-11-2022" });
            MyItems.Add(new MyItem() { Switch = "WSB CARS", Addend1 = "Check you user profile", Addend2 = "28-11-2022" });
            listMessage.ItemsSource = MyItems;
        }

            
    }

    public class MyItem : INotifyPropertyChanged
    {

        public string Switch { get; set; }


        public string Addend1 { get; set; }

        public string Addend2 { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}