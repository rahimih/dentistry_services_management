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
    public partial class Reporting_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int usercodexml;
        

        public Reporting_F()
        {
            InitializeComponent();
        }

        private bool loaddata(string string1, string string2)
        {
            DLUtilsobj.recipeobj.DoctorsCountPaient(string1, string2);
            SqlDataReader DataSource;
            DLUtilsobj.recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.recipeobj.Recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.recipeobj.Dbconnset(false);


            /*
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = "شناسه پزشکی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = "نسبت";
                radGridView1.Columns[5].HeaderText = "وضعیت بیمار";
                radGridView1.Columns[6].HeaderText = "نام مرکز";
                radGridView1.Columns[7].HeaderText = " نوع مرکز";
                radGridView1.Columns[8].HeaderText = " پزشک ارجاع دهنده";
                radGridView1.Columns[9].HeaderText = " تاریخ صدور معرفی نامه";
                radGridView1.Columns[10].HeaderText = "  ساعت صدور معرفی نامه";
                radGridView1.Columns[11].HeaderText = "  دندان";

            }
            */
            return true;
              
        }
        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void Reporting_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void Reporting_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();

            dialog.Document = this.radPrintDocument1;
            radPrintDocument1.MiddleHeader = "لیست تعداد نوبت پزشکان از تاریخ" + persianDateTimePicker2.Value.ToString("yyyy/MM/dd") + "  تا تاریخ " + persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog(); 
        }
    }
}
