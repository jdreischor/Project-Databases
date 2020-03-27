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
    public class Attendant_Service
    {
        public Attendant_DAO attendant_db = new SomerenDAL.Attendant_DAO();
        public List<Attendant> GetAttendants()
        {
            try
            {
                List<Attendant> attendants = attendant_db.Db_Get_All_Attendants();
                return attendants;
            }
            catch (Exception)
            {
                //Something went wrong with the connection to the database, so we will add a fake attendant list to make sure the rest of the application continues working!
                List<Attendant> attendants = new List<Attendant>();

                return attendants;
            }
        }

        public List<Attendant> GetNonAttendants()
        {
            try
            {
                List<Attendant> nonAttendants = attendant_db.Db_Get_All_Non_Attendants();
                return nonAttendants;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Attendant> nonAttendants = new List<Attendant>();
                Attendant a = new Attendant();
                a.Id = 24;
                a.voornaam = "Jacintha";
                a.achternaam = "Dreischor";


                nonAttendants.Add(a);

                return nonAttendants;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void AddAttendant(int id)
        {
            attendant_db.AddAttendant(id);
        }

        public void DeleteAttendant(int id)
        {
            attendant_db.DeleteAttendant(id);
        }




    }
}
