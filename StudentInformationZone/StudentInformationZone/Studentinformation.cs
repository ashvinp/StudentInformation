using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentInformationZone
{
    public partial class Studentinformation : Form
    {
        StudentOp ob = new StudentOp();
        SqlDataReader dr ;

        public Studentinformation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Studentinformation_Load(object sender, EventArgs e)
        {
            ob.connectionOpen();
            dr=ob.displayComboBox("Course");
            while (dr.Read()) 
            {
                CourseNamesCombo.Items.Add(dr["cname"]);
            }
            ob.connectionClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ob.connectionOpen();
            ob.insertStudent(usn.Text.ToString(), name.Text.ToString(), addr.Text.ToString(), (CourseNamesCombo.SelectedIndex)+1, int.Parse(yearofadnm.Text.ToString()));
            ob.connectionClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage fa = new HomePage();
            fa.Show();
            this.Hide();
        }
    }
}
