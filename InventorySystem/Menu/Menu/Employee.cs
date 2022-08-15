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
    public partial class EmployeeCnt : Form
    {
        public EmployeeCnt()
        {
            InitializeComponent();
            refreshDataGrid();
        }
        //refreshes datagridview
        public void refreshDataGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT schEmpId as 'School Employee ID', schEmpName as 'Name of\nSchool Employee', dept as 'Department', age as 'Age', address as 'Complete Address', contactNo as 'Contact No.', roomNo as 'Room/Office' FROM tblSchEmp", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEmployee.DataSource = dt;
            con.Close();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room s = new Room();
            s.TopLevel = false;
            EmployeePnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void btnEmployeeInfo_Click(object sender, EventArgs e)
        {
            EmployeeCnt s = new EmployeeCnt();
            s.TopLevel = false;
            EmployeePnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
            
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Equipment s = new Equipment();
            s.TopLevel = false;
            EmployeePnl.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void EmployeePnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //get datagridview selected row
            int selectedRow = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[selectedRow];

            //display datagridview selelcted row into textbox
            txtID.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtDept.Text = row.Cells[2].Value.ToString();
            txtAge.Text = row.Cells[3].Value.ToString();
            txtAddress.Text = row.Cells[4].Value.ToString();
            txtContact.Text = row.Cells[5].Value.ToString();
            txtRoom.Text = row.Cells[6].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSchEmp WHERE schEmpID = '" + txtID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Account Already Existed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
            }
            else
            {
                SqlCommand sc = new SqlCommand("INSERT INTO tblSchEmp (schEmpID, schEmpName, dept, age, address, contactNo, roomNo) VALUES ('" + txtID.Text + "', '" + txtName.Text + "', '" + txtDept.Text + "', '" + txtAge.Text + "', '" + txtAddress.Text + "', '" + txtContact.Text + "', '" + txtRoom.Text + "')", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
                refreshDataGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSchEmp WHERE schEmpID = '" + txtID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("UPDATE tblSchEmp SET schEmpName = @schEmpName, dept = @dept, age = @age,  address = @address, contactNo = @contactNo,  roomNo = @roomNo WHERE schEmpID = '" + txtID.Text + "'", con);
                sc.Parameters.AddWithValue("@schEmpName", txtName.Text);
                sc.Parameters.AddWithValue("@dept", txtDept.Text);
                sc.Parameters.AddWithValue("@age", txtAge.Text);
                sc.Parameters.AddWithValue("@address", txtAddress.Text);
                sc.Parameters.AddWithValue("@contactNo", txtContact.Text);
                sc.Parameters.AddWithValue("@roomNo", txtRoom.Text);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSchEmp WHERE schEmpID = '" + txtID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                SqlCommand sc = new SqlCommand("DELETE FROM tblSchEmp WHERE schEmpID = '" + txtID.Text + "'", con);                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Account Doesn't Exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Text = "";
                txtName.Text = "";
                txtDept.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRoom.Text = "";
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvEmployee.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvEmployee.SelectedRows[0].Cells[1].Value.ToString();
                txtDept.Text = dgvEmployee.SelectedRows[0].Cells[2].Value.ToString();
                txtAge.Text = dgvEmployee.SelectedRows[0].Cells[3].Value.ToString();
                txtAddress.Text = dgvEmployee.SelectedRows[0].Cells[4].Value.ToString();
                txtContact.Text = dgvEmployee.SelectedRows[0].Cells[5].Value.ToString();
                txtRoom.Text = dgvEmployee.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adrian Vela\Desktop\INVENTORY SYSTEM\Menu\Menu\dbSystem.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSchEmp where schEmpName = '" + txtSearch.Text + "'", con);
            con.Open();
            SqlCommandBuilder b = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvEmployee.DataSource = ds.Tables[0];
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
