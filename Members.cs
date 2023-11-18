using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymManagementSystem
{
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym_management_system";


        private void btnsave_Click(object sender, EventArgs e)
        {
          try { 
                if (txtmemberID.Text == "" &&
                    txtmembername.Text == "" &&
                    txtphoneno.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    dateTimePickerJoindate.Value.ToString() == "" &&
                    cmbstatus.SelectedIndex==-1 &&
                    txttiming.Text==""
                    )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 MemberID = Convert.ToInt32(txtmemberID.Text);
                    String MemberName = txtmembername.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Gender = cmbgender.SelectedItem.ToString();
                    String PhoneNo = txtphoneno.Text;
                    String JoinDate = dateTimePickerJoindate.Value.ToString();
                    String Status = cmbstatus.SelectedItem.ToString();
                    String Timing = txttiming.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO members(MembersId,MName,MGender,MDOB,MJoinDate,PhoneNo,Timing,Status) VALUES ('" + MemberID + "','" + MemberName + "','" + Gender + "','" + DOB + "','" + JoinDate + "','" + PhoneNo + "','" + Timing + "','" + Status + "')";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

            catch
            {
              //  MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }



    private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit ", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmemberID.Text == "" &&
                    txtmembername.Text == "" &&
                    txtphoneno.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    dateTimePickerJoindate.Value.ToString() == "" &&
                    cmbstatus.SelectedIndex == -1 &&
                      txttiming.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 MemberID = Convert.ToInt32(txtmemberID.Text);
                    String MemberName = txtmembername.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Gender = cmbgender.SelectedItem.ToString();
                    String PhoneNo = txtphoneno.Text;
                    String JoinDate = dateTimePickerJoindate.Value.ToString();
                    String Status = cmbstatus.SelectedItem.ToString();
                    String Timing = txttiming.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE members SET MName='" + MemberName + "',MGender='" + Gender + "',MDOB='" + DOB + "',MJoinDate='" + JoinDate + "',PhoneNo='"+PhoneNo+"',Timing='"+Timing+"',Status='"+Status+"' where MembersId='" + MemberID + "'";


                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Edited Successfully!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtmemberID.Text == "" &&
                    txtmembername.Text == "" &&
                    txtphoneno.Text == "" &&
                    cmbgender.SelectedIndex == -1 &&
                    dateTimePickerDOB.Value.ToString() == "" &&
                    dateTimePickerJoindate.Value.ToString() == "" &&
                    cmbstatus.SelectedIndex == -1 &&
                      txttiming.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Int32 MemberID = Convert.ToInt32(txtmemberID.Text);
                    String MemberName = txtmembername.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String Gender = cmbgender.SelectedItem.ToString();
                    String PhoneNo = txtphoneno.Text;
                    String JoinDate = dateTimePickerJoindate.Value.ToString();
                    String Status = cmbstatus.SelectedItem.ToString();
                    String Timing = txttiming.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "DELETE From members where MembersId='" +MemberID+ "'";


                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtmemberID.Clear();
                txtmembername.Clear();
                txtphoneno.Clear();
                cmbgender.SelectedIndex = -1;
                cmbstatus.SelectedIndex = -1;
                txttiming.Clear();
                dateTimePickerDOB.Value = DateTime.Today;
                dateTimePickerJoindate.Value = DateTime.Today;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            MySqlConnection conCmd = new MySqlConnection(con);
            string query1 = "SELECT * FROM members";
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
