using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;
using DLibraryUtils;



namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Log_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int kind;
        public int usercodexml;
        DateTime fromdate, todate;
        public Log_View_F()
        {
            InitializeComponent();
        }
        private bool loaddata()
        {
            fromdate = persianDateTimePicker1.Value;
            todate  =  persianDateTimePicker4.Value;
            DLUtilsobj.EventsLogobj.log_view(fromdate.ToShortDateString(),todate.ToShortDateString(), comboBox1.SelectedValue.ToString());
            SqlDataReader DataSource;
            DLUtilsobj.EventsLogobj.Dbconnset(true);
            DataSource = DLUtilsobj.EventsLogobj.EventsLogclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.EventsLogobj.Dbconnset(false);


         /*   if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام پزشک";
                radGridView1.Columns[2].HeaderText = "نوع مرخصی";
                radGridView1.Columns[3].HeaderText = "از تاریخ";
                radGridView1.Columns[4].HeaderText = "تا تاریخ";
                
            }
          */ 

            return true;
        }

        private void vacationsDoctors_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            comboBox1.DisplayMember = "Description";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = dentistryEntitiescontext.Event_report.ToList();
            
           
       
        }

        private void vacationsDoctors_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            kind = comboBox1.SelectedIndex + 1;
            loaddata();
        }

    

    

       }
    }
