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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalManagementSystem
{
    public partial class employee : Form
    {
        public employee()
        {

            InitializeComponent();
        }

        private void DeleteEmp(object sender, EventArgs e)
        {
            if (DeleteId.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id = int.Parse(DeleteId.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;";
                SqlConnection sqlc = new SqlConnection(con);
                string query = "Delete from Emloyee where Id = ('" + id + "')";
                SqlCommand sqlcom = new SqlCommand(query, sqlc);
                sqlc.Open();
                int n = sqlcom.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Emlpoyee Deleted!");
                }
                else
                {
                    MessageBox.Show("Error! Try Again");
                }
            }
        }
        private void addtodatabase(object sender, EventArgs e)
        {
            string gender = "";
            if (Male.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }


            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            cn.Open();
            if (name.Text != string.Empty && Age.Text != string.Empty && Contact.Text != string.Empty && Fow.Text != string.Empty && Address.Text != string.Empty && (Male.Checked || Female.Checked))
            {
                SqlCommand cmd = new SqlCommand("insert into Emloyee values(@Name,@Gender,@Age,@Contact,@FieldofWork,@Address)", cn);
                cmd.Parameters.AddWithValue("Name", name.Text);
                cmd.Parameters.AddWithValue("Gender", gender);
                cmd.Parameters.AddWithValue("Age", int.Parse(Age.Text));
                cmd.Parameters.AddWithValue("Contact", Contact.Text);
                cmd.Parameters.AddWithValue("FieldofWork", Fow.Text);
                cmd.Parameters.AddWithValue("Address", Address.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Added Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            name.Text = null;
            Male.Checked = false;
            Female.Checked = false;
            Age.Text = null;
            Contact.Text = null;
            Fow.Text = null;
            Address.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DeleteId.Text == null)
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id = int.Parse(DeleteId.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;";
                SqlConnection sqlc = new SqlConnection(con);
                string query = "Delete from Emloyee where Id = ('" + id + "')";
                SqlCommand sqlcom = new SqlCommand(query, sqlc);
                sqlc.Open();
                int n = sqlcom.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Task Deleted!");
                }
                else
                {
                    MessageBox.Show("Error! Try Again");
                }
            }
        }

        private void ShowAllEmp(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            SqlCommand sqlcom = new SqlCommand("Select * from Emloyee", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dataGridViewShow.DataSource = dt;
        }



        private void button8_Click(object sender, EventArgs e)
        {
            dataGridViewDEL.DataSource = null;
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

        private void ShowEmpDetToDelete(object sender, EventArgs e)
        {

            if (DeleteId.Text == null)
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id = int.Parse(DeleteId.Text);
                SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
                SqlCommand sqlcom = new SqlCommand("Select * from emloyee where Id like '" + id + "%'", sqlc);
                sqlc.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlc.Close();
                dataGridViewDEL.DataSource = dt;
            }
        }

        private void SearchandFill_Click(object sender, EventArgs e)
        {
            string id = UpdateId.Text;
            SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            SqlCommand Comm = new SqlCommand("Select * from Emloyee where ID = ('" + id + "')", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm.ExecuteReader();
            if (DR1.Read())
            {
                uname.Text = DR1.GetValue(1).ToString();
                ugender.Text = DR1.GetValue(2).ToString();
                uage.Text = DR1.GetValue(3).ToString();
                ucontact.Text = DR1.GetValue(4).ToString();
                ufow.Text = DR1.GetValue(5).ToString();
                uaddress.Text = DR1.GetValue(6).ToString();
            }
            Conn.Close();
        }

        private void updateEmp_Click(object sender, EventArgs e)
        {

            int id = int.Parse(UpdateId.Text);
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            cn.Open();
            if (uname.Text != string.Empty && ugender.Text != string.Empty && uage.Text != string.Empty && ucontact.Text != string.Empty && ufow.Text != string.Empty && uaddress.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("update  Emloyee set Name=@Name,Gender=@Gender,Age=@Age,Contact=@Contact,FieldofWork=@FieldofWork,Address=@Address where Id=('" + id + "')", cn);
                cmd.Parameters.AddWithValue("Name", uname.Text);
                cmd.Parameters.AddWithValue("Gender", ugender.Text);
                cmd.Parameters.AddWithValue("Age", int.Parse(uage.Text));
                cmd.Parameters.AddWithValue("Contact", ucontact.Text);
                cmd.Parameters.AddWithValue("FieldofWork", ufow.Text);
                cmd.Parameters.AddWithValue("Address", uaddress.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Details Updated Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uname.Text = null;
            ugender.Text = null;
            uage.Text = null;
            ucontact.Text = null;
            ufow.Text = null;
            uaddress.Text = null;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void employee_Load(object sender, EventArgs e)
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
                tabcontrol.TabPages.Remove(tabPage1);
                tabcontrol.TabPages.Remove(tabPage2);
                tabcontrol.TabPages.Remove(tabPage3);
            }
        }
    }
}

