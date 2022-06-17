using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLibraryUtils;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Main_f : Form
    {

        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int usercodetemp;
        public int accessleveltemp;
        public string ipadress;
        public DateTime sdate;
        public string user_name;
        public string recipedatecheck;
        int year, month;
        string month_namelabel;

        public Main_f()
      
        {    
            InitializeComponent();
        }

        private string month_name(int month)
        {
            if (month == 1)
                month_namelabel = "فروردین";

            if (month == 2)
                month_namelabel = "اردیبهشت";

            if (month == 3)
                month_namelabel = "خرداد";

            if (month == 4)
                month_namelabel = "تیر";

            if (month == 5)
                month_namelabel = "مرداد";

            if (month == 6)
                month_namelabel = "شهریور";

            if (month == 7)
                month_namelabel = "مهر";

            if (month == 8)
                month_namelabel = "آبان";

            if (month == 9)
                month_namelabel = "آذر";

            if (month == 10)
                month_namelabel = "دی";

            if (month == 11)
                month_namelabel = "بهمن";

            if (month == 12)
                month_namelabel = "اسفند";

            return month_namelabel;


        }
     

        private void Main_f_FormClosed(object sender, FormClosedEventArgs e)
        {
            DLUtilsobj.EventsLogobj.insertEventsLog(usercodetemp.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 59, Environment.MachineName,0);
            Application.Exit();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Planvst_f planvst_Frm = new Planvst_f();
            planvst_Frm.usercodexml = usercodetemp;
            
            planvst_Frm.persianDateTimePicker1.Value = sdate;
            planvst_Frm.persianDateTimePicker2.Value = sdate;
            planvst_Frm.persianDateTimePicker3.Value = sdate;
            planvst_Frm.persianDateTimePicker4.Value = sdate;
            planvst_Frm.faMonthView.SelectedDateTime = sdate;
            planvst_Frm.aceesslevel = accessleveltemp;
            planvst_Frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Clinics_f clinic_frm = new Clinics_f();
            clinic_frm.usercodexml = usercodetemp;
            clinic_frm.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ContractOutCenter_f ContractOutCenter_frm = new ContractOutCenter_f();
            ContractOutCenter_frm.usercodexml = usercodetemp;
            ContractOutCenter_frm.ShowDialog();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoctorsworkTime_f DoctorsworkTime_frm = new DoctorsworkTime_f();
            DoctorsworkTime_frm.usercodexml = usercodetemp;
            //************
            DoctorsworkTime_frm.persianDateTimePicker1.Value = sdate;
            DoctorsworkTime_frm.persianDateTimePicker2.Value = sdate;
            DoctorsworkTime_frm.persianDateTimePicker3.Value = sdate;
            DoctorsworkTime_frm.dateTimePicker1.Value = sdate;
            //****************                

            DoctorsworkTime_frm.ShowDialog();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            vacationsDoctors_f vacationsDoctors_frm = new vacationsDoctors_f();
            vacationsDoctors_frm.usercodexml = usercodetemp;
            //-----------
            vacationsDoctors_frm.persianDateTimePicker2.Value = sdate;
            vacationsDoctors_frm.persianDateTimePicker3.Value = sdate;
            vacationsDoctors_frm.Fromdate_persianDateTimePicker.Value = sdate;
            vacationsDoctors_frm.Todate_persianDateTimePicker.Value = sdate;
            vacationsDoctors_frm.ShowDialog();
            
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KFactor_f KFactor_frm = new KFactor_f();
            KFactor_frm.usercodexml = usercodetemp;
            KFactor_frm.TariffBegindate_persianDateTimePicker.Value = sdate;
            KFactor_frm.Tariffenddate_persianDateTimePicker.Value = sdate;
            KFactor_frm.ShowDialog();
            
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            F16Grouping_f F16Grouping_frm = new F16Grouping_f();
            F16Grouping_frm.usercodexml = usercodetemp;
            F16Grouping_frm.ShowDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_f Services_frm = new Services_f();
            Services_frm.usercodexml = usercodetemp;
            Services_frm.ShowDialog();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            kanonGrouping_f kanonGrouping_frm = new kanonGrouping_f();
            kanonGrouping_frm.usercodexml = usercodetemp;
            kanonGrouping_frm.ShowDialog();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Screengrouping_f Screengrouping_frm = new Screengrouping_f();
            Screengrouping_frm.usercodexml = usercodetemp;
            Screengrouping_frm.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            CostConfirm_f CostConfirm_frm = new CostConfirm_f();
            CostConfirm_frm.usercodexml = usercodetemp;
            //***************
            CostConfirm_frm.persianDateTimePicker1.Value = sdate;
            CostConfirm_frm.persianDateTimePicker2.Value = sdate;
            CostConfirm_frm.Fromdateeng_dateTimePicker.Value = sdate;
            //***************
            CostConfirm_frm.ShowDialog();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
     
            Users_f Users_frm = new Users_f();
            Users_frm.usercodexml = usercodetemp;
            Users_frm.ShowDialog();
       

        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            Introduction_ins_f Introduction_ins_frm = new Introduction_ins_f();
            Introduction_ins_frm.usercodexml = usercodetemp;
            Introduction_ins_frm.ipadress = ipadress;
            //*************
            Introduction_ins_frm.ServicesdatepersianDateTimePicker.Value = sdate;
            Introduction_ins_frm.IntroductionpersianDateTimePicker.Value = sdate;
            Introduction_ins_frm.Fromdateeng_dateTimePicker.Value = sdate;
            //************
            Introduction_ins_frm.ShowDialog();
  
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Introduction_F Introduction_Frm = new Introduction_F();
            Introduction_Frm.usercodexml = usercodetemp;
            Introduction_Frm.ipadress = ipadress;
            //***********
            Introduction_Frm.persianDateTimePicker2.Value = sdate;
            Introduction_Frm.persianDateTimePicker3.Value = sdate;
                //*************
            Introduction_Frm.ShowDialog();
        }

        private void navBarItem34_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comment_F Comment_Frm = new Comment_F();
            Comment_Frm.usercodexml = usercodetemp;
            Comment_Frm.kind = 1;
            Comment_Frm.ShowDialog();
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CostConfirmView_f CostConfirmView_frm = new CostConfirmView_f();
            CostConfirmView_frm.usercodexml = usercodetemp;
            //***************
            CostConfirmView_frm.persianDateTimePicker2.Value = sdate;
            CostConfirmView_frm.persianDateTimePicker3.Value = sdate;
            //***************
            CostConfirmView_frm.ShowDialog();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Recipet_f Recipet_frm = new Recipet_f();
            Recipet_frm.usercodexml = usercodetemp;
            Recipet_frm.ipadress = ipadress;
            Recipet_frm.accessleveltemp = accessleveltemp;
            Recipet_frm.persianDateTimePicker1.Value = sdate;
            Recipet_frm.persianDateTimePicker2.Value = sdate;
            Recipet_frm.persianDateTimePicker3.Value = sdate;
            Recipet_frm.recipedatecheck = recipedatecheck;
            Recipet_frm.ShowDialog();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doctorsService_f doctorsService_frm = new doctorsService_f();
            doctorsService_frm.usercodexml = usercodetemp;
            doctorsService_frm.ipadress = ipadress;
            doctorsService_frm.acessleveltemp = accessleveltemp;
     
            if (accessleveltemp == 1)
            {
                dentistryEntitiescontext = new dentistryEntities();
                doctorsService_frm.Doctors_Combobox.DisplayMember = "Lname";
                doctorsService_frm.Doctors_Combobox.ValueMember = "usercode";
                doctorsService_frm.Doctors_Combobox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
                doctorsService_frm.button6.Enabled = true;

                doctorsService_frm.groupBox1.Visible = true;
            }


            //****************
            doctorsService_frm.persianDateTimePicker1.Value = sdate;
            doctorsService_frm.sdate = sdate;
            //****************

            doctorsService_frm.ShowDialog();
        }

        private void navBarItem35_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comment_F Comment_Frm = new Comment_F();
            Comment_Frm.usercodexml = usercodetemp;
            Comment_Frm.kind = 2;
            Comment_Frm.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSearch_f PaientSearch_frm = new PaientSearch_f();
            //---------
            PaientSearch_frm.persianDateTimePicker2.Value = sdate;
            PaientSearch_frm.persianDateTimePicker3.Value = sdate;
            //-----------
            PaientSearch_frm.ShowDialog();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            IntroductionServices_f IntroductionServices_frm = new IntroductionServices_f();
            IntroductionServices_frm.usercodexml = usercodetemp;
            IntroductionServices_frm.ShowDialog();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ContractOutCenter_f ContractOutCenter_frm = new ContractOutCenter_f();
            ContractOutCenter_frm.usercodexml = usercodetemp;
            ContractOutCenter_frm.ShowDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            MedicalRest_f MedicalRest_frm = new MedicalRest_f();
            MedicalRest_frm.usercodexml = usercodetemp;
            //*************
            MedicalRest_frm.persianDateTimePicker1.Value = sdate;
            MedicalRest_frm.persianDateTimePicker2.Value = sdate;
            MedicalRest_frm.persianDateTimePicker3.Value = sdate;
            MedicalRest_frm.persianDateTimePicker4.Value = sdate;
            //-------------
            MedicalRest_frm.ShowDialog();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MedicalRestView_f MedicalRestView_frm = new MedicalRestView_f();
            MedicalRestView_frm.usercodexml = usercodetemp;
            //***********
            MedicalRestView_frm.persianDateTimePicker2.Value = sdate;
            MedicalRestView_frm.persianDateTimePicker3.Value = sdate;
            //------------
            MedicalRestView_frm.ShowDialog();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------------

            Consult_f Consult_frm = new Consult_f();
            Consult_frm.usercodexml = usercodetemp;
            //**************
            Consult_frm.persianDateTimePicker4.Value = sdate;
            //****************

            Consult_frm.ShowDialog();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ConsultView_f ConsultView_frm = new ConsultView_f();
            ConsultView_frm.usercodexml = usercodetemp;
            //************
            ConsultView_frm.persianDateTimePicker2.Value = sdate;
            ConsultView_frm.persianDateTimePicker3.Value = sdate;
            //***********
            ConsultView_frm.ShowDialog();
        }

        private void Main_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();

            if (accessleveltemp == 2)
            { 
                navBarGroup1.Visible = false;
                navBarGroup2.Visible = false;
            }

          if (accessleveltemp == 3)
          {
              navBarGroup4.Visible = false;
              navBarGroup2.Visible = false;
              navBarGroup3.Visible = false;
          }

          if (accessleveltemp == 5)
          {
              navBarGroup1.Visible = false;
              navBarGroup2.Visible = false;
              navBarGroup3.Visible = false;
              navBarGroup4.Visible = false;
              navBarGroup5.Visible = false;
          }

            // Day_label.Text = persianDateTimePicker1.Value.Day.ToString();
           // year = persianDateTimePicker1.Value.Year - 1300;
           // Year_label.Text = year.ToString();
           // Month_label.Text = month_name(persianDateTimePicker1.Value.Month);
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reporting_F Reporting_Frm = new Reporting_F();
            Reporting_Frm.usercodexml = usercodetemp;
            Reporting_Frm.persianDateTimePicker2.Value = sdate;
            Reporting_Frm.persianDateTimePicker3.Value = sdate;
            Reporting_Frm.ShowDialog();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSearchServices_f PaientSearchServices_frm = new PaientSearchServices_f();
            //********
            PaientSearchServices_frm.persianDateTimePicker2.Value = sdate;
            PaientSearchServices_frm.persianDateTimePicker3.Value = sdate;
            PaientSearchServices_frm.ipadress = ipadress;
            //----------
            PaientSearchServices_frm.ShowDialog();
        }

        private void navBarItem61_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reporting2_f Reporting2_frm = new Reporting2_f();
            Reporting2_frm.ipadress = ipadress;
            Reporting2_frm.persianDateTimePicker2.Value = sdate;
            Reporting2_frm.persianDateTimePicker3.Value = sdate;
            Reporting2_frm.ShowDialog();
        }

        private void navBarItem62_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ScreenView_F ScreenView_Frm = new ScreenView_F();
            ScreenView_Frm.usercodexml = usercodetemp;
            ScreenView_Frm.ShowDialog();
        }

        private void navBarItem63_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();
        }

        private void navBarItem64_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Refer_view Refer_view_Frm = new Refer_view();
            Refer_view_Frm.usercodexml = usercodetemp;
            Refer_view_Frm.user_name = user_name;
            Refer_view_Frm.persianDateTimePicker4.Value = sdate;
            Refer_view_Frm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void navBarItem68_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReferOut_F ReferOut_Frm = new ReferOut_F();
            ReferOut_Frm.usercodexml = usercodetemp;
            ReferOut_Frm.ServicesdatepersianDateTimePicker.Value = sdate;
            ReferOut_Frm.ipadressp = ipadress;
            ReferOut_Frm.ShowDialog();
        }

        private void navBarItem69_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReferOutView_F ReferOutView_Frm = new ReferOutView_F();
            ReferOutView_Frm.usercodexml = usercodetemp;
            ReferOutView_Frm.ipadress = ipadress;
            ReferOutView_Frm.persianDateTimePicker2.Value = sdate;
            ReferOutView_Frm.persianDateTimePicker3.Value = sdate;
            ReferOutView_Frm.ShowDialog();

        }

        private void navBarItem70_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Family_dentist_F Family_dentist_Frm = new Family_dentist_F();
            Family_dentist_Frm.usercode = usercodetemp;
            Family_dentist_Frm.persianDateTimePicker2.Value = sdate;
            Family_dentist_Frm.ShowDialog();
        }

        private void navBarItem71_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Services_Group_report_view_F Services_Group_report_view_Frm = new Services_Group_report_view_F();
            Services_Group_report_view_Frm.ShowDialog();
            //Services_Group_report_F Services_Group_report_Frm = new Services_Group_report_F();
            //Services_Group_report_Frm.ShowDialog();
            //this.WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {    
            this.WindowState = FormWindowState.Minimized;
        }

        private void navBarItem72_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //--------------- اسکن مدارک
            Scan_Document_F Scan_Document_Frm = new Scan_Document_F();
            Scan_Document_Frm.usercode = usercodetemp;
            Scan_Document_Frm.persianDateTimePicker2.Value = sdate;
            Scan_Document_Frm.ShowDialog();

        }

        private void navBarItem73_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Log_View_F Log_View_Frm = new Log_View_F();
            Log_View_Frm.kind = 1;
            Log_View_Frm.persianDateTimePicker1.Value = sdate;
            Log_View_Frm.persianDateTimePicker4.Value = sdate;
            Log_View_Frm.ShowDialog();
        }

  
    }
}
