using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GymManagementSystem
{
    public partial class Billing : Form
    {
        public Billing()
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
                if (txtagent.Text == "" &&
                    txtmember.Text == "" &&
                    txtperiod.Text == "" &&
                    dateTimePickerDate.Text == "" &&
                    txtamount.Text == ""
                    )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    String Agent = txtagent.Text;
                    String Member = txtmember.Text; 
                    String Period = txtperiod.Text;
                    Int32 Amount = Convert.ToInt32(txtamount.Text);
                    String Date = dateTimePickerDate.Value.ToString();

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO billing(Agent,Member,Period,Date,Amount) VALUES ('" + Agent + "','" + Member + "','" + Period + "','" + Date + "','" + Amount + "')";

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
                if (txtagent.Text == "" &&
                    txtmember.Text == "" &&
                    txtperiod.Text == "" &&
                    dateTimePickerDate.Text == "" &&
                    txtamount.Text == ""
                    )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    String Agent = txtagent.Text;
                    String Member = txtmember.Text;
                    String Period = txtperiod.Text;
                    Int32 Amount = Convert.ToInt32(txtamount.Text);
                    String Date = dateTimePickerDate.Value.ToString();


                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE  billing SET Agent='" + Agent + "',Member='" + Member + "',Period='" + Period + "',Date='" + Date + "' ,Amount='" + Amount + "'   where BillId='" + rowid + "'";
                    MySqlCommand queryCmd = new MySqlCommand(query, conn);
                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data edited Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtagent.Text == "" &&
                    txtmember.Text == "" &&
                    txtperiod.Text == "" &&
                    dateTimePickerDate.Text == "" &&
                    txtamount.Text == ""
                    )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else
                {
                    String Agent = txtagent.Text;

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "DELETE From billing where Agent='" + Agent + "'";

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
                txtagent.Clear();
                txtamount.Clear();
                txtmember.Clear();
                txtperiod.Clear();
                dateTimePickerDate.Value = DateTime.Today;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            MySqlConnection conCmd = new MySqlConnection(con);
            string query1 = "SELECT * FROM billing";
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
