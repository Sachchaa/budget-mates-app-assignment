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
    public partial class UpdateBill : ContentPage
    {
        public UpdateBill()
        {
            InitializeComponent();

            //Get the data from House table to add the all house codes to the Address list  
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<House>();
                var house = conn.Table<House>();

                foreach (var item in house)
                {
                    Address.Items.Add(item.houseCode);
                }
  
            }
            //These are the values of the Bill Type list
            BillType.Items.Add("Electricity Bill");
            BillType.Items.Add("Gas Bill");
            BillType.Items.Add("Water Bill");
            BillType.Items.Add("Internet Bill");
      
            //These are the values to the Months list
            Month.Items.Add("January");
            Month.Items.Add("February");
            Month.Items.Add("March");
            Month.Items.Add("April");
            Month.Items.Add("May");
            Month.Items.Add("June");
            Month.Items.Add("July");
            Month.Items.Add("August");
            Month.Items.Add("September");
            Month.Items.Add("October");
            Month.Items.Add("November");
            Month.Items.Add("December");


        }

        //This is the activity for the Update bills button.
        private void UpdateBill_Clicked(Object sender, EventArgs e)
        {
            //Check the main text fields are empty or not. If empty it shows an alert message
            if (BillType.SelectedIndex.ToString() == null || Address.SelectedIndex.ToString() == null || Month.SelectedIndex.ToString() == null || txtAmount.Text == null || txtDueDate.Text == null)
            {
                DisplayAlert("Unsuccessfull !", "Please enter details to all the fields!", "Ok");
            }

            //If the required text fields are with some values, then it will be added to the data base 
            else
            {
                ListViewItems listView = new ListViewItems()
                {
                    BillType = BillType.SelectedItem.ToString(),
                    Address = Address.SelectedItem.ToString(),
                    Month = Month.SelectedItem.ToString(),
                    Amount = int.Parse(txtAmount.Text),
                    DueDate = txtDueDate.Text
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<ListViewItems>();
                    int x = 1;
                    var bill = conn.Table<ListViewItems>();

                    //Check the bill is already exist. If the bill is already there, then diplays an alert
                    foreach (var item in bill)
                    {
                        if (item.Address == Address.SelectedIndex.ToString() && item.BillType == BillType.SelectedItem.ToString() && item.Month == Month.SelectedItem.ToString())
                        {
                            DisplayAlert("Unsuccessfull !", "This bill is already exist. Insert a new bill!", "Ok");
                            x = 2;
                            break;
                        }
                    }

                    //If the bill is a new button then it will be added to the database
                    if (x == 1)
                    {
                        conn.Insert(listView);
                        DisplayAlert("Successfull !", "Bill Added !", "Ok");
                    }               
                }
            }  
        }
    }
}
