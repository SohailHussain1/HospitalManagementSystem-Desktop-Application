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
    public partial class Main : Form
    {
        public string access { get; private set; }

        public Main()
        {
            InitializeComponent();
           
        }

        public Main(string text)
        {
            Text = text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Employee(object sender, EventArgs e)
        {
          
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            room check = new room();
            check.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            doctor check = new doctor();
            check.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            //dr.Close();
            employee check = new employee();
            check.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            patient check = new patient();
            check.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form1 check = new Form1();
            check.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void InfoHims(object sender, EventArgs e)
        {
            info hims = new info();
            hims.Show();
            this.Hide();
        }
    }
}
