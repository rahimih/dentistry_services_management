using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;


namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Services_Group_report_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;        
        public int usercodexml;        
        public string ipadress;
        SqlDataReader DataSource_h;
        
        
        public Services_Group_report_view_F()
        {
            InitializeComponent();
        }


        private bool loaddata_head()
        {
            DLUtilsobj.Servicesobj.Services_Group_view_h();
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "گروه خدمت";
              

            }

            return true;
        }

        public bool loaddata_detail(int Services_Group_code)
        {
            DLUtilsobj.Servicesobj.Services_Group_view_d(Services_Group_code);
            //SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource_h = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource_h;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = " کد ";
                radGridView2.Columns[1].HeaderText = " نام خدمت ";
               

            }

            return true;
        }

  

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_Group_report_F Services_Group_report_Frm = new Services_Group_report_F();
            Services_Group_report_Frm.ShowDialog();
        }

        private void Services_Group_report_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
           
            loaddata_head();
        }

        private void Services_Group_report_view_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
                loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Servicesobj.deleteServices_Group_report(a);
                    loaddata_head();
                }
            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_Group_report_F Services_Group_report_Frm = new Services_Group_report_F();



            Services_Group_report_Frm.Ins_Button.Visible = false;
            Services_Group_report_Frm.Edit_button.Visible = true;
            Services_Group_report_Frm.ShowDialog();
        }

      

     
       

    }
}
