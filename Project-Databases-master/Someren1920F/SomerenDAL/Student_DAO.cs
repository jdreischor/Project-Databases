﻿using System;
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
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT studentnummer, voornaam, achternaam, klas, aankopen FROM [Student]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {

                    Number = (int)dr["studentnummer"],
                    FirstName = (String)dr["voornaam"].ToString(),
                    LastName = (String)dr["achternaam"].ToString(),
                    Class = (String)dr["klas"].ToString(),
                    Purchases = (int)dr["aankopen"]
                };
                students.Add(student);
            }
            return students;
        }

        public void AddPurchase(int studentNumber)
        {
            string query = "UPDATE [Student] SET aankopen = aankopen +1 WHERE studentnummer = " + studentNumber;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
