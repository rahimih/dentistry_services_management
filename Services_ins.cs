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
    public partial class Services_ins : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        bool ISValidtmp;
        public int services_head;
      
        public Services_ins()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
                    
                //error cheking.................

            if (Services_detail_textbox.Text == " ")
            {
                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }
            else
            {
                if (Isvalid_comboBox.SelectedIndex == 0)
                    ISValidtmp = true;
                else
                    ISValidtmp = false;

                Services_detail Services_detailtable = new Services_detail
            {

                Services_Head_code = int.Parse(Serviceshead_combobox.SelectedValue.ToString()),
                Services_detail_Name = Services_detail_textbox.Text,
                ServicesTime = Convert.ToByte(ServicesTime_numericUpDown.Value),
                K_NO = Convert.ToByte(K_NO_numericUpDown.Value),
                Kkanoon_K_NO = Convert.ToByte(Kkanoon_K_NO_numericUpDown.Value),
                f16_K_NO = Convert.ToByte(f16_K_NO_numericUpDown.Value),
                ServiceTypeF16Code = Convert.ToByte(ServiceTypeF16Code_numericUpDown.Value),
                ServiceTypeKanoonCode = Convert.ToByte(ServiceTypeKanoonCode_numericUpDown.Value),
                TypeScreen_code = Convert.ToByte(TypeScreen_code_numericUpDown.Value),
                Tarefe_code = Convert.ToByte(Tarefe_code_numericUpDown.Value),
                Kanal_NO = Convert.ToByte(Kanal_NO_numericUpDown.Value),
                Pinaj_NO = Convert.ToByte(Pinaj_NO_numericUpDown.Value),
                Pinkanal_NO = Convert.ToByte(Pinkanal_NO_numericUpDown.Value),
                Pinamalgam_NO = Convert.ToByte(Pinamalgam_NO_numericUpDown.Value),
                Pinkampozit_NO = Convert.ToByte(Pinkampozit_NO_numericUpDown.Value),
                ISValid = ISValidtmp,
                deleted= false

            };

                dentistryEntitiescontext.Services_detail.Add(Services_detailtable);
                dentistryEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 23, Environment.MachineName, 0);
                this.Close();
              
            }
    }

        private void Services_ins_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            Serviceshead_combobox.DisplayMember = "Services_Head_name";
            Serviceshead_combobox.ValueMember = "Services_Head_code";
            Serviceshead_combobox.DataSource = dentistryEntitiescontext.Services_Head.ToList();

        }

        private void Serviceshead_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Services_detail_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void K_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Kanal_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }


        private void Pinamalgam_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Pinaj_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Pinkanal_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Pinkampozit_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void f16_K_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Kkanoon_K_NO_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Isvalid_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Tarefe_code_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Services_ins_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F16Grouping_f F16Grouping_frm = new F16Grouping_f();
            F16Grouping_frm.usercodexml = usercodexml;
            F16Grouping_frm.panel3.Visible = false;
            F16Grouping_frm.ShowDialog();
            ServiceTypeF16Code_numericUpDown.Value = F16Grouping_frm.f16value;
            
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click(toolStripMenuItem2, e);
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            kanonGrouping_f kanonGrouping_frm = new kanonGrouping_f();
            kanonGrouping_frm.usercodexml = usercodexml;
            kanonGrouping_frm.panel3.Visible = false;
            kanonGrouping_frm.ShowDialog();
            ServiceTypeKanoonCode_numericUpDown.Value = kanonGrouping_frm.kanonvalue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Screengrouping_f Screengrouping_frm = new Screengrouping_f();
            Screengrouping_frm.usercodexml = usercodexml;
            Screengrouping_frm.panel3.Visible = false;
            Screengrouping_frm.ShowDialog();
            TypeScreen_code_numericUpDown.Value = Screengrouping_frm.Screenvalue;
        }



        private void edit_Button_Click(object sender, EventArgs e)
        {

            if (Services_detail_textbox.Text == " ")

                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);

            else
            {
                if (Isvalid_comboBox.SelectedIndex == 0)
                    ISValidtmp = true;
                else
                    ISValidtmp = false;

                if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Services_detail Services_detailtable = dentistryEntitiescontext.Services_detail.First(i => i.Services_detail_Code == a);

                    Services_detailtable.Services_Head_code = int.Parse(Serviceshead_combobox.SelectedValue.ToString());
                    Services_detailtable.Services_detail_Name = Services_detail_textbox.Text;
                    Services_detailtable.ServicesTime = Convert.ToByte(ServicesTime_numericUpDown.Value);
                    Services_detailtable.K_NO = Convert.ToByte(K_NO_numericUpDown.Value);
                    Services_detailtable.Kkanoon_K_NO = Convert.ToByte(Kkanoon_K_NO_numericUpDown.Value);
                    Services_detailtable.f16_K_NO = Convert.ToByte(f16_K_NO_numericUpDown.Value);
                    Services_detailtable.ServiceTypeF16Code = Convert.ToByte(ServiceTypeF16Code_numericUpDown.Value);
                    Services_detailtable.ServiceTypeKanoonCode = Convert.ToByte(ServiceTypeKanoonCode_numericUpDown.Value);
                    Services_detailtable.TypeScreen_code = Convert.ToByte(TypeScreen_code_numericUpDown.Value);
                    Services_detailtable.Tarefe_code = Convert.ToByte(Tarefe_code_numericUpDown.Value);
                    Services_detailtable.Kanal_NO = Convert.ToByte(Kanal_NO_numericUpDown.Value);
                    Services_detailtable.Pinaj_NO = Convert.ToByte(Pinaj_NO_numericUpDown.Value);
                    Services_detailtable.Pinkanal_NO = Convert.ToByte(Pinkanal_NO_numericUpDown.Value);
                    Services_detailtable.Pinamalgam_NO = Convert.ToByte(Pinamalgam_NO_numericUpDown.Value);
                    Services_detailtable.Pinkampozit_NO = Convert.ToByte(Pinkampozit_NO_numericUpDown.Value);
                    Services_detailtable.ISValid = ISValidtmp;
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 24, Environment.MachineName, a);                 
                    this.Close();
                }
            }

        }

        private void Services_ins_Shown(object sender, EventArgs e)
        {
            if (edit_Button.Enabled==true )
            Serviceshead_combobox.SelectedValue = services_head;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
