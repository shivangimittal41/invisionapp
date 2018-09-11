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
	public partial class FilledQuestionare : ContentPage
	{
        private ObservableCollection<Questionare> _questionareList = new ObservableCollection<Questionare>() { };

        public FilledQuestionare (string squestionareTitle, string squestionareLastUpdated)
		{
			InitializeComponent ();
            questionareTitle.Text = squestionareTitle;
            questionareLastUpdated.Text = "Last saved " + squestionareLastUpdated;
            ListOfQuestions.ItemsSource = GetQuestionareList();
        }

        private IEnumerable<Questionare> GetQuestionareList()
        {
            _questionareList.Clear(); //Empty the older list.
            _questionareList = new ObservableCollection<Questionare>{
                new Questionare { qId=0, qTitle="This is Question 1", qLastUpdated="6/28/18", qPhoto="action_needed.png" },
                new Questionare { qId=1, qTitle="This is Question 2", qLastUpdated="6/28/18", qPhoto="Answer_No.png" },
                new Questionare { qId=2, qTitle="This is Question 3", qLastUpdated="6/28/18", qPhoto="action_needed.png" },
                new Questionare { qId=3, qTitle="This is Question 4", qLastUpdated="6/28/18", qPhoto="Answer_No.png" }
            };

            return _questionareList;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {

        }

        private void submitButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ListOfQuestions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedItem = e.SelectedItem as Questionare;
            await DisplayAlert(selectedItem.qId.ToString(), selectedItem.qTitle, "ok");

            ListOfQuestions.SelectedItem = null;
        }
    }
}