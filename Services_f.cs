using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Services_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        public Services_f()
        {
            InitializeComponent();
        }

        public  bool loaddata()
        {
            DLUtilsobj.Servicesobj.selectServices();
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[1].HeaderText = "نام گروه";
                radGridView1.Columns[2].HeaderText = "نام خدمت";
                radGridView1.Columns[3].HeaderText = "تعداد K";
                radGridView1.Columns[4].HeaderText = "تعداد کانال";
                radGridView1.Columns[5].HeaderText = "تعداد پین عاج ";
                radGridView1.Columns[6].HeaderText = "تعداد پین کانال ";
                radGridView1.Columns[7].HeaderText = " تعداد پین آمالگام";
                radGridView1.Columns[8].HeaderText = " تعداد پین کامپوزیت";
                radGridView1.Columns[9].HeaderText = "وضعیت";

            }

            return true;
        }

        private void Services_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            loaddata();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Services_ins Services_insfrm = new Services_ins();
            Services_insfrm.usercodexml = usercodexml;
            Services_insfrm.edit_Button.Enabled = false;
            Services_insfrm.ShowDialog();
            loaddata();
        }

        private void Services_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
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
            Del_Button_Click(toolStripMenuItem3, e);
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            //****************  
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Servicesobj.deleteServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 25, Environment.MachineName, a);
                    loaddata();
                }
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Services_ins Services_insfrm = new Services_ins();
                Services_insfrm.usercodexml = usercodexml;
                Services_insfrm.Ins_Button.Enabled = false;
                Services_insfrm.cancel_button.Enabled = true;


                Services_insfrm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                Services_detail Services_detailtable = dentistryEntitiescontext.Services_detail.First(i => i.Services_detail_Code == Services_insfrm.a);

                Services_insfrm.services_head = Services_detailtable.Services_Head_code.Value;
                Services_insfrm.Services_detail_textbox.Text = Services_detailtable.Services_detail_Name.ToString();
                Services_insfrm.ServicesTime_numericUpDown.Value = Services_detailtable.ServicesTime.Value;
                Services_insfrm.K_NO_numericUpDown.Value = Convert.ToDecimal(Services_detailtable.K_NO.Value);
                Services_insfrm.Kkanoon_K_NO_numericUpDown.Value = Convert.ToDecimal(Services_detailtable.Kkanoon_K_NO.Value);
                Services_insfrm.f16_K_NO_numericUpDown.Value = Convert.ToDecimal(Services_detailtable.f16_K_NO.Value);
                Services_insfrm.ServiceTypeF16Code_numericUpDown.Value = Services_detailtable.ServiceTypeF16Code.Value;
                Services_insfrm.ServiceTypeKanoonCode_numericUpDown.Value = Services_detailtable.ServiceTypeKanoonCode.Value;
                Services_insfrm.TypeScreen_code_numericUpDown.Value = Services_detailtable.TypeScreen_code.Value;
                Services_insfrm.Tarefe_code_numericUpDown.Value = Services_detailtable.Tarefe_code.Value;
                Services_insfrm.Kanal_NO_numericUpDown.Value = Services_detailtable.Kanal_NO.Value;
                Services_insfrm.Pinaj_NO_numericUpDown.Value = Services_detailtable.Pinaj_NO.Value;
                Services_insfrm.Pinkanal_NO_numericUpDown.Value = Services_detailtable.Pinkanal_NO.Value;
                Services_insfrm.Pinamalgam_NO_numericUpDown.Value = Services_detailtable.Pinamalgam_NO.Value;
                Services_insfrm.Pinkampozit_NO_numericUpDown.Value = Services_detailtable.Pinkampozit_NO.Value;
                if (Services_detailtable.ISValid == true)
                    Services_insfrm.Isvalid_comboBox.SelectedIndex = 0;
                else
                    Services_insfrm.Isvalid_comboBox.SelectedIndex = 1;


                Services_insfrm.ShowDialog();

                loaddata();
            }

        } 
    }
}
