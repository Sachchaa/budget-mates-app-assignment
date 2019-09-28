using System;
using System.Collections.Generic;
using BudgetMates.Models;
using SQLite;
using Xamarin.Forms;

namespace BudgetMates.View
{
    public partial class FindYourBills : ContentPage
    {
        public string home;
        public int yourShare;
        public int amount;
        public int numberOfRooms;
        public List<YourShare> billShare; 

        public FindYourBills()
        {
            InitializeComponent();
        }

        //Get the passed value from the homepage
        public FindYourBills(string parameter)
        {
            InitializeComponent();
            home = parameter;
        }

        //Get the data from database and shows in the list view 
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ListViewItems>();
                var bill = conn.Table<ListViewItems>().ToList();
                billShare = new List<YourShare>();
                conn.CreateTable<House>();
                var house = conn.Table<House>().ToList();

                //Get the number of rooms using home code
                foreach (var h in house)
                {
                    if (home == h.houseCode)
                    {
                        numberOfRooms = h.numberOfRooms;
                    }
                }

                //Get the data and set the data to YourShare Class
                foreach (var h in bill)
                {
                    if (home == h.Address)
                    {
                        //Calculate the share of each housemate
                        amount = h.Amount;
                        yourShare = amount/numberOfRooms;

                        billShare.Add(new YourShare
                        {
                            yourBillType = "Bill Type : " + h.BillType,
                            yourMonth = "Month : " + h.Month,
                            yourDueDate = "Due Date : " + h.DueDate,
                            yourShareAmount = "Your Share : " + yourShare

                        });
                    }
                }
                    //Add the data to the list view
                    viewBillShare.ItemsSource = billShare;
            }
        }
    }
}
