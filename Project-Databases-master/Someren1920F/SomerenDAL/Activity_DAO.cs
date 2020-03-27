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
    public class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT id, omschrijving, aantalStudenten, aantalBegeleiders, dag FROM [Activiteit]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {

                    Id = (int)dr["id"],
                    Omschijving = (String)dr["omschrijving"].ToString(),
                    aantalStudenten = (int)dr["aantalStudenten"],
                    aantalBegeleiders = (int)dr["aantalBegeleiders"],
                    Day = (string)dr["dag"].ToString()
                };
                activities.Add(activity);
            }
            return activities;
        }

        public void ChangeDates(string newDate, string activityName)
        {
            string query = "UPDATE [Activiteit] SET dag = '" + newDate + "' WHERE omschrijving = '" + activityName + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public List<Activity> DB_Get_Day_Activity(string day)
        {
            string query = "SELECT id, omschrijving, aantalStudenten, aantalBegeleiders, dag FROM [Activiteit] WHERE dag = '" + day + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void AddActivity(int Id, string Omschrijving, int AantalStudenten, int AantalBegeleiders)
        {
            string query = "INSERT INTO Activiteit(id, omschrijving, aantalStudenten, aantalBegeleiders) VALUES(" + Id + ", '" + Omschrijving + "', " + AantalStudenten + ", " + AantalBegeleiders + ")";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
