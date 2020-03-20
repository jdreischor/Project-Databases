using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Stock_Service
    {
        Stock_DAO stock_db = new Stock_DAO();

        public List<Stock> GetStock()
        {
            try
            {
                List<Stock> voorraden = stock_db.Db_Get_All_Stock();
                return voorraden;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Stock> voorraden = new List<Stock>();
                Stock v = new Stock();
                v.Name = "TestDrank";
                v.Price = 474791;
                v.Amount = 10;
                v.Sold = 0;
                v.SellDate = DateTime.Now;
                
                voorraden.Add(v);

                return voorraden;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void SellItem(String name)
        {
            stock_db.DrinkPurchased(name);
        }

        public void UpdateStock(String name, int amount)
        {
            stock_db.StockChange(name, amount);
        }

        public void ChangeName(string oldName, string newName, int amount)
        {
            stock_db.StockNameChange(oldName, newName, amount);
        }

        public void UpdatePrice(string oldName, string newName, double newPrice)
        {
            stock_db.StockPriceChange(oldName, newName, newPrice);
        }

        public void UpdateAll(string oldName, string newName, int newAmount, double newPrice)
        {
            stock_db.ChangeAll(oldName, newName, newAmount, newPrice);
        }
    }
}
