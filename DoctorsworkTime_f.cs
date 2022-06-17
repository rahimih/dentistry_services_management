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
    public partial class DoctorsworkTime_f : Form
    {
       
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        DateTime miladidate;
        
        public DoctorsworkTime_f()
        {
            InitializeComponent();
        }

           private bool loaddata(string string1,string string2)
        {
            DLUtilsobj.doctorsworktimeobj.selectDoctorsworktime(string1,string2);
            SqlDataReader DataSource;
            DLUtilsobj.doctorsworktimeobj.Dbconnset(true);
            DataSource = DLUtilsobj.doctorsworktimeobj.Doctorsworktimeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.doctorsworktimeobj.Dbconnset(false);
            

            if (radGridView1.RowCount > 0)
            { 
            radGridView1.Columns[0].HeaderText = "ردیف";
            radGridView1.Columns[1].HeaderText = "نام پزشک";
            radGridView1.Columns[2].HeaderText = "تاریخ";
            radGridView1.Columns[3].HeaderText = "شیفت";
            radGridView1.Columns[4].HeaderText = "از ساعت";
            radGridView1.Columns[5].HeaderText = "تا ساعت";
            radGridView1.Columns[6].HeaderText = "نوع";
            }

            return true;
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");

            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void FromTime_maskedit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void DoctorsworkTime_f_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
       
            dentistryEntitiescontext = new dentistryEntities();
            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "ShiftCode";
            doctors_comboBox.DisplayMember = "Lname";
            doctors_comboBox.ValueMember = "usercode";
            doctors_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            Shift_comboBox.DataSource = dentistryEntitiescontext.Shifts.ToList(); 
            Kind_comboBox.SelectedIndex = 0;

            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

          
        }

        private void button1_Click(object sender, EventArgs e)
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
                //error cheking.................

                if ((FromTime_maskedit.Text == "ــ:ــ") || (ToTime_maskedit.Text == "ــ:ــ"))
                {
                    MessageBox.Show("لطفا ساعت حضور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
                else
                {
                    TimeSpan dt1 = TimeSpan.Parse(FromTime_maskedit.Text);
                    TimeSpan dt2 = TimeSpan.Parse(ToTime_maskedit.Text);
                    miladidate= DLUtilsobj.doctorsworktimeobj.shamsitomiladi(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));
                    

                    DoctorsWorkTime DoctorsWorkTimetable = new DoctorsWorkTime
                    {
                        Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString()),
                        Workdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                        Workdate_eng = miladidate,
                        Workshift = Byte.Parse(Shift_comboBox.SelectedValue.ToString()),
                        Kind = Kind_comboBox.Text,
                        timeFrom = dt1,
                        timeTo = dt2,
                        Usercode = usercodexml,
                        deleted = false
                    };

                    dentistryEntitiescontext.DoctorsWorkTimes.Add(DoctorsWorkTimetable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 9, Environment.MachineName,0);
                    edit_Button.Enabled = true;
                    Del_Button.Enabled = true;
                    panel2.Enabled = false;

                    //***************************
                    loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                    //***************************

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.doctorsworktimeobj.deleteDoctorsworktime(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 11, Environment.MachineName,a);

                    //***************************
                    loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                    //***************************


                }
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

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

                DoctorsWorkTime DoctorsWorkTimetable = dentistryEntitiescontext.DoctorsWorkTimes.First(i => i.DoctorsWorkTimeCode == a);
                str1 = str1 + 1;

                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;
                  

                    doctors_comboBox.SelectedValue = DoctorsWorkTimetable.Doctorscode.Value;
                    Shift_comboBox.SelectedValue = DoctorsWorkTimetable.Workshift.Value;
                    Kind_comboBox.Text = DoctorsWorkTimetable.Kind.ToString();
                    FromTime_maskedit.Text = DoctorsWorkTimetable.timeFrom.ToString();
                    ToTime_maskedit.Text = DoctorsWorkTimetable.timeTo.ToString();
                    dateTimePicker1.Value = DoctorsWorkTimetable.Workdate_eng.Value;
                    persianDateTimePicker1.Value = dateTimePicker1.Value;


                }


                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        TimeSpan dt1 = TimeSpan.Parse(FromTime_maskedit.Text);
                        TimeSpan dt2 = TimeSpan.Parse(ToTime_maskedit.Text);
                        miladidate = DLUtilsobj.doctorsworktimeobj.shamsitomiladi(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));

                        DoctorsWorkTimetable.Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString());
                        DoctorsWorkTimetable.Workdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                        DoctorsWorkTimetable.Workdate_eng = miladidate;
                        DoctorsWorkTimetable.Workshift = byte.Parse(Shift_comboBox.SelectedValue.ToString());
                        DoctorsWorkTimetable.Kind = Kind_comboBox.Text;
                        DoctorsWorkTimetable.timeFrom = dt1;
                        DoctorsWorkTimetable.timeTo = dt2;
                        dentistryEntitiescontext.SaveChanges();
                        str1 = 0;

                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 10, Environment.MachineName, a);

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
            button1_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem3, e);
        }

        private void DoctorsworkTime_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }



     
    }
}