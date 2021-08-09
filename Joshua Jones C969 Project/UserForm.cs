using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Joshua_Jones_C969_Project
{
    public partial class UserForm : Form
    {
        public int startDay = 0;

        public bool sortByWeek = false;

        public int intMonth = 0;


        public string creator;
        public UserForm(string creatorName)
        {
            creator = creatorName;
            InitializeComponent();
            rightArrowButton.Visible = false;
            leftArrowButton.Visible = false;
            weekMonthLabel.Visible = false;
            userFormLabel.Text = creator;
            DataTable dt = SendDbCmd("SELECT * FROM customer");
            customerDataGridView.DataSource = dt;

            for (int idx = 0; idx < dt.Rows.Count; idx++)
            {
                dt.Rows[idx]["createDate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[idx]["createDate"], TimeZoneInfo.Local).ToString();
                dt.Rows[idx]["lastUpdate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[idx]["lastUpdate"], TimeZoneInfo.Local).ToString();
            }

            DataTable dt1 = SendDbCmd("SELECT * FROM appointment");
            appointmentDataGridView.DataSource = dt1;

            for (int idx = 0; idx < dt1.Rows.Count; idx++)
            {
                dt1.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["createDate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["createDate"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["lastUpdate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["lastUpdate"], TimeZoneInfo.Local).ToString();
            }

            CheckForAppointments();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            
            var addCustomer = new addUpdateCustomerForm(creator);
            addCustomer.Show();
            this.Hide();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGridView.Rows.Count < 1)
            {
                string message = "There are no customers to update...";
                MessageBox.Show(message);
            }
            else
            {
                int selectedCust = (int)customerDataGridView.SelectedCells[0].Value;
                var addcustomer = new addUpdateCustomerForm(selectedCust, creator);
                addcustomer.Show();
                this.Hide();
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=wgudb.ucertify.com;username=U06oD8;password=53688824840;database=U06oD8;port=3306");
            if (customerDataGridView.Rows.Count < 1)
            {
                string message = "There are no more customers to delete...";
                MessageBox.Show(message);
            }
            else
            {
                int selectedCust = (int)customerDataGridView.SelectedCells[0].Value;
                string sqlString = "DELETE FROM appointment WHERE customerId=" + selectedCust + "; DELETE FROM customer WHERE customerId = " + selectedCust;
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string sqlString1 = "SELECT * FROM customer";
                MySqlCommand cmd1 = new MySqlCommand(sqlString1, con);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                customerDataGridView.DataSource = dt1;

                string sqlString2 = "SELECT * FROM appointment";
                MySqlCommand cmd2 = new MySqlCommand(sqlString2, con);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                appointmentDataGridView.DataSource = dt2;
            }
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            var addAppointment = new addUpdateAppointmentForm(creator);
            addAppointment.Show();
            this.Hide();
        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            int selectedAppointment = (int)appointmentDataGridView.SelectedCells[0].Value;
            
            var addAppointment = new addUpdateAppointmentForm(creator, selectedAppointment);
            addAppointment.Show();
            this.Hide();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            int selectedAppointment = (int)appointmentDataGridView.SelectedCells[0].Value;
            DataTable dt = SendDbCmd("DELETE FROM appointment WHERE appointmentId =" + selectedAppointment + ";");
         
            DataTable dt1 = SendDbCmd("SELECT * FROM appointment;");
            appointmentDataGridView.DataSource = dt1;
        }

        private DataTable SendDbCmd(string sqlCmd)
        {
            MySqlConnection con = new MySqlConnection("server=wgudb.ucertify.com;username=U06oD8;password=53688824840;database=U06oD8;port=3306");
            MySqlCommand cmd = new MySqlCommand(sqlCmd, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        private DateTime GetCurrentDate()
        {
            DateTime theDate = DateTime.Now;
            
            return theDate;
        }

        private void appointmentWeekButton_Click(object sender, EventArgs e)
        {
            sortByWeek = true;
            rightArrowButton.Visible = true;
            leftArrowButton.Visible = true;
            weekMonthLabel.Visible = true;

            int endDay = startDay + 6;
            if (startDay == 0)
            {

                    DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE DATE(start) >=  CURDATE() + INTERVAL " + startDay + " DAY AND Date(start) <= CURDATE() + INTERVAL " + endDay + " DAY;");
                    appointmentDataGridView.DataSource = dt;
            }
            else
            {
                try
                {
                    DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE DATE(start) >=  CURDATE() + INTERVAL " + startDay + " DAY AND Date(start) <= CURDATE() + INTERVAL " + endDay + " DAY;"); DataRow row = dt.Rows[0];
                    appointmentDataGridView.DataSource = dt;
                }
                catch
                {
                    appointmentDataGridView.DataSource = null;
                }
            }

            DateTime theDate = DateTime.Now.AddDays(startDay);
            DateTime endDate = DateTime.Now.AddDays(endDay);
            string startWeekDate = theDate.ToString("MM-dd-yyyy");
            string endWeekDate = endDate.ToString("MM-dd-yyyy");

            weekMonthLabel.Text = "Week: " + startWeekDate + " thru " + endWeekDate;
        }

        private void rightArrowButton_Click(object sender, EventArgs e)
        {
            if (sortByWeek == true)
            {
                startDay = startDay + 7;
                int endDay = startDay + 6;

                if (startDay == 0)
                {
                    DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE DATE(start) >=  CURDATE() + INTERVAL " + startDay + " DAY AND Date(start) <= CURDATE() + INTERVAL " + endDay + " DAY;");
                    appointmentDataGridView.DataSource = dt;
                }
                else
                {
                    DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE DATE(start) >=  CURDATE() + INTERVAL " + startDay + " DAY AND Date(start) <= CURDATE() + INTERVAL " + endDay + " DAY;");
                    appointmentDataGridView.DataSource = dt;

                }
                DateTime theDate = DateTime.Now.AddDays(startDay);
                DateTime endDate = DateTime.Now.AddDays(endDay);
                string startWeekDate = theDate.ToString("MM-dd-yyyy");
                string endWeekDate = endDate.ToString("MM-dd-yyyy");

                weekMonthLabel.Text = "Week: " + startWeekDate + " thru " + endWeekDate;
            }
            else if (sortByWeek == false)
            {
                intMonth = intMonth + 1;

                DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE month(start) =  " + intMonth + ";");
                appointmentDataGridView.DataSource = dt;


                switch (intMonth)
                {
                    case 1:
                        weekMonthLabel.Text = "Month of January";
                        break;
                    case 2:
                        weekMonthLabel.Text = "Month of February";
                        break;
                    case 3:
                        weekMonthLabel.Text = "Month of March";
                        break;
                    case 4:
                        weekMonthLabel.Text = "Month of April";
                        break;
                    case 5:
                        weekMonthLabel.Text = "Month of May";
                        break;
                    case 6:
                        weekMonthLabel.Text = "Month of June";
                        break;
                    case 7:
                        weekMonthLabel.Text = "Month of July";
                        break;
                    case 8:
                        weekMonthLabel.Text = "Month of August";
                        break;
                    case 9:
                        weekMonthLabel.Text = "Month of September";
                        break;
                    case 10:
                        weekMonthLabel.Text = "Month of October";
                        break;
                    case 11:
                        weekMonthLabel.Text = "Month of November";
                        break;
                    case 12:
                        weekMonthLabel.Text = "Month of December";
                        break;
                }
            }
        }

        private void leftArrowButton_Click(object sender, EventArgs e)
        {
            if (sortByWeek == true)
            {
                startDay = startDay - 7;
                int endDay = startDay + 6;

                DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE DATE(start) >=  CURDATE() + INTERVAL " + startDay + " DAY AND Date(start) <= CURDATE() + INTERVAL " + endDay + " DAY;"); 
                appointmentDataGridView.DataSource = dt;

                DateTime theDate = DateTime.Now.AddDays(startDay);
                DateTime endDate = DateTime.Now.AddDays(endDay);
                string startWeekDate = theDate.ToString("MM-dd-yyyy");
                string endWeekDate = endDate.ToString("MM-dd-yyyy");

                weekMonthLabel.Text = "Week: " + startWeekDate + " thru " + endWeekDate;
                
            }
            else if (sortByWeek == false)
            {
                intMonth = intMonth - 1;

                DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE month(start) =  " + intMonth + ";");
                appointmentDataGridView.DataSource = dt;


                switch (intMonth)
                {
                    case 1:
                        weekMonthLabel.Text = "Month of January";
                        break;
                    case 2:
                        weekMonthLabel.Text = "Month of February";
                        break;
                    case 3:
                        weekMonthLabel.Text = "Month of March";
                        break;
                    case 4:
                        weekMonthLabel.Text = "Month of April";
                        break;
                    case 5:
                        weekMonthLabel.Text = "Month of May";
                        break;
                    case 6:
                        weekMonthLabel.Text = "Month of June";
                        break;
                    case 7:
                        weekMonthLabel.Text = "Month of July";
                        break;
                    case 8:
                        weekMonthLabel.Text = "Month of August";
                        break;
                    case 9:
                        weekMonthLabel.Text = "Month of September";
                        break;
                    case 10:
                        weekMonthLabel.Text = "Month of October";
                        break;
                    case 11:
                        weekMonthLabel.Text = "Month of November";
                        break;
                    case 12:
                        weekMonthLabel.Text = "Month of December";
                        break;
                }

            }
        }

        private void appointmentByMonthButton_Click(object sender, EventArgs e)
        {
            sortByWeek = false;
            rightArrowButton.Visible = true;
            leftArrowButton.Visible = true;
            weekMonthLabel.Visible = true;

            DateTime theDate = DateTime.Now;
            string stringMonth = theDate.ToString("MM");
            intMonth = Int32.Parse(stringMonth);

            DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE month(start) =  " + intMonth + ";");
            appointmentDataGridView.DataSource = dt;



            switch (intMonth)
            {
                case 1:
                    weekMonthLabel.Text = "Month of January";
                    break;
                case 2:
                    weekMonthLabel.Text = "Month of February";
                    break;
                case 3:
                    weekMonthLabel.Text = "Month of March";
                    break;
                case 4:
                    weekMonthLabel.Text = "Month of April";
                    break;
                case 5:
                    weekMonthLabel.Text = "Month of May";
                    break;
                case 6:
                    weekMonthLabel.Text = "Month of June";
                    break;
                case 7:
                    weekMonthLabel.Text = "Month of July";
                    break;
                case 8:
                    weekMonthLabel.Text = "Month of August";
                    break;
                case 9:
                    weekMonthLabel.Text = "Month of September";
                    break;
                case 10:
                    weekMonthLabel.Text = "Month of October";
                    break;
                case 11:
                    weekMonthLabel.Text = "Month of November";
                    break;
                case 12:
                    weekMonthLabel.Text = "Month of December";
                    break;


            }

        }

        private void allAppointmentsButton_Click(object sender, EventArgs e)
        {
            rightArrowButton.Visible = false;
            leftArrowButton.Visible = false;
            weekMonthLabel.Visible = false;

            DataTable dt = SendDbCmd("SELECT * FROM appointment");
         
            appointmentDataGridView.DataSource = dt;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void CheckForAppointments()
        {
            DataTable dt = SendDbCmd("Select * FROM user where userName ='" + creator + "';");
            DataRow row = dt.Rows[0];
            int userId = (int)(row["userId"]);

            DataTable dt1 = SendDbCmd("SELECT * FROM appointment where userId =" + userId + ";");

            for (int idx = 0; idx < dt1.Rows.Count; idx++)
            {
                DataRow row1 = dt1.Rows[idx];
                DateTime startTime = (DateTime)(row1["start"]);
                DateTime priorToStart = (DateTime)(row1["start"]);
                priorToStart = priorToStart.AddMinutes(-15);
                DateTime currentTime = GetCurrentDate().ToUniversalTime();
                if(currentTime > priorToStart && currentTime < startTime)
                {
                    string message = "You have an appointment starting at " + (startTime.ToLocalTime()).ToString() + " ...";
                    MessageBox.Show(message);
                }
            }
        }

        private void openReportsButton_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(creator);
            reportForm.Show();
            this.Hide();
        }

        private void tableSortButton_Click(object sender, EventArgs e)
        {
            var sortForm = new sortTableForm(creator);
            sortForm.Show();
            this.Hide();
        }
    }
}

