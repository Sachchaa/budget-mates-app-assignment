using System;
using BudgetMates.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BudgetMates
{
    public partial class App : Application
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        //Created this App method with a parameter to pass the file path to link with database
        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
            FilePath = filePath;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
