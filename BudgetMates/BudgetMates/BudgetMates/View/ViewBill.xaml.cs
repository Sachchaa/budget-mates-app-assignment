using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMates.Models;
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
            InitList();

		}

        void InitList()
        {
            Items = new List<ListViewItems>();

            Items.Add(new ListViewItems
            {
                BillType = "Test Electricity",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Water",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Gas",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Internet",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            Items.Add(new ListViewItems
            {
                BillType = "Test Rent",
                Month = "Test Month",
                Amount = 100,
                DueDate = "Test Month"
            });

            viewBillList.ItemsSource = Items;



        }
	}
}