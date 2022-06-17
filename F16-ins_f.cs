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
    public partial class F16_ins_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        public int statusform;

        public F16_ins_f()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            if (Services_detail_textbox.Text == " ")

                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);

            else
            {
                if (statusform == 1)
                {
                    ServiceTypeF16 ServiceTypeF16table = new ServiceTypeF16
                 {
                     ServiceTypeF16Name = Services_detail_textbox.Text,
                     F16Code = Convert.ToInt32(Code_numericUpDown.Value),
                     Comment = Comment_textBox.Text,
                     deleted = false
                 };

                    dentistryEntitiescontext.ServiceTypeF16.Add(ServiceTypeF16table);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 26, Environment.MachineName, 0);
                    this.Close();
                }
                else if (statusform == 2)
                {
                    ServiceTypeKanoon ServiceTypeKanoontable = new ServiceTypeKanoon
                {
                    ServiceTypeKanoonName = Services_detail_textbox.Text,
                    Xmlcode = Convert.ToInt16(Code_numericUpDown.Value),
                    Comment = Comment_textBox.Text
                };

                    dentistryEntitiescontext.ServiceTypeKanoons.Add(ServiceTypeKanoontable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 29, Environment.MachineName, 0);
                    this.Close();
                }

                else if (statusform == 3)
                {
                    ServiceTypeScreen ServiceTypeScreentable = new ServiceTypeScreen
                {
                    ServiceTypeScreenName = Services_detail_textbox.Text,
                    screenCode = Convert.ToInt16(Code_numericUpDown.Value),
                    Comment = Comment_textBox.Text
                };

                    dentistryEntitiescontext.ServiceTypeScreens.Add(ServiceTypeScreentable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 32, Environment.MachineName, 0);
                    this.Close();
                }
            }
        }

        private void F16_ins_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
        }

        private void F16_ins_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
             if (Services_detail_textbox.Text == " ")

                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);

            else
            {
              
                if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (statusform==1)
                    {
                        ServiceTypeF16 ServiceTypeF16table = dentistryEntitiescontext.ServiceTypeF16.First(i => i.ServiceTypeF16Code == a);
                        ServiceTypeF16table.ServiceTypeF16Name = Services_detail_textbox.Text;
                        ServiceTypeF16table.F16Code = Convert.ToInt32(Code_numericUpDown.Value);
                        ServiceTypeF16table.Comment = Comment_textBox.Text;
                        dentistryEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 30, Environment.MachineName, a);                 
                        this.Close();
                    }


                     if (statusform==2)
                    {
                        ServiceTypeKanoon ServiceTypeKanoontable = dentistryEntitiescontext.ServiceTypeKanoons.First(i => i.ServiceTypeKanoonCode == a);
                        ServiceTypeKanoontable.ServiceTypeKanoonName = Services_detail_textbox.Text;
                        ServiceTypeKanoontable.Xmlcode = Convert.ToInt16(Code_numericUpDown.Value);
                        ServiceTypeKanoontable.Comment = Comment_textBox.Text;
                        dentistryEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 33, Environment.MachineName, a);                 
                        this.Close();
                    }

                     if (statusform == 3)
                     {
                         ServiceTypeScreen ServiceTypeScreentable = dentistryEntitiescontext.ServiceTypeScreens.First(i => i.ServiceTypeScreenCode == a);
                         ServiceTypeScreentable.ServiceTypeScreenName = Services_detail_textbox.Text;
                         ServiceTypeScreentable.screenCode = Convert.ToInt16(Code_numericUpDown.Value);
                         ServiceTypeScreentable.Comment = Comment_textBox.Text;
                         dentistryEntitiescontext.SaveChanges();
                         MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                         DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 27, Environment.MachineName, a);
                         this.Close();
                     }
                }    
        }
    }

        private void Services_detail_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Code_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
