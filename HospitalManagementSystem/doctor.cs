using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class doctor : Form
    {
        public doctor()
        {
            InitializeComponent();
            int id = 999999999;
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from DoctorDetails where Id like '" + id + "%'", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dgvDocDel.DataSource = dt;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Main check = new Main();
            check.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddDoctor(object sender, EventArgs e)
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


            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            cn.Open();
            if (name.Text != string.Empty && Age.Text != string.Empty && Contact.Text != string.Empty && comboBoxspeciality.Text != null && Fees.Text != string.Empty && Exp.Text != string.Empty && Address.Text != string.Empty && (Male.Checked || Female.Checked))
            {
                SqlCommand cmd = new SqlCommand("insert into DoctorDetails values(@Name,@Gender,@Age,@Contact,@Speciality,@Fees,@Experience,@Address,@Free)", cn);
                cmd.Parameters.AddWithValue("Name", name.Text);
                cmd.Parameters.AddWithValue("Gender", gender);
                cmd.Parameters.AddWithValue("Age", int.Parse(Age.Text));
                cmd.Parameters.AddWithValue("Contact", Contact.Text);
                cmd.Parameters.AddWithValue("Speciality", comboBoxspeciality.Text);
                cmd.Parameters.AddWithValue("Fees", Fees.Text);
                cmd.Parameters.AddWithValue("Experience", Exp.Text);
                cmd.Parameters.AddWithValue("Address", Address.Text);
                cmd.Parameters.AddWithValue("Free", 1);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearDoctorDetails(object sender, EventArgs e)
        {
            name.Text = null;
            Male.Checked = false;
            Female.Checked = false;
            Age.Text = null;
            Contact.Text = null;
            comboBoxspeciality.Text = null;
            Fees.Text = null;
            Exp.Text = null;
            Address.Text = null;
        }

        private void deleteDoc_Click(object sender, EventArgs e)
        {

            if (Doctor_idtodel.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id = int.Parse(Doctor_idtodel.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True";
                SqlConnection sqlc = new SqlConnection(con);
                string query = "Delete from DoctorDetails where Id = ('" + id + "')";
                SqlCommand sqlcom = new SqlCommand(query, sqlc);
                sqlc.Open();
                int n = sqlcom.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Doctor Deleted!");
                }
                else
                {
                    MessageBox.Show("Error! Try Again");
                }
            }
        }

        private void showdoctortodel(object sender, EventArgs e)
        {
            int i = 0;
            int id = int.Parse(Doctor_idtodel.Text);
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from DoctorDetails where Id like '" + id + "%'", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dgvDocDel.DataSource = dt;
            if (Doctor_idtodel.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else if (dgvDocDel.Rows[i].Cells[0].Value == null)
            {
                MessageBox.Show("ID Not Found! Please Try Again");

            }
        }

        private void UpdateDoctor(object sender, EventArgs e)
        {
            int docid = int.Parse(updateId_Doc.Text);
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            cn.Open();
            if (uname.Text != string.Empty && uage.Text != string.Empty && ucontact.Text != string.Empty && uspeciality.Text != null && ufees.Text != string.Empty && uexp.Text != string.Empty && uaddress.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("update  DoctorDetails set Name=@Name,Age=@Age,Contact=@Contact,Speciality=@Speciality,Fees=@Fees,Experience=@Experience,Address=@Address  where Id=('" + docid + "')", cn);
                cmd.Parameters.AddWithValue("Name", uname.Text);
                //cmd.Parameters.AddWithValue("Gender", gender);
                cmd.Parameters.AddWithValue("Age", int.Parse(uage.Text));
                cmd.Parameters.AddWithValue("Contact", ucontact.Text);
                cmd.Parameters.AddWithValue("Speciality", uspeciality.Text);
                cmd.Parameters.AddWithValue("Fees", ufees.Text);
                cmd.Parameters.AddWithValue("Experience", uexp.Text);
                cmd.Parameters.AddWithValue("Address", uaddress.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Details Updated Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter All Fields");
            }
        }

        private void ClearDatadoc(object sender, EventArgs e)
        {
            uname.Text = null;
            uage.Text = null;
            ucontact.Text = null;
            uspeciality.Text = null;
            ufees.Text = null;
            uexp.Text = null;
            uaddress.Text = null;
            updateId_Doc.Text = null;
        }

        private void ShowAllDoctors(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from DoctorDetails", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dgvDoctorData.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(updateId_Doc.Text);
            SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand Comm = new SqlCommand("Select * from DoctorDetails where Id = ('" + id + "')", Conn);
            Conn.Open();
            SqlDataReader dr = Comm.ExecuteReader();
            if (dr.Read())
            {
                uname.Text = dr.GetValue(1).ToString();
                uage.Text = dr.GetValue(3).ToString();
                ucontact.Text = dr.GetValue(4).ToString();
                uspeciality.Text = dr.GetValue(5).ToString();
                ufees.Text = dr.GetValue(6).ToString();
                uexp.Text = dr.GetValue(7).ToString();
                uaddress.Text = dr.GetValue(8).ToString();
            }
            Conn.Close();
        }

        private void docdel_Click(object sender, EventArgs e)
        {
          

            int i = 0;
            if (Doctor_idtodel.Text == "")
            {
                MessageBox.Show("Please Enter The Id First");
            }
            else
            {
                int id2 = int.Parse(Doctor_idtodel.Text);
                SqlConnection sqlc2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
                SqlCommand sqlcom2 = new SqlCommand("Select * from DoctorDetails where Id like '" + id2 + "%'", sqlc2);
                sqlc2.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter(sqlcom2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                sqlc2.Close();
                dgvDocDel.DataSource = dt2;
            }
            
            if (dgvDocDel.Rows[i].Cells[0].Value == null)
            {
                MessageBox.Show("ID Not Found! Please Try Again");

            }

        }

        private void doctor_Load(object sender, EventArgs e)
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
