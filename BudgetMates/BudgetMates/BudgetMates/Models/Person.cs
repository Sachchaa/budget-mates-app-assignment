using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BudgetMates.Objects
{
    class Person
    {
        public string name { get; set; }

        public string phoneNo { get; set; }

        public string email { get; set; }

        [PrimaryKey]
        public string userName { get; set; }

        public string password { get; set; }

        public string homeAddress { get; set; }

        public Person()
        {

        }
    }
}


