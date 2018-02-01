using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationZone
{
    public partial class DisplayYearWise : Form
    {
        StudentOp ob = new StudentOp();
        DataSet ds = new DataSet();

        public DisplayYearWise()
        {
            InitializeComponent();
        }

        private void DisplayYearWise_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            ds = ob.diplayYearWise(int.Parse(enteredYear.Text));
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "student";
        }
    }
}
