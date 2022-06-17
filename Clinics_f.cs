using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Clinics_f : Form
    {
        int str1 = 0;
        public int usercodexml;
        public DLibraryUtils.DLUtils DLUtilsobj;
        public Clinics_f()
        {
            InitializeComponent();
        }

        dentistryEntities database = new dentistryEntities();
        ClinicType currentclinictype = new ClinicType();       
        
        private void Clinics_f_Load(object sender, EventArgs e)
        {


            DLUtilsobj = new DLibraryUtils.DLUtils();
           
           
            ClinicType_combobox.DisplayMember = "ClinictypeName";
            ClinicType_combobox.ValueMember = "ClinicTypecode";
            ClinicType_combobox.DataSource = database.ClinicTypes.ToList();
           
            radGridView1.DataSource = database.Clinics.Where(p => p.deleted == false).ToList();
            radGridView1.Columns[0].HeaderText = "کد کلینیک";
            radGridView1.Columns[1].HeaderText = "نام کلینیک";
            radGridView1.Columns[2].HeaderText = "نام بخش";
            radGridView1.Columns[3].HeaderText = "شماره اطاق";
            radGridView1.Columns[4].IsVisible = false;
            radGridView1.Columns[5].IsVisible = false;
            radGridView1.Columns[6].IsVisible = false;
            radGridView1.Columns[7].IsVisible = false;          
            ClinicType_combobox.SelectedIndex = 0;
            

 
                           
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled==false)
            {
            panel2.Enabled = true;
            cancel_button.Enabled = true;
            Clinicname_textbox.Focus();
            edit_Button.Enabled = false;
            Del_Button.Enabled = false;
             
            }
            else if (panel2.Enabled==true)
            {
                //error cheking.................

                if (Clinicname_textbox.Text.ToString() == "")
                {
                    MessageBox.Show("لطفا نام کلینیک را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
                else {
            
                   
                    Clinic clinictable = new Clinic
                   {
                    ClinicName=Clinicname_textbox.Text,
                    Depatrment=Department_textBox.Text,
                    RoomNO=RoomNO_textbox.Text,
                    ClinicType=byte.Parse(ClinicType_combobox.SelectedValue.ToString()),
                    Comment=Comment_textBox.Text ,
                    deleted= false
                   };

                database.Clinics.Add(clinictable);
                database.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 6, Environment.MachineName,0);
                panel2.Enabled = false;
                cancel_button.Enabled = false;
                edit_Button.Enabled = true;
                Del_Button.Enabled = true;
                Clinicname_textbox.Text="";
                Department_textBox.Text="";
                RoomNO_textbox.Text="";
                Comment_textBox.Text = "";
                ClinicType_combobox.SelectedIndex = 0;
                radGridView1.DataSource = database.Clinics.ToList();
                   }

            }
            
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //if  در planvst تعریف نشده بود قابل حذف می باشد.

                    DLUtilsobj = new DLibraryUtils.DLUtils();
                    if ((DLUtilsobj.planvisitobj.selectclinicinplanvisit("cliniccode", "cliniccode= " + a.ToString())) == false)
                    {
                        DLUtilsobj.clinicsobj.deleteClinic(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 8, Environment.MachineName,a);
                        radGridView1.DataSource = database.Clinics.ToList();
                    }
                    else
                        MessageBox.Show("شما مجاز به حذف این کلینیک نمی باشید", "information", MessageBoxButtons.OK);
                }

            }
        }

      
        private void Clinicname_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Department_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void RoomNO_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ClinicTypeName_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void edit_Button_Click_1(object sender, EventArgs e)
        {

            if (radGridView1.RowCount > 0)
            {

                Del_Button.Enabled = false;
                Ins_Button.Enabled = false;
                radGridView1.Enabled = false;
                cancel_button.Enabled = true;
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                Clinic clinictable = database.Clinics.First(i => i.ClinicCode == a);
                str1 = str1 + 1;

                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    Clinicname_textbox.Text = clinictable.ClinicName;
                    Department_textBox.Text = clinictable.Depatrment;
                    RoomNO_textbox.Text = clinictable.RoomNO;
                    Comment_textBox.Text = clinictable.Comment;
                    ClinicType_combobox.SelectedValue = clinictable.ClinicType.Value;


                }

                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("تغییرات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clinictable.ClinicName = Clinicname_textbox.Text;
                        clinictable.Depatrment = Department_textBox.Text;
                        clinictable.RoomNO = RoomNO_textbox.Text;
                        clinictable.ClinicType = byte.Parse(ClinicType_combobox.SelectedValue.ToString());
                        clinictable.Comment = Comment_textBox.Text;
                        database.SaveChanges();
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 7, Environment.MachineName, a);
                        radGridView1.DataSource = database.Clinics.ToList();

                        Del_Button.Enabled = true;
                        Ins_Button.Enabled = true;
                        radGridView1.Enabled = true;
                        panel2.Enabled = false;
                        cancel_button.Enabled = false;
                        Clinicname_textbox.Text = "";
                        Department_textBox.Text = "";
                        RoomNO_textbox.Text = "";
                        Comment_textBox.Text = "";
                        ClinicType_combobox.SelectedIndex = 0;
                        str1 = 0;
                    }
                }
            }

        }     

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled==true) 
            {
                panel2.Enabled = false;
                edit_Button.Enabled = true;
                Del_Button.Enabled = true;
                Ins_Button.Enabled = true;
                Clinicname_textbox.Text = "";
                Department_textBox.Text = "";
                RoomNO_textbox.Text = "";
                Comment_textBox.Text = "";
                ClinicType_combobox.SelectedIndex = 0;
                radGridView1.Enabled = true;
                str1 = 0;
            }
        }

        private void Clinics_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.Dispose();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click_1(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Del_Button_Click(toolStripMenuItem3, e);
        }

        private void ClinicType_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        


       

     
      

    

 

        

        
    }
}
