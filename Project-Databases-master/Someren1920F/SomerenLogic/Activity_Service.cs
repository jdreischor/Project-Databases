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

	public class Activity_Service
	{
		public Activity_DAO activity_db = new Activity_DAO();
        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activities = activity_db.Db_Get_All_Activities();
                return activities;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Activity> activities = new List<Activity>();

                return activities;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void ChangeActivity(string newDate, string activityName)
        {
            activity_db.ChangeDates(newDate, activityName);
        }

        public List<Activity> GetDayActivity(string day)
        {
            try
            {
                List<Activity> activities = activity_db.DB_Get_Day_Activity(day);
                return activities;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Activity> activities = new List<Activity>();

                return activities;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }

        public List<Activity> EmptyActivity()
        {
            List<Activity> emptyList = new List<Activity>();

            return emptyList;
        }

        public void AddActivity(int Id, string Omschrijving, int AantalStudenten, int AantalBegeleiders)
        {
            activity_db.AddActivity(Id, Omschrijving, AantalStudenten, AantalBegeleiders);
        }
    }
}

	

