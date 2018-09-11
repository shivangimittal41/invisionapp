using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MobileAppUI
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BackgroundImage = "background_image_cropped.png";
            
        }

        private async void OnScreenTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TOU());
        }
    }
}
