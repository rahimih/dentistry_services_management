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
      
       
    public partial class CostConfirmView_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int usercodexml;
        public CostConfirmView_f()
        {
            InitializeComponent();
        }

        public bool loaddata_head(string stratdate,string enddate)
        {
            DLUtilsobj.costconfirmobj.selectCostConfirm_head(stratdate,enddate);
            SqlDataReader DataSource;
            DLUtilsobj.costconfirmobj.Dbconnset(true);
            DataSource = DLUtilsobj.costconfirmobj.CostConfirmclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.costconfirmobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " کد تایید هزینه ";
                radGridView1.Columns[1].HeaderText = " شماره پرسنلی";
                radGridView1.Columns[2].HeaderText = " تاریخ ویزیت";
                radGridView1.Columns[3].HeaderText = "پزشک معالج ";
                radGridView1.Columns[4].HeaderText = " تاریخ تایید";
                radGridView1.Columns[5].HeaderText = " ساعت تایید";
                radGridView1.Columns[6].HeaderText = " پزشک تایید کننده";
    
            }

            return true;
        }

           public bool loaddata_detail(int costconfirmHeadCode)
        {
            DLUtilsobj.costconfirmobj.selectCostConfirm_detail(costconfirmHeadCode);
            SqlDataReader DataSource;
            DLUtilsobj.costconfirmobj.Dbconnset(true);
            DataSource = DLUtilsobj.costconfirmobj.CostConfirmclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.costconfirmobj.Dbconnset(false);


            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = " کد ";
                radGridView2.Columns[1].HeaderText = " نام خدمت ";
                radGridView2.Columns[2].HeaderText = " عکس دندان ";
                

            }

            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            CostConfirm_f CostConfirm_frm = new CostConfirm_f();
            CostConfirm_frm.usercodexml = usercodexml;
            CostConfirm_frm.ShowDialog();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
            if (radGridView1.RowCount > 0)
                loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void CostConfirmView_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
           if (radGridView1.RowCount > 0)
            loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void CostConfirmView_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            
            if (radGridView1.RowCount > 0)
                loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.costconfirmobj.deleteCostConfirm_head(a);
                    DLUtilsobj.costconfirmobj.deleteCostConfirm_detail(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 37, Environment.MachineName, a);

                    //***************************
                    loaddata_head(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    if (radGridView1.RowCount > 0)
                        loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));

                    //***************************
                }
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Button_Click(toolStripMenuItem3, e);
        }
    }
}
