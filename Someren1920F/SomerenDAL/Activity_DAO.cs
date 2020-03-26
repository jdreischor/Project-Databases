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
            string query = "SELECT activityid, omschrijving, aantalstudenten, aantalbegeleiders FROM [Activiteit]";
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

                    Id = (int)dr["activiteitid"],
                    Omschijving = (String)dr["omschrijving"].ToString(),
                    aantalStudenten = (int)dr["aantalstudenten"],
                    aantalBegeleiders = (int)dr["aantalbegeleiders"],
                };
                activities.Add(activity);
            }
            return activities;
        }
    }
}
