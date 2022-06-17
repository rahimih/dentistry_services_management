using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class IntroductionServices_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        public int f16value = 0;
        public IntroductionServices_f()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {

            radGridView1.DataSource = dentistryEntitiescontext.ServiceTypeIntroductions.ToList();
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[1].HeaderText = "نام خدمت";
                radGridView1.Columns[2].HeaderText = "وضعیت";
                
            }

            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Introduction_services_F Introduction_services_Frm = new Introduction_services_F();
            Introduction_services_Frm.usercodexml = usercodexml;
            Introduction_services_Frm.edit_Button.Enabled = false;
            Introduction_services_Frm.ShowDialog();
            loaddata();
        }

        private void IntroductionServices_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            loaddata();     
        }

        private void IntroductionServices_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Introduction_services_F Introduction_services_Frm = new Introduction_services_F();
                Introduction_services_Frm.usercodexml = usercodexml;
                Introduction_services_Frm.Ins_Button.Enabled = false;
                Introduction_services_Frm.cancel_button.Enabled = true;


                Introduction_services_Frm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                ServiceTypeIntroduction ServiceTypeIntroductiontable = dentistryEntitiescontext.ServiceTypeIntroductions.First(i => i.ServiceId == Introduction_services_Frm.a);

                Introduction_services_Frm.Services_detail_textbox.Text = ServiceTypeIntroductiontable.Servicename.ToString();
                if (ServiceTypeIntroductiontable.Status.Value == true)
                Introduction_services_Frm.comboBox1.SelectedIndex = 0;
                else
                   Introduction_services_Frm.comboBox1.SelectedIndex = 1;


                    Introduction_services_Frm.ShowDialog();

                loaddata();
            }
        }
    }
}
