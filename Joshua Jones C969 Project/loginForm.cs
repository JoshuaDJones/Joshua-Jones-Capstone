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
using System.IO;
using System.Globalization;


namespace Joshua_Jones_C969_Project
{
    public partial class loginForm : Form
    {
        private StreamWriter fileWriter;
        private string culture = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        public loginForm()
        {
            InitializeComponent();

            if(culture == "de")
            {
                userNameLabel.Text = "Nutzername:";
                passWordLabel.Text = "Passwort:";
                submittButton.Text = "einloggen";
            }
        }

        private void submittButton_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=wgudb.ucertify.com;username=U06oD8;password=53688824840;database=U06oD8;port=3306");
            string sqlString = "SELECT * FROM user where userName = '" + userNameTextBox.Text.Trim() + "' and password = '" + passWordTextBox.Text.Trim() + "'";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            
            if (dt.Rows.Count == 1)
            {
                string creatorName = userNameTextBox.Text;
                UserForm userFrm = new UserForm(creatorName);
                this.Hide();
                userFrm.Show();
                WriteToFile(creatorName);
            }
            else
            {
                if (culture == "de")
                {
                    string error = "Login ist ungültig...";
                    MessageBox.Show(error);
                }
                else
                {
                    string error = "Login is invalid...";
                    MessageBox.Show(error);
                }
            }
        }

        private void WriteToFile(string userName)
        {
            DateTime date = GetCurrentTime();
            string stringDate = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local).ToString("yyyy-MM-dd HH:mm:ss");
            string fileName = "LoginLog.txt";

            if (File.Exists(fileName))
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
              
                    sw.WriteLine($"{userName}" + " " + $"{stringDate}" + "\n");
               
                    sw.Close();
                }
            }
            else
            {
                File.WriteAllText(fileName, userName + " " + stringDate + "\n");
            }
        }

        private DateTime GetCurrentTime()
        {
            DateTime theDate = DateTime.Now.ToUniversalTime();
            return theDate;
        }
    }
}
