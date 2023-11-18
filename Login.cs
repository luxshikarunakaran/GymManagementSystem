using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace GymManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym_management_system";

     

       

        private void pictureBoxYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");

        }

        private void pictureBoxfacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/?_rdc=1&_rdr");

        }

        private void pictureBoxInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            String username = Convert.ToString(txtusername.Text);
            String password = Convert.ToString(txtpassword.Text);

            if (username == "")
            {
                MessageBox.Show("Enter the username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password == "")
            {
                MessageBox.Show("Enter the password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                MySqlConnection conn = new MySqlConnection();

                string query = "SELECT * FROM login where Name='" + txtusername.Text + "' and Password='" + txtpassword.Text + "'";

                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                Coach coach = new Coach();
                coach.Show();

                Login login=new Login();
                login.Hide();

             
            }

          


        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
