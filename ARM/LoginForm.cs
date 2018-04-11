using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        public LoginForm()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (medicalChk.Checked)
            {

                MedicalForm frm = new MedicalForm();
                frm.Show();
            }
            if (payrollChk.Checked)
            {
                HomeForm f = new HomeForm();
                f.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            createSqlliteDB();
        }
        private void createSqlliteDB()
        {
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Customer()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Exceptions()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Users()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Item()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Vendor()));
        }
    }
}
