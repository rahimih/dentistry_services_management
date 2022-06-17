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
    
    public partial class ContractOutCenter_f : Form
    {

     
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        bool status1;
        public ContractOutCenter_f()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {
            DLUtilsobj.ContractoutCenterobj.selectContractoutCenter();
            SqlDataReader DataSource;
            DLUtilsobj.ContractoutCenterobj.Dbconnset(true);
            DataSource = DLUtilsobj.ContractoutCenterobj.ContractoutCenterclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.ContractoutCenterobj.Dbconnset(false);

            if  (radGridView1.RowCount>0)
            { 
            radGridView1.Columns[0].HeaderText = "کد ";
            radGridView1.Columns[1].HeaderText = "نام مرکز";
            radGridView1.Columns[2].HeaderText = "نوع";
            radGridView1.Columns[3].HeaderText = "نوع مرکز";
            radGridView1.Columns[4].HeaderText = "تاریخ شروع قرارداد";
            radGridView1.Columns[5].HeaderText = "تاریخ اتمام قرارداد";
            radGridView1.Columns[6].HeaderText = "وضعیت";
            }
            return true;

        }
        private void ContractOutCenter_f_Load(object sender, EventArgs e)
        {
            dentistryEntitiescontext = new dentistryEntities();
            DLUtilsobj = new DLibraryUtils.DLUtils();

            Department_comboBox.DisplayMember = "departmentDesc";
            Department_comboBox.ValueMember = "OutCenterDepartmentCode";
            Kind_comboBox.DisplayMember = "kindDesc";
            Kind_comboBox.ValueMember = "outcenterKindCode";
            
            Department_comboBox.DataSource = dentistryEntitiescontext.OutCenterdepartments.ToList();
            Kind_comboBox.DataSource = dentistryEntitiescontext.outcenterKinds.ToList();
            

            Kind_comboBox.SelectedIndex = 0;
            Department_comboBox.SelectedIndex = 0;
            status_comboBox.SelectedIndex = 0;
            
            loaddata();

    
          
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == true)
            {
                panel2.Enabled = false;
                edit_Button.Enabled = true;
                Del_Button.Enabled = true;
                Ins_Button.Enabled = true;
                radGridView1.Enabled = true;
                str1 = 0;

                //***************
                name_textBox.Text = "";
                Kind_comboBox.SelectedIndex = 0;
                Department_comboBox.SelectedIndex = 0;
         
                //******************

            }
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.ContractoutCenterobj.deleteContractoutCenter(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 14, Environment.MachineName,a);

                    //***************************
                    loaddata();
                }
            }
        }

        private void Button_Click_2(object sender, EventArgs e)
        {
              if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                name_textBox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {
                //error cheking.................

                if (name_textBox.Text == " ")
                {
                    MessageBox.Show("لطفا نام مرکز را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
                else
                {

                    
                    dateTimePicker1.Value = persianDateTimePicker1.Value;
                    dateTimePicker2.Value = persianDateTimePicker2.Value;

                    if (status_comboBox.SelectedIndex == 0)
                    {
                        status1 = true;
                    }
                    else
                    {
                        status1 = false;
                    }
                   
                    outcenter outcentertable = new outcenter
                    {
                        outcenterName = name_textBox.Text,
                        outcenterKind = byte.Parse(Kind_comboBox.SelectedValue.ToString()),
                        Status = status1,
                        OutCenterdepartment =byte.Parse(Department_comboBox.SelectedValue.ToString()),
                        beginDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                        beginDate_Eng=dateTimePicker1.Value,
                        Enddate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                        Enddate_Eng= dateTimePicker2.Value,
                        usercode = usercodexml,
                        adress = textBox1.Text,
                        phone = textBox2.Text,
                        Comment = textBox3.Text,
                        outcenternamePrint = textBox4.Text

                    };

                    dentistryEntitiescontext.outcenters.Add(outcentertable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 12, Environment.MachineName,0);
                    //***************
                    name_textBox.Text = "";
                    Kind_comboBox.SelectedIndex = 0;
                    Department_comboBox.SelectedIndex = 0;
                    
                  //******************
                    edit_Button.Enabled = true;
                    Del_Button.Enabled = true;
                    panel2.Enabled = false;

                    //******************
                    loaddata();

                    //***************************
                }
       }
      }

        private void Button_Click_3(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Del_Button.Enabled = false;
                Ins_Button.Enabled = false;
                radGridView1.Enabled = false;
                cancel_button.Enabled = true;
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                outcenter outcentertable = dentistryEntitiescontext.outcenters.First(i => i.outcenterCode == a);
                str1 = str1 + 1;

                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    name_textBox.Text = outcentertable.outcenterName;
                    Kind_comboBox.SelectedValue = outcentertable.outcenterKind.Value;
                    Department_comboBox.SelectedValue = outcentertable.OutCenterdepartment.Value;
                    dateTimePicker1.Value = outcentertable.beginDate_Eng.Value;
                    dateTimePicker2.Value = outcentertable.Enddate_Eng.Value;
                    persianDateTimePicker1.Value = dateTimePicker1.Value;
                    persianDateTimePicker2.Value = dateTimePicker2.Value;
                    textBox1.Text = outcentertable.adress;
                    textBox2.Text = outcentertable.phone;
                    textBox3.Text = outcentertable.Comment;
                    textBox4.Text = outcentertable.outcenternamePrint;

                    if (outcentertable.Status == true)
                    {
                        status_comboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        status_comboBox.SelectedIndex = 1;
                    }

                }


                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        if (status_comboBox.SelectedIndex == 0)
                        {
                            status1 = true;
                        }
                        else
                        {
                            status1 = false;
                        }

                        outcentertable.outcenterName = name_textBox.Text;
                        outcentertable.outcenterKind = byte.Parse(Kind_comboBox.SelectedValue.ToString());
                        outcentertable.Status = status1;
                        outcentertable.OutCenterdepartment = byte.Parse(Department_comboBox.SelectedValue.ToString());
                        outcentertable.beginDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                        outcentertable.beginDate_Eng = dateTimePicker1.Value;
                        outcentertable.Enddate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                        outcentertable.Enddate_Eng = persianDateTimePicker2.Value;
                        outcentertable.usercode = usercodexml;
                        outcentertable.adress = textBox1.Text;
                        outcentertable.phone = textBox2.Text;
                        outcentertable.Comment = textBox3.Text;
                        outcentertable.outcenternamePrint = textBox4.Text;

                        dentistryEntitiescontext.SaveChanges();
                        str1 = 0;


                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 13, Environment.MachineName, 0);

                        //***************************
                        loaddata();

                        //***************************
                        //***************
                        name_textBox.Text = "";
                        Kind_comboBox.SelectedIndex = 0;
                        Department_comboBox.SelectedIndex = 0;
                        //******************

                        Del_Button.Enabled = true;
                        Ins_Button.Enabled = true;
                        radGridView1.Enabled = true;
                        cancel_button.Enabled = false;
                    }
                }

            }
        }

        private void ContractOutCenter_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Ins_Button_Click(toolStripMenuItem1, e);
            Button_Click_2(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //edit_Button_Click_1(toolStripMenuItem2, e);
            Button_Click_3(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Del_Button_Click(toolStripMenuItem3, e);
            Button_Click_1(toolStripMenuItem3, e);
            
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void name_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Kind_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void status_comboBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Department_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void name_textBox_Leave(object sender, EventArgs e)
        {
            textBox4.Text = name_textBox.Text;
        }

    }
}
    

