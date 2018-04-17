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
                HrmForm f = new HrmForm();
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
           
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Vendor()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Transaction()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Payment()));

            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Rate()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Account()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Responsible()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Insurance()));

            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Orders()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Instruction()));

            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Deliveries()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Delivery()));

            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new ItemReview()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new PatientStatus()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new Follow()));
            DBConnect.createSQLLiteDB(DBConnect.CreateDBSQL(new ItemStatus()));
        }
    }
}
