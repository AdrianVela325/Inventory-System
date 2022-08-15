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
    public partial class CoreData : Form
    {
        public CoreData()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrillDown s = new DrillDown();
            s.TopLevel = false;
            CoreDataPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GraphicalData s = new GraphicalData();
            s.TopLevel = false;
            CoreDataPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CoreData s = new CoreData();
            s.TopLevel = false;
            CoreDataPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }
    }
}
