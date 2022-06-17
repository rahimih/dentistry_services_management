﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;
using DLibraryUtils;



namespace PIHO_DENTIST_SOFTWARE
{
    public partial class vacationsDoctors_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        public vacationsDoctors_f()
        {
            InitializeComponent();
        }
        private bool loaddata(string string1, string string2)
        {
            DLUtilsobj.vacationsobj.selectvacations(string1, string2);
            SqlDataReader DataSource;
            DLUtilsobj.vacationsobj.Dbconnset(true);
            DataSource = DLUtilsobj.vacationsobj.vacationsclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.vacationsobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام پزشک";
                radGridView1.Columns[2].HeaderText = "نوع مرخصی";
                radGridView1.Columns[3].HeaderText = "از تاریخ";
                radGridView1.Columns[4].HeaderText = "تا تاریخ";
                
            }

            return true;
        }

        private void vacationsDoctors_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            doctors_comboBox.DisplayMember = "Lname";
            doctors_comboBox.ValueMember = "usercode";
            doctors_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            vacationType_comboBox.SelectedIndex = 0;
            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
       
        }

        private void vacationsDoctors_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
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

        private void Del_Button_Click(object sender, EventArgs e)
        {
                        if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.vacationsobj.deletevacations(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 17, Environment.MachineName,a);

                    //***************************
                    loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                    //***************************

        }

     
    }
}

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                doctors_comboBox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {
               
                if (DLUtilsobj.vacationsobj.checkduplicatevacations(int.Parse(doctors_comboBox.SelectedValue.ToString()), Fromdate_persianDateTimePicker.Value.ToString("yyyy/MM/dd"), Todate_persianDateTimePicker.Value.ToString("yyyy/MM/dd")) == true)
                    MessageBox.Show("مرخصی برای پزشک انتخابی قبلا ثبت گردیده است","خطا",MessageBoxButtons.OK);
                //error cheking.................

             /*   if ((FromTime_maskedit.Text == "ــ:ــ") || (ToTime_maskedit.Text == "ــ:ــ"))
                {
                    MessageBox.Show("لطفا ساعت حضور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                } */
                else
                {
              
        
                    vacation vacationtable = new vacation
                    {
                        Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString()),
                        vacationType = vacationType_comboBox.Text,
                        fromDate = Fromdate_persianDateTimePicker.Value.ToString("yyyy/MM/dd"),
                        fromDate_Eng = Fromdateeng_dateTimePicker.Value,
                        Todate = Todate_persianDateTimePicker.Value.ToString("yyyy/MM/dd"),
                        Todate_Eng = TodateEng_dateTimePicker.Value,
                        usercode = usercodexml,
                        deleted = false
                    };

                    dentistryEntitiescontext.vacations.Add(vacationtable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 15, Environment.MachineName,0);
                    edit_Button.Enabled = true;
                    Del_Button.Enabled = true;
                    panel2.Enabled = false;

                    //***************************
                    loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                    //***************************

                }
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

                vacation vacationtable = dentistryEntitiescontext.vacations.First(i => i.vacationsCode == a);
                str1 = str1 + 1;

                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    doctors_comboBox.SelectedValue = vacationtable.Doctorscode.Value;
                    vacationType_comboBox.Text = vacationtable.vacationType.ToString();
                    Fromdateeng_dateTimePicker.Value = vacationtable.fromDate_Eng.Value;
                    TodateEng_dateTimePicker.Value = vacationtable.Todate_Eng.Value;
                    Fromdate_persianDateTimePicker.Value = Fromdateeng_dateTimePicker.Value;
                    Todate_persianDateTimePicker.Value = TodateEng_dateTimePicker.Value;

                }


                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        vacationtable.Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString());
                        vacationtable.vacationType = vacationType_comboBox.Text;
                        vacationtable.fromDate = Fromdate_persianDateTimePicker.Value.ToString("yyyy/MM/dd");
                        vacationtable.fromDate_Eng = Fromdateeng_dateTimePicker.Value;
                        vacationtable.Todate = Fromdate_persianDateTimePicker.Value.ToString("yyyy/MM/dd");
                        vacationtable.Todate_Eng = TodateEng_dateTimePicker.Value;

                        dentistryEntitiescontext.SaveChanges();
                        str1 = 0;

                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 16, Environment.MachineName, a);

                        //***************************
                        loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //edit_Button_Click_1(toolStripMenuItem2, e);
            edit_Button_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Del_Button_Click(toolStripMenuItem3, e);
        }
       }
    }
