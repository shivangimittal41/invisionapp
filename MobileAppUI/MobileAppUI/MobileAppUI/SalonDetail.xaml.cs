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
	public partial class SalonDetail : ContentPage
	{
        private ObservableCollection<QuestionareDetails> _questionareList = new ObservableCollection<QuestionareDetails>() { };
        
        public SalonDetail (string sAccountNumber, string sAddress, string sPhone, string sEmail)
		{
			InitializeComponent ();
            sAccountNumberLabel.Text = sAccountNumber;
            sAddressLabel.Text = sAddress;
            sPhoneLabel.Text = sPhone;
            sEmailLabel.Text = sEmail;
            ListOfQuestionares.ItemsSource = GetQuestionareList();
        }

        private IEnumerable<QuestionareDetails> GetQuestionareList()
        {
            _questionareList.Clear(); //Empty the older list.
            _questionareList = new ObservableCollection<QuestionareDetails>{
                new QuestionareDetails { qId=0, qTitle="This is Questionare 1", qResponse="Yes", qLastUpdated="6/28/18", qPhoto="", qText="This is my comment." },
                new QuestionareDetails { qId=1, qTitle="This is Questionare 2", qResponse="No", qLastUpdated="6/29/18", qPhoto="", qText="This is my comment 2." },
                new QuestionareDetails { qId=2, qTitle="This is Questionare 3", qResponse="Yes", qLastUpdated="6/20/18", qPhoto="", qText="This is my comment 3." },
                new QuestionareDetails { qId=3, qTitle="This is Questionare 4", qResponse="No", qLastUpdated="6/21/18", qPhoto="", qText="This is my comment 4." },
                new QuestionareDetails { qId=4, qTitle="This is Questionare 5", qResponse="Yes", qLastUpdated="6/10/18", qPhoto="", qText="This is my comment 5." }
            };

            return _questionareList;
        }

        private async void newQuestionareButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Under Development", "BRB", "ok");
        }

        private void ListOfQuestionares_Refreshing(object sender, EventArgs e)
        {
            ListOfQuestionares.ItemsSource = GetQuestionareList();
            ListOfQuestionares.EndRefresh();
        }

        private async void ListOfQuestionares_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedItem = e.SelectedItem as QuestionareDetails;
            await DisplayAlert(selectedItem.qId.ToString(), selectedItem.qText, "ok");

            ListOfQuestionares.SelectedItem = null;
        }
    }
}