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
    public partial class KFactor_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public  int usercodexml;
        int Kindjobpaient_managment_tmp;
        int Kindjobpaient_company_tmp;
        int Kindpaient_tmp;
        public KFactor_f()
        {
            InitializeComponent();
        }
        private bool loaddata()
        {
            DLUtilsobj.tariffsobj.selecttariffs(Convert.ToInt16(numericUpDown1.Value));
            SqlDataReader DataSource;
            DLUtilsobj.tariffsobj.Dbconnset(true);
            DataSource = DLUtilsobj.tariffsobj.tariffsclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.tariffsobj.Dbconnset(false);
            

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = " نوع تعرفه";
                radGridView1.Columns[2].HeaderText = "تاریخ شروع تعرفه";
                radGridView1.Columns[3].HeaderText = "تاریخ پایان تعرفه";
                radGridView1.Columns[4].HeaderText = "ضریب k";
                radGridView1.Columns[5].HeaderText = "نوع بیمار ";
                radGridView1.Columns[6].HeaderText = "محل کار بیمار";
                radGridView1.Columns[7].HeaderText = " سال ";
                radGridView1.Columns[8].HeaderText = " فرانشیز ";
            }

            return true;
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == true)
            {
                panel2.Enabled = false;
                edit_Button.Enabled = true;
                Del_Button.Enabled = true;
                Ins_Button.Enabled = true;
                radGridView1.Enabled = true;
                str1 = 0;

            }

        }

        private void KFactor_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "id";
            managment_combobox.DataSource = dentistryEntitiescontext.TblManagements.Where(p => p.Description != null).ToList();
        

            Tariffkind_comboBox.SelectedIndex = 0;
            Kindpaient_comboBox.SelectedIndex = 0;
            managment_combobox.SelectedIndex = 0;
            managment_combobox.SelectedValue = 0;
            numericUpDown1.Value = persianDateTimePicker1.Value.Year;

            loaddata();
    
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
                 
  
               
            if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                Tariffkind_comboBox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {

                if (checkBox1.Checked == true)
                {
                    Kindjobpaient_managment_tmp = -1;
                    Kindjobpaient_company_tmp = -1;
                }

                else
                {
                    Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());
                    Kindjobpaient_company_tmp = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                }

                if (Kindpaient_comboBox.SelectedIndex == 0)
                {
                    Kindpaient_tmp = -1;
                }
                else
                    Kindpaient_tmp = int.Parse(Kindpaientcode_comboBox.Text);
                    Kindpaientcode_comboBox.SelectedIndex = Kindpaient_comboBox.SelectedIndex;
                    TariffBegindate_dateTimePicker.Value = TariffBegindate_persianDateTimePicker.Value;
                    Tariffenddate_dateTimePicker.Value = Tariffenddate_persianDateTimePicker.Value;

            //error cheking.................
                if (Tariffkind_comboBox.Text=="" )
                {
                    MessageBox.Show("لطفا نام تعرفه را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
               
                else if (int.Parse(maskedTextBox2.Text)==0)
                {
                    MessageBox.Show("لطفا ضریب تعرفه را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
                else
                {

                      tariff tarifftable = new tariff
                    {
                        Tariffkind=Tariffkind_comboBox.Text,
                        TariffBegindate =TariffBegindate_persianDateTimePicker.Value.ToString("yyyy/MM/dd"),
                        Tariffenddate = Tariffenddate_persianDateTimePicker.Value.ToString("yyyy/MM/dd"),
                        Zarib=int.Parse(maskedTextBox2.Text),
                        Kindpaient = Kindpaient_tmp,
                        Kindjobpaient_managment = Kindjobpaient_managment_tmp,
                        Kindjobpaient_company = Kindjobpaient_company_tmp,
                        TariffBegindate_Eng= TariffBegindate_dateTimePicker.Value,
                        Tariffenddate_Eng = Tariffenddate_dateTimePicker.Value,
                        year = TariffBegindate_persianDateTimePicker.Value.Year,
                        Tariffkind_int = Tariffkind_comboBox.SelectedIndex , 
                        Feranshiz = int.Parse(numericUpDown2.Value.ToString())
                        
                     };

                      dentistryEntitiescontext.tariffs.Add(tarifftable);
                      dentistryEntitiescontext.SaveChanges();
                      MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                      DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, 0);
                      edit_Button.Enabled = true;
                      Del_Button.Enabled = true;
                      panel2.Enabled = false;

                      //***************************
                      loaddata();

                    //***************************

                }

            }

        }

        private void Tariffkind_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

        private void Kindpaient_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

        private void TariffBegindate_persianDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

        private void Tariffenddate_persianDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

        private void Zarib_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

    

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked== true)
            {
                managment_combobox.Enabled = false;
                Kindjobpaient_comboBox.Enabled = false;

            }
            else
            {
                Kindjobpaient_comboBox.Enabled = true;
                managment_combobox.Enabled = true;
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Del_Button.Enabled = false;
                Ins_Button.Enabled = false;
                radGridView1.Enabled = false;
                cancel_button.Enabled = true;
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                tariff tarifftable = dentistryEntitiescontext.tariffs.First(i => i.Tariffcode == a);
                str1 = str1 + 1;


                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    Tariffkind_comboBox.SelectedIndex = tarifftable.Tariffkind_int.Value; //Tariffkind_comboBox.FindString(tarifftable.Tariffkind.ToString());                   
                    Kindpaientcode_comboBox.SelectedIndex = Kindpaientcode_comboBox.FindString(tarifftable.Kindpaient.ToString());
                    Kindpaient_comboBox.SelectedIndex = Kindpaientcode_comboBox.SelectedIndex;
                    TariffBegindate_dateTimePicker.Value = tarifftable.TariffBegindate_Eng.Value;
                    TariffBegindate_persianDateTimePicker.Value = TariffBegindate_dateTimePicker.Value;
                    Tariffenddate_dateTimePicker.Value = tarifftable.Tariffenddate_Eng.Value;
                    Tariffenddate_persianDateTimePicker.Value = Tariffenddate_dateTimePicker.Value;
                    maskedTextBox2.Text = tarifftable.Zarib.ToString();
                    if (tarifftable.Kindjobpaient_managment == -1)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {

                        managment_combobox.Enabled = true;
                        Kindjobpaient_comboBox.Enabled = true;
                        checkBox1.Checked = false;


                        managment_combobox.SelectedValue = tarifftable.Kindjobpaient_managment.Value;

                        Kindjobpaient_managment_tmp = tarifftable.Kindjobpaient_managment.Value;


                        Kindjobpaient_comboBox.DisplayMember = "Description";
                        Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
                        Kindjobpaient_comboBox.DataSource = dentistryEntitiescontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();

                        Kindjobpaient_comboBox.SelectedValue = tarifftable.Kindjobpaient_company.Value;


                    }
                }


                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        if (checkBox1.Checked == true)
                        {
                            Kindjobpaient_managment_tmp = -1;
                            Kindjobpaient_company_tmp = -1;
                        }

                        else
                        {
                            Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());
                            Kindjobpaient_company_tmp = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                        }

                        if (Kindpaient_comboBox.SelectedIndex == 0)
                        {
                            Kindpaient_tmp = -1;
                        }
                        else
                            Kindpaient_tmp = int.Parse(Kindpaientcode_comboBox.Text);


                        tarifftable.Tariffkind = Tariffkind_comboBox.Text;
                        tarifftable.TariffBegindate = TariffBegindate_persianDateTimePicker.Value.ToString("yyyy/MM/dd");
                        tarifftable.Tariffenddate = Tariffenddate_persianDateTimePicker.Value.ToString("yyyy/MM/dd");
                        tarifftable.Zarib = int.Parse(maskedTextBox2.Text);
                        tarifftable.Kindpaient = Kindpaient_tmp;
                        tarifftable.Kindjobpaient_managment = Kindjobpaient_managment_tmp;
                        tarifftable.Kindjobpaient_company = Kindjobpaient_company_tmp;
                        tarifftable.TariffBegindate_Eng = TariffBegindate_dateTimePicker.Value;
                        tarifftable.Tariffenddate_Eng = Tariffenddate_dateTimePicker.Value;
                        tarifftable.year = TariffBegindate_persianDateTimePicker.Value.Year;
                        tarifftable.Tariffkind_int = Tariffkind_comboBox.SelectedIndex;
                        tarifftable.Feranshiz = int.Parse(numericUpDown2.Value.ToString());
                        dentistryEntitiescontext.SaveChanges();
                        str1 = 0;

                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 10, Environment.MachineName, a);

                        //***************************
                        loaddata();

                        //***************************

                        Del_Button.Enabled = true;
                        Ins_Button.Enabled = true;
                        radGridView1.Enabled = true;
                        cancel_button.Enabled = false;
                        panel2.Enabled = false;
                    }
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

                    DLUtilsobj.tariffsobj.deletetariffs(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 11, Environment.MachineName, a);

                    //***************************
                    loaddata();

                    //***************************

                }
            }

        }

        private void managment_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
/*
          if ((checkBox1.Checked==false ) && (panel2.Enabled==true))
          {

              Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());
            
              Kindjobpaient_comboBox.DisplayMember = "ManagementDesc";
              Kindjobpaient_comboBox.ValueMember = "Fk_Management";
              Kindjobpaient_comboBox.DataSource = dentistryEntitiescontext.Tbl_Company.Where(p => p.Pk_Company == Kindjobpaient_managment_tmp).ToList();
              
          }
*/            

        }

        private void Kindjobpaient_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kindpaientcode_comboBox.SelectedIndex = Kindpaient_comboBox.SelectedIndex;
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

        private void managment_combobox_Leave(object sender, EventArgs e)
        {

            if ((checkBox1.Checked == false) && (panel2.Enabled == true))
            {

                Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

                Kindjobpaient_comboBox.DisplayMember = "Description";
                Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
                Kindjobpaient_comboBox.DataSource = dentistryEntitiescontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
                Kindjobpaient_comboBox.SelectedIndex = 0;

            }

        }

        private void Kindpaient_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kindpaientcode_comboBox.SelectedIndex = Kindpaient_comboBox.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void KFactor_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        
    }
}
