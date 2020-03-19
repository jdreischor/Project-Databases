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
            string query = "SELECT dranknaam, aantal, prijs FROM [Voorraad]";
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
                    Price = (double)dr["prijs"]

                };
                voorraden.Add(voorraad);
            }
            return voorraden;
        }
    }
}
