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
    class StudentOp
    {
        SqlConnection conn;
        SqlCommand cmd,cmd2;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        
        public void connectionOpen() {
            conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"c:\\users\\anil\\documents\\visual studio 2010\\Projects\\StudentInformationZone\\StudentInformationZone\\Database1.mdf\";Integrated Security=True;User Instance=True");
            conn.Open();
        }
        
        public void connectionClose() {
            conn.Close();
        }
        
        public void insertCourse(String name) {
            cmd = new SqlCommand("insert into Course values('"+name+"') ",conn);
            cmd.ExecuteNonQuery();
        }
        
        public void insertStudent(String usn,String name,String address,int cid,int yearofadmn)
        {
            cmd2 = new SqlCommand("insert into student values('" + usn + "','" + name + "','" + address + "',"+cid+","+yearofadmn+") ", conn);
            cmd2.ExecuteNonQuery();
        }

        public SqlDataReader displayComboBox(String TableName) {
            cmd = new SqlCommand("select * from " + TableName , conn);
            dr = cmd.ExecuteReader();
            return dr;
        }
        
        public DataSet displayCourseWise(int selectedCid) 
        {
            ds = new DataSet();
            da = new SqlDataAdapter("select * from student where cid="+selectedCid, conn);
            da.Fill(ds, "student");
            return ds;
        }
        public DataSet diplayYearWise(int admtnYear) {
            ds = new DataSet();
            da = new SqlDataAdapter("select * from student where yearofpassing=" + admtnYear, conn);
            da.Fill(ds, "student");
            return ds;
        }
    }
}
