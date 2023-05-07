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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register check = new Register();
            check.Show();
            this.Hide();
        }



        private void login_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\HMS.mdf"";Integrated Security=True");

            //  SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf";Integrated Security=True");
            cn.Open();
            string username = usern.Text;
            string password = pass.Text;

            if (username == "Admin" && password == "Admin")
            {
                int id = 1;
               
                SqlCommand cmd = new SqlCommand("update  nnnn set Id=@Id,chuck=@chuck ", cn);
                cmd.Parameters.AddWithValue("Id",id);
                cmd.Parameters.AddWithValue("chuck", id);
                cmd.ExecuteNonQuery();
                Main check = new Main();
                check.Show();
                this.Hide();
            }
            else
            {
                if (pass.Text != string.Empty || usern.Text != string.Empty)
                {

                    SqlCommand cmd = new SqlCommand("select * from LoginDetail where Username='" + username + "' and Password='" + password + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int id = 0;
                        dr.Close();
                        SqlCommand cmd2 = new SqlCommand("update  nnnn set Id=@Id,chuck=@chuck", cn);
                        cmd2.Parameters.AddWithValue("Id", id);
                        cmd2.Parameters.AddWithValue("chuck", id);
                        cmd2.ExecuteNonQuery();
                       
                        Main check = new Main();
                        

                        check.Show();
                        this.Hide();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
    }






/* SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="M:\Basit Project\HospitalManagementSystem\HospitalManagementSystem\HospitalManagementSystem\logindetails.mdf";Integrated Security=True");
 cn.Open();
 if (usern.Text == "Admin" && pass.Text == "Admin")
 {

     SqlCommand cmd = new SqlCommand("select * from LoginTable where Username='" + usern.Text + "'", cn);
     SqlDataReader dr = cmd.ExecuteReader();
     cmd = new SqlCommand("insert into LoginTable values(@Username,@Password,@acces)", cn);
     cmd.Parameters.AddWithValue("Username", "Admin");
     cmd.Parameters.AddWithValue("Password", "Admin");
     cmd.Parameters.AddWithValue("acces",1);
     dr.Close();
     cmd.ExecuteNonQuery();

 }
 else
 {
     if (pass.Text != string.Empty || usern.Text != string.Empty)
     {

         SqlCommand cmd = new SqlCommand("select * from LoginTable where username='" + usern.Text + "' and password='" + pass.Text + "'", cn);
         SqlDataReader dr = cmd.ExecuteReader();
         if (dr.Read())
         {
             dr.Close();
             Main check = new Main();
             check.Show();
             this.Hide();
         }
         else
         {
             dr.Close();
             MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

     }
     else
     {
         MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     }*/


