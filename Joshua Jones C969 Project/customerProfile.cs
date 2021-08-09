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
    public partial class CustomerProfileForm : Form
    {
        public CustomerProfileForm(string customerName)
        {
            InitializeComponent();
            DataTable dt = SendDbCmd("SELECT * FROM customer WHERE customerName ='" + customerName + "';");
            DataRow row = dt.Rows[0];
            int addressId = (int)(row["addressId"]);
            int custId = (int)(row["customerId"]);
            bool activeBool = (bool)(row["active"]);
            string activeStatus;
            if(activeBool == true)
            {
                activeStatus = "Yes";
            }
            else
            {
                activeStatus = "No";
            }


            DataTable dt1 = SendDbCmd("SELECT * FROM address WHERE addressId = " + addressId + ";");
            DataRow row1 = dt1.Rows[0];
            
            string postalCode = row1["postalCode"].ToString();
            string address = row1["address"].ToString();
            string phone = row1["phone"].ToString();
            int cityId = (int)(row1["cityId"]);

            DataTable dt2 = SendDbCmd("SELECT * FROM city WHERE cityId = " + cityId + ";");
            DataRow row2 = dt2.Rows[0];
            string city = row2["city"].ToString();
            int countryId = (int)row2["countryId"];

            DataTable dt3 = SendDbCmd("SELECT * FROM country WHERE countryId = " + countryId + ";");
            DataRow row3 = dt3.Rows[0];
            string country = row3["country"].ToString();

            customerNameLabel.Text = customerName;
            customerActiveLabel.Text = activeStatus;
            customerAddressLabel.Text = address;
            customerPostalLabel.Text = postalCode;
            customerCityLabel.Text = city;
            customerCountryLabel.Text = country;
            customerPhoneLabel.Text = phone;

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
  
}
