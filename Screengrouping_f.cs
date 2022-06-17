﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Screengrouping_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int a;
        public int usercodexml;
        public int Screenvalue = 0;
        public Screengrouping_f()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {

            radGridView1.DataSource = dentistryEntitiescontext.ServiceTypeScreens.Where(p => p.deleted == false).ToList();
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[1].HeaderText = "نام خدمت";
                radGridView1.Columns[2].HeaderText = " کد Screen";
                radGridView1.Columns[3].IsVisible = false;
            }


            return true;
        }
        private void Screengrouping_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            loaddata();
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {

                Screenvalue = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            F16_ins_f F16_ins_frm = new F16_ins_f();
            F16_ins_frm.usercodexml = usercodexml;
            F16_ins_frm.edit_Button.Enabled = false;
            F16_ins_frm.statusform = 3;
            F16_ins_frm.label1.Text = "کد Screen";
            F16_ins_frm.Text = "فرم اسکرین";
            F16_ins_frm.ShowDialog();
            loaddata();
        }

        private void Screengrouping_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Servicesobj.deleteServicestypeScreen(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                    loaddata();
                    
                }
            }

        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                F16_ins_f F16_ins_frm = new F16_ins_f();
                F16_ins_frm.usercodexml = usercodexml;
                F16_ins_frm.Ins_Button.Enabled = false;
                F16_ins_frm.cancel_button.Enabled = true;
                F16_ins_frm.statusform = 3;
                F16_ins_frm.label1.Text = "کد Screen";
                F16_ins_frm.Text = "فرم اسکرین";


                F16_ins_frm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                ServiceTypeScreen ServiceTypeScreentable = dentistryEntitiescontext.ServiceTypeScreens.First(i => i.ServiceTypeScreenCode == F16_ins_frm.a);

                F16_ins_frm.Services_detail_textbox.Text = ServiceTypeScreentable.ServiceTypeScreenName.ToString();
                F16_ins_frm.Code_numericUpDown.Value = ServiceTypeScreentable.screenCode.Value;
                F16_ins_frm.Comment_textBox.Text = ServiceTypeScreentable.Comment.ToString();


                F16_ins_frm.ShowDialog();

                loaddata();
            }
            
        }
    }
    }

