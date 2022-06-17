using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;


namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Search_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        SqlDataReader DataSource;
        string str1, str2, str3;
        public Search_F()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text== "")
                str1 = "1=1";
            else
                str1 = "nationalcode = ''"+ textBox1.Text+ "''";


            if (textBox2.Text== "")
                str2 = "1=1";
            else
                str2 = "fname like ''"+ textBox2.Text + "%''";


            if (textBox3.Text == "")
                str3 = "1=1";
            else
                str3 = "lname like ''" + textBox3.Text + "%''";

            DLUtilsobj.persontblobj.serach(str1+" and "+str2+" and "+str3);
            DLUtilsobj.persontblobj.Dbconnset(true);
            DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.persontblobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[1].HeaderText = "کد ملی";
                radGridView1.Columns[2].HeaderText = "نام ";
                radGridView1.Columns[3].HeaderText = "نام خانوادگی";
                radGridView1.Columns[4].HeaderText = "تاریخ تولد";
                radGridView1.Columns[5].HeaderText = "نسبت";
                radGridView1.Columns[6].HeaderText = "وضعیت";
                radGridView1.Columns[7].HeaderText = "منطقه درمانی";
                

            }


        }

        private void Search_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void Search_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
