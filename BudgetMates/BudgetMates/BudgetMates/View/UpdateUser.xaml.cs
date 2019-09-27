using System;
using System.Collections.Generic;

using BudgetMates.Models;
using BudgetMates.Objects;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMates.View
{
    public partial class UpdateUser : ContentPage
    {
        public string user;

        public UpdateUser()
        {
            InitializeComponent();
        }

        //get the user name from the home page and set the value to local variable
        public UpdateUser(string parameter)
        {
            InitializeComponent();
            setUserName.Text = parameter;
            user = parameter; 
        }

        //This methods brings what will display when update user page loading.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Use the databse
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<House>();
                var house = conn.Table<House>();

                //get the house codes from the house table and add to list 
                foreach (var item in house)
                {
                    pickHomeAddress.Items.Add(item.houseCode);
                }

                conn.CreateTable<Person>();
                var person = conn.Table<Person>();

                //get the data from Person class and assign them to the text fields 
                foreach (var item in person)
                {
                    if (item.userName == user)
                    {
                        setName.Text = item.name;
                        setPhone.Text = item.phoneNo;
                        setEmail.Text = item.email; 
                        setPassword.Text = item.password;
                        setHomeAddress.Text = item.homeAddress;               
                    }
                }
            }
        }

        //Activity for the update user button click
        private void UpdateUser_Clicked(Object sender, EventArgs e)
        {
            //Check the text fields are empty or not, it empty it shows an alert 
            if (setName.Text == null || setPhone.Text == null || setPassword.Text == null || setUserName.Text == null)
            {
                DisplayAlert("Unsuccessfull !", "Please enter details to all the fields!", "Ok");
            }

            //If not the Person table will be updated with changed values 
            else
            {
                setHomeAddress.Text = pickHomeAddress.SelectedItem.ToString();

                Person person = new Person()
                {
                    name = setName.Text,
                    phoneNo = setPhone.Text,
                    email = setEmail.Text,
                    homeAddress = setHomeAddress.Text,
                    userName = setUserName.Text,
                    password = setPassword.Text
                    
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Person>();
                    conn.Update(person);
                    DisplayAlert("Update your profile", "Successfully Updated !", "Ok");
                }
            }
        }

        //Activity for the Delete user button click
        private void DeleteUser_Clicked(Object sender, EventArgs e)
        {

        }

    }

}