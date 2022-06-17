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
    public partial class F16Grouping_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        public int f16value = 0;
     
        public F16Grouping_f()
        {
            InitializeComponent();
        }
        private bool loaddata()
        {

            radGridView1.DataSource = dentistryEntitiescontext.ServiceTypeF16.Where(p => p.deleted == false).ToList();
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[1].HeaderText = "نام خدمت";
                radGridView1.Columns[2].HeaderText = " کد فرم F16";
                radGridView1.Columns[3].IsVisible = false;
            }   

            return true;
        }

       
        private void F16Grouping_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            loaddata();     

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
           {
            if (radGridView1.RowCount > 0)
            { 
            f16value = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            }
             this.Close();
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
            Del_Button_Click(toolStripMenuItem3, e);
        }

  
        private void edit_Button_Click(object sender, EventArgs e)
        {

            if (radGridView1.RowCount > 0)
            {
                F16_ins_f F16_ins_frm = new F16_ins_f();
                F16_ins_frm.usercodexml = usercodexml;
                F16_ins_frm.Ins_Button.Enabled = false;
                F16_ins_frm.cancel_button.Enabled = true;
                F16_ins_frm.statusform = 1;

                F16_ins_frm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                ServiceTypeF16 ServiceTypeF16table = dentistryEntitiescontext.ServiceTypeF16.First(i => i.ServiceTypeF16Code == F16_ins_frm.a);

                F16_ins_frm.Services_detail_textbox.Text = ServiceTypeF16table.ServiceTypeF16Name.ToString();
                F16_ins_frm.Code_numericUpDown.Value = ServiceTypeF16table.F16Code.Value;
                F16_ins_frm.Comment_textBox.Text = ServiceTypeF16table.Comment.ToString();


                F16_ins_frm.ShowDialog();

                loaddata();
            }
            
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            F16_ins_f F16_ins_frm = new F16_ins_f();
            F16_ins_frm.usercodexml = usercodexml;
            F16_ins_frm.edit_Button.Enabled = false;
            F16_ins_frm.statusform = 1;
            F16_ins_frm.ShowDialog();
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            //***********************
            //****************  
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Servicesobj.deleteServicestypeF16(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 28, Environment.MachineName, a);
                    loaddata();
                  
                }
            }

        }

        private void F16Grouping_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {

        }
    }
}
