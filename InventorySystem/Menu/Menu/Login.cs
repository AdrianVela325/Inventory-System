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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            Register S = new Register();
            S.Show();
            //close the opened form
            this.Hide();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                lblError.Text = "Please input your username and password.";
            }
            else if (txtUsername.Text == "")
            {
                lblError.Text = "Username field can't be empty.";
            }
            else if (txtPassword.Text == "")
            {
                lblError.Text = "Password field can't be empty.";
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRegister WHERE username = '" + txtUsername.Text + "'and password = '" + txtPassword.Text + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //if account exists in tblRegister
                    if (dt.Rows.Count == 1)
                    {
                        SqlCommand sc = new SqlCommand("SELECT * FROM tblRegister WHERE username = '" + txtUsername.Text + "'and password = '" + txtPassword.Text + "'", conn);
                        conn.Open();
                        SqlDataReader sdr = sc.ExecuteReader();
                        //if account exists
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            //if type is "Admin"
                            if (sdr[1].ToString() == "Admin")
                            {
                                Menu m = new Menu();
                                this.Hide();
                                m.Show();
                            }
                            //if type is "Guest"
                            //disable some features
                            else if (sdr[1].ToString() == "Guest")
                            {
                                Menu m = new Menu();
                                m.btnInventory.Enabled = false;
                                m.lblInventory1.Enabled = false;
                                this.Hide();
                                m.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    //MessageBox.Show("There is no existing account! Please create one.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(ex.Message);
                }
            }    
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {

        }

        private void Login_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.BackColor = Color.Red;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.BackColor = Color.Transparent;
        }

        private void lblHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '•')
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

        private void Close_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Exit Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                //properly close the whole application
                System.Windows.Forms.Application.Exit();
            }
            else if (dr == DialogResult.Cancel)
            {

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
