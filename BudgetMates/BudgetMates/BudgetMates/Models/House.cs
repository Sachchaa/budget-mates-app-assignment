using System;
namespace BudgetMates.Models
{
    public class House
    {
        public string houseCode { get; set; }

        public string addressLine { get; set; }

        public string suburb { get; set; }

        public string state { get; set; }

        public string postCode { get; set; }

        public int numberOfRooms { get; set; }


        public House()
        {
        }
    }
}
