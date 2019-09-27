using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMates.Models;
using BudgetMates.Objects;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BudgetMates.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewBill : ContentPage
	{
        List<ListViewItems> Items;
        public string home;

		public ViewBill ()
		{
			InitializeComponent ();
		}

        //Get the house code from the home page
        public ViewBill(string parameter)
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
                var house = conn.Table<ListViewItems>().ToList();

                //Assign the data in to the lables in List View
                foreach (var h in house)
                {
                    if (home == h.Address)
                    {
                        Items = new List<ListViewItems>();
                        Items.Add(new ListViewItems
                        {
                            BillType = h.BillType,
                            Address = h.Address,
                            Month = h.Month,
                            Amount = h.Amount,
                            DueDate = h.DueDate
                        });    
                    }
                }

                //Add the data to the list view
                viewBillList.ItemsSource = Items;
            }
        }
    }
}