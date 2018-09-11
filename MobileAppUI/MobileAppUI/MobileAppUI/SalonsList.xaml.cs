using MobileAppUI.InternalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SalonsList : ContentPage
	{
        private ObservableCollection<SalonList_Class> _salonList = new ObservableCollection<SalonList_Class>() { };
		public SalonsList ()
		{
			InitializeComponent ();
            ListOfSalons.ItemsSource = GetSalonList();
        }

        private IEnumerable<SalonList_Class> GetSalonList(string userSearch = null)
        {
            _salonList.Clear(); //Empty the older list.
            _salonList = new ObservableCollection<SalonList_Class>{
                new SalonList_Class { sId=0, sName="6 Salon", sAddress="777 20th Ave S, Ann Arbor, MI 48103", sState="Birmingham", sAccountNumber="123", sEmail="xyz@zbc.com", sPhone="978546879", sStatus="Complete" },
                new SalonList_Class { sId=1, sName="Elle Studio", sAddress="777 20th Ave S, Ann Arbor, MI 48103", sState="Northville", sAccountNumber="456", sEmail="xyz@zbc.com", sPhone="978546879", sStatus="In Progress" },
                new SalonList_Class { sId=2, sName="Liquid Salon", sAddress="777 20th Ave S, Ann Arbor, MI 48103", sState="Bloomfield Hills", sAccountNumber="789", sEmail="xyz@zbc.com", sPhone="978546879", sStatus="Not Started" },
                new SalonList_Class { sId=3, sName="One Society", sAddress="777 20th Ave S, Ann Arbor, MI 48103", sState="Northville", sAccountNumber="101112", sEmail="xyz@zbc.com", sPhone="978546879", sStatus="Rejected" },
                new SalonList_Class { sId=4, sName="Salon XL Color & Design Group", sAddress="777 20th Ave S, Ann Arbor, MI 48103", sState="", sAccountNumber="131415", sEmail="xyz@zbc.com", sPhone="978546879", sStatus="In Progress" }
            };

            if (string.IsNullOrEmpty(userSearch))
                return _salonList;

            return _salonList.Where(c => c.sName.Contains(userSearch));
        }

        private void ListOfSalons_Refreshing(object sender, EventArgs e)
        {
            ListOfSalons.ItemsSource = GetSalonList();
            ListOfSalons.EndRefresh();
        }

        private async void ListOfSalons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedItem = e.SelectedItem as SalonList_Class;
            //await DisplayAlert(selectedItem.sId.ToString(), selectedItem.sStatus, "ok");
            //string sAccountNumber, string sAddress, string sPhone, string sEmail
            await Navigation.PushAsync(new SalonDetail(selectedItem.sAccountNumber, selectedItem.sAddress, selectedItem.sPhone, selectedItem.sEmail));

            ListOfSalons.SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOfSalons.ItemsSource = GetSalonList(e.NewTextValue);
        }
    }
}