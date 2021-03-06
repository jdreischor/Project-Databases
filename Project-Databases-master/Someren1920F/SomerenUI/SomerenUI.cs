﻿using SomerenModel;
using System;
using System.Collections.Generic;
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
                HidePanels();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                HidePanels();

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
                    string studentName = (s.FirstName + " " + s.LastName);

                    ListViewItem li = new ListViewItem();
                    li.Text = s.Number.ToString();
                    li.SubItems.Add(studentName);
                    li.SubItems.Add(s.Class);

                    listViewStudents.Items.Add(li);
                }
            }

            else if (panelName == "Lecturers")
            {
                // hide all other panels
                HidePanels();

                // show lecturers
                pnl_Lecturers.Show();

                SomerenLogic.Lecturer_Service lectureService = new SomerenLogic.Lecturer_Service();
                List<Lecturer> lecturerList = lectureService.GetTeachers();

                listViewLecturers.Items.Clear();

                foreach (Lecturer l in lecturerList)
                {

                    String lecturerName = (l.FirstName + " " + l.LastName);

                    ListViewItem li = new ListViewItem();
                    li.Text = l.Number.ToString();
                    li.SubItems.Add(lecturerName);
                    li.SubItems.Add(l.Course);

                    listViewLecturers.Items.Add(li);
                }
            }

            else if (panelName == "Rooms")
            {
                // hide all other panels
                HidePanels();

                // show rooms
                panelRooms.Show();

                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();
                listViewRooms.Items.Clear();

                foreach (Room r in roomList)
                {
                    ListViewItem li = new ListViewItem();

                    li.Text = r.Number.ToString();
                    li.SubItems.Add(r.Capacity.ToString());
                    li.SubItems.Add(r.Kind);

                    listViewRooms.Items.Add(li);
                }
            }

            else if (panelName == "Stock")
            {
                // hide all other panels
                HidePanels();

                // show rooms
                pnl_Stock.Show();

                SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                List<Stock> stockList = stockService.GetStock();
                listViewStock.Items.Clear();

                foreach (Stock s in stockList)
                {
                    ListViewItem li = new ListViewItem();

                    li.Text = s.Name;
                    li.SubItems.Add(s.Amount.ToString());
                    li.SubItems.Add(s.Price.ToString());

                    listViewStock.Items.Add(li);
                }
            }

            else if (panelName == "Cash Register")
            {
                HidePanels();

                // show register
                pnl_CashRegister.Show();

                cmb_Drink.Items.Clear();
                cmb_Student.Items.Clear();

                StudentInit();
                DrinkInit();
            }


            else if (panelName == "Analysis")
            {
                HidePanels();

                pnl_Analysis.Show();

                SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                List<Stock> stockList = stockService.GetStock();
                listViewAnalysis.Items.Clear();

                foreach (Stock s in stockList)
                {
                    ListViewItem li = new ListViewItem();
                    if (s.Sold >= 1)
                    {
                        li.Text = s.Name;
                        li.SubItems.Add(s.Amount.ToString());
                        li.SubItems.Add(s.Price.ToString());
                        listViewAnalysis.Items.Add(li);
                    }
                }
            }

            else if (panelName == "Activities")
            {
                HidePanels();

                pnl_Activities.Show();

                listViewActivities.Items.Clear();
                ShowActivities();
            }

            else if (panelName == "Attendants")
            {
                HidePanels();

                pnl_Attendants.Show();

                // show all current attendants
                SomerenLogic.Attendant_Service AttendantService = new SomerenLogic.Attendant_Service();
                List<Attendant> attendantList = AttendantService.GetAttendants();



                listViewAttendants.Items.Clear();

                foreach (Attendant a in attendantList)
                {

                    String attendantName = (a.voornaam + " " + a.achternaam);

                    ListViewItem li = new ListViewItem();
                    li.Text = a.Id.ToString();
                    li.SubItems.Add(attendantName);
                    listViewAttendants.Items.Add(li);
                }


            }

            else if (panelName == "DeleteAttendant")
            {
                pnl_DeleteAttendant.Show();

                // show all current attendants
                SomerenLogic.Attendant_Service AttendantService = new SomerenLogic.Attendant_Service();
                List<Attendant> attendantList = AttendantService.GetAttendants();



                listViewDeleteAttendant.Items.Clear();

                foreach (Attendant a in attendantList)
                {

                    String attendantName = (a.voornaam + " " + a.achternaam);

                    ListViewItem li = new ListViewItem();
                    li.Text = a.Id.ToString();
                    li.SubItems.Add(attendantName);
                    listViewDeleteAttendant.Items.Add(li);
                }

            }

            else if (panelName == "AddAttendants")
            {
                pnl_AddAttendant.Show();

                // show all non attendants
                SomerenLogic.Attendant_Service AttendantService = new SomerenLogic.Attendant_Service();
                List<Attendant> attendantList = AttendantService.GetNonAttendants();

                listViewAddAttendant.Items.Clear();

                foreach (Attendant a in attendantList)
                {

                    String attendantName = (a.voornaam + " " + a.achternaam);

                    ListViewItem li = new ListViewItem();
                    li.Text = a.Id.ToString();
                    li.SubItems.Add(attendantName);
                    listViewAddAttendant.Items.Add(li);
                }
            }
            else if (panelName == "Schedule")
            {
                HidePanels();

                pnl_Schedule.Show();
                ShowMonday();


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

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Analysis");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Fill combobox with Student options
        private void StudentInit()
        {
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();

            foreach (SomerenModel.Student s in studentList)
            {
                cmb_Student.Items.Add(s.FirstName + " " + s.LastName);
            }
        }

        // Fill combobox with Drink options
        private void DrinkInit()
        {
            SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
            List<Stock> stockList = stockService.GetStock();

            foreach (SomerenModel.Stock c in stockList)
            {
                cmb_Drink.Items.Add(c.Name);
                cmb_StockSelect.Items.Add(c.Name);

            }
        }

        // Send payment to database (amount -1)
        private void buttonPay_Click(object sender, EventArgs e)
        {
            SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();

            // Get the name from the selected items
            string studentName = cmb_Student.SelectedItem.ToString();
            string drinkName = cmb_Drink.SelectedItem.ToString();

            // Give a message that the payment has succeeded
            testLabel.Text = studentName + " Has purchased " + drinkName;
            stockService.SellItem(drinkName);

            // Match the right studentnumber with the right name, then add a purchase to that student.
            foreach (Student s in studentList)
            {
                string fullName = s.FirstName + " " + s.LastName;
                if (fullName == studentName)
                {
                    studService.AddPurchase(s.Number);
                }
            }
          
        }

        //Bring up the panel to change stock
        private void btn_StockChange_Click(object sender, EventArgs e)
        {

            cmb_StockSelect.Items.Clear();
            txt_StockAmount.Clear();
            txt_StockNewName.Clear();
            txt_StockNewPrice.Clear();

            if (chk_ChangeName.Checked)
            {
                chk_ChangeName.Checked = false;
            }
            if (chk_PriceChange.Checked)
            {
                chk_PriceChange.Checked = false;
            }

            DrinkInit();
            pnl_StockChange.Show();

        }

        // Hide all panels and stuff
        public void HidePanels()
        {
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_CashRegister.Hide();
            pnl_Lecturers.Hide();
            pnl_Students.Hide();
            pnl_Stock.Hide();
            panelRooms.Hide();
            pnl_Rooms.Hide();
            pnl_Analysis.Hide();
            pnl_StockChange.Hide();
            pnl_Attendants.Hide();
            pnl_Activities.Hide();
            pnl_AddAttendant.Hide();
            pnl_DeleteAttendant.Hide();
            pnl_Schedule.Hide();
            pnl_EditActivities.Hide();
            pnl_DeleteWaarshuwing.Hide();
            pnl_AddActivity.Hide();


            //Hide stuff
            lbl_StockNewName.Hide();
            txt_StockNewName.Hide();
            lbl_StockNewPrice.Hide();
            txt_StockNewPrice.Hide();

        }

        // Confirm the options and make the corresponding changes to the database
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();

            string selectedDrink = cmb_StockSelect.SelectedItem.ToString();
            int newAmount = int.Parse(txt_StockAmount.Text);
            string newName = "";
            double price = 1.00;

            // Pak de waarden alleen als de hokjes aangevinkt zijn
            if (chk_ChangeName.Checked)
            {
                newName = txt_StockNewName.Text;
            }
            if (chk_PriceChange.Checked)
            {
                price = double.Parse(txt_StockNewPrice.Text);
            }

            /*
             * Hieronder wordt bepaald welke query er verstuurd wordt.
             * De methode geeft een opdracht aan Stock_Service om een methode uit te voeren 
             * De Methode doet niets anders dan de namen die hierboven zijn aangegeven doorgeven naar de Stock_DAO
             * Bij de Stock_DAO zijn ook weer een aantal methoden aangemaakt welke de query sturen naar de database.
             * De Stock_DAO pakt de meegegeven waarden, zet ze in de query die wordt aangeroepen en stuurt dit naar de database
             */
            if (chk_ChangeName.Checked && chk_PriceChange.Checked)
            {
                stockService.UpdateAll(selectedDrink, newName, newAmount, price);
            }
            else if (chk_ChangeName.Checked)
            {
                stockService.ChangeName(selectedDrink, newName, newAmount);
            }
            else if (chk_PriceChange.Checked)
            {
                stockService.UpdatePrice(selectedDrink, selectedDrink, price);
            }
            else
            {
                stockService.UpdateStock(selectedDrink, newAmount);
            }

            pnl_StockChange.Hide();

        }

        private void chk_ChangeName_CheckedChanged(object sender, EventArgs e)
        {
            lbl_StockNewName.Show();
            txt_StockNewName.Show();
        }

        private void chk_Price_CheckedChanged(object sender, EventArgs e)
        {
            lbl_StockNewPrice.Show();
            txt_StockNewPrice.Show();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Schedule");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }

        private void btn_EditActivities_Click(object sender, EventArgs e)
        {
            pnl_EditActivities.Show();
        }

        private void attendantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Attendants");
        }

        private void btn_AddAttendant_Click(object sender, EventArgs e)
        {
            showPanel("AddAttendants");
        }

        private void btn_DeleteAttendant_Click(object sender, EventArgs e)
        {
            showPanel("DeleteAttendant");
        }

        private void btn_ConfirmAttendant_Click(object sender, EventArgs e)
        {
            SomerenLogic.Attendant_Service attendantService = new SomerenLogic.Attendant_Service();

            int selectedLecturer = int.Parse(listViewAddAttendant.SelectedItems[0].SubItems[0].Text);
            attendantService.AddAttendant(selectedLecturer);

            pnl_AddAttendant.Hide();
        }

        private void btn_CofirmDeleteAttendant_Click(object sender, EventArgs e)
        {
            pnl_DeleteWaarshuwing.Show();

        }

        private void btn_SwitchActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = activityService.GetActivities();

           
            string selectedItem = dgv_Schedule.CurrentCell.Value.ToString();
            Console.WriteLine(selectedItem);

            foreach (Activity a in activityList)
            {
                if(a.Omschijving == selectedItem)
                {
                    if(a.Day == "monday")
                    {
                        activityService.ChangeActivity("tuesday", selectedItem);
                        ShowMonday();
                    } if( a.Day == "tuesday")
                    {
                        activityService.ChangeActivity("monday", selectedItem);
                        ShowTuesday();
                    }
                }
            }
        }

        private void btn_ConfirmEditAttendant_Click(object sender, EventArgs e)
        {
            pnl_EditActivities.Hide();
        }

            public void ShowMonday()
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = activityService.GetActivities();


            List<Activity> dailyList = activityService.GetDayActivity("monday");

            dgv_Schedule.DataSource = dailyList;
            dgv_Schedule.Columns.RemoveAt(0);
            dgv_Schedule.Columns.RemoveAt(3);
        }


        public void ShowTuesday()
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = activityService.GetActivities();


            List<Activity> dailyList = activityService.GetDayActivity("tuesday");

            dgv_Schedule.DataSource = dailyList;
            dgv_Schedule.Columns.RemoveAt(0);
            dgv_Schedule.Columns.RemoveAt(3);
        }

        public void ShowEmptyList()
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> emptyList = activityService.EmptyActivity();

            dgv_Schedule.DataSource = emptyList;
            dgv_Schedule.Columns.RemoveAt(0);
            dgv_Schedule.Columns.RemoveAt(3);
        }


        private void btnSelectMonday_Click(object sender, EventArgs e)
        {

            ShowMonday();
        }

        private void btn_SelectTuesday_Click(object sender, EventArgs e)
        {

            ShowTuesday();

        }

        private void btn_SelectWednesday_Click(object sender, EventArgs e)
        {
            ShowEmptyList();
        }

        private void btn_SelectThursday_Click(object sender, EventArgs e)
        {
            ShowEmptyList();
        }

        private void btn_ScheduleSelectDAy_Click(object sender, EventArgs e)
        {
            ShowEmptyList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_DeleteAttendant.Hide();
        }

        private void btn_CloseAddAttendant_Click(object sender, EventArgs e)
        {
            pnl_AddAttendant.Hide();
        }

        private void btn_DeleteNo_Click(object sender, EventArgs e)
        {
            pnl_DeleteWaarshuwing.Hide();
        }

        private void btn_DeleteYes_Click(object sender, EventArgs e)
        {
            SomerenLogic.Attendant_Service attendantService = new SomerenLogic.Attendant_Service();

            int selectedLecturer = int.Parse(listViewDeleteAttendant.SelectedItems[0].SubItems[0].Text);
            attendantService.DeleteAttendant(selectedLecturer);

            pnl_DeleteAttendant.Hide();
            pnl_DeleteWaarshuwing.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            pnl_AddActivity.Show();
        }
        private void btnAddActivityconfirm_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();

            int ActivityId = int.Parse(txt_AddActivityId.Text);
            string ActivityOmschrijving = txt_AddActivityName.Text;
            int ActivityAantalStudenten = int.Parse(txt_AddActivityaantalstudenten.Text);
            int ActivityAantalBegeleiders = int.Parse(txt_AddActivityAantalbegeleiders.Text);

            activityService.AddActivity(ActivityId, ActivityOmschrijving, ActivityAantalStudenten, ActivityAantalBegeleiders);

            pnl_AddActivity.Hide();
            listViewActivities.Refresh();
            listViewActivities.Items.Clear();
            ShowActivities();
        }

        public void ShowActivities()
        {
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = activityService.GetActivities();

            foreach (Activity a in activityList)
            {
                ListViewItem li = new ListViewItem();

                li.SubItems.Add(a.Id.ToString());
                li.Text = a.Omschijving;
                li.SubItems.Add(a.aantalStudenten.ToString());
                li.SubItems.Add(a.aantalBegeleiders.ToString());

                listViewActivities.Items.Add(li);
            }
        }

    }

}


