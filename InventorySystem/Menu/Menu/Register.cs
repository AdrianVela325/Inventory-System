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

namespace Menu
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //local database connection
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRegister WHERE username = '" + txtUser.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (txtPassword.Text == "" && txtConPass.Text == "" && cmbType.Text == "" && txtUser.Text == "")
            {
                lblError.Text = "Please fill out all fields.";
            }
            else if (cmbType.Text == "")
            {
                lblError.Text = "Please enter the type of user.";
            }
            else if (txtPassword.Text != txtConPass.Text)
            {
                lblError.Text = "Password didn't match! Please check.";
            }
            else if (txtUser.Text == "")
            {
                lblError.Text = "Username field can't be empty.";
            }
            else if (txtPassword.Text == "" || txtConPass.Text == "")
            {
                lblError.Text = "Password field can't be empty.";
            }
            else
            {
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Account Already Existed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Text = "";
                    cmbType.Text = "";
                    txtPassword.Text = "";
                    txtConPass.Text = "";
                }
                else
                {
                    SqlCommand sc = new SqlCommand("INSERT INTO tblRegister (username, type, password) VALUES ('" + txtUser.Text + "','" + cmbType.Text + "','" + txtPassword.Text + "')", conn);
                    conn.Open();
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    if (cmbType.Text == "Admin")
                    {
                        SqlConnection cona = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
                        SqlDataAdapter sdaa = new SqlDataAdapter("SELECT * FROM tblAdmin WHERE username = '" + txtUser.Text + "'", cona);
                        DataTable dta = new DataTable();
                        sdaa.Fill(dta);
                        SqlCommand sca = new SqlCommand("INSERT INTO tblAdmin (username, type, password) VALUES ('" + txtUser.Text + "','" + cmbType.Text + "','" + txtPassword.Text + "')", cona);
                        cona.Open();
                        sca.ExecuteNonQuery();
                        cona.Close();
                    }
                    else if (cmbType.Text == "Guest")
                    {
                        SqlConnection cong = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
                        SqlDataAdapter sdag = new SqlDataAdapter("SELECT * FROM tblGuest WHERE username = '" + txtUser.Text + "'", cong);
                        DataTable dtg = new DataTable();
                        sdag.Fill(dtg);
                        SqlCommand scg = new SqlCommand("INSERT INTO tblGuest (username, type, password) VALUES ('" + txtUser.Text + "','" + cmbType.Text + "','" + txtPassword.Text + "')", cong);
                        cong.Open();
                        scg.ExecuteNonQuery();
                        cong.Close();
                    }
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                }

            }
        }
        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = Color.Red;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = Color.Transparent;
        }

        private void close_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Exit Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dr == DialogResult.Cancel)
            {

            }
        }

        private void SignIn_MouseClick(object sender, MouseEventArgs e)
        {
            Login S = new Login();
            S.Show();
            this.Hide();
        }

        private void lblHide_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtPassword.PasswordChar == '•')
            {
                lblShow.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void lblShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                lblHide.BringToFront();
                txtPassword.PasswordChar = '•';
            }
        }

        private void lblHide2_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtConPass.PasswordChar == '•')
            {
                lblShow2.BringToFront();
                txtConPass.PasswordChar = '\0';
            }
        }

        private void lblShow2_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtConPass.PasswordChar == '\0')
            {
                lblHide2.BringToFront();
                txtConPass.PasswordChar = '•';
            }
        }

        private void close_Click(object sender, EventArgs e)
        {

        }
    }
}
