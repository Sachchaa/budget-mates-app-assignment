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
        private async void Login_Clicked(Object sender, EventArgs e)
        {

            //getName getEmail getPhone getUserName getPassword getCPasword
            //path string for the database file -1
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "M_DB.db3");
            //setup the db connection
            var db = new SQLiteConnection(dbPath);
            //setup a table - 2
            //check username available
            int x = 1;
            var table = db.Table<Person>();
            foreach (var item in table)
            {
                if (item.username == getUserName1.Text && getpassword1.Text == item.password)
                {
                    await Navigation.PushAsync(new Home());
                    x = 2;
                    break;
                }
                

            }
            if (x == 1)
            {
                DisplayAlert("Unsuccessfull !", "Please Enter Correct login details ! ", "Ok");
            }


        }

        private async void SignUp_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}