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
    public partial class Planvst_f : Form
    {

        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        List<DateTime> selection = new List<DateTime>();
        int str1 = 0;
        public int usercodexml;
        byte shiftcode;
        byte oldcapacity,turnno;
        DateTime Fromdatet;
        public int aceesslevel;
        string screen_counts;
        
        
        public Planvst_f()
        {
            InitializeComponent();
        }

   
        private bool loaddata(string string1, string string2)
        {
            DLUtilsobj.planvisitobj.selectplanvisit(string1, string2);
            SqlDataReader DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(true);
            DataSource = DLUtilsobj.planvisitobj.planvisitclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(false);
            

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام پزشک";
                radGridView1.Columns[2].HeaderText = "نام کلینیک";
                radGridView1.Columns[3].HeaderText = "ظرفیت پذیرش";
                radGridView1.Columns[4].HeaderText = "تاریخ";
                radGridView1.Columns[5].HeaderText = "شیفت";
                radGridView1.Columns[6].HeaderText = "از ساعت";
                radGridView1.Columns[7].HeaderText = "تا ساعت";
                radGridView1.Columns[8].HeaderText = "مدت زمان";
                radGridView1.Columns[9].HeaderText = " نوع";

            }

            return true;
        } 

        private void Planvst_f_Load(object sender, EventArgs e)
        {

            //********************
            faMonthView.DefaultCalendar = faMonthView.PersianCalendar;
            faMonthView.DefaultCulture = faMonthView.PersianCulture;
            faMonthView.SelectedDateTime = persianDateTimePicker1.Value;
            faMonthView.SetTodayDay();
            //**********************
            
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            Clinics_comboBox.DisplayMember = "Clinicname";
            Shift_comboBox.DisplayMember = "Shiftname";
            Doctors_Combobox.DisplayMember = "Lname";
            Clinics_comboBox.ValueMember = "ClinicCode";
            Shift_comboBox.ValueMember = "Shiftcode";
            Doctors_Combobox.ValueMember = "usercode";
            Clinics_comboBox.DataSource = dentistryEntitiescontext.Clinics.ToList();
            Shift_comboBox.DataSource = dentistryEntitiescontext.Shifts.ToList(); 
            Doctors_Combobox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            comboBox1.SelectedIndex = 0;

            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                                
        }

        private void Clinics_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Doctors_Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Fromdate_edit_KeyDown(object sender, KeyEventArgs e)
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

        private void ToTime_maskedit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Shift_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Capacity_dropdown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
           if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                Clinics_comboBox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {
                //error cheking.................

                if ((FromTime_maskedit.Text == "ــ:ــ") || (ToTime_maskedit.Text == "ــ:ــ"))
               
                    MessageBox.Show("لطفا ساعت حضور را وارد نمائید", "خطا", MessageBoxButtons.OK);
               
                else
                {
                    if (Capacity_dropdown.Value==0)
                        MessageBox.Show("لطفا حداکثر ظرفیت پذیرش را وارد نمائید", "خطا", MessageBoxButtons.OK);
                    else
                 { 
                    TimeSpan dt1 = TimeSpan.Parse(FromTime_maskedit.Text);
                    TimeSpan dt2 = TimeSpan.Parse(ToTime_maskedit.Text);
                    
                        
                        faMonthView.SelectedDateRange.AddRange(selection.ToArray());

                        int i = faMonthView.SelectedDateRange.Count;

                        for (int j = 0; j <= i - 1; j++)
                        {
                    
                            persianDateTimePicker1.Value = faMonthView.SelectedDateRange.ElementAt(j);

                         //   if (persianDateTimePicker1.Value < persianDateTimePicker4.Value)
                         //       MessageBox.Show("شما مجاز به ثبت برنامه جهت روزهای قبل نیستید."+ "\n" + persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), "خطا", MessageBoxButtons.OK);
                         //   else { 

                            if (DLUtilsobj.planvisitobj.Duplicateinplanvisit(int.Parse(Doctors_Combobox.SelectedValue.ToString()), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), dt1, dt2,int.Parse(comboBox1.SelectedIndex+1.ToString())) == true)
                                MessageBox.Show("این برنامه قبلا ثبت گردیده است."+ "\n" + persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), "خطا", MessageBoxButtons.OK);
                            else
                            {
                                if (DLUtilsobj.planvisitobj.vacationinplanvisit(int.Parse(Doctors_Combobox.SelectedValue.ToString()), persianDateTimePicker1.Value.ToString("yyyy/MM/dd")) == true)
                                    MessageBox.Show("پزشک انتخابی در این تاریخ مرخصی می باشد. "+ "\n" + persianDateTimePicker1.Value.ToString("yyyy/MM/dd") , "خطا", MessageBoxButtons.OK);
                                else
                                {
                    
                            
                            PlanVisit PlanVisittable = new PlanVisit
                            {
                                Doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString()),
                                Cliniccode = byte.Parse(Clinics_comboBox.SelectedValue.ToString()),
                                Capacity = byte.Parse(Capacity_dropdown.Value.ToString()),
                                Fromdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                                todate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                                Shiftcode = byte.Parse(Shift_comboBox.SelectedValue.ToString()),
                                Fromtime = dt1,
                                totime = dt2,
                                intervaltime = byte.Parse(interval_dropdown.Value.ToString()),
                                insertdate = DateTime.Now.Date,
                                inserttime = DateTime.Now.TimeOfDay,
                                usercode = usercodexml,
                                status = true,
                                kind = Convert.ToByte(comboBox1.SelectedIndex+1),
                                InternetCapacity = byte.Parse(numericUpDown1.Value.ToString()),
                                deleted = false
                            };

                            dentistryEntitiescontext.PlanVisits.Add(PlanVisittable);
                            dentistryEntitiescontext.SaveChanges();
                        }

                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    edit_Button.Enabled = true;
                    Del_Button.Enabled = true;
                    panel2.Enabled = false;

                    //***************************
                    loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                    //***************************
                      }
                   // }
                   }
                }
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
                faMonthView.Visible = true;
                persianDateTimePicker1.Visible = false;    
            }

        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (DLUtilsobj.planvisitobj.CheckDeleteplanvist(a) == true)
                    {
                        MessageBox.Show("شما مجاز به حذف برنامه ویزیت انتخابی نیستید.", "خطا", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DLUtilsobj.planvisitobj.deleteplanvisit(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 22, Environment.MachineName, a);

                        //***************************
                        loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                        //***************************
                    }
                }
            }

        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                //***********
                faMonthView.Visible = false;
                persianDateTimePicker1.Visible = true;
                //***********
                Del_Button.Enabled = false;
                Ins_Button.Enabled = false;
                radGridView1.Enabled = false;
                cancel_button.Enabled = true;
        
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                PlanVisit PlanVisittable = dentistryEntitiescontext.PlanVisits.First(i => i.planvisit_Code == a);
                str1 = str1 + 1;


                //**************select count turnno
                turnno = DLUtilsobj.recipeobj.selectcountRecipe(a);
                //************************


                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    Clinics_comboBox.SelectedValue = PlanVisittable.Cliniccode.Value;
                    Doctors_Combobox.SelectedValue = PlanVisittable.Doctorscode.Value;
                    Shift_comboBox.SelectedValue = PlanVisittable.Shiftcode.Value;
                    FromTime_maskedit.Text = PlanVisittable.Fromtime.ToString();
                    ToTime_maskedit.Text = PlanVisittable.totime.ToString();
                    Capacity_dropdown.Value = PlanVisittable.Capacity.Value;
                    oldcapacity =Convert.ToByte(Capacity_dropdown.Value);
                    interval_dropdown.Value = PlanVisittable.intervaltime.Value;
                    Fromdatet = DLUtilsobj.doctorsworktimeobj.shamsitomiladi(PlanVisittable.Fromdate.ToString());
                    persianDateTimePicker1.Value = Fromdatet;
                    comboBox1.SelectedIndex = PlanVisittable.kind.Value-1;
                    numericUpDown1.Value = PlanVisittable.InternetCapacity.Value;
                    
                    
                }

                    if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {
                    if (MessageBox.Show("تغییرات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        if ((turnno>0) && (oldcapacity != Capacity_dropdown.Value) && (Capacity_dropdown.Value < turnno))
                            MessageBox.Show("شما مجاز به تغییر ظرفیت پذیرش نمی باشید", "Information", MessageBoxButtons.OK);
                        
                        else if  ((turnno==0) || ((turnno>0) && (oldcapacity!=Capacity_dropdown.Value) && (Capacity_dropdown.Value>turnno)))
                        {

                            TimeSpan dt1 = TimeSpan.Parse(FromTime_maskedit.Text);
                            TimeSpan dt2 = TimeSpan.Parse(ToTime_maskedit.Text);
                            if (DLUtilsobj.planvisitobj.Duplicateineditplanvisit(int.Parse(Doctors_Combobox.SelectedValue.ToString()), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), dt1, dt2,int.Parse(comboBox1.SelectedIndex+1.ToString()),a) == true)
                                MessageBox.Show("این برنامه قبلا ثبت گردیده است.", "خطا", MessageBoxButtons.OK);
                            else
                            {
                                if (DLUtilsobj.planvisitobj.vacationinplanvisit(int.Parse(Doctors_Combobox.SelectedValue.ToString()), persianDateTimePicker1.Value.ToString("yyyy/MM/dd")) == true)
                                    MessageBox.Show("پزشک انتخابی در این تاریخ مرخصی می باشد. ", "خطا", MessageBoxButtons.OK);
                                else
                                {

                                PlanVisittable.Doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                                PlanVisittable.Cliniccode = byte.Parse(Clinics_comboBox.SelectedValue.ToString());
                                PlanVisittable.Capacity = byte.Parse(Capacity_dropdown.Value.ToString());
                                PlanVisittable.Fromdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                                PlanVisittable.todate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                                PlanVisittable.Shiftcode = byte.Parse(Shift_comboBox.SelectedValue.ToString());
                                PlanVisittable.Fromtime = dt1;
                                PlanVisittable.totime = dt2;
                                PlanVisittable.intervaltime = byte.Parse(interval_dropdown.Value.ToString());
                                PlanVisittable.kind = Convert.ToByte(comboBox1.SelectedIndex+1);
                                PlanVisittable.InternetCapacity = byte.Parse(numericUpDown1.Value.ToString());
                                dentistryEntitiescontext.SaveChanges();
                                 DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(),21, Environment.MachineName, a);
                                 MessageBox.Show("تغییرات ثبت گردید.", "Information", MessageBoxButtons.OK);

                                //--------------
                                 panel2.Enabled = false;
                                 edit_Button.Enabled = true;
                                 Del_Button.Enabled = true;
                                 Ins_Button.Enabled = true;
                                 radGridView1.Enabled = true;
                                 str1 = 0;
                                 faMonthView.Visible = true;
                                 persianDateTimePicker1.Visible = false;
                                 loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                                }

                           }

                         } //if turnno==0
                        
                        }
                        }
            }
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void Planvst_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
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

        private void Shift_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftcode=Convert.ToByte(Shift_comboBox.SelectedValue.ToString());
            Shift shifttable = dentistryEntitiescontext.Shifts.First(i => i.Shiftcode == shiftcode);

            FromTime_maskedit.Text = shifttable.Fromtime.ToString();
            ToTime_maskedit.Text = shifttable.totime.ToString();


            if (comboBox1.SelectedIndex == 2)
            {
                screen_counts = (DLUtilsobj.usercheckingobj.search_screen_count(int.Parse(Doctors_Combobox.SelectedValue.ToString()), int.Parse(Shift_comboBox.SelectedValue.ToString())));

                if (screen_counts == "-1")
                    numericUpDown1.Value = 0;
                else
                    numericUpDown1.Value = int.Parse(screen_counts);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex==2) && (aceesslevel>1))
            {

                screen_counts = (DLUtilsobj.usercheckingobj.search_screen_count(int.Parse(Doctors_Combobox.SelectedValue.ToString()), int.Parse(Shift_comboBox.SelectedValue.ToString())));
                if (screen_counts == "-1")
                    numericUpDown1.Value = 0;
                else
                   numericUpDown1.Value = int.Parse(screen_counts);

                   numericUpDown1.Enabled = false;
            }

             else if ((comboBox1.SelectedIndex!=2) || (aceesslevel==1))
            {
                Capacity_dropdown.Value = 0;
                numericUpDown1.Value = 0;
                numericUpDown1.Enabled=true;

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Capacity_dropdown.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void Planvst_f_Shown(object sender, EventArgs e)
        {
            faMonthView.SelectedDateTime = persianDateTimePicker1.Value;
        }

        private void Planvst_f_Enter(object sender, EventArgs e)
        {
            faMonthView.SelectedDateTime = persianDateTimePicker1.Value;
        }

        private void Doctors_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (comboBox1.SelectedIndex==2)
              {
                  screen_counts = (DLUtilsobj.usercheckingobj.search_screen_count(int.Parse(Doctors_Combobox.SelectedValue.ToString()), int.Parse(Shift_comboBox.SelectedValue.ToString())));

                  if (screen_counts == "-1")
                      numericUpDown1.Value = 0;
                  else
                      numericUpDown1.Value = int.Parse(screen_counts);

              }
        }

        

    

      
    }
}
