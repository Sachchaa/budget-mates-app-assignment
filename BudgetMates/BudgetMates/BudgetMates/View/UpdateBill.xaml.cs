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


            BillType.Items.Add("Electricity Bill");
            BillType.Items.Add("Gas Bill");
            BillType.Items.Add("Water Bill");
            BillType.Items.Add("Internet Bill");
            BillType.Items.Add("Rent");

            Address.Items.Add("Burwood");
            Address.Items.Add("Dandenong");
            Address.Items.Add("Clayton");
            Address.Items.Add("Boxhill");
            Address.Items.Add("Brewick");

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

        private void UpdateBill_Clicked(Object sender, EventArgs e)
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
               conn.Insert(listView);
            }
        }

    }
}