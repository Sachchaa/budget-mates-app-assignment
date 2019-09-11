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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void Login_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private async void SignUp_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}