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

        private void SignUp_Clicked(Object sender, EventArgs e)
        {
            if (getName.Text==null|| getPhone.Text==null||getPassword.Text==null|| getUserName.Text==null)
            {
                DisplayAlert("Unsuccessfull !", "Please enter details to all the fields!", "Ok");


            }
            else
            {
                //getName getEmail getPhone getUserName getPassword getCPasword
                //path string for the database file -1
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "M_DB.db3");
                //setup the db connection
                var db = new SQLiteConnection(dbPath);
                //setup a table - 2
                db.CreateTable<Person>();
                //check username available
                int x = 1;
                var table = db.Table<Person>();
                foreach (var item in table)
                {

                    if (item.username == getUserName.Text)
                    {
                        DisplayAlert("Unsuccessfull !", "Username unavailable , please use a different user name !", "Ok");
                        x = 2;
                        break;

                    }

                }

                if (x == 1)
                {

                    //Register user
                    Person newPerson = new Person(getName.Text, getPhone.Text, getPassword.Text, getUserName.Text);
                    //store
                    db.Insert(newPerson);
                    DisplayAlert("Successfull !", "Registered!  !", "Ok");
                }

            }


        }


    }
}