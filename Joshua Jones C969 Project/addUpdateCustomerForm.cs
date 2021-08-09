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
    public partial class addUpdateCustomerForm : Form
    {
        public string creator;
        public bool updateCust;
        public int custToBeUpdatedId = 0;
        public int custToBeUpdatedAddressId = 0; 

        public addUpdateCustomerForm(int rowIndex, string creatorName)
        {
            custToBeUpdatedId = rowIndex;
            creator = creatorName;
            updateCust = true;
            InitializeComponent();
            countryComboBox.Enabled = false;
            cityComboBox.Enabled = false;
            clearButton.Enabled = false;
            PopulateTheFields(rowIndex);
        }
        public addUpdateCustomerForm(string creatorName)
        {
            creator = creatorName;
            updateCust = false;
            InitializeComponent();
            countryComboBox.Enabled = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var userfrm = new UserForm(creator);
            userfrm.Show();
            this.Hide();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            customerNameTextBox.Text = "";
            streetAddressTextBox.Text = "";
            postalCodeTextBox.Text = "";
            phoneNumberCustomerTextBox.Text = "";
            countryComboBox.SelectedIndex = 0;
            cityComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            bool nullCheck = CheckForNull();
            if(updateCust == true)
            {
                if (nullCheck == true)
                {
                    string message = "All fields must be filled out to save...";
                    MessageBox.Show(message);

                }
                else if(nullCheck == false)
                {
                    SaveUpdatedCustomer();
                }
            }
            else if(updateCust == false)
            {
                if (nullCheck == true)
                {
                    string message = "All fields must be filled out to save...";
                    MessageBox.Show(message);

                }
                else if (nullCheck == false)
                {
                    string customerName = customerNameTextBox.Text;
                    string address = streetAddressTextBox.Text;
                    string postal = postalCodeTextBox.Text;
                    string country = countryComboBox.Text;
                    string city = cityComboBox.Text;
                    string phone = phoneNumberCustomerTextBox.Text;
                    int isActive;
                    if (activeCustomerYesRadioButton.Checked == true)
                    {
                        isActive = 1;
                    }
                    else
                    {
                        isActive = 0;
                    }

                    AddNewCustomer(customerName, isActive, address, postal, city, country, phone);
                }
            }
            var userfrm = new UserForm(creator);
            userfrm.Show();
            this.Hide();
        }

        private bool CheckForNull()
        {
            bool nullResult;
            if(customerNameTextBox.Text == "" || streetAddressTextBox.Text == "" || postalCodeTextBox.Text == ""
                ||cityComboBox.Text == "" || countryComboBox.Text == "" || phoneNumberCustomerTextBox.Text == "")
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

        private void AddNewCustomer(string cusName, int act, string add, string post, string cty, string ctry, string ph)
        {
            int countryId = FindCountryId(ctry);
            int cityId = FindCityId(cty);
            int addressId = FindAddressId(add);
            int customerId = 0;
            if (addressId == -1)
            {
               addressId = CreateNewAddressRow(addressId, add, cityId, ph, post);
            }

            DataTable dt = SendDbCmd("SELECT * FROM customer ORDER BY customerId DESC LIMIT 0, 1");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                customerId = (int)(row["customerId"]);
                customerId = customerId + 1;
            }
            else
            {
                customerId = 1;
            }
            string currentTime = GetCurrentTime();

            DataTable dt1 = SendDbCmd("INSERT INTO customer VALUES(" + customerId + ",'" + cusName + "'," + addressId + "," + act + ",'" + currentTime + "','" + creator + "','" + currentTime + "','" + creator + "');");

        }

        private int FindCountryId(string country)
        {
            int countryId;

            DataTable dt = SendDbCmd("SELECT * FROM country WHERE country = '" + country + "'");
            DataRow row = dt.Rows[0];
            countryId = (int)(row["countryId"]);
            
            return countryId;
        }

        private int FindCityId(string city)
        {
            int cityId;

            DataTable dt = SendDbCmd("SELECT * FROM city WHERE city ='" + city +"'");
            DataRow row = dt.Rows[0];
            cityId = (int)(row["cityId"]);

            return cityId;
        }

        private int FindAddressId(string address)
        {
            int addressId = 0;
            DataTable dt = SendDbCmd("SELECT * FROM address WHERE address ='" + address + "'");
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                addressId = (int)(row["addressId"]);
                return addressId;
            }
            else
            {
                addressId = -1;
                return addressId;
            }
        }

        private int CreateNewAddressRow(int id, string address, int ctyId, string phone, string postal)
        {
            DataTable dt = SendDbCmd("SELECT * FROM address ORDER BY addressId DESC LIMIT 0, 1");
            DataRow row = dt.Rows[0];
            int addressId = (int)(row["addressId"]);
            addressId = addressId + 1;
            string currentTime = GetCurrentTime();

            DataTable dt1 = SendDbCmd("INSERT INTO address VALUES(" + addressId + ",'" + address + "','" + "" + "'," + ctyId + ",'" 
                + postal + "','" + phone + "','" + currentTime + "','" + creator + "','" + currentTime + "','" + creator + "');");

            return addressId;
        }

        private string GetCurrentTime()
        {
            DateTime theDate = DateTime.Now.ToUniversalTime();
            string currentDateTime = theDate.ToString("yyyy-MM-dd H:mm:ss");
            return currentDateTime;
        }

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cityComboBox.SelectedIndex == 1 || cityComboBox.SelectedIndex == 2)
            {
                countryComboBox.SelectedItem = "US";
            }
            else if(cityComboBox.SelectedIndex == 3 || cityComboBox.SelectedIndex == 4)
            {
                countryComboBox.SelectedItem = "Canada";
            }
            else if(cityComboBox.SelectedIndex == 5)
            {
                countryComboBox.SelectedItem = "Norway";
            }
            else
            {
                countryComboBox.SelectedItem = "";
            }
        }

        private void PopulateTheFields(int index)
        {
            DataTable dt = SendDbCmd("SELECT * FROM customer WHERE customerId =" + index);
            DataRow row = dt.Rows[0];
            customerNameTextBox.Text = (row["customerName"]).ToString();
            int addressId = (int)(row["addressId"]);
            bool isActive = (bool)row["active"]; 
            if(isActive == true)
            {
                activeCustomerYesRadioButton.Checked = true;
                activeCustomerNoRadioButton.Checked = false;
            }
            else
            {
                activeCustomerYesRadioButton.Checked = false;
                activeCustomerNoRadioButton.Checked = true;
            }

            DataTable dt1 = SendDbCmd("SELECT * FROM address WHERE addressId =" + addressId);
            DataRow row1 = dt1.Rows[0];
            custToBeUpdatedAddressId = addressId;
            streetAddressTextBox.Text = (row1["address"]).ToString();
            postalCodeTextBox.Text = (row1["postalCode"]).ToString();
            phoneNumberCustomerTextBox.Text = (row1["phone"]).ToString();

            int cityId = (int)(row1["cityId"]);
            DataTable dt2 = SendDbCmd("SELECT * FROM city WHERE cityId=" + cityId);
            DataRow row2 = dt2.Rows[0];
            string cityName = (row2["city"]).ToString();
            cityComboBox.SelectedItem = cityName;
            int countryId = (int)(row2["countryId"]);

            DataTable dt3 = SendDbCmd("SELECT * FROM country where countryId=" + countryId);
            DataRow row3 = dt3.Rows[0];
            string countryName = (row3["country"]).ToString();
            countryComboBox.SelectedItem = countryName;  
        }

        private void SaveUpdatedCustomer()
        {
            string custName = customerNameTextBox.Text;
            int active;
            if (activeCustomerYesRadioButton.Checked == true)
            {
                active = 1;
            }
            else
            {
                active = 0;
            }
            string streetAddress = streetAddressTextBox.Text;
            string postalCode = postalCodeTextBox.Text;
            string phoneNo = phoneNumberCustomerTextBox.Text;

            DataTable dt1 = SendDbCmd("SELECT * FROM address WHERE addressId =" + custToBeUpdatedAddressId);
            DataRow row1 = dt1.Rows[0];
            string origAddress = row1["address"].ToString();
            int origCityId = (int)row1["cityId"];

            if (origAddress == streetAddress)
            {
                
                DataTable dt2 = SendDbCmd("update address set postalCode ='" + postalCode + "', phone='" + phoneNo + "', lastUpdate='" + GetCurrentTime() + "', lastUpdatedBy='" + creator + " where addressId =" + custToBeUpdatedAddressId + ";");
                          
            }
            else
            {
                DataTable dt3 = SendDbCmd("SELECT * FROM address ORDER BY addressId DESC LIMIT 0, 1");
                if (dt3.Rows.Count > 0)
                {
                    DataRow row2 = dt3.Rows[0];
                    custToBeUpdatedAddressId = (int)(row2["addressId"]);
                    custToBeUpdatedAddressId = custToBeUpdatedAddressId + 1;
                }
                
                DataTable dt4 = SendDbCmd("INSERT INTO address VALUES(" + custToBeUpdatedAddressId + ", '" + streetAddress + "', ''," + origCityId + ", '" + postalCode + "', '" + phoneNo + "', '" + GetCurrentTime() + "', '" + creator + "', '" + GetCurrentTime() + "', '" + creator + "');");
            }

            DataTable dt = SendDbCmd("update customer set customerName ='" + custName + "', addressId=" + custToBeUpdatedAddressId + ", active=" + active + " where customerId =" + custToBeUpdatedId + ";");

        }
    }
}
