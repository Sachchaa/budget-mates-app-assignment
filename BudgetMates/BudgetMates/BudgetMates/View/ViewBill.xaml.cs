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
	public partial class ViewBill : ContentPage
	{
        List<ListViewItems> Items;

		public ViewBill ()
		{
			InitializeComponent ();
            //InitList();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ListViewItems>();
                var bills = conn.Table<ListViewItems>().ToList();

                viewBillList.ItemsSource = bills;
            }
        }

        /*
        void InitList()
        {
            Items = new List<ListViewItems>();

            Items.Add(new ListViewItems
            {
                BillType = "Test Electricity",
                Address = "Test Address",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Water",
                Address = "Test Address",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Gas",
                Address = "Test Address",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Internet",
                Address = "Test Address",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Rent",
                Address = "Test Address",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            viewBillList.ItemsSource = Items;

    

        }

        */
    }
}