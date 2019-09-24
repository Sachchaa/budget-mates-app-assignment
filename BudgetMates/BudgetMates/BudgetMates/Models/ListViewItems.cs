using System;
using BudgetMates.View;
using SQLite;

namespace BudgetMates.Models
{
    public class ListViewItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;  }

        public string BillType { get; set; }

        public string Address { get; set; }

        public string Month { get; set; }

        public int Amount { get; set; }

        public string DueDate { get; set; }
      

        public ListViewItems()
        {

        }
    }
}
