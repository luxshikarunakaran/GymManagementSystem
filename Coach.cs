using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymManagementSystem
{
    public partial class Coach : Form
    {
        public Coach()
        {
            InitializeComponent();
           
        }

       string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym_management_system";


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit ", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        
        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCoachid.Text == "" &&
                    txtname.Text == "" &&
                    txtaddress.Text == "" &&
                    txtexperience.Text == "" &&
                    txtpassword.Text == "" &&
                    txtphoneno.Text == "" &&
                    cmbgender.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 CoachId = Convert.ToInt32(txtCoachid.Text);
                    String Name = txtname.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Gender = cmbgender.SelectedItem.ToString();
                    String PhoneNo = txtphoneno.Text;
                    Int32 Experience = Convert.ToInt32(txtexperience.Text);
                    String Address = txtaddress.Text;
                    String Password = txtpassword.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO coach(CId,CName,CDOB,CPhoneNo,CExperience,CAddress,CPassword,Gender) VALUES ('" + CoachId + "','" + Name + "','" + DOB + "','" + PhoneNo + "','" + Experience + "','" + Address + "','" + Password + "','" + Gender + "')";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();

                  
                    MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch
            {
                  MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnedit_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCoachid.Text == "" &&
                    txtname.Text == "" &&
                    txtaddress.Text == "" &&
                    txtexperience.Text == "" &&
                    txtpassword.Text == "" &&
                    txtphoneno.Text == "" &&
                    cmbgender.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Int32 CoachId = Convert.ToInt32(txtCoachid.Text);
                    String Name = txtname.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Gender = cmbgender.SelectedItem.ToString();
                    String PhoneNo = txtphoneno.Text;
                    Int32 Experience = Convert.ToInt32(txtexperience.Text);
                    String Address = txtaddress.Text;
                    String Password = txtpassword.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE coach SET CName='" + Name+ "', CDOB='" + DOB + "',CPhoneNo='" + PhoneNo + "',CExperience='" + Experience+ "',CAddress='" + Address + "',CPassword='" + Password + "',Gender='" + Gender + "'  where CId='" + CoachId + "'";
                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();

                    MessageBox.Show("Data Edit Successfully!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            catch
            {
                MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCoachid.Text == "" &&
                     txtname.Text == "" &&
                     txtaddress.Text == "" &&
                     txtexperience.Text == "" &&
                     txtpassword.Text == "" &&
                     txtphoneno.Text == "" &&
                     cmbgender.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Int32 CoachId = Convert.ToInt32(txtCoachid.Text);
                   
                    MySqlConnection conCmd = new MySqlConnection(con);
                    string query1 = "DELETE From coach where CId='" +CoachId+ "'";
                    MySqlCommand queryCmd = new MySqlCommand(query1, conCmd);

                    conCmd.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();

                    MessageBox.Show("Do you want to delete the data", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnreferesh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to refresh", "Referesh", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                txtCoachid.Clear();
                txtname.Clear();
                txtaddress.Clear();
                txtexperience.Clear();
                txtpassword.Clear();
                txtphoneno.Clear();
                dateTimePickerDOB.Value = DateTime.Today;
                cmbgender.SelectedIndex = -1;
                
            }
        }

       
      

        private void btnview_Click(object sender, EventArgs e)
        {
            MySqlConnection conCmd = new MySqlConnection(con);
            string query1 = "SELECT * FROM coach";
            MySqlCommand queryCmd = new MySqlCommand(query1, conCmd);


            conCmd.Open();


            MySqlDataAdapter md = new MySqlDataAdapter(queryCmd);
            DataSet ds = new DataSet();
            md.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

      

       
        

        private void label9_Click(object sender, EventArgs e)
        {
            Coach coach = new Coach();
            coach.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Members members=new Members();
            members.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Memberships memberships = new Memberships();
            memberships.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Receptionists receptionists = new Receptionists();
            receptionists.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
          
                if (MessageBox.Show("Are You sure you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Exit();
                }
           
        }
    }
}
