using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopGUI
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShoppingList { get; set; }

        public Store()
        {
            CarList = new List<Car>();
            ShoppingList = new List<Car>();
        }

        public decimal checkout()
        {
            decimal totalCost = 0;

            foreach (var c in ShoppingList)
            {
                totalCost += c.Price;
            }

            ShoppingList.Clear();

            return totalCost;
        }
    }
}
