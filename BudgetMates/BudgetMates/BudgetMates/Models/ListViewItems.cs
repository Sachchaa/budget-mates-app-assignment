using System;
using BudgetMates.View;

namespace BudgetMates.Models
{
    public class ListViewItems
    {

        public string BillType { get; set; }
        public string Month { get; set; }
        public int Amount { get; set; }
        public string DueDate { get; set; }
      

        public ListViewItems()
        {
        }
    }
}
