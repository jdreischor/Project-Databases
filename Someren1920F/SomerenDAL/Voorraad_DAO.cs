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
   public class Voorraad_DAO : Base
    {
        public List<Voorraad> Db_Get_All_Stock()
        {
            string query = "SELECT dranknaam, aantal, prijs FROM [Voorraad]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Voorraad> ReadTables(DataTable dataTable)
        {
            List<Voorraad> voorraden = new List<Voorraad>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Voorraad voorraad = new Voorraad()
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
