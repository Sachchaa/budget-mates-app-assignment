using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using BudgetMates.Objects;


namespace BudgetMates.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        //This is the activity for the Login button
        private async void Login_Clicked(Object sender, EventArgs e)
        {
            //Check the database to get the user name and password
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Person>();
                int x = 1; 
                var person = conn.Table<Person>();

                /*
                  Check the Person table to verify the user name and password is correct. If correct, it goes to home page.
                  And the user name will be passed to the home page to display.
                */
                foreach (var item in person)
                {
                    if (getUserName1.Text == item.userName && getpassword1.Text == item.password)
                    {
                        await Navigation.PushAsync(new Home(item.userName));
                        x = 2;
                        break;
                    }
                }
                //If the user name and passwrord is incorrect, the displays an alert message.
                if (x == 1)
                {
                    DisplayAlert("Unsuccessfull !", "Please Enter Correct login details ! ", "Ok");
                }
            }
        }

        //This is the activity for the Sign Up page. 'Sign Up' page displays when the button clicked
        private async void SignUp_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}