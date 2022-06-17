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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Recipet_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public PrintRecipe_f PrintRecipe_Frm;
        SqlDataReader DataSource;
        public Dentaltooth_f Dentaltooth_frm;
        int str1 = 0;
        public int usercodexml;
        int temppersno, fkvdfamily, idemployeetype;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate;
        int id, planvist_code, doctorscode;
        byte toothid=100;
        string currentdate, turndate, currentdatet;
        string recipeError, recipeError2;
        string fromtime;
        byte intervaltime;
        bool okrecipte1, okrecipte2, okrecipte3, okrecipte4, okrecipte5;
        Int64 turnid;
        public string ipadress;
        byte kind = 2;
        public int accessleveltemp;
        int age,age1,specialityKindCode;
        public byte showform=1;
        public string recipedatecheck;
        string IDJobRelated,tdate,doctorsname,familydentist;
        string perdate, nextdate;
    
        public Recipet_f()
        {
            InitializeComponent();
        }
        private bool cleardata()
        {
            //------------clear Data
            label18.Text = "-";
            label19.Text = "-";
            label20.Text = "-";
            label21.Text = "-";
            label22_Phone.Text = "-";
            label23.Text = "-";
            label24.Text = "-";
            label22.Text = "-";
            label26.Text = "-";
            textBox1.Text = "";
            Clinic_textBox.Text = "";
            Doctorsname_textBox.Text = "";
            textBox2.Text = "";
            toothid = 100;
            paienttype_comboBox.SelectedIndex = 0;
            paientstatus_comboBox.SelectedIndex = 0;
            takekindrecipe_comboBox.SelectedIndex = 0;
            textBox1.Text = "";
            loaddent_tooth(100);
            comboBox1.SelectedIndex = -1;
            label36.Text = "-";
            label37.Text = "-";
            label40.Text = "-";
            textBox1.Focus();
            return true;
        }

        private bool loaddata(string fromdate,byte shiftcode,byte kind)
        {
            DLUtilsobj.planvisitobj.selectplanvisit(fromdate,shiftcode,kind);
            SqlDataReader DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(true);
            DataSource = DLUtilsobj.planvisitobj.planvisitclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام کلینیک";
                radGridView1.Columns[2].HeaderText = "نام پزشک";
                radGridView1.Columns[3].HeaderText = "نوع";
                radGridView1.Columns[4].HeaderText = "تاریخ";
                radGridView1.Columns[5].HeaderText = "شیفت";
                radGridView1.Columns[6].HeaderText = "ظرفیت پذیرش";
                radGridView1.Columns[7].HeaderText = "تعداد نوبت های داده شده";
                radGridView1.Columns[8].IsVisible = false;
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[0].Width = 30;
                radGridView1.Columns[1].Width = 30;
                radGridView1.Columns[2].Width = 95;
                radGridView1.Columns[3].Width = 40;
                radGridView1.Columns[4].Width = 60;
                radGridView1.Columns[5].Width = 30;
                radGridView1.Columns[6].Width = 20;
                radGridView1.Columns[7].Width = 20;




            }

            return true;
        }

        private bool loaddent_tooth(int toothid)
        {
            DLUtilsobj.planvisitobj.selectdentaltooth(toothid);
            SqlDataReader DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(true);
            DataSource = DLUtilsobj.planvisitobj.planvisitclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.planvisitobj.Dbconnset(false);
                if (radGridView2.RowCount > 0)
            
                radGridView2.Columns[0].HeaderText = "---";

            return true;
        }

        private void SetLogin(ConnectionInfo connectionInfo, ReportDocument reportdocument)
        {
            Tables tables = reportdocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo TbLogonInfo = table.LogOnInfo;
                TbLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(TbLogonInfo);
            }
        }

        private void printreport()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "dentistry";
            connectionInfo.UserID = "dentistryuser";
            connectionInfo.Password = "dentistrynothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\Recipe_print.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = turnid;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //crystalReportViewer1.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            cryRpt.PrintToPrinter(1, true, 0, 0);
            //crystalReportViewer1.Refresh();  
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    temppersno = int.Parse(textBox1.Text);
                    comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                    comboBox2.DisplayMember = "fullname2";
                    comboBox2.ValueMember = "Pk_vdfamily";
                    SendKeys.Send("{tab}");

            

                }
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
            {
                DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(comboBox2.SelectedValue.ToString()));
                SqlDataReader DataSource;
                DLUtilsobj.persontblobj.Dbconnset(true);
                DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                DataSource.Read();
                //...........................

                label18.Text = DataSource["fullname"].ToString();

                fkvdfamily = int.Parse(DataSource["Pk_vdfamily"].ToString());

                if (DataSource["NesbatDesc"] != DBNull.Value)
                    label19.Text = DataSource["NesbatDesc"].ToString();

                if (DataSource["companyname"] != DBNull.Value)
                    label20.Text = DataSource["companyname"].ToString();

                if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                    label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                if (DataSource["BirthDate"] != DBNull.Value)
                {
                    label22.Text = DataSource["BirthDate"].ToString();
                    age1 = int.Parse(label22.Text.Substring(0, 4));
                    age = persianDateTimePicker3.Value.Year - age1;
                }
                else
                    age = 200;

                if (DataSource["mobile"] != DBNull.Value)
                    label22_Phone.Text = DataSource["mobile"].ToString();

                label23.Text = DataSource["persno"].ToString();
                persno = int.Parse(DataSource["persno"].ToString());
                idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                if (idemployeetype == 1)
                { 
                    label24.Text = "شاغل";
                    paienttype_comboBox.SelectedIndex = 0;

                }
                if (idemployeetype == 5)
                { 
                    label24.Text = "بازنشسته";
                    paienttype_comboBox.SelectedIndex = 4;
                 }

                if (idemployeetype == 65)
                    { 
                        label24.Text = "غیر شرکتی";
                        paienttype_comboBox.SelectedIndex = 5;
                    }

                if (idemployeetype == 75)
                {
                    label24.Text = "غیر شرکتی";
                    paienttype_comboBox.SelectedIndex = 6;
                }

                    if (idemployeetype == 85) 
                    {
                        label24.Text = " شرکتی";
                        paienttype_comboBox.SelectedIndex = 7;
                    }

                    if (idemployeetype == 100)
                    {
                        label24.Text = " شرکتی";
                        paienttype_comboBox.SelectedIndex = 8;
                    }

                    if (DataSource["IDJobRelated"] != DBNull.Value)
                        IDJobRelated = DataSource["IDJobRelated"].ToString();
                    if (IDJobRelated == "-1")
                    {
                        paienttype_comboBox.SelectedValue = 4;
                        paientstatus_comboBox.SelectedValue = 4;
                    }
               
                if (DataSource["id"] != DBNull.Value)
                    id = int.Parse(DataSource["id"].ToString());
                else
                    id = 0;

                if (DataSource["fk_ValidCenter"] != DBNull.Value)
                    fk_ValidCenter = int.Parse(DataSource["fk_ValidCenter"].ToString());
                else
                    fk_ValidCenter = 0;

                if (DataSource["TblValidCenterZone_Id"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["TblValidCenterZone_Id"].ToString());
                else
                    Pk_ValidCenterZone = 0;

                Validcenterzone_combobox.SelectedValue = Pk_ValidCenterZone;

                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60))
                paienttype_comboBox.SelectedIndex=2;


                if (DataSource["RelationOrderNo"] != DBNull.Value)
                    relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                else
                    relationorderno = -1;


                if (relationorderno < 10)

                    label26.Text = label23.Text + "-0" + relationorderno.ToString();
                else
                    label26.Text = label23.Text + "-" + relationorderno.ToString();


                if (DataSource["idperson"] != DBNull.Value)
                    idperson = DataSource["idperson"].ToString();
                else
                    idperson = "";

                if (DataSource["Fk_Nesbat"] != DBNull.Value)
                    fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                else
                    fk_nesbat = -1;

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);
                 
                //********************
                familydentist= DLUtilsobj.familydentistobj.search_familydentistperson(fkvdfamily);
                if (familydentist=="-1")
                {
                    comboBox1.SelectedIndex = -1;
                    label36.Text = "-";
                    label37.Text = "-";
                    label40.Text = "-";
                }

                else
                {
                    comboBox1.SelectedValue = int.Parse(familydentist);
                    currentdatet = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                    DLUtilsobj.familydentistobj.checkFkvdfamilyRecipe_familydentist(fkvdfamily, familydentist, currentdate,1,out perdate);
                    DLUtilsobj.familydentistobj.checkFkvdfamilyRecipe_familydentist(fkvdfamily, familydentist, currentdate,2,out nextdate);
                    label36.Text = perdate;
                    label40.Text = nextdate;
                    label37.Text = comboBox1.Text;
                }

                /*currentdatet = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                recipeError2 = DLUtilsobj.recipeobj.checkFkvdfamilyRecipe(fkvdfamily, persno, currentdatet, 0,out tdate,out doctorsname);
                label36.Text = tdate;
                label37.Text = doctorsname;
                 */ 
                //**************                 
            }

        }

        private void Recipet_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            PrintRecipe_Frm = new PrintRecipe_f();
            PrintRecipe_Frm.ipadress = ipadress;
  
            Shift_comboBox.DisplayMember = "Shiftname";  
            Shift_comboBox.ValueMember = "Shiftcode";
            
            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";
            
            paientstatus_comboBox.DisplayMember = "PaientStatusName";
            paientstatus_comboBox.ValueMember = "PaientStatuscode";
            
            takekindrecipe_comboBox.DisplayMember = "Takekind_RecipeName";
            takekindrecipe_comboBox.ValueMember = "Takekind_RecipeCode";
            
            services_comboBox.DisplayMember = "Recipe_Desc";
            services_comboBox.ValueMember = "RecipeServices_code";

            Validcenterzone_combobox.DisplayMember = "Description";
            Validcenterzone_combobox.ValueMember = "id";

            comboBox1.DisplayMember = "drname";
            comboBox1.ValueMember = "usercode";


            Shift_comboBox.DataSource = dentistryEntitiescontext.Shifts.ToList();
            paientstatus_comboBox.DataSource = dentistryEntitiescontext.PaientStatus.ToList();
            paienttype_comboBox.DataSource = dentistryEntitiescontext.PaientTypes.ToList();
            takekindrecipe_comboBox.DataSource = dentistryEntitiescontext.Takekind_Recipe.ToList();
            services_comboBox.DataSource = dentistryEntitiescontext.RecipeServices.ToList();
            Validcenterzone_combobox.DataSource = dentistryEntitiescontext.Tbl_ValidCenterZone.ToList();
            comboBox1.DataSource = dentistryEntitiescontext.familydentist_view.OrderBy(p => p.drname).ToList();

            services_comboBox.SelectedIndex = 0;

           //********************
            persianDateTimePicker1.Value = persianDateTimePicker3.Value;
            loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),Convert.ToByte(Shift_comboBox.SelectedValue.ToString()),kind);
           //********************

            //-------------------- تغییر به عدم مراجعه در صورت ثبت نشدن خدمات
            //DLUtilsobj.recipeobj.changeNOnPaientReferStatus(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

                   
                     Dentaltooth_frm = new Dentaltooth_f();
                    Dentaltooth_frm.ShowDialog();
                    loaddent_tooth(Dentaltooth_frm.toothid);
                    toothid = Convert.ToByte(Dentaltooth_frm.toothid); 
                    
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void TurnNum_numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Turntime_maskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void services_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void paienttype_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void paientstatus_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker1_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {

            if (recipedatecheck == "Y")
            {
                if ((accessleveltemp > 1) && (persianDateTimePicker1.Value < persianDateTimePicker3.Value))
                {
                    MessageBox.Show("امکان صدور نوبت جهت روزهای قبل وجود ندارد.", "Information", MessageBoxButtons.OK);
                    persianDateTimePicker1.Value = persianDateTimePicker3.Value;
                }
                //********************
                else if (((accessleveltemp > 1) && (persianDateTimePicker1.Value >= persianDateTimePicker3.Value) && (showform == 2)) || ((accessleveltemp == 1) && (showform == 2)))
                    //  else   
                    loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), Convert.ToByte(Shift_comboBox.SelectedValue.ToString()), kind);
            }

            else if (recipedatecheck == "N")
                loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), Convert.ToByte(Shift_comboBox.SelectedValue.ToString()), kind);
                //********************
            
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

             if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

             else if (comboBox2.Items.Count > 0)
             {

                 if (comboBox1.SelectedIndex == -1)
                 {
                     MessageBox.Show("لطفا نام دندان پزشک خانواده را انتخاب نمائید.", "warning", MessageBoxButtons.OK);
                     okrecipte5 = false;
                 }
                 else if (comboBox1.SelectedIndex != -1)
                 {
                     okrecipte5 = true;
                 }
                 
                 if (Clinic_textBox.Text == "")
                     MessageBox.Show("لطفا پزشک مورد نظر را انتخاب کنید.","خطا",MessageBoxButtons.OK);
                 else
                 {
                     okrecipte1 = true;
                     okrecipte2 = true;
                     okrecipte3 = true;
                     okrecipte4 = true;
                 //******************
                     if (DLUtilsobj.recipeobj.CheckDuplicateTurnno(planvist_code,byte.Parse(Turnno_comboBox.SelectedItem.ToString()))==true)
                     { 
                         MessageBox.Show("شماره نوبت تکراری می باشد،لطفا شماره نوبت دیگری را انتخاب نمائید.", "warning", MessageBoxButtons.OK);
                         okrecipte1 = false;
                     }

                     else
                     { 

           /*
                 //چک کردن خطای گذاشته شده
                 recipeError=DLUtilsobj.recipeobj.selectRecipeError(fkvdfamily);
                 if (recipeError != "@@")
                 {
                     MessageBox.Show(recipeError, "warning", MessageBoxButtons.OK);
                      var result = MessageBox.Show("آیا مایل به صدور نوبت می باشید؟","تائیدیه",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                     if (result==DialogResult.Yes)
                         okrecipte2=true;
                     else
                         okrecipte2=false;
                 }
              */
                  //******************
                 // چک کردن نوبت تکراری شخص یا اعضای خانواده
                 currentdatet = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                 recipeError2 = DLUtilsobj.recipeobj.checkFkvdfamilyRecipe(fkvdfamily, persno, currentdatet, 0,out tdate,out doctorsname);
                 if (recipeError2 != "@@")
                 {
                     MessageBox.Show(recipeError2, "warning", MessageBoxButtons.OK);

                       var result = MessageBox.Show("آیا مایل به صدور نوبت می باشید؟","تائیدیه",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                     if (result==DialogResult.Yes)
                         okrecipte3=true;
                     else
                         okrecipte3=false;
                 }
                 //******************
                         // چک کردن مرخصی نبودن پزشک
                 if (DLUtilsobj.planvisitobj.vacationinplanvisit(doctorscode, persianDateTimePicker2.Value.ToString("yyyy/MM/dd")) == true)
                 {
                     MessageBox.Show("پزشک انتخابی در این تاریخ مرخصی می باشد. " + "\n" + persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), "خطا", MessageBoxButtons.OK);
                     okrecipte4 = false;
                 }
                 else
                     okrecipte4 = true;



                 if ((okrecipte1 == true) && (okrecipte2 == true) && (okrecipte3 == true) && (okrecipte4 == true) && (okrecipte5 == true))
                 {
                     currentdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                     turndate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                     turnid = DLUtilsobj.recipeobj.Insertrecipe(idperson, persno,(label26.Text), int.Parse(comboBox2.SelectedValue.ToString()), currentdate, DateTime.Now.ToShortTimeString(), turndate, Turntime_maskedTextBox.Text, Convert.ToByte(Turnno_comboBox.SelectedItem.ToString()), doctorscode, planvist_code, int.Parse(services_comboBox.SelectedValue.ToString()), 1, byte.Parse(Shift_comboBox.SelectedValue.ToString()), toothid, byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()), usercodexml, byte.Parse(takekindrecipe_comboBox.SelectedValue.ToString()), Environment.MachineName,int.Parse(Validcenterzone_combobox.SelectedValue.ToString()),fk_ValidCenter,relationorderno,specialityKindCode,age);
                     if (familydentist != comboBox1.SelectedValue.ToString())
                     {
                         if (familydentist=="-1")
                         {
                             DLUtilsobj.familydentistobj.insert_Family_Dentist_Person(fkvdfamily,persno,comboBox1.SelectedValue.ToString(),currentdate,"-",usercodexml,Environment.MachineName,currentdate,DateTime.Now.ToShortTimeString());
                         }

                         else
                         {
                             DLUtilsobj.familydentistobj.update_Family_Dentist_Person_todate(fkvdfamily, currentdate);
                             DLUtilsobj.familydentistobj.insert_Family_Dentist_Person(fkvdfamily, persno, comboBox1.SelectedValue.ToString(), currentdate, "-", usercodexml, Environment.MachineName, currentdate, DateTime.Now.ToShortTimeString());

                         }
                     }

                     //------------clear Data
                     cleardata();
                     //**************************
                     loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), Convert.ToByte(Shift_comboBox.SelectedValue.ToString()),kind);
                     //***************************

                     //*********************چاپ نوبت
                     //printreport();
                     PrintRecipe_Frm.turnid = turnid;
                     PrintRecipe_Frm.ipadress = ipadress;
                     PrintRecipe_Frm.ShowDialog();                      
                     //**********************
                 } 
               }

                 } //end of else
             }
        }

        private void Shift_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            //********************
            loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), Convert.ToByte(Shift_comboBox.SelectedValue.ToString()),kind);
            //********************
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                //******************
                //تکمیل ظرفیت

                if (DLUtilsobj.recipeobj.selectcountRecipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString())) == (int.Parse(radGridView1.CurrentRow.Cells[6].Value.ToString())))
                {
                    MessageBox.Show(" ظرفیت پذیرش پزشک فوق تکمیل گردیده است", "warning", MessageBoxButtons.OK);
                    Clinic_textBox.Text = "";
                    Doctorsname_textBox.Text = "";
                    textBox2.Text = "";
                }
                else
                {

                    if (DLUtilsobj.planvisitobj.vacationinplanvisit(int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString()), radGridView1.CurrentRow.Cells[4].Value.ToString()) == true)
                    {
                        MessageBox.Show("پزشک انتخابی در این تاریخ مرخصی می باشد. " + "\n" + radGridView1.CurrentRow.Cells[4].Value.ToString(), "خطا", MessageBoxButtons.OK);
                        Clinic_textBox.Text = "";
                        Doctorsname_textBox.Text = "";
                        textBox2.Text = "";
                        
                    }
                    else
                    {

                        planvist_code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                        doctorscode = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                        intervaltime = byte.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString());
                        fromtime = (radGridView1.CurrentRow.Cells[12].Value.ToString());
                        Clinic_textBox.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                        Doctorsname_textBox.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                        textBox2.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                        persianDateTimePicker2.Value = Convert.ToDateTime(radGridView1.CurrentRow.Cells[10].Value.ToString());
                        specialityKindCode = int.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());
                        

                        //-----------------------select turnno
                        Turnno_comboBox.Items.Clear();
                        DLUtilsobj.recipeobj.selectturnno(planvist_code);
                        DLUtilsobj.recipeobj.Dbconnset(true);
                        DataSource = DLUtilsobj.recipeobj.Recipeclientdataset.ExecuteReader();

                        while (DataSource.Read())
                        {
                            Turnno_comboBox.Items.Add(DataSource["Turnno"].ToString());
                        }
                        DLUtilsobj.recipeobj.Dbconnset(false);

                        if (Turnno_comboBox.Items.Count > 0)
                            Turnno_comboBox.SelectedIndex = 0;

                        Turntime_maskedTextBox.Text = DLUtilsobj.recipeobj.recipetime(TimeSpan.Parse(fromtime), intervaltime, byte.Parse(Turnno_comboBox.SelectedItem.ToString()));
                    }
                }
            }
        }

        private void Recipet_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

            recipeError = DLUtilsobj.recipeobj.selectRecipeError(fkvdfamily);
            if (recipeError != "@@")
            {
                MessageBox.Show(recipeError, "warning", MessageBoxButtons.OK);
            }
           
        }

        private void Turnno_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turntime_maskedTextBox.Text = DLUtilsobj.recipeobj.recipetime(TimeSpan.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()), byte.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString()), byte.Parse(Turnno_comboBox.SelectedItem.ToString()));
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                radGridView1_DoubleClick(radGridView1, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                PaientView_F PaientView_Frm = new PaientView_F();
                PaientView_Frm.usercodexml = usercodexml;
                PaientView_Frm.turndate = radGridView1.CurrentRow.Cells[4].Value.ToString();
                PaientView_Frm.doctorscode = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                PaientView_Frm.turnstatus = 0;
                PaientView_Frm.ipadress = ipadress;
                PaientView_Frm.doctorsname = radGridView1.CurrentRow.Cells[2].Value.ToString();
                PaientView_Frm.cdate = radGridView1.CurrentRow.Cells[4].Value.ToString();
                PaientView_Frm.kind = byte.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                PaientView_Frm.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                PaientView_F PaientView_Frm = new PaientView_F();
                PaientView_Frm.usercodexml = usercodexml;
                PaientView_Frm.turndate = radGridView1.CurrentRow.Cells[4].Value.ToString();
                PaientView_Frm.doctorscode = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                PaientView_Frm.turnstatus = 1;
                PaientView_Frm.ipadress = ipadress;
                PaientView_Frm.doctorsname = radGridView1.CurrentRow.Cells[2].Value.ToString();
                PaientView_Frm.cdate = radGridView1.CurrentRow.Cells[4].Value.ToString();
                PaientView_Frm.kind = byte.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                PaientView_Frm.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PaientSearch_f PaientSearch_frm = new PaientSearch_f();
            PaientSearch_frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporting_F Reporting_Frm = new Reporting_F();
            Reporting_Frm.usercodexml = usercodexml;
            Reporting_Frm.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                kind = 2;
            else
                kind = 1;

            loaddata(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), Convert.ToByte(Shift_comboBox.SelectedValue.ToString()), kind);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPerson_F AddPerson_Frm = new AddPerson_F();
            //AddPerson_Frm.usercodexml = usercodexml;
            AddPerson_Frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(Insert,e);
        }

        private void search_Click(object sender, EventArgs e)
        {
            button5_Click(search, e);
        }

        private void list_Click(object sender, EventArgs e)
        {
            button2_Click(list, e);
        }

        private void newPerson_Click(object sender, EventArgs e)
        {
            button6_Click(newPerson, e);
        }

        private void label22_Phone_Click(object sender, EventArgs e)
        {
         if (textBox1.Text!="")
          { 
            ChangePhone_F ChangePhone_Frm = new ChangePhone_F();
            ChangePhone_Frm.Persno_textbox.Text = label18.Text;
            ChangePhone_Frm.textBox1.Text = label22_Phone.Text;
            ChangePhone_Frm.usercode = usercodexml;
            ChangePhone_Frm.IdEmployeeType = idemployeetype;
            ChangePhone_Frm.fkvdfamily = fkvdfamily;
            ChangePhone_Frm.ShowDialog();
            if (ChangePhone_Frm.confirm==true)
             label22_Phone.Text = ChangePhone_Frm.textBox2.Text;

         }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();
        }

        private void persianDateTimePicker1_Enter(object sender, EventArgs e)
        {
            showform = 2;
        }

        private void label37_Click(object sender, EventArgs e)
        {
            if (familydentist!="-1")
            {
                Family_Dentist_Person_view_F Family_Dentist_Person_view_Frm = new Family_Dentist_Person_view_F();
                Family_Dentist_Person_view_Frm.fk_vdfamily = fkvdfamily;
                Family_Dentist_Person_view_Frm.ShowDialog();
            }
        }

  

  
    }
}
