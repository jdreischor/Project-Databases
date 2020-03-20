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
   public class Lecturer_Service
    {
        Lecturer_DAO lecturer_db = new Lecturer_DAO();

        public List<Lecturer> GetTeachers()
        {
            try
            {
                List<Lecturer> teachers = lecturer_db.Db_Get_All_Lecturers();
                return teachers;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Lecturer> teachers = new List<Lecturer>();

                return teachers;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }
    }
}
