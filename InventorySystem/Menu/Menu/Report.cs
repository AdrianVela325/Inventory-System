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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrillDown s = new DrillDown();
            s.TopLevel = false;
            ReportPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GraphicalData s = new GraphicalData();
            s.TopLevel = false;
            ReportPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CoreData s = new CoreData();
            s.TopLevel = false;
            ReportPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void Close_MouseClick(object sender, MouseEventArgs e)
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
    }
}
