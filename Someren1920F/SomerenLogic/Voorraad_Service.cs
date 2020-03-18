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
    public class Voorraad_Service
    {
        Voorraad_DAO voorraad_db = new Voorraad_DAO();

        public List<Voorraad> GetVoorraad()
        {
            try
            {
                List<Voorraad> voorraden = voorraad_db.Db_Get_All_Stock();
                return voorraden;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Voorraad> voorraden = new List<Voorraad>();
                Voorraad v = new Voorraad();
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
