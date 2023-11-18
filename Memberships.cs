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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymManagementSystem
{
    public partial class Memberships : Form
    {
        public Memberships()
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
                if (txtmembershipid.Text == "" &&
                    txtmembershipname.Text == "" &&
                    txtduration.Text == "" &&
                    txtgoal.Text=="" &&
                    txtcost.Text=="")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

              
                else
                {
                    Int32 Memberid = Convert.ToInt32(txtmembershipid.Text);
                    String MemberName = txtmembershipname.Text;
                    Int32 Duration = Convert.ToInt32(txtduration.Text);
                    String Goal=txtgoal.Text;
                    Int32 Cost = Convert.ToInt32(txtcost.Text);

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO member(MemberId,MName,MDuration,MGoal,MCost) VALUES ('" + Memberid + "','" + MemberName + "','" + Duration + "','" + Goal + "','" + Cost + "')";

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
                if (txtmembershipid.Text == "" &&
                    txtmembershipname.Text == "" &&
                    txtduration.Text == "" &&
                    txtgoal.Text == "" &&
                    txtcost.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else
                {
                    Int32 Memberid = Convert.ToInt32(txtmembershipid.Text);
                    String MemberName = txtmembershipname.Text;
                    Int32 Duration = Convert.ToInt32(txtduration.Text);
                    String Goal = txtgoal.Text;
                    Int32 Cost = Convert.ToInt32(txtcost.Text);

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE member SET MName='" + MemberName + "',MDuration='" + Duration + "',MGoal='" + Goal + "',MCost='" + Cost + "'  where MemberId='" + Memberid + "'";

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
                if (txtmembershipid.Text == "" &&
                    txtmembershipname.Text == "" &&
                    txtduration.Text == "" &&
                    txtgoal.Text == "" &&
                    txtcost.Text == "")
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else
                {
                    Int32 Memberid = Convert.ToInt32(txtmembershipid.Text);
                    String MemberName = txtmembershipname.Text;
                    Int32 Duration = Convert.ToInt32(txtduration.Text);
                    String Goal = txtgoal.Text;
                    Int32 Cost = Convert.ToInt32(txtcost.Text);

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "DELETE From member where MemberId='" + Memberid + "'";

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Refresh ", "Refresh", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                txtmembershipid.Clear();
                txtmembershipname.Clear();
                txtduration.Clear();
                txtgoal.Clear();
                txtcost.Clear();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {

            MySqlConnection conCmd = new MySqlConnection(con);
            string query1 = "SELECT * FROM member";
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
