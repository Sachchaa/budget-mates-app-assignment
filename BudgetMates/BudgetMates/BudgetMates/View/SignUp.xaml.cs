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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();

        }

        //This is the activity for the Sign Up button click
        private void SignUp_Clicked(Object sender, EventArgs e)
        {
            //Check the main text fields are empty or not. If empty it shows an alert message
            if (getName.Text == null || getPhone.Text == null || getPassword.Text == null || getUserName.Text == null)
            {
                DisplayAlert("Unsuccessfull !", "Please enter details to all the fields!", "Ok");
            }

            //Check the password field and the Confirm password field are the same. If they are not same then shows an alert
            else if (getPassword.Text != getCPasword.Text)
            {
                DisplayAlert("Unsuccessfull !", "Please enter same password for both password fields!", "Ok");
            }

            //If the all required text fields are with values the it adds to the database
            else
            {
                Person person = new Person()
                {
                    name = getName.Text,
                    phoneNo = getPhone.Text,
                    email = getEmail.Text,
                    userName = getUserName.Text,
                    password = getPassword.Text

                };

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Person>();
                    int x = 1;
                    var table = conn.Table<Person>();

                    /*
                     Check the database for the user name is already exist. If the user name is already exist, display an alert
                     */
                    foreach (var item in table)
                    {
                        if (item.userName == getUserName.Text)
                        {
                            DisplayAlert("Unsuccessfull !", "Username unavailable , please use a different user name !", "Ok");
                            x = 2;
                            break;
                        }

                    }

                    //If the user name is a new user name, then it adds to the database
                    if (x == 1)
                    {
                        conn.Insert(person);
                        DisplayAlert("Successfull !", "Registered!  !", "Ok");
                        
                    }

                }
            }


        }


    }
}
