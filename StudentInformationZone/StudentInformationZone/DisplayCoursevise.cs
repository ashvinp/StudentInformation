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
    public partial class DisplayCoursevise : Form
    {
        StudentOp ob = new StudentOp();
        SqlDataReader dr;
        DataSet ds = new DataSet();
            
        public DisplayCoursevise()
        {
            InitializeComponent();
        }

        private void DisplayCoursevise_Load(object sender, EventArgs e)
        {
            ob.connectionOpen();
            dr = ob.displayComboBox("Course");
            while (dr.Read())
            {
                CourseNamesCombo.Items.Add(dr["cname"]);
            }
            ob.connectionClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage fa = new HomePage();
            fa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            ob.connectionOpen();
            ds = ob.displayCourseWise((CourseNamesCombo.SelectedIndex)+1);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "student";
        }
    }
}
