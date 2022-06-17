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
    public partial class ReferOutView_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        int turnid;
        public string ipadress;
        int persnoo;
        byte clinickind = 1;
        public ReferOutView_F()
        {
            InitializeComponent();
        }
        private bool loaddata()
        {            
            DLUtilsobj.referingobj.Referoutsearch(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), persnoo, clinickind);            
            SqlDataReader DataSource;
            DLUtilsobj.referingobj.Dbconnset(true);
            DataSource = DLUtilsobj.referingobj.referingclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.referingobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = "شناسه پزشکی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = "نسبت";
                radGridView1.Columns[5].HeaderText = " محل کار";
                radGridView1.Columns[6].HeaderText = " تاریخ ارجاع";                
                radGridView1.Columns[7].HeaderText = " پزشک ارجاع دهنده";
                radGridView1.Columns[8].HeaderText = " تشخیص اولیه";
                radGridView1.Columns[9].HeaderText = "علت ارجاع";                
               
            }

            return true;
        }
    
  
    

        private void Introduction_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            
        }

        private void Introduction_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            //Referoutsearch(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"),0,1);            
            persnoo = 0;
            clinickind = 1;
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.referingobj.deletereferout(turnid);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 65, Environment.MachineName, turnid);

                    //***************************
                    loaddata();

                      }
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            ReferOut_F ReferOut_Frm = new ReferOut_F();
            ReferOut_Frm.referoutcode = turnid;
            ReferOut_Frm.ipadressp = ipadress;
            ReferOut_Frm.ShowDialog();
             

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radGridView1.RowCount > 0)
            {
                turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                ReferOut_printview_F ReferOut_printview_Frm = new ReferOut_printview_F();
                ReferOut_printview_Frm.referoutcode = turnid;
                ReferOut_printview_Frm.ipadress = ipadress;
                ReferOut_printview_Frm.ShowDialog();
              
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
            {
                clinickind = 2;
                persnoo = int.Parse(textBox1.Text);
                loaddata();
            }
        }

   
    }
}
