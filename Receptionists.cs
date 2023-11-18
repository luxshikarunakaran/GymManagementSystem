using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Receptionists : Form
    {
        public Receptionists()
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
                if (txtreceid.Text=="" &&
                    txtRecName.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    txtaddress.Text == "" &&
                    txtphoneno.Text == "" &&
                    txtpassword.Text=="")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 ReceId = Convert.ToInt32(txtreceid.Text);
                    String ReceName = txtRecName.Text;
                    String Gender = cmbgender.SelectedItem.ToString();
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Address = txtaddress.Text;
                    String Password = txtpassword.Text;
                    String PhoneNo=txtphoneno.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO receptionists(ReceId,RName,RGender,RDOB,RAddress,RPhoneNo,RPassword) VALUES ('"+ReceId+"','" + ReceName + "','" + Gender + "','" + DOB + "','" + Address + "','" + PhoneNo + "','"+Password+"')";

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

        Int32 rowid;
        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtreceid.Text == "" &&
                    txtRecName.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    txtaddress.Text == "" &&
                    txtphoneno.Text == "" &&
                    txtpassword.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 ReceId = Convert.ToInt32(txtreceid.Text);
                    String ReceName = txtRecName.Text;
                    String Gender = cmbgender.SelectedItem.ToString();
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Address = txtaddress.Text;
                    String Password = txtpassword.Text;
                    String PhoneNo = txtphoneno.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE  receptionists SET RName='" + ReceName + "',RGender='" + Gender + "',RDOB='" + DOB + "',RAddress='" + Address + "' ,RPhoneNo='" + PhoneNo + "' ,RPassword='" + Password + "'  where ReceId='" + ReceId + "'";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Edited Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtreceid.Text == "" &&
                    txtRecName.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    txtaddress.Text == "" &&
                    txtphoneno.Text == "" &&
                    txtpassword.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 ReceId = Convert.ToInt32(txtreceid.Text);

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "DELETE From receptionists where ReceId='" + ReceId + "'";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch
            {
                MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit ", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                txtreceid.Clear();
                txtRecName.Clear();
                txtphoneno.Clear();
                txtpassword.Clear();
                txtaddress.Clear();
                dateTimePickerDOB.Value = DateTime.Today;
                cmbgender.SelectedIndex = -1;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            Int32 ReceId = Convert.ToInt32(txtreceid.Text);

            MySqlConnection conCmd = new MySqlConnection(con);
            string query1 = "SELECT * FROM receptionists";
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
            Members members = new Members();
            members.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Memberships members = new Memberships();
            members.Show();
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
