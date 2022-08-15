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
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
            refreshDataGrid();
        }

        DataTable dts = new DataTable();

        //refreshes datagridview
        public void refreshDataGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT roomNo as 'Room/Office', schEmpName as 'Name of\nSchool Employee', floor as 'Floor' FROM tblRoom", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvRoom.DataSource = dt;
            con.Close();
        }

        

        private void RoomTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EqAdd_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EmployeeCnt s = new EmployeeCnt();
            s.TopLevel = false;
            RoomPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Room s = new Room();
            s.TopLevel = false;
            RoomPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Equipment s = new Equipment();
            s.TopLevel = false;
            RoomPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void EqAdd_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRoom WHERE roomNo = '" + txtRoom.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Account Already Existed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
            }
            else
            {
                SqlCommand sc = new SqlCommand("INSERT INTO tblRoom (roomNo, schEmpName, floor) VALUES ('" + txtRoom.Text + "', '" + txtSchEmp.Text + "', '" + cmbFloor.Text + "')", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
                refreshDataGrid();
            }
        }

        private void RoomPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dbSystemDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        
        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRoom WHERE roomNo = '" + txtRoom.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("UPDATE tblRoom SET schEmpName = @schEmpName, floor = @floor WHERE roomNo = '" + txtRoom.Text + "'", con);
                sc.Parameters.AddWithValue("@schEmpName", txtSchEmp.Text);
                sc.Parameters.AddWithValue("@floor", cmbFloor.Text);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRoom WHERE roomNo = '" + txtRoom.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("DELETE FROM tblRoom WHERE roomNo = '" + txtRoom.Text + "'", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                cmbFloor.Text = "";
            }
        }

        //display data from datagridview to textbox, set selectionmode in properties to fullselectedrow
        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                txtRoom.Text = dgvRoom.SelectedRows[0].Cells[0].Value.ToString();
                txtSchEmp.Text = dgvRoom.SelectedRows[0].Cells[1].Value.ToString();
                cmbFloor.Text = dgvRoom.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //for searching
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblRoom where roomNo = '" + txtSearch.Text + "'", con);
            con.Open();
            SqlCommandBuilder b = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvRoom.DataSource = ds.Tables[0];
            con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                refreshDataGrid();
            }
        }
    }
}
