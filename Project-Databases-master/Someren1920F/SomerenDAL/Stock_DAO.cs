using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
   public class Stock_DAO : Base
    {
        public List<Stock> Db_Get_All_Stock()
        {
            string query = "SELECT dranknaam, aantal, prijs, verkocht, verkoopdatum FROM [Voorraad]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Stock> ReadTables(DataTable dataTable)
        {
            List<Stock> voorraden = new List<Stock>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Stock voorraad = new Stock()
                {
                    Name = (string)dr["dranknaam"].ToString(),
                    Amount = (int)dr["aantal"],
                    Price = (double)dr["prijs"],
                    Sold = (int)dr["verkocht"],
                };
                voorraden.Add(voorraad);
            }
            return voorraden;
        }

        public void StockChange(string name, int amount)
        {
            string query = "UPDATE [Voorraad] SET aantal = " + amount + " WHERE dranknaam = '" + name + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void StockNameChange(string oldName, string newName, int amount)
        {
            string query = "UPDATE [Voorraad] SET aantal = " + amount + ", dranknaam = '" + newName + "'" + " WHERE dranknaam = '" + oldName +"'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void StockPriceChange(string oldName, string newName, double newPrice)
        {
            string query = "UPDATE [Voorraad] SET prijs = " + newPrice + ", dranknaam = '" + newName + "' WHERE dranknaam = '" + oldName + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
      
        public void DrinkPurchased(string name)
        {
            string query = "UPDATE [Voorraad] SET aantal = aantal -1, verkocht = verkocht + 1 WHERE dranknaam = " + "'" + name + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void ChangeAll(string oldName, string newName, int newAmount, double newPrice)
        {
            string query = "UPDATE [Voorraad] SET aantal = " + newAmount + ", dranknaam = '" + newName + "', prijs = " +
                newPrice + " WHERE dranknaam = '" + oldName + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);

        }

        public void GetAllSold(string drankNaam)
        {
            string query = "SELECT dranknaam, drankprijs, verkocht FROM Voorraad WHERE dranknaam = '" + drankNaam + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteSelectQuery(query, sqlParameters);
         }

    }

}
