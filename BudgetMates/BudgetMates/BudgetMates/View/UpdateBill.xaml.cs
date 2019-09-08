using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMates.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateBill : ContentPage
	{
		public UpdateBill ()
		{
			InitializeComponent ();

           
            BillType.Items.Add("Electricity Bill");
            BillType.Items.Add("Gas Bill");
            BillType.Items.Add("Water Bill");
            BillType.Items.Add("Internet Bill");
            BillType.Items.Add("Rent");


		}



	}
}