using System;
using System.Collections.Generic;
using BudgetMates.Models;
using BudgetMates.Objects;
using SQLite;
using Xamarin.Forms;

namespace BudgetMates.View
{
    public partial class ViewHouses : ContentPage
    {
        public string user;
        public string home;

        public ViewHouses()
        {
            InitializeComponent();
        }

        //Get the passed value from home page
        public ViewHouses(string parameter)
        {
            InitializeComponent();
            getViewUserName.Text = parameter;
            user = parameter;
        }

        //Get the data and display on the labels
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Person>();
                var person = conn.Table<Person>();

                //Get the housecode from Person database
                foreach (var item in person)
                {
                    if (user == item.userName)
                    {
                        getViewHomeCode.Text = item.homeAddress;
                    }
                }

                conn.CreateTable<House>();
                var house = conn.Table<House>();

                //Assign the data to labels in the screen.
                foreach (var h in house)
                {
                    if (getViewHomeCode.Text == h.houseCode)
                    {
                        getViewAdressLine.Text = h.addressLine;
                        getViewSuburb.Text = h.suburb;
                        getViewState.Text = h.state;
                        getViewPostCode.Text = h.postCode;
                        getViewNumberOfRooms.Text = h.numberOfRooms.ToString();
                    }
                }
                
            }
        }
    }
}
