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
    public partial class Introduction_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        int turnid;
        public string ipadress;
        public Introduction_F()
        {
            InitializeComponent();
        }
        private bool loaddata_head(string string1, string string2)
        {
            DLUtilsobj.introductionsobj.introduction_Headselect(string1,string2);
            SqlDataReader DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(true);
            DataSource = DLUtilsobj.introductionsobj.introductionsclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(false);


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
                
               
            }

            return true;
        }
    
        public bool loaddata_detail(int introductioncode)
        {
            DLUtilsobj.introductionsobj.selectintroduction_detail(introductioncode);
            SqlDataReader DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(true);
            DataSource = DLUtilsobj.introductionsobj.introductionsclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(false);


            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = " کد ";
                radGridView2.Columns[1].HeaderText = " نام خدمت ";
                radGridView2.Columns[2].HeaderText = " عکس دندان ";
                radGridView2.Columns[3].HeaderText = " عکس دندان ";
                radGridView2.Columns[4].HeaderText = " عکس دندان ";
                radGridView2.Columns[5].HeaderText = " عکس دندان ";
                radGridView2.Columns[6].HeaderText = " عکس دندان ";


            }

            return true;
        }

        private bool loaddata_persno(int persno)
        {
            DLUtilsobj.introductionsobj.introductionsselect_persno(persno);
            SqlDataReader DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(true);
            DataSource = DLUtilsobj.introductionsobj.introductionsclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(false);


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

            return true;
        }

        private void Introduction_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void Introduction_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.introductionsobj.deleteIntroduction(a);
                    DLUtilsobj.introductionsobj.deleteIntroduction_detail(a);
                    DLUtilsobj.introductionsobj.deleteIntroductionComment(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 46, Environment.MachineName, a);

                    //***************************
                    loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                }
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            Introduction_ins_f Introduction_ins_frm = new Introduction_ins_f();
            Introduction_ins_frm.usercodexml = usercodexml;
            Introduction_ins_frm.ipadress = ipadress;
            Introduction_ins_frm.ShowDialog();
             

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radGridView1.RowCount > 0)
            {
                turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                introductionprint introductionprint_frm = new introductionprint();
                introductionprint_frm.introductioncode = turnid;
                introductionprint_frm.ipadress = ipadress;
                introductionprint_frm.ShowDialog();
            }
  
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else

                loaddata_persno(int.Parse(textBox1.Text));
        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
                loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        } 
    }
}
