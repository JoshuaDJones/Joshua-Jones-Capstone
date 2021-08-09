using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joshua_Jones_C969_Project
{
    public partial class sortTableForm : Form
    {
        string creator = null;
        public sortTableForm(string creatorName)
        { 
            creator = creatorName;

            InitializeComponent();

            createDatePicker.Value = DateTime.Now.Date;
            lastUpdatedDatePicker.Value = DateTime.Now.Date; 
            appointmentDatePicker.Value = DateTime.Now.Date;
            appointmentCreatedDatePicker.Value = DateTime.Now.Date;
            appointmentLastUpdatedDatePicker.Value = DateTime.Now.Date;

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
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm(creator);
            userForm.Show();
            this.Hide();
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

        private void sortCustomersButton_Click(object sender, EventArgs e)
        {
            string customerSort = "SELECT * FROM customer where";
            bool needsAComma = false;

            if ((custNameTextBox.Text == "") && (customerActiveDropDown.SelectedItem == null) && (createDatePicker.Value.Date == DateTime.Today.Date) &&
                 (createByTextBox.Text == "") && (lastUpdatedDatePicker.Value.Date == DateTime.Today.Date) && (lastUpdatedByTextbox.Text == ""))
            {
                string message = "None of the sorting fields have a value...";
                MessageBox.Show(message);
            }
            else
            {
                if (custNameTextBox.Text != "")
                {
                    customerSort = customerSort + " customerName = '" + (custNameTextBox.Text) + "'";
                    needsAComma = true;
                }
                else if (customerActiveDropDown.SelectedItem != null)
                {
                    int isActive = 0;
                    if(customerActiveDropDown.SelectedItem.ToString() == "Active")
                    {
                        isActive = 1;
                    }

                    if(needsAComma == true)
                    {
                        customerSort = customerSort + ", active = " + isActive;
                        needsAComma = true;
                    }
                    else
                    {
                        customerSort = customerSort + " active = " + isActive;
                        needsAComma = true;
                    }
                }
                else if (createDatePicker.Value.Date != DateTime.Today.Date)
                {
                    if (needsAComma == true)
                    {
                        //SELECT * FROM customers where DATE(column_name) = DATE('2016-01-14')
                        customerSort = customerSort + ", DATE(createDate) = DATE('" + createDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                    else
                    {
                        customerSort = customerSort + " DATE(createDate) = DATE('" + createDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                }
                else if (createByTextBox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        customerSort = customerSort + ", createdBy = '" + createByTextBox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        customerSort = customerSort + " createdBy = '" + createByTextBox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (lastUpdatedDatePicker.Value.Date != DateTime.Today.Date)
                {
                    if (needsAComma == true)
                    {
                        customerSort = customerSort + ", DATE(lastUpdate) = DATE('" + lastUpdatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                    else
                    {
                        customerSort = customerSort + " DATE(lastUpdate) = DATE('" + lastUpdatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        //DATE(column_name) = DATE('2016-01-14')
                        needsAComma = true;
                    }
                }
                else if (lastUpdatedByTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        customerSort = customerSort + ", lastUpdateBy = '" + lastUpdatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        customerSort = customerSort + " lastUpdateBy = '" + lastUpdatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                }

                DataTable dt = SendDbCmd(customerSort);
                customerDataGridView.DataSource = dt;
            }
        }

        private void customerListReset_Click(object sender, EventArgs e)
        {
            DataTable dt = SendDbCmd("SELECT * FROM customer");
            customerDataGridView.DataSource = dt;

            for (int idx = 0; idx < dt.Rows.Count; idx++)
            {
                dt.Rows[idx]["createDate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[idx]["createDate"], TimeZoneInfo.Local).ToString();
                dt.Rows[idx]["lastUpdate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[idx]["lastUpdate"], TimeZoneInfo.Local).ToString();
            }

            custNameTextBox.Text = "";
            customerActiveDropDown.SelectedItem = null;
            createDatePicker.Value = DateTime.Today.Date;
            createByTextBox.Text = "";
            lastUpdatedDatePicker.Value = DateTime.Today.Date;
            lastUpdatedByTextbox.Text = "";
      
        }

        private void sortAppointmentsButton_Click(object sender, EventArgs e)
        {
            string appointmentSort = "SELECT * FROM appointment where";
            bool needsAComma = false;

            if ((appointmentTitleTextbox.Text == "") && (appointmentDescriptionTextBox.Text == "") && (appointmentLocationTextbox.Text == "") &&
                 (appointmentContactTextbox.Text == "") && (appointmentTypeTextbox.Text == "") && (appointmentDatePicker.Value.Date == DateTime.Today.Date)
                 && (appointmentCreatedByTextbox.Text == "") && (appointmentCreatedDatePicker.Value.Date == DateTime.Today.Date) && (appointmentLastUpdatedByTextbox.Text == "")
                 && (appointmentLastUpdatedDatePicker.Value.Date == DateTime.Today.Date))
            {
                string message = "None of the sorting fields have a value...";
                MessageBox.Show(message);
            }
            else
            {
                if (appointmentTitleTextbox.Text != "")
                {
                    appointmentSort = appointmentSort + " title = '" + (appointmentTitleTextbox.Text) + "'";
                    needsAComma = true;
                }
                else if (appointmentDescriptionTextBox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", description = '" + appointmentDescriptionTextBox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " description = '" + appointmentDescriptionTextBox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentLocationTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", location = '" + appointmentLocationTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " location = '" + appointmentLocationTextbox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentContactTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", contact = '" + appointmentContactTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " contact = '" + appointmentContactTextbox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentTypeTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", type = '" + appointmentTypeTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " type = '" + appointmentTypeTextbox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentDatePicker.Value.Date != DateTime.Today.Date)
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", DATE(start) = DATE('" + appointmentDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " DATE(start) = DATE('" + appointmentDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                }
                else if (appointmentCreatedByTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", createdBy = '" + appointmentCreatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " createdBy = '" + appointmentCreatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentCreatedDatePicker.Value.Date != DateTime.Today.Date)
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", DATE(createDate) = DATE('" + appointmentCreatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " DATE(createDate) = DATE('" + appointmentCreatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                }
                else if (appointmentLastUpdatedByTextbox.Text != "")
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", lastUpdateBy = '" + appointmentLastUpdatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " lastUpdateBy = '" + appointmentLastUpdatedByTextbox.Text + "'";
                        needsAComma = true;
                    }
                }
                else if (appointmentLastUpdatedDatePicker.Value.Date != DateTime.Today.Date)
                {
                    if (needsAComma == true)
                    {
                        appointmentSort = appointmentSort + ", DATE(lastUpdate) = DATE('" + appointmentLastUpdatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                    else
                    {
                        appointmentSort = appointmentSort + " DATE(lastUpdate) = DATE('" + appointmentLastUpdatedDatePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd") + "')";
                        needsAComma = true;
                    }
                }

                DataTable dt = SendDbCmd(appointmentSort);
                appointmentDataGridView.DataSource = dt;
            }
        }

        private void resetAppointmentsListButton_Click(object sender, EventArgs e)
        {
            DataTable dt1 = SendDbCmd("SELECT * FROM appointment");
            appointmentDataGridView.DataSource = dt1;

            for (int idx = 0; idx < dt1.Rows.Count; idx++)
            {
                dt1.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["createDate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["createDate"], TimeZoneInfo.Local).ToString();
                dt1.Rows[idx]["lastUpdate"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt1.Rows[idx]["lastUpdate"], TimeZoneInfo.Local).ToString();
            }

            appointmentTitleTextbox.Text = "";
            appointmentDescriptionTextBox.Text = "";
            appointmentLocationTextbox.Text = "";
            appointmentContactTextbox.Text = "";
            appointmentTypeTextbox.Text = "";
            appointmentDatePicker.Value = DateTime.Today.Date;
            appointmentCreatedByTextbox.Text = "";
            appointmentCreatedDatePicker.Value = DateTime.Today.Date;
            appointmentLastUpdatedByTextbox.Text = "";
            appointmentLastUpdatedDatePicker.Value = DateTime.Today.Date;

        }
    }
}
