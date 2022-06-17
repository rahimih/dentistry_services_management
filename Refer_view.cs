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
    public partial class Refer_view : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress;
        public string user_name;
        int fkvdfamily;
        public Refer_view()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    //---------------
                    DLUtilsobj.usercheckingobj.search_persontbl(textBox1.Text);
                    SqlDataReader DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    radGridView1.DataSource = DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                    if (radGridView1.RowCount > 0)
                    {
                        radGridView1.Columns[0].HeaderText = "شماره پرسنلی";
                        radGridView1.Columns[1].HeaderText = "نام";
                        radGridView1.Columns[2].HeaderText = "نام خانوادگی";
                        radGridView1.Columns[3].HeaderText = "نسبت";
                        radGridView1.Columns[4].HeaderText = " محل کار";
                        radGridView1.Columns[5].IsVisible = false;

                    }
                }
            }
        }

        private void Refer_view_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void radGridView1_1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                //------------------
                DLUtilsobj.screenobj.selectChiefcomplain(fkvdfamily);
                SqlDataReader DataSource2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource2;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView2.RowCount > 0)
                {

                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "تاریخ";
                    radGridView2.Columns[3].HeaderText = "نام پزشک";
                    radGridView2.Columns[0].Width = 20;
                    radGridView2.Columns[1].Width = 50;
                    radGridView2.Columns[2].Width = 150;
                    radGridView2.Columns[3].Width = 80;
                }
                //---------------
                //------------------
                DLUtilsobj.referingobj.search_persontbl_refer(fkvdfamily);
                SqlDataReader DataSource3;
                DLUtilsobj.referingobj.Dbconnset(true);
                DataSource3 = DLUtilsobj.referingobj.referingclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource3;
                DLUtilsobj.referingobj.Dbconnset(false);
                if (radGridView3.RowCount > 0)
                {
                    radGridView3.Columns[0].HeaderText = "ردیف";
                    radGridView3.Columns[1].HeaderText = "تاریخ ارجاع";
                    radGridView3.Columns[2].HeaderText = "ساعت ارجاع";

                }
                //---------------
            }
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            /*if (radGridView3.RowCount > 0)
            {
                MessageBox.Show("شخص انتخابی قبلا ارجاع داده شده است", "information", MessageBoxButtons.OK);
            }

            else
            {*/
                Refer_F Refer_Frm = new Refer_F();
                Refer_Frm.usercodexml = usercodexml;
                Refer_Frm.label18.Text = radGridView1.CurrentRow.Cells[1].Value.ToString() + " " + radGridView1.CurrentRow.Cells[2].Value.ToString();
                Refer_Frm.label23.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
                Refer_Frm.label20.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                Refer_Frm.label19.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                Refer_Frm.label22.Text = persianDateTimePicker4.Value.ToString("yyyy/MM/dd");
                Refer_Frm.label3.Text = user_name;
                Refer_Frm.fkvdfamily = fkvdfamily;
                Refer_Frm.ShowDialog();
                //------------
                //------------------
                DLUtilsobj.referingobj.search_persontbl_refer(fkvdfamily);
                SqlDataReader DataSource3;
                DLUtilsobj.referingobj.Dbconnset(true);
                DataSource3 = DLUtilsobj.referingobj.referingclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource3;
                DLUtilsobj.referingobj.Dbconnset(false);
                if (radGridView3.RowCount > 0)
                {
                    radGridView3.Columns[0].HeaderText = "ردیف";
                    radGridView3.Columns[1].HeaderText = "تاریخ ارجاع";
                    radGridView3.Columns[2].HeaderText = "ساعت ارجاع";

                }
                //---------------
            //}
        }
    }
}
