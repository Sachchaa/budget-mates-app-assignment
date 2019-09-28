using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMates.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMates.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HouseSettings : ContentPage
	{
		public HouseSettings ()
		{
			InitializeComponent ();
		}

        /*
         This is the activity for the 'Add House' button.  
         */
        private async void AssignHouse_clicked(Object sender, EventArgs e)
        {
            //Check main textfields are empty or not. If empty, then shows a alert message. 
            if (getAddressLine.Text == null || getSuburb.Text == null || getState.Text == null || getPostCode.Text == null)
            {
                DisplayAlert("Unsuccessfull !", "Please enter details to all the fields!", "Ok");
            }
            //If the main text fields are with some values, then it will be added to the database
            else {
                House house = new House()
                {
                    addressLine = getAddressLine.Text,
                    suburb = getSuburb.Text,
                    state = getState.Text,
                    postCode = getPostCode.Text,
                    numberOfRooms = int.Parse(getNUmberOfRooms.Text),
                    houseCode = getSuburb.Text + " " + getPostCode.Text
                    
                };
               
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<House>();
                    int x = 1;
                    var table = conn.Table<House>();

                    //Check the database if the house code is already created or not. 
                    foreach (var item in table)
                    {
                        //If the house code is already in database, display an alert
                        if ((getSuburb.Text + " " + getPostCode.Text) == item.houseCode)
                        {
                            DisplayAlert("Unsuccessfull !", "This house is already in the system !", "Ok");
                            x = 2;
                            break;
                        }
                    }

                    //If the house code is not generated before, then it will be generated. And showHouseCode label will show the generated house code
                    if (x == 1)
                    {
                        conn.Insert(house);
                        DisplayAlert("Successfull !", "Registered!  !", "Ok");

                        showHouseCode.Text = getSuburb.Text + " " + getPostCode.Text;
                        
                    }
                }

               
            }
           
        }
    }
  
}