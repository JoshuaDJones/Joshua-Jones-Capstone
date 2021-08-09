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
    public partial class ReportForm : Form
    {
        public string creatorName;
        public ReportForm(string creator)
        {
            InitializeComponent();
            creatorName = creator;
        }

        private void typesByMonthButton_Click(object sender, EventArgs e)
        {
            

            for (int i = 1; i <= 12; i++)
            {
                string[] types = { "NULL" };
                DataTable dt = SendDbCmd("Select * FROM appointment where month(start) = " + i + ";");

                switch (i)
                {
                    case 1:
                        outputTextBox.Text = "Month of January\n";
                        break;
                    case 2:
                        outputTextBox.AppendText("\nMonth of February\n");
                        break;
                    case 3:
                        outputTextBox.AppendText("\nMonth of March\n");
                        break;
                    case 4:
                        outputTextBox.AppendText("\nMonth of April\n");
                        break;
                    case 5:
                        outputTextBox.AppendText("\nMonth of May\n");
                        break;
                    case 6:
                        outputTextBox.AppendText("\nMonth of June\n");
                        break;
                    case 7:
                        outputTextBox.AppendText("\nMonth of July\n");
                        break;
                    case 8:
                        outputTextBox.AppendText("\nMonth of August\n");
                        break;
                    case 9:
                        outputTextBox.AppendText("\nMonth of September\n");
                        break;
                    case 10:
                        outputTextBox.AppendText("\nMonth of October\n");
                        break;
                    case 11:
                        outputTextBox.AppendText("\nMonth of November\n");
                        break;
                    case 12:
                        outputTextBox.AppendText("\nMonth of December\n");
                        break;
                }

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    DataRow row = dt.Rows[r];
                    string type = (row["type"]).ToString();

                    //this lambda expression evaluates the array to see if an element exists in a easier more efficient way
                    // instead of having to use a for loop this expression checks the array in a way thats easier to read
                    if (Array.Exists(types, element => element == type) == false)
                    {
                        int numberOfThisType = 0;
                        Array.Resize(ref types, types.Length + 1);
                        types[types.Length - 1] = type;

                        for(int q = 0; q < dt.Rows.Count; q++)
                        {
                            DataRow row1 = dt.Rows[q];
                            string testType = (row1["type"]).ToString();
                         
                            if(testType == type)
                            {
                                numberOfThisType++;
                            }
                        }

                        outputTextBox.AppendText("\nThere are/is " + numberOfThisType + " appointment(s) of type " + type + " in this month.");


                    }
                }
                outputTextBox.AppendText("\n");
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            UserForm userFrm = new UserForm(creatorName);
            this.Hide();
            userFrm.Show();
        }

        private void consultantScheduleButton_Click(object sender, EventArgs e)
        {
            DataTable dt = SendDbCmd("SELECT * FROM user where userName='" + creatorName + "';");

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow row = dt.Rows[r];
                int userId = (int)(row["userId"]);
                string userName = (row["userName"]).ToString();

                outputTextBox.Text = "User " + userName + " has the following appointments:\n\n";

                DataTable dt1 = SendDbCmd("SELECT * FROM appointment where userId=" + userId + ";");

                for(int o = 0; o < dt1.Rows.Count; o++)
                {
                    DataRow row1 = dt1.Rows[o];
                    int customerId = (int)(row1["customerId"]);
                    string startDate = (row1["start"]).ToString();
                    string endDate = (row1["end"]).ToString();

                    DataTable dt2 = SendDbCmd("SELECT * FROM customer where customerId=" + customerId + ";");
                    DataRow row2 = dt2.Rows[0];
                    string customerName = (row2["customerName"]).ToString();

                    outputTextBox.AppendText(customerName + " starting date and time: " + startDate + " ending date and time: " + endDate + "\n");
                }

            }
        }

        private void showCustomersButton_Click(object sender, EventArgs e)
        {
            DataTable dt = SendDbCmd("SELECT * FROM customer");

            outputTextBox.Text = "Customers:\n\n";


            for (int o = 0; o < dt.Rows.Count; o++)
            {
                DataRow row = dt.Rows[o];
                string customerName = (row["customerName"]).ToString();
                string createDate = (row["createDate"]).ToString();
                string createdBy = (row["createdBy"]).ToString();

                outputTextBox.AppendText("customer: " + customerName + " created: " + createDate + " created by: " + createdBy + "\n");

            }
        }
    }
}
