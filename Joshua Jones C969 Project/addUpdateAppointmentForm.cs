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
    public partial class addUpdateAppointmentForm : Form
    {
        public string creatorName;
        public bool isNull;
        public int appointmentId;
        public int custIdForProfile;
        public addUpdateAppointmentForm(string creator)
        {
            InitializeComponent();
            creatorName = creator;
            PopulateTheCustomersComboBox();
            appointmentUserLabel.Text = creatorName;
            updateButton.Enabled = false;
            startTimePicker.Format = DateTimePickerFormat.Time;
            startTimePicker.ShowUpDown = true;
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.ShowUpDown = true;
        }

        public addUpdateAppointmentForm(string creator, int selectedAppointment)
        {
            InitializeComponent();
            creatorName = creator;
            appointmentId = selectedAppointment;
            appointmentUserLabel.Text = creatorName;
            PopulateTheCustomersComboBox();
            FillFieldsWithSelectedAppointment(selectedAppointment);
            createAppointmentButton.Enabled = false;
            
            startTimePicker.Format = DateTimePickerFormat.Time;
            startTimePicker.ShowUpDown = true;
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.ShowUpDown = true;
        }

        private bool CheckForNull()
        {
            bool nullResult;

            if (appointmentTitleTextBox.Text == "" || appointmentDesciptionTextBox.Text == "" || (string)appointmentCustomerComboBox.SelectedItem == ""
                || appointmentLocationTextBox.Text == "" || appointmentContactTextBox.Text == "" || appointmentURLTextBox.Text == "") 
            {
                return nullResult = true;
            }
            else
            {
                return nullResult = false;
            }
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

        private void PopulateTheCustomersComboBox()
        {
            DataTable dt = SendDbCmd("SELECT customerName FROM customer ORDER BY customerId");

            List<string> customerNamesList = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                customerNamesList.Add((string)Convert.ToString(row["customerName"]));
            }
            appointmentCustomerComboBox.DataSource = customerNamesList;
        }

        private void createAppointmentButton_Click(object sender, EventArgs e)
        {
            isNull = CheckForNull();

            if(isNull == true)
            {
                string message = "All fields must be filled out to create an appointment...";
                MessageBox.Show(message);
            }
            else
            {

                DateTime dayOfMeeting = (DateTime)(appointmentDatePicker.Value).ToUniversalTime();
                int dayYear = dayOfMeeting.Year;
                int dayMonth = dayOfMeeting.Month;
                int dayDay = dayOfMeeting.Day;

                TimeSpan startOfDay = new TimeSpan(13, 0, 0);
                TimeSpan endOfDay = new TimeSpan(21, 0, 0);
                DateTime appointmentStarttartTime = (DateTime)(startTimePicker.Value).ToUniversalTime();
                int startHour = appointmentStarttartTime.Hour;
                int startMinute = appointmentStarttartTime.Minute;

                DateTime appointmentEndTime = (DateTime)(endTimePicker.Value).ToUniversalTime();
                int endHour = appointmentEndTime.Hour;
                int endMinute = appointmentEndTime.Minute;

                DateTime testStart = new DateTime(dayYear, dayMonth, dayDay, startHour, startMinute, 0);
                DateTime testEnd = new DateTime(dayYear, dayMonth, dayDay, endHour, endMinute, 0);

                DateTime open = (DateTime)(dayOfMeeting.Date + startOfDay);
                DateTime close = (DateTime)(dayOfMeeting.Date + endOfDay);

                if (testStart < open || testStart > close)
                {
                    string message = "The selected times are out of operating hours (9am-5pm)...";
                    MessageBox.Show(message);
                }
                else if (testEnd < open || testEnd > close)
                {
                    string message = "The selected times are out of operating hours (9am-5pm)...";
                    MessageBox.Show(message);
                }
                else if ((CheckForOverLap(testStart, testEnd, appointmentId)) == true)
                {
                    string message = "The appointment overlaps with an existing appointment. Please change the appointment times...";
                    MessageBox.Show(message);
                }
                else
                {

                    string startTime = ((DateTime)(startTimePicker.Value).ToUniversalTime()).ToString("HH:mm:ss");
                    string endTime = ((DateTime)(endTimePicker.Value).ToUniversalTime()).ToString("HH:mm:ss");


                    var startTimeParse = DateTime.Parse(startTime);
                    var endTimeParse = DateTime.Parse(endTime);


                    if (startTimeParse > endTimeParse)
                    {
                        string message = "The start time of the appointment must be before the end time...";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        string title = appointmentTitleTextBox.Text;
                        string desciption = appointmentDesciptionTextBox.Text;
                        string custName = (string)appointmentCustomerComboBox.SelectedItem;
                        string location = appointmentLocationTextBox.Text;
                        string contact = appointmentContactTextBox.Text;
                        string type = appointmentTypeTextBox.Text;
                        string url = appointmentURLTextBox.Text;
                        string dateOfMeeting = ((DateTime)(appointmentDatePicker.Value).ToUniversalTime()).ToString("yyyy-MM-dd");
                        string startDateTime = dateOfMeeting + " " + startTime;
                        string endDateTime = dateOfMeeting + " " + endTime;

                        int userId = GetUserId(creatorName);
                        int custId = GetCustomerId(custName);
                        int appointmentId = GetNewAppointmentId();

                        DataTable dt = SendDbCmd("INSERT INTO appointment VALUES (" + appointmentId + "," + custId + "," + userId + ", '" + title + "', '" +
                        desciption + "', '" + location + "', '" + contact + "','" + type + "','" + url + "', '" + startDateTime + "','" + endDateTime +
                        "','" + GetCurrentTime() + "', '" + creatorName + "', '" + GetCurrentTime() + "', '" + creatorName + "');");

                        UserForm userform = new UserForm(creatorName);
                        userform.Show();
                        this.Hide();
                    }
                }
            }
        }
        private string GetCurrentTime()
        {
            DateTime theDate = DateTime.Now.ToUniversalTime();
            string currentDateTime = theDate.ToString("yyyy-MM-dd HH:mm:ss");
            return currentDateTime;
        }

        private int GetCustomerId(string name)
        {
            DataTable dt = SendDbCmd("SELECT * FROM customer WHERE customerName ='" + name + "'");
            DataRow row = dt.Rows[0];
            int custId = (int)(row["customerId"]);
            return custId;
        }

        private int GetUserId(string user)
        {
            DataTable dt = SendDbCmd("SELECT * FROM user WHERE userName ='" + user + "'");
            DataRow row = dt.Rows[0];
            int userId = (int)(row["userId"]);
            return userId;
        }

        private int GetNewAppointmentId()
        {
            int appointmentId;

            DataTable dt = SendDbCmd("SELECT * FROM appointment ORDER BY appointmentId DESC LIMIT 0, 1");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                appointmentId = (int)(row["appointmentId"]);
                appointmentId = appointmentId + 1;
            }
            else
            {
                appointmentId = 1;
            }
            return appointmentId;
        }

        private void FillFieldsWithSelectedAppointment(int appointmentId)
        {
            DataTable dt = SendDbCmd("SELECT * FROM appointment WHERE appointmentId =" + appointmentId);
            DataRow row = dt.Rows[0];
            
            string custId = (row["customerId"]).ToString();
            custIdForProfile = Int32.Parse(custId);
            appointmentTitleTextBox.Text = (row["title"]).ToString();
            appointmentDesciptionTextBox.Text = (row["description"]).ToString();
            appointmentLocationTextBox.Text = (row["location"]).ToString();
            appointmentContactTextBox.Text = (row["contact"]).ToString();
            appointmentTypeTextBox.Text = (row["type"]).ToString();
            appointmentURLTextBox.Text = (row["url"]).ToString();

            DataTable dt1 = SendDbCmd("select date_format(start,'%Y') AS Date from appointment WHERE appointmentId =" + appointmentId);
            DataRow row1 = dt1.Rows[0];
            string year = (row1["Date"]).ToString();
            
            DataTable dt2 = SendDbCmd("select date_format(start,'%m') AS Date from appointment WHERE appointmentId =" + appointmentId);
            DataRow row2 = dt2.Rows[0];
            string month = (row2["Date"]).ToString();

            DataTable dt3 = SendDbCmd("select date_format(start,'%d') AS Date from appointment WHERE appointmentId =" + appointmentId);
            DataRow row3 = dt3.Rows[0];
            string day = (row3["Date"]).ToString();

            DataTable dt4 = SendDbCmd("SELECT HOUR(start) AS Hour, MINUTE(start) AS Minute, SECOND(start) AS Second FROM appointment where appointmentId=" + appointmentId + ";");
            DataRow row4 = dt4.Rows[0];

            string startHour = (row4["Hour"]).ToString();
            string startMinute = (row4["Minute"]).ToString();
            string startSecond = (row4["Second"]).ToString();

            int year1 = Int32.Parse(year);
            int month1 = Int32.Parse(month);
            int day1 = Int32.Parse(day);
            int startHour1 = Int32.Parse(startHour);
            int startMinute1 = Int32.Parse(startMinute);
            int startSecond1 = Int32.Parse(startSecond);

            DateTime dayPicker = new DateTime(year1, month1, day1, startHour1, startMinute1, startSecond1).ToLocalTime();
            appointmentDatePicker.Value = dayPicker;

           DataTable dt5 = SendDbCmd("SELECT * FROM customer WHERE customerId =" + custId);
            DataRow row5 = dt5.Rows[0];

            string customerName = (row5["customerName"]).ToString();
            appointmentCustomerComboBox.SelectedItem = customerName;

            DataTable dt6 = SendDbCmd("SELECT HOUR(end) AS Hour, MINUTE(end) AS Minute, SECOND(end) AS Second FROM appointment where appointmentId=" + appointmentId + ";");
            DataRow row6 = dt6.Rows[0];

            string endHour = (row6["Hour"]).ToString();
            int endHour1 = Int32.Parse(endHour);
            string endMinute = (row6["Minute"]).ToString();
            int endMinute1 = Int32.Parse(endMinute);
            string endSecond = (row6["Second"]).ToString(); 
            int endSecond1 = Int32.Parse(endSecond);

            startTimePicker.Value = new DateTime(year1, month1, day1, startHour1, startMinute1, startSecond1).ToLocalTime();
            endTimePicker.Value = new DateTime(year1, month1, day1, endHour1, endMinute1, endSecond1).ToLocalTime();
         
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            UserForm userFrm = new UserForm(creatorName);
            this.Hide();
            userFrm.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            isNull = CheckForNull();

            if (isNull == true)
            {
                string message = "All fields must be filled out to create an appointment...";
                MessageBox.Show(message);
            }
            else
            {
                DateTime dayOfMeeting = (DateTime)(appointmentDatePicker.Value).ToUniversalTime();
                int dayYear = dayOfMeeting.Year;
                int dayMonth = dayOfMeeting.Month;
                int dayDay = dayOfMeeting.Day;

                TimeSpan startOfDay = new TimeSpan(13, 0, 0);
                TimeSpan endOfDay = new TimeSpan(21, 0, 0);
                DateTime appointmentStarttartTime = (DateTime)(startTimePicker.Value).ToUniversalTime();
                int startHour = appointmentStarttartTime.Hour;
                int startMinute = appointmentStarttartTime.Minute;
               
                DateTime appointmentEndTime = (DateTime)(endTimePicker.Value).ToUniversalTime();
                int endHour = appointmentEndTime.Hour;
                int endMinute = appointmentEndTime.Minute;

                DateTime testStart = new DateTime(dayYear, dayMonth, dayDay, startHour, startMinute, 0);
                DateTime testEnd = new DateTime(dayYear, dayMonth, dayDay, endHour, endMinute, 0);

                DateTime open = (DateTime)(dayOfMeeting.Date + startOfDay);
                DateTime close = (DateTime)(dayOfMeeting.Date + endOfDay);

                if (testStart < open || testStart > close)
                {
                    string message = "The selected times are out of operating hours (9am-5pm)...";
                    MessageBox.Show(message);
                }
                else if (testEnd < open || testEnd > close)
                {
                    string message = "The selected times are out of operating hours (9am-5pm)...";
                    MessageBox.Show(message);
                }
                else if ((CheckForOverLap(testStart, testEnd, appointmentId)) == true)
                {
                    string message = "The appointment overlaps with an existing appointment. Please change the appointment times...";
                    MessageBox.Show(message);
                }
                else
                {
                    string startTime = ((DateTime)(startTimePicker.Value).ToUniversalTime()).ToString("HH:mm:ss");
                    string endTime = ((DateTime)(endTimePicker.Value).ToUniversalTime()).ToString("HH:mm:ss");


                    var startTimeParse = DateTime.Parse(startTime);
                    var endTimeParse = DateTime.Parse(endTime);


                    if (startTimeParse > endTimeParse)
                    {
                        string message = "The start time of the appointment must be before the end time...";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        int userId = GetUserId(creatorName);
                        string title = appointmentTitleTextBox.Text;
                        string description = appointmentDesciptionTextBox.Text;
                        string customer = appointmentCustomerComboBox.Text;
                        string location = appointmentLocationTextBox.Text;
                        string contact = appointmentContactTextBox.Text;
                        string type = appointmentTypeTextBox.Text;
                        string url = appointmentURLTextBox.Text;

                        string dateOfMeeting = ((DateTime)(appointmentDatePicker.Value).ToUniversalTime()).ToString("yyyy-MM-dd");
                        string startDateTime = dateOfMeeting + " " + startTime;
                        string endDateTime = dateOfMeeting + " " + endTime;

                        DataTable dt = SendDbCmd("SELECT * FROM customer WHERE customerName ='" + customer + "'");
                        DataRow row = dt.Rows[0];
                        int custId = (int)(row["customerId"]);

                        DataTable dt1 = SendDbCmd("update appointment set customerId =" + custId + "," + "userId=" + userId + "," + "title=" + "'" + title + "'," + "description=" + "'" + description + "'," + "location=" + "'" + location + "'," + "contact=" + "'" + contact + "'," + "type=" + "'" + type + "'," + "url=" + "'" + url + "'," + "start=" + "'" + startDateTime + "'," + "end=" + "'" + endDateTime + "'," + "lastUpdate=" + "'" + GetCurrentTime() + "'," + "lastUpdateBy=" + "'" + creatorName + "' where appointmentId = " + appointmentId + "; ");

                        UserForm userform = new UserForm(creatorName);
                        userform.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void customerProfileButton_Click(object sender, EventArgs e)
        {
            if (appointmentCustomerComboBox.Text == "")
            {
                string message = "You must select a customer before you can view a profile...";
                MessageBox.Show(message);
            }
            else
            {
                CustomerProfileForm profileForm = new CustomerProfileForm(appointmentCustomerComboBox.Text);
                profileForm.Show();
            }
        }

        private bool CheckForOverLap(DateTime st, DateTime en, int id)
        {
            bool timesOverLap = false;

            int appId = id;
            DateTime startingTime = st;
            DateTime endingTime = en;

            DataTable dt = SendDbCmd("SELECT * FROM appointment;");
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow row = dt.Rows[r];
                DateTime startingTimeFromDb = (DateTime)(row["start"]);
                DateTime endingTimeFromDb = (DateTime)(row["end"]);
                int appIdFrmDb = (int)(row["appointmentId"]);

                //This lambda expression is used to evaluate the appointment id's more efficiently and returns a bool value

                Func<int, int, bool> testForEquality = (x, y) => x == y;

                if (testForEquality(appId, appIdFrmDb) == false)
                {
                    if (startingTime >= startingTimeFromDb && startingTime <= endingTimeFromDb)
                    {
                        timesOverLap = true;
                    }
                    else if (endingTime >= startingTimeFromDb && endingTime <= endingTimeFromDb)
                    {
                        timesOverLap = true;
                    }
                    else
                    {
                        timesOverLap = false;
                    }
                }
            }
                return timesOverLap;
        }
    }
}
