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

namespace HospitalManagementSystem
{
    public partial class room : Form
    {
        public room()
        {
            InitializeComponent();
        }


        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Main check = new Main();
            check.Show();
            this.Hide();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"DData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            cn.Open();
            if (roomprice.Text != string.Empty && comboBox2.Text != null)
            {

                SqlCommand cmd = new SqlCommand("insert into RoomDetails values(@RoomType,@Price,@Vacant)", cn);
                cmd.Parameters.AddWithValue("RoomType", comboBox2.Text);
                cmd.Parameters.AddWithValue("Price", roomprice.Text);
                cmd.Parameters.AddWithValue("Vacant", 1);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Added Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = null;
            roomprice.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (deleroom.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id = int.Parse(deleroom.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True";
                SqlConnection sqlc = new SqlConnection(con);
                string query = "Delete from RoomDetails where Id = ('" + id + "')";
                SqlCommand sqlcom = new SqlCommand(query, sqlc);
                sqlc.Open();
                int n = sqlcom.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Room Deleted!");
                }
                else
                {
                    MessageBox.Show("Error! Try Again");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 0;
            int id = int.Parse(deleroom.Text);
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from RoomDetails where Id like '" + id + "%'", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dgvRoom.DataSource = dt;
            if (deleroom.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else if (dgvRoom.Rows[i].Cells[0].Value == null)
            {
                MessageBox.Show("ID Not Found! Please Try Again");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            int id = int.Parse(roomidto_upd.Text);
            SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand Comm = new SqlCommand("Select * from RoomDetails where Id = ('" + id + "')", Conn);
            Conn.Open();
            SqlDataReader dr = Comm.ExecuteReader();
            if (dr.Read())
            {

                comboBox1.Text = dr.GetValue(1).ToString();
                uprice.Text = dr.GetValue(2).ToString();
            }
            Conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int id = int.Parse(roomidto_upd.Text);
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            cn.Open();
            if (uprice.Text != string.Empty && comboBox1.Text != null)
            {
                SqlCommand cmd = new SqlCommand("update  RoomDetails set RoomType=@RoomType,Price=@Pricewhere Id=('" + id + "')", cn);
                cmd.Parameters.AddWithValue("RoomType", comboBox1.Text);
                cmd.Parameters.AddWithValue("Price", uprice.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter All Fields");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            roomidto_upd.Text = null;
            comboBox1.Text = null;
            uprice.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from RoomDetails", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dgvAllRooms.DataSource = dt;
        }

        private void room_Load(object sender, EventArgs e)
        {
            string access = "";
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\HMS.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            cn.Open();
            int k = 0;
            SqlCommand cmd = new SqlCommand("select * from nnnn where Id='" + k + "' and chuck='" + k + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                access = "pass";
            }
            if (access == "pass")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }
        }
    }
}
