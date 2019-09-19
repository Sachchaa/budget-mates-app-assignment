using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetMates.Objects
{
    class Person
    {
        public string Name { get; set; }
        public string phone_No { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        //getName getEmail getPhone getUserName getPassword getCPasword

        public Person(string name , string phone , string Password, string UserName )
        {
            Name = name;
            phone_No = phone;
            password = Password;
            username = UserName;
          //  email = Email;
        }

        public Person()
        { }
    }
}


