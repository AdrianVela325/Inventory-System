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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            refreshDataGrid();
        }

        public void refreshDataGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT serialNo as 'Serial No.' , equipName as 'Equipment Name', assignDate as 'Assigned Date' , roomNo as 'Room/Office' , schEmpName as 'Name of \nSchool Employee' , status as 'Status' FROM tblEquipment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEquip.DataSource = dt;
            con.Close();
        }

        private void btnRoomInfo_Click(object sender, EventArgs e)
        {
     
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void btnEmployeeInfo_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEmployeeInfo_Click_1(object sender, EventArgs e)
        {
            EmployeeCnt s = new EmployeeCnt();
            s.TopLevel = false;
            InventoryPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room s = new Room();
            s.TopLevel = false;
            InventoryPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnEquipment_Click_1(object sender, EventArgs e)
        {
            Equipment s = new Equipment();
            s.TopLevel = false;
            InventoryPnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblEquipment WHERE serialNo = '" + txtSerial.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Account Already Existed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
            }
            else
            {
                SqlCommand sc = new SqlCommand("INSERT INTO tblEquipment (serialNo, equipName, assignDate, roomNo, schEmpName, status) VALUES ('" + txtSerial.Text + "', '" + txtEquip.Text + "', '" + txtDate.Text + "', '" + txtRoom.Text + "', '" + txtSchEmp.Text + "', '" + txtStatus.Text + "')", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
                refreshDataGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblEquipment WHERE serialNo = '" + txtSerial.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("UPDATE tblEquipment SET equipName = @equipName, assignDate = @assignDate, roomNo = @roomNo,  schEmpName = @schEmpName, status = @status WHERE serialNo = '" + txtSerial.Text + "'", con);
                sc.Parameters.AddWithValue("@equipName", txtEquip.Text);
                sc.Parameters.AddWithValue("@assignDate", txtDate.Text);
                sc.Parameters.AddWithValue("@roomNo", txtRoom.Text);
                sc.Parameters.AddWithValue("@schEmpName", txtSchEmp.Text);
                sc.Parameters.AddWithValue("@status", txtStatus.Text);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblEquipment WHERE serialNo = '" + txtSerial.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("DELETE FROM tblEquipment WHERE serialNo = '" + txtSerial.Text + "'", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerial.Text = "";
                txtEquip.Text = "";
                txtDate.Text = "";
                txtRoom.Text = "";
                txtSchEmp.Text = "";
                txtStatus.Text = "";
            }
        }

        private void dgvEquip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSerial.Text = dgvEquip.SelectedRows[0].Cells[0].Value.ToString();
                txtEquip.Text = dgvEquip.SelectedRows[0].Cells[1].Value.ToString();
                txtDate.Text = dgvEquip.SelectedRows[0].Cells[2].Value.ToString();
                txtRoom.Text = dgvEquip.SelectedRows[0].Cells[3].Value.ToString();
                txtSchEmp.Text = dgvEquip.SelectedRows[0].Cells[4].Value.ToString();
                txtStatus.Text = dgvEquip.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblEquipment where serialNo = '" + txtSearch.Text + "'", con);
            con.Open();
            SqlCommandBuilder b = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvEquip.DataSource = ds.Tables[0];
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
