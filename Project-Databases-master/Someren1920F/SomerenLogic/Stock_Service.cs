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

                voorraden.Add(v);

                return voorraden;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }


    }
}
