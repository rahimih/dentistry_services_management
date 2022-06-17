using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Introduction_services_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        bool tempstatus;
        public Introduction_services_F()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                tempstatus = true;
            else
                tempstatus = false;


            if (Services_detail_textbox.Text == " ")

                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);

            else
            {

                ServiceTypeIntroduction ServiceTypeIntroductiontable = new ServiceTypeIntroduction
                    {
                        Servicename = Services_detail_textbox.Text,
                        Status = tempstatus
                    };

                dentistryEntitiescontext.ServiceTypeIntroductions.Add(ServiceTypeIntroductiontable);
                dentistryEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 44, Environment.MachineName, 0);
                this.Close();

            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
                if (Services_detail_textbox.Text == " ")

                MessageBox.Show("لطفا نام خدمت  را وارد نمائید", "خطا", MessageBoxButtons.OK);

            else
            {
              
                if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                  
                        ServiceTypeIntroduction ServiceTypeIntroductiontable = dentistryEntitiescontext.ServiceTypeIntroductions.First(i => i.ServiceId == a);
                        ServiceTypeIntroductiontable.Servicename = Services_detail_textbox.Text;
                        if (comboBox1.SelectedIndex==0)
                            ServiceTypeIntroductiontable.Status= true;
                        else
                            ServiceTypeIntroductiontable.Status = false;
                        dentistryEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 45, Environment.MachineName, a);                 
                        this.Close();
                }
    }
}

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Introduction_services_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            comboBox1.SelectedIndex = 0;
        }

        private void Introduction_services_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

    }

}