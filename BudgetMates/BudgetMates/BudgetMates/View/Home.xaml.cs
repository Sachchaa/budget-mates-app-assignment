using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMates.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}

        private async void UpdateBills_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateBill());
        }

        private async void ViewBills_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewBill());
        }
        private async void HouseSettings_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HouseSettings());
        }
        private async void AddHouseMate_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHouseMate());
        }
        private async void FindBill_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindYourBills());
        }


    }
}