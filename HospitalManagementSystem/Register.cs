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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 check = new Form1();
            check.Show();
            this.Hide();
        }

        private void register(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\AU work\Semester 5\VP\LAB\HospitalManagementSystem\HospitalManagementSystem\HMS.mdf"";Integrated Security=True");
            cn.Open();
            if (confirmpassword.Text != string.Empty && password.Text != string.Empty && username.Text != string.Empty)
            {
                if (password.Text == confirmpassword.Text)
                {
                    string user=username.Text;
                    string pass=password.Text;
                    SqlCommand cmd = new SqlCommand("select * from LoginDetail where Username='" + user + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginDetail  values(@Username,@Password,@acces)", cn);
                        cmd.Parameters.AddWithValue("Username", user);
                        cmd.Parameters.AddWithValue("Password", pass);
                        cmd.Parameters.AddWithValue("acces", 0);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        username.Text = null;
                        password.Text = null;
                        confirmpassword.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            password.UseSystemPasswordChar = false;
            confirmpassword.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
            confirmpassword.UseSystemPasswordChar = true;
        }
    }
}
