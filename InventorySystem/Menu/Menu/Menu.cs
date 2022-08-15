using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.White;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Employee s = new Employee();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblDashboard1.BackColor = Color.White;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Dashboard s = new Dashboard();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.White;
            lblAccount1.BackColor = Color.Transparent;
            Report s = new Report();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.White;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Manual s = new Manual();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.White;
            Account s = new Account();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Login l = new Login();
                this.Hide();
                l.Show();
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void Date_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblDashboard1_MouseClick(object sender, MouseEventArgs e)
        {
            lblDashboard1.BackColor = Color.White;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Dashboard s = new Dashboard();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void lblInventory1_MouseClick(object sender, MouseEventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.White;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Employee s = new Employee();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void lblManual1_MouseClick(object sender, MouseEventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.White;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.Transparent;
            Manual s = new Manual();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void lblReport1_MouseClick(object sender, MouseEventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.White;
            lblAccount1.BackColor = Color.Transparent;
            Report s = new Report();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void lblAccount1_MouseClick(object sender, MouseEventArgs e)
        {
            lblDashboard1.BackColor = Color.Transparent;
            lblInventory1.BackColor = Color.Transparent;
            lblManual1.BackColor = Color.Transparent;
            lblReport1.BackColor = Color.Transparent;
            lblAccount1.BackColor = Color.White;
            Account s = new Account();
            s.TopLevel = false;
            pnlContent.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
