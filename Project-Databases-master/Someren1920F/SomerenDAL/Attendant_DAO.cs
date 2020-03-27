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
    public class Attendant_DAO : Base
    {
        public List<Attendant> Db_Get_All_Attendants()
        {
            string query = "SELECT docentnummer, voornaam, achternaam FROM [Docent] INNER JOIN [Begeleider] ON docentnummer = docentId";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }


        private List<Attendant> ReadTables(DataTable dataTable)
        {
            List<Attendant> attendants = new List<Attendant>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Attendant attendant = new Attendant()
                {
                    Id = (int)dr["docentnummer"],
                    voornaam = (String)dr["voornaam"].ToString(),
                    achternaam = (String)dr["achternaam"].ToString()
                };
                attendants.Add(attendant);
            }
            return attendants;
        }

        public List<Attendant> Db_Get_All_Non_Attendants()
        {
            string query = "SELECT docentnummer, voornaam, achternaam FROM Docent WHERE docentnummer NOT IN(SELECT docentID FROM Begeleider)";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void AddAttendant(int id)
        {
            string query = "INSERT INTO Begeleider(docentID) VALUES(" + id + ") ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteAttendant(int id)
        {
            string query = "DELETE FROM Begeleider WHERE docentID = '" + id + "';";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
