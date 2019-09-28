using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMates.Objects;
using BudgetMates.View;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent();
		}

        
        //Using this method to get the passed value from login page.
        public Home(string parameter)
        {
            InitializeComponent();
            lblUserName.Text = parameter;
        }

        //OnAppearing method helps to show the data when screen loads. 
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //get the "Home Code" from the database for the user who has logged  
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Person>();
                var person = conn.Table<Person>();

                foreach (var item in person)
                {
                    if (lblUserName.Text == item.userName)
                    {
                        lblUserHomeCode.Text = item.homeAddress;
                    }
                } 

            }
        }

        /*  Activity for the Update Account button. 'Update User' page displays when the button clicked.
            And pass the user name to the update page
        */
        private async void UpdateAccount_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateUser(lblUserName.Text));
        }

        /*  Activity for the Update BIll button. 'Update Bill' page displays when the button clicked. */ 
        private async void UpdateBills_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateBill());
        }

        /*  Activity for the View Bills button. 'View Bill' page displays when the button clicked.
            And pass the home code to the View Bills page
        */
        private async void ViewBills_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewBill(lblUserHomeCode.Text));
        }

        /*  Activity for the Generate House Code button. 'Generate House Code' page displays when the button clicked */
        private async void HouseSettings_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HouseSettings());
        }

        /*  Activity for the View House Details button. 'View Hoese Details' page displays when the button clicked.
            And pass the user name to the View Bills page
        */
        private async void ViewHouses_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewHouses(lblUserName.Text));
        }

        /*  Activity for the Find Your Bill Share button. 'Find Your Bill Share' page displays when the button clicked.
            
        */
        private async void FindBill_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindYourBills(lblUserHomeCode.Text));
        }

        /*  Activity for the Log Out button. 'Login' page displays when the button clicked. */
        private async void Logout_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }


    }
}