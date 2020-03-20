using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_CashRegister.Hide();
                panelRooms.Hide();
                pnl_Lecturers.Hide();


                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_CashRegister.Hide();
                panelRooms.Hide();
                pnl_Lecturers.Hide();
                pnl_Stock.Hide();


                // show students
                pnl_Students.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Items.Clear();

                // TODO: Listview Aanpassen
                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);

                }
            }

            else if (panelName == "Lecturers")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_CashRegister.Hide();
                panelRooms.Hide();
                pnl_Students.Hide();
                pnl_Stock.Hide();


                // show lecturers
                pnl_Lecturers.Show();

                SomerenLogic.Lecturer_Service lectureService = new SomerenLogic.Lecturer_Service();
                List<Lecturer> lecturerList = lectureService.GetTeachers();

                listViewLecturers.Items.Clear();

                foreach (Lecturer l in lecturerList)
                {
                    ListViewItem li = new ListViewItem(l.Name);
                    listViewLecturers.Items.Add(li);
                }
            }

            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_CashRegister.Hide();
                pnl_Lecturers.Hide();
                pnl_Students.Hide();
                pnl_Stock.Hide();


                // show rooms
                panelRooms.Show();

                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();
                listViewRooms.Items.Clear();


                foreach (Room r in roomList)
                {
                    ListViewItem li = new ListViewItem(r.Number.ToString());
                    listViewRooms.Items.Add(li);
                }
            }

            else if (panelName == "Stock")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_CashRegister.Hide();
                pnl_Lecturers.Hide();
                pnl_Students.Hide();
                panelRooms.Hide();

                // show rooms
                pnl_Stock.Show();

                SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                List<Stock> stockList = stockService.GetStock();
                listViewStock.Items.Clear();

                foreach (Stock s in stockList)
                {
                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStock.Items.Add(li);
                }

            }
            
            else if (panelName == "Cash Register")
            {

                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                panelRooms.Hide();
                pnl_Lecturers.Hide();
                pnl_Students.Hide();


                // show register
                pnl_CashRegister.Show();

                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();


                lv_RegisterStudent.Clear();
                lv_RegisterStock.Clear();

                foreach (SomerenModel.Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.Name);

                    lv_RegisterStudent.Items.Add(li);
                }

                SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                List<Stock> stockList = stockService.GetStock();

                foreach (SomerenModel.Stock v in stockList)
                {
                    ListViewItem li = new ListViewItem(v.Name);
                    lv_RegisterStock.Items.Add(li);
                }
            }

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }


       // Show the teachers
        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        // Show the rooms
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        //Show the cashregister
        private void cashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Cash Register");
           
        }

        private void stockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Stock");
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
