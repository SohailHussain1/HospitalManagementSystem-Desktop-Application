using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalManagementSystem
{
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
            Idno.Visible = false;
            name.Visible = false;
            gender.Visible = false;
            age.Visible = false;
            contact.Visible = false;
            disease.Visible = false;
            roomno.Visible = false;
            roomtype.Visible = false;
            datein.Visible = false;
            dateout.Visible = false;
            roomcharges.Visible = false;
            doctorfees.Visible = false;
            totalbill.Visible = false;
            panelbill.Visible = false;
        }

        private void patient_Load(object sender, EventArgs e)
        {

        }

    



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Main check = new Main();
            check.Show();
            this.Hide();
        }
      
       
        

        private void button1_Click_1(object sender, EventArgs e)
        {
             SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            cn.Open();
            string gender = "";
            if (pMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (pname.Text != string.Empty && pAge.Text != string.Empty && pContact.Text != string.Empty && pDisease.Text != string.Empty && pAddress.Text != string.Empty && pRoom.Text != string.Empty && (pMale.Checked || pFemale.Checked) && dateTimePicker1.Value != null)
            {
                int rcheck = Convert.ToInt32(pRoom.Value);
                int k= 1;
                string speccheck = comboBox1.Text;

                SqlCommand roomcheck = new SqlCommand("select * from RoomDetails where id='" + rcheck + "' AND Vacant='" + k + "'", cn);
                roomcheck.ExecuteNonQuery();

               /* SqlCommand vaccheck = new SqlCommand("select * from RoomDetails where Vacant='" + 1 + "'", cn);
                vaccheck.ExecuteNonQuery();*/

                SqlCommand speciacheck = new SqlCommand("select * from DoctorDetails where Speciality='" + speccheck + "' AND Free='" + k + "'", cn);
                speciacheck.ExecuteNonQuery();
/*
                SqlCommand freecheck = new SqlCommand("select * from DoctorDetails where Free='" + 1 + "'", cn);
                freecheck.ExecuteNonQuery();
*/
               
               // SqlDataReader DR2 = vaccheck.ExecuteReader();
                    
                SqlDataReader DR1 = roomcheck.ExecuteReader();
                SqlDataReader DR3 = speciacheck.ExecuteReader();
                //SqlDataReader DR4 = freecheck.ExecuteReader();
                if (DR1.Read() &&DR3.Read() )
                {
                    pRoomtype.Text = DR1.GetValue(1).ToString();
                    pRoomprice.Text = DR1.GetValue(2).ToString();
                    textBox1.Text = DR3.GetValue(0).ToString();

                    SqlCommand rommvac = new SqlCommand("update  RoomDetails set Vacant=@Vacant where id='" + rcheck + "'", cn);
                    rommvac.Parameters.AddWithValue("Vacant", 0);
                    rommvac.ExecuteNonQuery();

                    SqlCommand docfree = new SqlCommand("update  DoctorDetails set Free=@Free where id='" + int.Parse(textBox1.Text) + "'", cn);
                    docfree.Parameters.AddWithValue("Free", 0);
                    docfree.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("insert into PatientReg values(@Date,@Name,@Gender,@Age,@Contact,@Disease,@Address,@RoomNo,@DoctorId)", cn);
                    cmd.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("Name", pname.Text);
                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters.AddWithValue("Age", int.Parse(pAge.Text));
                    cmd.Parameters.AddWithValue("Contact", pContact.Text);
                    cmd.Parameters.AddWithValue("Disease", pDisease.Text);
                    cmd.Parameters.AddWithValue("Address", pAddress.Text);
                    cmd.Parameters.AddWithValue("RoomNo", int.Parse(pRoom.Text));
                    cmd.Parameters.AddWithValue("DoctorId", int.Parse(textBox1.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient Registered Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    MessageBox.Show("No Room found Or Not Avaiable .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cn.Close();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

             
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = null;
            pname.Text = null;
            pMale.Checked = false;
            pFemale.Checked = false;
            pAge.Text = null;
            pContact.Text = null;
            pDisease.Text = null;
            pAddress.Text = null;
            pRoom.Text = null;
        }

       

        private void SpecificPatient_Click(object sender, EventArgs e)
        {
            if (updatePatient.TextLength==0)
            {
                MessageBox.Show("Please Enter the ID First");
            }
            else
            {
                int Id = int.Parse(updatePatient.Text);
                SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
                SqlCommand sqlcom = new SqlCommand("Select * from PatientReg where Id = ('" + Id + "')", sqlc);
                sqlc.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlc.Close();
                DgvPatientData.DataSource = dt;
            }
        }

        private void ShowAllPatients_Click(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from PatientReg", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            DgvPatientData.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DgvPatientData.DataSource = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");

            string speccheck = comboBox1.Text;
            cn.Open();
            SqlCommand speciacheck = new SqlCommand("select * from DoctorDetails where Speciality='" + speccheck + "'", cn);
            SqlDataReader DR3 = speciacheck.ExecuteReader();
            if(DR3.Read())
            {
                textBox1.Text = DR3.GetValue(0).ToString();
            }
            else
            {
                textBox1.Text =null;
            }
            cn.Close();
        }

 

    

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True");
            
            int rcheck = Convert.ToInt32(pRoom.Value);
            cn.Open();
            SqlCommand roomcheck = new SqlCommand("select * from RoomDetails where id='" + rcheck + "'", cn);
            SqlDataReader DR3 = roomcheck.ExecuteReader();
            if (DR3.Read())
            {
                pRoomtype.Text = DR3.GetValue(1).ToString();
                pRoomprice.Text = DR3.GetValue(2).ToString();
            }
            else
            {
                pRoomtype.Text = null;
                pRoomprice.Text = null;
            }

            cn.Close();

        }
        private void PrintBill_Click(object sender, EventArgs e)
        {

            string id = pidBill.Text;
            SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;");
            SqlCommand Comm = new SqlCommand("Select * from PatientReg where ID = ('" + id + "')", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm.ExecuteReader();
            if (DR1.Read())
            {
                panelbill.Visible = true;
                Idno.Visible = true;
                name.Visible = true;
                gender.Visible = true;
                age.Visible = true;
                contact.Visible = true;
                disease.Visible = true;
                roomno.Visible = true;
                roomtype.Visible = true;
                datein.Visible = true;
                dateout.Visible = true;
                roomcharges.Visible = true;
                doctorfees.Visible = true;
                totalbill.Visible = true;
                Idno.Text = DR1.GetValue(0).ToString();
                datein.Text = DR1.GetValue(1).ToString();
                name.Text = DR1.GetValue(2).ToString();
                gender.Text = DR1.GetValue(3).ToString();
                age.Text = DR1.GetValue(4).ToString();
                contact.Text = DR1.GetValue(5).ToString();
                disease.Text = DR1.GetValue(6).ToString();
                roomno.Text = DR1.GetValue(8).ToString();
                int id2 = int.Parse(roomno.Text);

                dateout.Text = DateTime.Now.ToString();
                contact.Text = DR1.GetValue(5).ToString();
                SqlCommand Comm2 = new SqlCommand("Select * from RoomDetails where Id = ('" + id2 + "')", Conn);

                SqlDataReader DR2 = Comm2.ExecuteReader();
                int rprice = 0, dcharges = 0;
                if (DR2.Read())
                {
                    roomtype.Text = DR2.GetValue(1).ToString();
                    roomcharges.Text = DR2.GetValue(2).ToString();
                    rprice = int.Parse(DR2.GetValue(2).ToString());
                }
                int id3 = int.Parse(DR1.GetValue(9).ToString());
                SqlCommand Comm3 = new SqlCommand("Select * from DoctorDetails where Id = ('" + id3 + "')", Conn);

                SqlDataReader DR3 = Comm3.ExecuteReader();

                if (DR3.Read())
                {
                    doctorfees.Text = DR3.GetValue(6).ToString();
                    dcharges = int.Parse(DR3.GetValue(6).ToString());
                }
                totalbill.Text = (rprice + dcharges).ToString();
            }
            else
            {
                MessageBox.Show("No Patient Found");
            }
            Conn.Close();
        }
        private void PayBIllCheckout(object sender, EventArgs e)
        {
            int id3=0;
            int id = int.Parse(pidBill.Text);
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf"";Integrated Security=True;MultipleActiveResultSets=True;";
            SqlConnection sqlc = new SqlConnection(con);
            string query = "Delete from PatientReg where Id = ('" + id + "')";
            SqlCommand sqlcom = new SqlCommand(query, sqlc);
            sqlc.Open();

            int id2 = int.Parse(roomno.Text);
            SqlCommand Comm = new SqlCommand("Select * from PatientReg where ID = ('" + id + "')", sqlc);
            SqlDataReader DR1 = Comm.ExecuteReader();
            if (DR1.Read())
            {
                id3 = int.Parse(DR1.GetValue(9).ToString());
            }
            int n = sqlcom.ExecuteNonQuery();
            if (n > 0)
            {
                SqlCommand rommvac = new SqlCommand("update  RoomDetails set Vacant=@Vacant where id='" + id2 + "'", sqlc);
                rommvac.Parameters.AddWithValue("Vacant", 1);
                rommvac.ExecuteNonQuery();

                SqlCommand docfree = new SqlCommand("update  DoctorDetails set Free=@Free where id='" + id3 + "'", sqlc);
                docfree.Parameters.AddWithValue("Free", 1);
                docfree.ExecuteNonQuery();
                panelbill.Visible = false;
                MessageBox.Show("Patient Discharged Successfully! ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

         
        }
    }
}
