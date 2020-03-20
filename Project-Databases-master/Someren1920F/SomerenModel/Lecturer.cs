using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Lecturer
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Number { get; set; } // LecturerNumber, e.g. 47198
        public string Course { get; set; }

        public void Add(Lecturer teacher)
        {
            throw new NotImplementedException();
        }
    }
}