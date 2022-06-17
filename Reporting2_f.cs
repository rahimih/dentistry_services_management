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
using System.Xml;
using System.IO;


namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Reporting2_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int zarib;
        int year;
        int fromyear, toyear;
        string monthd, dayd;
        public string ipadress;
        int Kindjobpaient_managment_tmp;
        int reporintNo=1;
        public Reporting2_f()
        {
            InitializeComponent();
        }
      

        private void Reporting2_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            //------------------
            Doctors_Combobox.DisplayMember = "Lname";
            Doctors_Combobox.ValueMember = "usercode";
            Doctors_Combobox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();

            Services_combox.DisplayMember = "Services_detail_Name";
            Services_combox.ValueMember = "Services_detail_Code";
            Services_combox.DataSource = dentistryEntitiescontext.Services_detail.Where(p => p.ISValid == true).ToList();

            Group_Services_comboBox.DisplayMember = "Services_Group_Desc_report";
            Group_Services_comboBox.ValueMember = "Services_Group_code_report";
            Group_Services_comboBox.DataSource = dentistryEntitiescontext.Services_Group_report.ToList();

            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "id";
            managment_combobox.DataSource = dentistryEntitiescontext.TblManagements.Where(p => p.Description!=null ).ToList();


            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";
            paienttype_comboBox.DataSource = dentistryEntitiescontext.PaientTypes.ToList();


            PaientStatus_comboBox.DisplayMember = "PaientStatusName";
            PaientStatus_comboBox.ValueMember = "PaientStatuscode";
            PaientStatus_comboBox.DataSource = dentistryEntitiescontext.PaientStatus.ToList();

            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "Shiftcode";
            Shift_comboBox.DataSource = dentistryEntitiescontext.Shifts.ToList(); 

            Tariffkind_comboBox.SelectedIndex = 0;

        }

        private void Search_button_Click(object sender, EventArgs e)
        {

        }

        private void managment_combobox_Leave(object sender, EventArgs e)
        {
         

                Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

                Kindjobpaient_comboBox.DisplayMember = "Description";
                Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
                Kindjobpaient_comboBox.DataSource = dentistryEntitiescontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
                Kindjobpaient_comboBox.SelectedIndex = 0;

            }

        private void Search_button_Click_1(object sender, EventArgs e)
        {
            
            if (reporintNo==1)
            {
            reporting2_view reporting2_viewfrm = new reporting2_view();
            reporting2_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            reporting2_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            reporting2_viewfrm.doctorscode =int.Parse(Doctors_Combobox.SelectedValue.ToString());
            reporting2_viewfrm.zarib = zarib;
            reporting2_viewfrm.ipadress = ipadress;
            reporting2_viewfrm.ShowDialog();
            }

            if (reporintNo == 2)
            {
                reporting3_view reporting3_viewfrm = new reporting3_view();
                reporting3_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting3_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting3_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                reporting3_viewfrm.servicescode = int.Parse(Services_combox.SelectedValue.ToString());
                reporting3_viewfrm.zarib = zarib;
                reporting3_viewfrm.ipadress = ipadress;
                reporting3_viewfrm.ShowDialog();
            }


            if (reporintNo == 5)
            {
                reporting4_view reporting4_viewfrm = new reporting4_view();
                reporting4_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting4_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting4_viewfrm.paienttype = int.Parse(paienttype_comboBox.SelectedValue.ToString());
                reporting4_viewfrm.zarib = zarib;
                reporting4_viewfrm.code = 1;
                reporting4_viewfrm.ipadress = ipadress;
                reporting4_viewfrm.ShowDialog();
            }

            if (reporintNo == 6)
            {
                reporting5_view reporting5_viewfrm = new reporting5_view();
                reporting5_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting5_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting5_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                
                reporting5_viewfrm.ipadress = ipadress;
                reporting5_viewfrm.ShowDialog();
            }


            if (reporintNo == 7)
            {
                reporting6_view reporting6_viewfrm = new reporting6_view();
                reporting6_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting6_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                
                reporting6_viewfrm.ipadress = ipadress;
                reporting6_viewfrm.ShowDialog();
            }


            if (reporintNo == 8)
            {
                reporting7_view reporting7_viewfrm = new reporting7_view();
                reporting7_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting7_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                reporting7_viewfrm.ipadress = ipadress;
                reporting7_viewfrm.ShowDialog();
            }

            if (reporintNo == 9)
            {
                reporting8_view reporting8_viewfrm = new reporting8_view();
                reporting8_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting8_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                reporting8_viewfrm.ipadress = ipadress;
                reporting8_viewfrm.ShowDialog();
            }

            if (reporintNo == 10)
            {
                reporting9_view reporting9_viewfrm = new reporting9_view();
                reporting9_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting9_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                reporting9_viewfrm.ipadress = ipadress;
                reporting9_viewfrm.ShowDialog();
            }


            if (reporintNo == 11)
            {
                reporting11_view reporting11_viewfrm = new reporting11_view();
                reporting11_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting11_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting11_viewfrm.pk_company = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                reporting11_viewfrm.pk_managment = int.Parse(managment_combobox.SelectedValue.ToString());
                reporting11_viewfrm.zarib = zarib;
                reporting11_viewfrm.ipadress = ipadress;
                reporting11_viewfrm.ShowDialog();
            }


            if (reporintNo == 12)
            {
                
                /*
                fromyear= persianDateTimePicker4.Value.Year-int.Parse(numericUpDown1.Value.ToString());
                toyear = persianDateTimePicker4.Value.Year - int.Parse(numericUpDown2.Value.ToString());
                
                if (persianDateTimePicker4.Value.Month < 10)
                    monthd = "0"+ persianDateTimePicker4.Value.Month.ToString();
                else
                    monthd =  persianDateTimePicker4.Value.Month.ToString();


                if (persianDateTimePicker4.Value.Day < 10)
                    dayd = "0" + persianDateTimePicker4.Value.Day.ToString();
                else
                    dayd = persianDateTimePicker4.Value.Day.ToString();
                 */ 

                

                reporting12_view reporting12_viewfrm = new reporting12_view();
                reporting12_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting12_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting12_viewfrm.fromage = (numericUpDown1.Value.ToString());  //toyear.ToString() + "/" + monthd + "/" + dayd;
                reporting12_viewfrm.toage = (numericUpDown2.Value.ToString());    //fromyear.ToString() + "/" + monthd + "/" + dayd;
                reporting12_viewfrm.zarib = zarib;
                reporting12_viewfrm.ipadress = ipadress;
                reporting12_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                reporting12_viewfrm.ShowDialog();
            }


            if (reporintNo == 13)
            {
                reporting10_view reporting10_viewfrm = new reporting10_view();
                reporting10_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting10_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting10_viewfrm.pk_company = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                reporting10_viewfrm.pk_managment = int.Parse(managment_combobox.SelectedValue.ToString());
                reporting10_viewfrm.zarib = zarib;
                reporting10_viewfrm.ipadress = ipadress;
                reporting10_viewfrm.ShowDialog();
            }


            if (reporintNo == 14)
            
            {
                
                DLUtilsobj.screenobj.xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zarib,5);
                SqlDataReader DataSource1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3.DataSource= DataSource1;
                DLUtilsobj.screenobj.Dbconnset(false);
                
                //..............................
                
                DLUtilsobj.screenobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zarib,5);
                SqlDataReader DataSource;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                
                 
                    /*XmlTextWriter XmlWrt = new XmlTextWriter("dentistxml_"+persianDateTimePicker3.Value.Year.ToString()+persianDateTimePicker3.Value.Month.ToString()+".xml",System.Text.UTF8Encoding.UTF8);

                    XmlWrt.Formatting = Formatting.Indented;
                    XmlWrt.WriteStartDocument();    
                    XmlWrt.WriteStartElement("ReaderDataset");
                    while (DataSource.Read())
              {

                    
                    XmlWrt.WriteStartElement("NonXml");
                    XmlWrt.WriteElementString("PersonalNo",DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation",DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("VisitDate", DataSource["VisitDate"].ToString());
                    XmlWrt.WriteElementString("Shift", DataSource["Shift"].ToString());
                    XmlWrt.WriteElementString("MedicalService", DataSource["MedicalService"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                 }
                    XmlWrt.WriteEndDocument();
                    XmlWrt.Close();
                    DataSource.Close();
                    DLUtilsobj.screenobj.Dbconnset(false);
                    MessageBox.Show("فایل با نام " + "dentistxml_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                     */
                saveFileDialog1.FileName = "dentistxml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<NonXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<VisitDate>" + DataSource["VisitDate"].ToString() + "</VisitDate>");
                        tw.WriteLine("<Shift>" + DataSource["Shift"].ToString() + "</Shift>");
                        tw.WriteLine("<MedicalService>" + DataSource["MedicalService"].ToString() + "</MedicalService>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</NonXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "dentistxml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.screenobj.Dbconnset(false);

                
            }

            if (reporintNo == 15)
            {
                reporting13_view reporting13_viewfrm = new reporting13_view();
                reporting13_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting13_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting13_viewfrm.ipadress = ipadress;
                reporting13_viewfrm.ShowDialog();
            }


            if (reporintNo == 16)
            {
                reporting14_view reporting14_viewfrm = new reporting14_view();
                reporting14_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting14_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting14_viewfrm.ipadress = ipadress;
                reporting14_viewfrm.ShowDialog();
            }


            if (reporintNo == 17)
            {
                reporting15_view reporting15_viewfrm = new reporting15_view();
                reporting15_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting15_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting15_viewfrm.ipadress = ipadress;
                reporting15_viewfrm.ShowDialog();
            }


            if (reporintNo == 18)
            {
                reporting16_view reporting16_viewfrm = new reporting16_view();
                reporting16_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting16_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting16_viewfrm.ipadress = ipadress;
                reporting16_viewfrm.ShowDialog();
            }



            if (reporintNo == 19)
            {
                reporting17_view reporting17_viewfrm = new reporting17_view();
                reporting17_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.turnstatus = 5;
                reporting17_viewfrm.ipadress = ipadress;
                reporting17_viewfrm.ShowDialog();
            }


            if (reporintNo == 20)
            {
                reporting17_view reporting17_viewfrm = new reporting17_view();
                reporting17_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.turnstatus = 4;
                reporting17_viewfrm.ipadress = ipadress;
                reporting17_viewfrm.ShowDialog();
            }


            if (reporintNo == 21)
            {
                reporting17_view reporting17_viewfrm = new reporting17_view();
                reporting17_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting17_viewfrm.turnstatus = 3;
                reporting17_viewfrm.ipadress = ipadress;
                reporting17_viewfrm.ShowDialog();
            }

            if (reporintNo == 22)
            {
                reporting19_view reporting19_viewfrm = new reporting19_view();
                reporting19_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting19_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting19_viewfrm.paienttype = int.Parse(PaientStatus_comboBox.SelectedValue.ToString());
                reporting19_viewfrm.zarib = zarib;
              
                reporting19_viewfrm.ipadress = ipadress;
                reporting19_viewfrm.ShowDialog();
            }


            if (reporintNo == 24)
            {
                reporting22_view reporting22_viewfrm = new reporting22_view();
                reporting22_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting22_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                reporting22_viewfrm.ipadress = ipadress;
                reporting22_viewfrm.ShowDialog();
            }

            if (reporintNo == 23)
            {
                reporting24_view reporting24_viewfrm = new reporting24_view();
                reporting24_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting24_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                
                reporting24_viewfrm.ipadress = ipadress;
                reporting24_viewfrm.ShowDialog();
            }

            if (reporintNo == 25)
            {
                reporting25_view reporting25_viewfrm = new reporting25_view();
                reporting25_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting25_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting25_viewfrm.ipadress = ipadress;
                reporting25_viewfrm.ShowDialog();
            }


            if (reporintNo == 26)
            {
                reporting26_view reporting26_viewfrm = new reporting26_view();
                reporting26_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting26_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting26_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                reporting26_viewfrm.ipadress = ipadress;
                reporting26_viewfrm.ShowDialog();
            }



            
            if (reporintNo == 27)
            {
                reporting23_view reporting23_viewfrm = new reporting23_view();
                reporting23_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting23_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting23_viewfrm.zarib = zarib;
                reporting23_viewfrm.ipadress = ipadress;
                reporting23_viewfrm.ShowDialog();
            }

            if (reporintNo == 28)
            {
                Report_health_1_F  Report_health_1_Frm = new Report_health_1_F();
                Report_health_1_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Report_health_1_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Report_health_1_Frm.ipadress = ipadress;
                Report_health_1_Frm.ShowDialog();
            }


            if (reporintNo == 29)
            {
                Report_health_2_F  Report_health_2_Frm = new Report_health_2_F();
                Report_health_2_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Report_health_2_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Report_health_2_Frm.ipadress = ipadress;
                Report_health_2_Frm.ShowDialog();
            }


            if (reporintNo == 30)
            {
                Report_health_3_F Report_health_3_Frm = new Report_health_3_F();
                 Report_health_3_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                 Report_health_3_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                 Report_health_3_Frm.ipadress = ipadress;
                 Report_health_3_Frm.ShowDialog();
            }

            if (reporintNo == 31)
            {
                Report_health_4_F Report_health_4_Frm = new Report_health_4_F();
                 Report_health_4_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                 Report_health_4_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                 Report_health_4_Frm.fromage = persianDateTimePicker4.Value.Year - int.Parse(numericUpDown2.Value.ToString());
                 Report_health_4_Frm.endage = persianDateTimePicker4.Value.Year - int.Parse(numericUpDown1.Value.ToString());

                Report_health_4_Frm.ipadress = ipadress;
                Report_health_4_Frm.ShowDialog();
            }


            if (reporintNo == 32)
            {
                reporting32_view reporting32_viewfrm = new reporting32_view();
                reporting32_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting32_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting32_viewfrm.turnstatus = 3;
                reporting32_viewfrm.ipadress = ipadress;
                reporting32_viewfrm.ShowDialog();
            }

            if (reporintNo == 33)
            {
                reporting33_view reporting33_viewfrm = new reporting33_view();
                reporting33_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting33_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting33_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                reporting33_viewfrm.groupcode = int.Parse(Group_Services_comboBox.SelectedValue.ToString());
                reporting33_viewfrm.zarib = zarib;
                reporting33_viewfrm.ipadress = ipadress;
                reporting33_viewfrm.ShowDialog();
            }

            if (reporintNo == 34)
            {
                reporting34_view reporting34_viewfrm = new reporting34_view();
                reporting34_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting34_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");                
                reporting34_viewfrm.ipadress = ipadress;
                reporting34_viewfrm.ShowDialog();
            }


            if (reporintNo == 35)
            {
                reporting35_view reporting35_viewfrm = new reporting35_view();
                reporting35_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting35_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting35_viewfrm.ipadress = ipadress;
                reporting35_viewfrm.ShowDialog();
            }

            if (reporintNo == 36)
            {
                reporting36_view reporting36_viewfrm = new reporting36_view();
                reporting36_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting36_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting36_viewfrm.ipadress = ipadress;
                reporting36_viewfrm.ShowDialog();
            }


            if (reporintNo == 77)
            {

                DLUtilsobj.screenobj.xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zarib,1);
                SqlDataReader DataSource1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.screenobj.Dbconnset(false);

                //..............................

                DLUtilsobj.screenobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zarib,1);
                SqlDataReader DataSource;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("dentistxml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {


                    XmlWrt.WriteStartElement("NonXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("VisitDate", DataSource["VisitDate"].ToString());
                    XmlWrt.WriteElementString("Shift", DataSource["Shift"].ToString());
                    XmlWrt.WriteElementString("MedicalService", DataSource["MedicalService"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.screenobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "dentistxml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */

                saveFileDialog1.FileName = "dentistxml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<NonXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<VisitDate>" + DataSource["VisitDate"].ToString() + "</VisitDate>");
                        tw.WriteLine("<Shift>" + DataSource["Shift"].ToString() + "</Shift>");
                        tw.WriteLine("<MedicalService>" + DataSource["MedicalService"].ToString() + "</MedicalService>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</NonXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "dentistxml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.screenobj.Dbconnset(false);
            }


            if (reporintNo == 78)
            {
                DLUtilsobj.screenobj.reporting37(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zarib);
                SqlDataReader DataSource1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.screenobj.Dbconnset(false);
            }

            if (reporintNo == 79)
            {
                reporting79_view reporting79_viewfrm = new reporting79_view();
                reporting79_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting79_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting79_viewfrm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                reporting79_viewfrm.shiftcode = int.Parse(Shift_comboBox.SelectedValue.ToString());                 
                reporting79_viewfrm.zarib = zarib;
                reporting79_viewfrm.ipadress = ipadress;
                reporting79_viewfrm.ShowDialog();
            }

            if (reporintNo == 80)
            {
                reporting80_view reporting80_viewfrm = new reporting80_view();
                reporting80_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting80_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting80_viewfrm.ipadress = ipadress;
                reporting80_viewfrm.ShowDialog();
            }

            if (reporintNo == 81)
            {
                reporting81_view reporting81_viewfrm = new reporting81_view();
                reporting81_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting81_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting81_viewfrm.fromage = (numericUpDown1.Value.ToString());  
                reporting81_viewfrm.toage = (numericUpDown2.Value.ToString());    
                reporting81_viewfrm.ipadress = ipadress;
                reporting81_viewfrm.ShowDialog();
            }

            if (reporintNo == 82)
            {
                reporting82_view reporting82_viewfrm = new reporting82_view();
                reporting82_viewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                reporting82_viewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                reporting82_viewfrm.fromage = (numericUpDown1.Value.ToString());  
                reporting82_viewfrm.toage = (numericUpDown2.Value.ToString());    
                reporting82_viewfrm.ipadress = ipadress;
                reporting82_viewfrm.ShowDialog();
            }


        }

        private void Tariffkind_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Tariffkind_comboBox.SelectedIndex < (Tariffkind_comboBox.Items.Count-1))
            {
                year = int.Parse(persianDateTimePicker2.Value.ToString().Substring(0, 4));
                if (DLUtilsobj.tariffsobj.selecttariffs(year, Tariffkind_comboBox.SelectedIndex) == false)
                {
                    MessageBox.Show("تعرفه سال " + year.ToString() + "برای این نوع تعرفه تعریف نگردیده است.", "Information", MessageBoxButtons.OK);
                    zarib = 0;
                }
                else
                {
 
                    SqlDataReader DataSource;
                    DLUtilsobj.tariffsobj.Dbconnset(true);
                    DataSource = DLUtilsobj.tariffsobj.tariffsclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    zarib = int.Parse(DataSource["Zarib"].ToString());
                    DLUtilsobj.tariffsobj.Dbconnset(false);
                }

            }
            else if (Tariffkind_comboBox.SelectedIndex == Tariffkind_comboBox.Items.Count-1)
          {
              zarib = 0;

          }

        }

        private void navBarItem50_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            label2.Visible = true;
            Doctors_Combobox.Visible = true;
            label7.Text = "نام خدمت";
            label7.Visible = true;
            Group_Services_comboBox.Visible = false;
            Services_combox.Visible = true;            
            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 2;
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;
            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            Group_Services_comboBox.Visible = false;
            label7.Visible = false;
            Services_combox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;

            reporintNo = 1;
        }

        private void navBarItem32_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label16.Text = "نوع بیمار";
            label16.Visible = true;
            paienttype_comboBox.Visible = true;
            PaientStatus_comboBox.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            Group_Services_comboBox.Visible = false;
            label7.Visible = false;
            Services_combox.Visible = false;
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 5;

        }

        private void navBarItem42_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 6;

        }

        private void navBarItem36_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 7;
        }

        private void navBarItem37_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 8;
        }

        private void navBarItem38_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 9;
        }

        private void navBarItem39_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 10;
        }

        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            
            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            groupBox4.Visible = true;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 11;
        }


        private void navBarItem41_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            groupBox4.Visible = true;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 13;
        }

        private void navBarItem51_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            groupBox3.Location = new Point(351,220);            
            groupBox3.Visible = true;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 12;

        }

        private void navBarItem53_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            radGridView3.Visible = true;
            Shift_comboBox.Visible = false;
            reporintNo = 14;

        }

        private void navBarItem40_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 15;
        }

        private void navBarItem43_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 16;

        }

        private void navBarItem44_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 17;
        }

        private void navBarItem45_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 18;
        }

        private void navBarItem55_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 19;
        }

        private void navBarItem56_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;

            reporintNo = 20;
        }

        private void navBarItem46_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 21;
        }

        private void navBarItem31_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label16.Text = "وضعیت  بیمار";
            label16.Visible = true;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = true;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 22;
        }

        private void navBarItem65_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 23;
        }

        private void navBarItem63_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 24;
        }

        private void navBarItem61_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 25;
        }

        private void navBarItem64_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 26;
        }

        private void navBarItem66_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 27;
        }

        private void navBarItem67_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 28;
        }

        private void navBarItem68_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 29;
        }

        private void navBarItem69_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 30;
        }

        private void navBarItem70_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 31;
        }

  
        private void navBarItem72_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 32;
        }

        private void navBarItem73_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;
            label7.Text = "گروه خدمت";
            label7.Visible = true;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = true;
            Group_Services_comboBox.Location = Services_combox.Location;
            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 33;
        }

        private void navBarItem74_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;            
            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;
            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 34;
        }

        private void navBarItem75_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 35;
        }

        private void navBarItem76_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 36;
        }

        private void navBarIte77_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            radGridView3.Visible = true;
            Shift_comboBox.Visible = false;
            reporintNo = 77;
        }

        private void navBarItem78_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            radGridView3.Visible = true;
            Shift_comboBox.Visible = false;
            reporintNo = 78;
        }

        private void navBarItem79_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = true;
            Doctors_Combobox.Visible = true;
            label7.Text = "  شیفت  ";
            label7.Visible = true;
            Group_Services_comboBox.Visible = false;
            Services_combox.Visible = false;
            label15.Visible = true;
            Tariffkind_comboBox.Visible = true;
            Group_Services_comboBox.Visible = false;
            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Location = Services_combox.Location;
            Shift_comboBox.Visible = true;            
            reporintNo = 79;
        }

        private void navBarItem80_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Visible = false;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 80;
       
        }

        private void navBarItem81_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;
            groupBox3.Location = new Point(351, 90); 
            groupBox3.Visible = true;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 81;
        
        }

        private void navBarItem82_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label2.Visible = false;
            Doctors_Combobox.Visible = false;

            label7.Visible = false;
            Services_combox.Visible = false;
            Group_Services_comboBox.Visible = false;

            label16.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;

            groupBox4.Visible = false;

            groupBox3.Location = new Point(351, 90); 
            groupBox3.Visible = true;

            label15.Visible = false;
            Tariffkind_comboBox.Visible = false;
            radGridView3.Visible = false;
            Shift_comboBox.Visible = false;
            reporintNo = 82;
      
        }

        

        }
    }

