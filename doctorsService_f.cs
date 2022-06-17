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
    public partial class doctorsService_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public InsertRadioServices_F InsertRadioServices_Frm;
        public InsertServices_F InsertServices_Frm;
        public int usercodexml,temppersno,acessleveltemp;
        int yearj, Kindpaient, zarib, feranshiz, Kindpaient2;
        public string ipadress;
        byte statuscode = 1;
        byte kind;
        string currentdate;
        Boolean closing = false;
        int fkvdfamily;
        public DateTime sdate;

        public doctorsService_f()
        {
            InitializeComponent();
        }

        private bool loaddata(int doctorscode, string turndate, byte statuscode,byte kind)
        {

            if (groupBox1.Visible == true)
            {
                usercodexml = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                currentdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            }

            
            DLUtilsobj.recipeobj.selectPaientList(doctorscode, turndate, statuscode,kind);
            SqlDataReader DataSource;
            DLUtilsobj.recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.recipeobj.Recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.recipeobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره نوبت";
                radGridView1.Columns[2].HeaderText = "ساعت مراجعه";
                radGridView1.Columns[3].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[4].HeaderText = "نام مراجعه کننده ";
                radGridView1.Columns[5].HeaderText = "نسبت";
                radGridView1.Columns[6].HeaderText = "نوع";
                radGridView1.Columns[7].HeaderText = "وضعیت استخدام ";
                radGridView1.Columns[8].HeaderText = "علت مراجعه";
                radGridView1.Columns[9].HeaderText = "وضعیت نوبت";
                radGridView1.Columns[10].HeaderText = " تلفن";
                radGridView1.Columns[11].HeaderText = "دندان";
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;
                radGridView1.Columns[17].IsVisible = false;



            }

            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode < 3))
            //if ((radGridView1.RowCount > 0) && (statuscode == 1))
            {

                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertServices_Frm.insertForm = 2;
                InsertServices_Frm.fkvdfamily = fkvdfamily;

                DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(30));
                InsertServices_Frm.Fromdateeng_dateTimePicker.Value = result;
                InsertServices_Frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                InsertServices_Frm.visitdate = InsertServices_Frm.persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                InsertServices_Frm.persianDateTimePicker2.Value = sdate;
                //----------------
                InsertServices_Frm.idperson = radGridView1.CurrentRow.Cells[14].Value.ToString();
                InsertServices_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());
                InsertServices_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertServices_Frm.planvisitcode = int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                InsertServices_Frm.turnno = int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                InsertServices_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                InsertServices_Frm.usercodexml = usercodexml;

                InsertServices_Frm.listView1.Items.Clear();

                InsertServices_Frm.acessleveltemp = acessleveltemp;
                InsertServices_Frm.Del_Button.Visible = true;
                
                InsertServices_Frm.ShowDialog();

               // loaddata(usercodexml, currentdate, statuscode);
            }
        }

        private void doctorsService_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            InsertServices_Frm = new InsertServices_F();
            InsertRadioServices_Frm = new InsertRadioServices_F();
            currentdate=persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            kind = 1;

            loaddata(usercodexml, currentdate, statuscode,kind);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            statuscode = 1;
            loaddata(usercodexml, currentdate, statuscode,kind);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            statuscode = 2;
            loaddata(usercodexml, currentdate, statuscode,kind);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            statuscode = 3;
            loaddata(usercodexml, currentdate, statuscode,kind);
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            //  if ((radGridView1.RowCount > 0) && (statuscode==1))
            {

                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertServices_Frm.insertForm = 2;
                InsertServices_Frm.fkvdfamily = fkvdfamily;

                DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(30));
                InsertServices_Frm.Fromdateeng_dateTimePicker.Value = result;
                InsertServices_Frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                InsertServices_Frm.visitdate = InsertServices_Frm.persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                //----------------
                InsertServices_Frm.idperson = radGridView1.CurrentRow.Cells[14].Value.ToString();
                InsertServices_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());
                InsertServices_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertServices_Frm.planvisitcode = int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                InsertServices_Frm.turnno = int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                InsertServices_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                InsertServices_Frm.usercodexml = usercodexml;
               


                InsertServices_Frm.listView1.Items.Clear();
                
                InsertServices_Frm.ShowDialog();

               // loaddata(usercodexml, currentdate, statuscode);
            }
        }

        private void doctorsService_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            InsertServices_Frm.Dispose();
            if (closing == true)
            {
                InsertServices_Frm.Dentaltooth_frm.Dispose();
            }
            
            this.Dispose();
            
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
    /*
            if ((radGridView1.RowCount > 0))
            {

                Introduction_ins_f Introduction_ins_frm = new Introduction_ins_f();
                Introduction_ins_frm.usercodexml = usercodexml;
                Introduction_ins_frm.ipadress = ipadress;
                //-----------------
                Introduction_ins_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[4].Value.ToString());
                Introduction_ins_frm.textBox1.Enabled = false;

                temppersno = int.Parse(Introduction_ins_frm.textBox1.Text);
                Introduction_ins_frm.comboBox1.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                Introduction_ins_frm.comboBox1.DisplayMember = "fullname2";
                Introduction_ins_frm.comboBox1.ValueMember = "Pk_vdfamily";

                Introduction_ins_frm.comboBox1.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                Introduction_ins_frm.comboBox1.Enabled = false;
              
                //***************
                if (Introduction_ins_frm.comboBox1.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString()));
                    SqlDataReader DataSource;
                    DLUtilsobj.persontblobj.Dbconnset(true);
                    DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    Introduction_ins_frm.label18.Text = DataSource["fullname"].ToString();

                    if (DataSource["NesbatDesc"] != DBNull.Value)
                        Introduction_ins_frm.label19.Text = DataSource["NesbatDesc"].ToString();

                    if (DataSource["companyname"] != DBNull.Value)
                        Introduction_ins_frm.label20.Text = DataSource["companyname"].ToString();

                    if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                        Introduction_ins_frm.label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                    if (DataSource["BirthDate"] != DBNull.Value)
                        Introduction_ins_frm.label22.Text = DataSource["BirthDate"].ToString();

                    Introduction_ins_frm.label23.Text = DataSource["persno"].ToString();
                    Introduction_ins_frm.persno = int.Parse(DataSource["persno"].ToString());
                    Introduction_ins_frm.idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                    if (Introduction_ins_frm.idemployeetype == 1)
                    {
                        Introduction_ins_frm.label24.Text = "شاغل";
                        Introduction_ins_frm.selectedindexk = 0;
                    }
                    if (Introduction_ins_frm.idemployeetype == 5)
                    {
                        Introduction_ins_frm.label24.Text = "بازنشسته";
                        Introduction_ins_frm.selectedindexk = 1;
                    }

                    if (DataSource["id"] != DBNull.Value)
                        Introduction_ins_frm.id = int.Parse(DataSource["id"].ToString());
                    else
                        Introduction_ins_frm.id = 0;

                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.id == 28))
                        Introduction_ins_frm.selectedindexk = 3;


                    if (DataSource["Pk_ValidCenterZone"] != DBNull.Value)
                        Introduction_ins_frm.Pk_ValidCenterZone = int.Parse(DataSource["Pk_ValidCenterZone"].ToString());
                    else
                        Introduction_ins_frm.Pk_ValidCenterZone = 0;

                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.Pk_ValidCenterZone != 60) && (Introduction_ins_frm.id == 28))
                        Introduction_ins_frm.selectedindexk = 3;


                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.Pk_ValidCenterZone != 60) && (Introduction_ins_frm.id != 28))
                        Introduction_ins_frm.selectedindexk = 2;


                    if (DataSource["RelationOrderNo"] != DBNull.Value)
                        Introduction_ins_frm.relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                    else
                        Introduction_ins_frm.relationorderno = -1;


                    if (Introduction_ins_frm.relationorderno < 10)

                        Introduction_ins_frm.label26.Text = Introduction_ins_frm.label23.Text + "-0" + Introduction_ins_frm.relationorderno.ToString();
                    else
                        Introduction_ins_frm.label26.Text = Introduction_ins_frm.label23.Text + "-" + Introduction_ins_frm.relationorderno.ToString();


                    if (DataSource["idperson"] != DBNull.Value)
                        Introduction_ins_frm.idperson = DataSource["idperson"].ToString();
                    else
                        Introduction_ins_frm.idperson = "";

                    if (DataSource["Fk_Nesbat"] != DBNull.Value)
                        Introduction_ins_frm.fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                    else
                        Introduction_ins_frm.fk_nesbat = -1;


                    //............................

                    DLUtilsobj.persontblobj.Dbconnset(false);

                }

                //****************
                Introduction_ins_frm.kind = 1;
                Introduction_ins_frm.OutCenter_comboBox.Focus();
                Introduction_ins_frm.ShowDialog();
                
                
              
            }*/

            edit_Button_Click(radGridView1, e);
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode < 3))
            // if ((radGridView1.RowCount > 0) && (statuscode == 1))
            
            {

                Introduction_ins_f Introduction_ins_frm = new Introduction_ins_f();
                Introduction_ins_frm.usercodexml = usercodexml;
                Introduction_ins_frm.ipadress = ipadress;
                Introduction_ins_frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                //-----------------
                Introduction_ins_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                Introduction_ins_frm.textBox1.Enabled = false;

                temppersno = int.Parse(Introduction_ins_frm.textBox1.Text);
                Introduction_ins_frm.comboBox1.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                Introduction_ins_frm.comboBox1.DisplayMember = "fullname2";
                Introduction_ins_frm.comboBox1.ValueMember = "Pk_vdfamily";

                Introduction_ins_frm.comboBox1.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                Introduction_ins_frm.comboBox1.Enabled = false;

                //***************
                if (Introduction_ins_frm.comboBox1.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()));
                    SqlDataReader DataSource;
                    DLUtilsobj.persontblobj.Dbconnset(true);
                    DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    Introduction_ins_frm.label18.Text = DataSource["fullname"].ToString();

                    if (DataSource["NesbatDesc"] != DBNull.Value)
                        Introduction_ins_frm.label19.Text = DataSource["NesbatDesc"].ToString();

                    if (DataSource["companyname"] != DBNull.Value)
                        Introduction_ins_frm.label20.Text = DataSource["companyname"].ToString();

                    if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                        Introduction_ins_frm.label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                    if (DataSource["BirthDate"] != DBNull.Value)
                        Introduction_ins_frm.label22.Text = DataSource["BirthDate"].ToString();

                    Introduction_ins_frm.label23.Text = DataSource["persno"].ToString();
                    Introduction_ins_frm.persno = int.Parse(DataSource["persno"].ToString());
                    Introduction_ins_frm.idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                    if (Introduction_ins_frm.idemployeetype == 1)
                    {
                        Introduction_ins_frm.label24.Text = "شاغل";
                        Introduction_ins_frm.selectedindexk = 0;
                    }
                    if (Introduction_ins_frm.idemployeetype == 5)
                    {
                        Introduction_ins_frm.label24.Text = "بازنشسته";
                        Introduction_ins_frm.selectedindexk = 1;
                    }

                    if (DataSource["id"] != DBNull.Value)
                        Introduction_ins_frm.id = int.Parse(DataSource["id"].ToString());
                    else
                        Introduction_ins_frm.id = 0;

                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.id == 28))
                        Introduction_ins_frm.selectedindexk = 3;


                    if (DataSource["TblValidCenterZone_Id"] != DBNull.Value)
                        Introduction_ins_frm.Pk_ValidCenterZone = int.Parse(DataSource["TblValidCenterZone_Id"].ToString());
                    else
                        Introduction_ins_frm.Pk_ValidCenterZone = 0;

                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.Pk_ValidCenterZone != 60) && (Introduction_ins_frm.id == 28))
                        Introduction_ins_frm.selectedindexk = 3;


                    if ((Introduction_ins_frm.idemployeetype == 1) && (Introduction_ins_frm.Pk_ValidCenterZone != 60) && (Introduction_ins_frm.id != 28))
                        Introduction_ins_frm.selectedindexk = 2;


                    if (DataSource["RelationOrderNo"] != DBNull.Value)
                        Introduction_ins_frm.relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                    else
                        Introduction_ins_frm.relationorderno = -1;


                    if (Introduction_ins_frm.relationorderno < 10)

                        Introduction_ins_frm.label26.Text = Introduction_ins_frm.label23.Text + "-0" + Introduction_ins_frm.relationorderno.ToString();
                    else
                        Introduction_ins_frm.label26.Text = Introduction_ins_frm.label23.Text + "-" + Introduction_ins_frm.relationorderno.ToString();


                    if (DataSource["idperson"] != DBNull.Value)
                        Introduction_ins_frm.idperson = DataSource["idperson"].ToString();
                    else
                        Introduction_ins_frm.idperson = "";

                    if (DataSource["Fk_Nesbat"] != DBNull.Value)
                        Introduction_ins_frm.fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                    else
                        Introduction_ins_frm.fk_nesbat = -1;


                    //............................

                    DLUtilsobj.persontblobj.Dbconnset(false);

                }

                //****************
                Introduction_ins_frm.kind = 1;
                Introduction_ins_frm.OutCenter_comboBox.Focus();
                Introduction_ins_frm.edit = true;
                if (groupBox1.Visible == true)
                 Introduction_ins_frm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                else
                Introduction_ins_frm.doctorscode = usercodexml;

                Introduction_ins_frm.ServicesdatepersianDateTimePicker.Value = persianDateTimePicker1.Value;
                Introduction_ins_frm.IntroductionpersianDateTimePicker.Value = persianDateTimePicker1.Value;
                Introduction_ins_frm.ShowDialog();



            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode == 1))
            {
                DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 2);
                loaddata(usercodexml, currentdate, 1,kind);
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
             if ((radGridView1.RowCount > 0) && (statuscode <3 ))
            {

                MedicalRest_f MedicalRest_frm = new MedicalRest_f();
                MedicalRest_frm.usercodexml = usercodexml;
                MedicalRest_frm.ipadress = ipadress;
                //-----------------
                MedicalRest_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                MedicalRest_frm.textBox1.Enabled = false;

                temppersno = int.Parse(MedicalRest_frm.textBox1.Text);
                MedicalRest_frm.comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                MedicalRest_frm.comboBox2.DisplayMember = "fullname2";
                MedicalRest_frm.comboBox2.ValueMember = "Pk_vdfamily";

                MedicalRest_frm.comboBox2.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                MedicalRest_frm.comboBox2.Enabled = false;
              
                //***************
                if (MedicalRest_frm.comboBox2.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()));
                    SqlDataReader DataSource;
                    DLUtilsobj.persontblobj.Dbconnset(true);
                    DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    MedicalRest_frm.label18.Text = DataSource["fullname"].ToString();

                    if (DataSource["NesbatDesc"] != DBNull.Value)
                        MedicalRest_frm.label19.Text = DataSource["NesbatDesc"].ToString();

                    if (DataSource["companyname"] != DBNull.Value)
                        MedicalRest_frm.label20.Text = DataSource["companyname"].ToString();

                    if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                        MedicalRest_frm.label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                    if (DataSource["BirthDate"] != DBNull.Value)
                        MedicalRest_frm.label22.Text = DataSource["BirthDate"].ToString();

                    MedicalRest_frm.label23.Text = DataSource["persno"].ToString();
                    MedicalRest_frm.persno = int.Parse(DataSource["persno"].ToString());
                    MedicalRest_frm.idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                    if (MedicalRest_frm.idemployeetype == 1)
                    {
                        MedicalRest_frm.label24.Text = "شاغل";
                        
                    }
                    if (MedicalRest_frm.idemployeetype == 5)
                    {
                        MedicalRest_frm.label24.Text = "بازنشسته";
                        
                    }

                 


                    if (DataSource["RelationOrderNo"] != DBNull.Value)
                        MedicalRest_frm.relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                    else
                        MedicalRest_frm.relationorderno = -1;


                    if (MedicalRest_frm.relationorderno < 10)

                        MedicalRest_frm.label26.Text = MedicalRest_frm.label23.Text + "-0" + MedicalRest_frm.relationorderno.ToString();
                    else
                        MedicalRest_frm.label26.Text = MedicalRest_frm.label23.Text + "-" + MedicalRest_frm.relationorderno.ToString();


                    if (DataSource["idperson"] != DBNull.Value)
                        MedicalRest_frm.idperson = DataSource["idperson"].ToString();
                    else
                        MedicalRest_frm.idperson = "";

                    if (DataSource["Fk_Nesbat"] != DBNull.Value)
                        MedicalRest_frm.fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                    else
                        MedicalRest_frm.fk_nesbat = -1;


                    //............................

                    DLUtilsobj.persontblobj.Dbconnset(false);

                }

                //****************

                MedicalRest_frm.EDIT2 = true;
                if (groupBox1.Visible == true)
                    MedicalRest_frm.DOCTORSCODE = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                else
                    MedicalRest_frm.DOCTORSCODE = usercodexml;

                 //MedicalRest_frm.DOCTORSCODE = usercodexml;
                 MedicalRest_frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                 MedicalRest_frm.persianDateTimePicker2.Value = persianDateTimePicker1.Value;
                 MedicalRest_frm.persianDateTimePicker3.Value = persianDateTimePicker1.Value;
                 MedicalRest_frm.persianDateTimePicker4.Value = persianDateTimePicker1.Value;
                 MedicalRest_frm.ShowDialog();
               
            
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (radGridView1.RowCount > 0)
            if ((radGridView1.RowCount > 0) && (statuscode <3 ))
            {

                CostConfirm_f CostConfirm_frm = new CostConfirm_f();
                CostConfirm_frm.usercodexml = usercodexml;
                CostConfirm_frm.ipadress = ipadress;
                //-----------------
                CostConfirm_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                CostConfirm_frm.textBox1.Enabled = false;
                CostConfirm_frm.temppersno = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());

                temppersno = int.Parse(CostConfirm_frm.textBox1.Text);
                CostConfirm_frm.comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                CostConfirm_frm.comboBox2.DisplayMember = "fullname2";
                CostConfirm_frm.comboBox2.ValueMember = "Pk_vdfamily";

                CostConfirm_frm.comboBox2.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                CostConfirm_frm.comboBox2.Enabled = false;

                //***************
                if (CostConfirm_frm.comboBox2.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()));
                    SqlDataReader DataSource;
                    DLUtilsobj.persontblobj.Dbconnset(true);
                    DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    CostConfirm_frm.label18.Text = DataSource["fullname"].ToString();

                    if (DataSource["NesbatDesc"] != DBNull.Value)
                        CostConfirm_frm.label19.Text = DataSource["NesbatDesc"].ToString();

                    if (DataSource["companyname"] != DBNull.Value)
                        CostConfirm_frm.label20.Text = DataSource["companyname"].ToString();

                    if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                        CostConfirm_frm.label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                    if (DataSource["BirthDate"] != DBNull.Value)
                        CostConfirm_frm.label22.Text = DataSource["BirthDate"].ToString();

                    CostConfirm_frm.label23.Text = DataSource["persno"].ToString();
                    CostConfirm_frm.persno = int.Parse(DataSource["persno"].ToString());
                    CostConfirm_frm.idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                    if (CostConfirm_frm.idemployeetype == 1)
                    {
                        CostConfirm_frm.label24.Text = "شاغل";

                    }
                    if (CostConfirm_frm.idemployeetype == 5)
                    {
                        CostConfirm_frm.label24.Text = "بازنشسته";

                    }




                    if (DataSource["RelationOrderNo"] != DBNull.Value)
                        CostConfirm_frm.relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                    else
                        CostConfirm_frm.relationorderno = -1;


                    if (CostConfirm_frm.relationorderno < 10)

                        CostConfirm_frm.label26.Text = CostConfirm_frm.label23.Text + "-0" + CostConfirm_frm.relationorderno.ToString();
                    else
                        CostConfirm_frm.label26.Text = CostConfirm_frm.label23.Text + "-" + CostConfirm_frm.relationorderno.ToString();


                    if (DataSource["idperson"] != DBNull.Value)
                        CostConfirm_frm.idperson = DataSource["idperson"].ToString();
                    else
                        CostConfirm_frm.idperson = "";

                    if (DataSource["Fk_Nesbat"] != DBNull.Value)
                        CostConfirm_frm.fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                    else
                        CostConfirm_frm.fk_nesbat = -1;


                    //............................

                    DLUtilsobj.persontblobj.Dbconnset(false);

                }

                //****************

                CostConfirm_frm.edit = true;

                if (groupBox1.Visible == true)
                    CostConfirm_frm.doctorscode = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                else
                    CostConfirm_frm.doctorscode = usercodexml;

                //CostConfirm_frm.doctorscode = usercodexml;
                CostConfirm_frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                CostConfirm_frm.persianDateTimePicker2.Value = persianDateTimePicker1.Value;
                CostConfirm_frm.ShowDialog();


            }
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Del_Button_Click(radGridView1,e);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button1_Click(radGridView1, e);
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button2_Click(radGridView1, e);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            cancel_button_Click(radGridView1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (radGridView1.RowCount > 0)
            if ((radGridView1.RowCount > 0) && (statuscode < 3 ))
            {

                Consult_f Consult_frm = new Consult_f();
                Consult_frm.usercodexml = usercodexml;
                Consult_frm.ipadress = ipadress;
                //-----------------
                Consult_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                Consult_frm.textBox1.Enabled = false;

                temppersno = int.Parse(Consult_frm.textBox1.Text);
                Consult_frm.comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                Consult_frm.comboBox2.DisplayMember = "fullname2";
                Consult_frm.comboBox2.ValueMember = "Pk_vdfamily";

                Consult_frm.comboBox2.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                Consult_frm.comboBox2.Enabled = false;

                //***************
                if (Consult_frm.comboBox2.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()));
                    SqlDataReader DataSource;
                    DLUtilsobj.persontblobj.Dbconnset(true);
                    DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                    DataSource.Read();
                    //...........................

                    Consult_frm.label18.Text = DataSource["fullname"].ToString();

                    if (DataSource["NesbatDesc"] != DBNull.Value)
                        Consult_frm.label19.Text = DataSource["NesbatDesc"].ToString();

                    if (DataSource["companyname"] != DBNull.Value)
                        Consult_frm.label20.Text = DataSource["companyname"].ToString();

                    if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                        Consult_frm.label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                    if (DataSource["BirthDate"] != DBNull.Value)
                        Consult_frm.label22.Text = DataSource["BirthDate"].ToString();

                    Consult_frm.label23.Text = DataSource["persno"].ToString();
                    Consult_frm.persno = int.Parse(DataSource["persno"].ToString());
                    Consult_frm.idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                    if (Consult_frm.idemployeetype == 1)
                    {
                        Consult_frm.label24.Text = "شاغل";

                    }
                    if (Consult_frm.idemployeetype == 5)
                    {
                        Consult_frm.label24.Text = "بازنشسته";

                    }




                    if (DataSource["RelationOrderNo"] != DBNull.Value)
                        Consult_frm.relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                    else
                        Consult_frm.relationorderno = -1;


                    if (Consult_frm.relationorderno < 10)

                        Consult_frm.label26.Text = Consult_frm.label23.Text + "-0" + Consult_frm.relationorderno.ToString();
                    else
                        Consult_frm.label26.Text = Consult_frm.label23.Text + "-" + Consult_frm.relationorderno.ToString();


                    if (DataSource["idperson"] != DBNull.Value)
                        Consult_frm.idperson = DataSource["idperson"].ToString();
                    else
                        Consult_frm.idperson = "";

                    if (DataSource["Fk_Nesbat"] != DBNull.Value)
                        Consult_frm.fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                    else
                        Consult_frm.fk_nesbat = -1;


                    //............................

                    DLUtilsobj.persontblobj.Dbconnset(false);

                }

                //****************

                Consult_frm.EDIT2 = true;

                if (groupBox1.Visible == true)
                    Consult_frm.DOCTORSCODE = int.Parse(Doctors_Combobox.SelectedValue.ToString());
                else
                    Consult_frm.DOCTORSCODE = usercodexml;
              
                //Consult_frm.DOCTORSCODE = usercodexml;
                Consult_frm.DoctorsCode_comboBox.Enabled = false;
                Consult_frm.persianDateTimePicker4.Value = persianDateTimePicker1.Value;
                Consult_frm.ShowDialog();


            }
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button3_Click(radGridView1, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            PrintPreviewDialog dialog = new PrintPreviewDialog();

            radPrintDocument1.RightHeader = "نام پزشک : دکتر   " + Doctors_Combobox.Text;
            radPrintDocument1.MiddleHeader = "تاریخ ویزیت : " + persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            dialog.Document = this.radPrintDocument1; 
            dialog.StartPosition = FormStartPosition.CenterScreen; 
            dialog.ShowDialog(); 
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            loaddata(int.Parse(Doctors_Combobox.SelectedValue.ToString()), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), statuscode,kind);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if ((radGridView1.RowCount > 0) && (statuscode < 3))
            {

                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());

                Screen_F Screen_Frm = new Screen_F();
                Screen_Frm.usercodexml = usercodexml;
                Screen_Frm.ipadress = ipadress;
                Screen_Frm.fkvdfamily = fkvdfamily;
                Screen_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());
                Screen_Frm.idperson = radGridView1.CurrentRow.Cells[14].Value.ToString();
                Screen_Frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Screen_Frm.turn_no =int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                Screen_Frm.planvst =int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                Screen_Frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                if (groupBox1.Visible==true)
                    Screen_Frm.Del_Button.Enabled=true;

            /*    if (DLUtilsobj.screenobj.selectdent_screen2(fkvdfamily) == true)
                { 
                    Screen_Frm.edit_Button.Enabled = true;
                   
                }
                else
                    Screen_Frm.Ins_Button.Enabled = true;
                */

                Screen_Frm.ShowDialog();
            }
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button5_Click(radGridView1, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode == 3))
            {
                DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 1);
                loaddata(usercodexml, currentdate, 1,kind);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode != 3))
            {
                DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 3);
                loaddata(usercodexml, currentdate, 1,kind);
            }
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSearchServices_f PaientSearchServices_frm = new PaientSearchServices_f();
            PaientSearchServices_frm.ShowDialog();
        }

  

        private void navBarItem7_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            kind = 1;
            loaddata(usercodexml, currentdate, statuscode, kind);
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            kind = 2;
            loaddata(usercodexml, currentdate, statuscode, kind);
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            kind = 3;
            loaddata(usercodexml, currentdate, statuscode, kind);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ((radGridView1.RowCount > 0) && (statuscode < 3))
            //if ((radGridView1.RowCount > 0) && (statuscode == 1))
            {

                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertRadioServices_Frm.insertForm = 2;
                InsertRadioServices_Frm.fkvdfamily = fkvdfamily;

                DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(30));
                InsertRadioServices_Frm.Fromdateeng_dateTimePicker.Value = result;
                InsertRadioServices_Frm.persianDateTimePicker1.Value = persianDateTimePicker1.Value;
                InsertRadioServices_Frm.visitdate = InsertRadioServices_Frm.persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                InsertRadioServices_Frm.persianDateTimePicker2.Value = sdate;
                //----------------
                InsertRadioServices_Frm.idperson = radGridView1.CurrentRow.Cells[14].Value.ToString();
                InsertRadioServices_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());
                InsertRadioServices_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                InsertRadioServices_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                InsertRadioServices_Frm.validcenterzone = int.Parse(radGridView1.CurrentRow.Cells[16].Value.ToString());
                InsertRadioServices_Frm.usercodexml = usercodexml;

                InsertRadioServices_Frm.listView2.Items.Clear();

                InsertRadioServices_Frm.acessleveltemp = acessleveltemp;
                InsertRadioServices_Frm.Del_Button.Visible = true;

                InsertRadioServices_Frm.ShowDialog();

                // loaddata(usercodexml, currentdate, statuscode);
            }
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button2_Click_1(navBarItem16, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            //--------------
            yearj = int.Parse(persianDateTimePicker1.Value.ToString().Substring(0, 4));
            Kindpaient = int.Parse(radGridView1.CurrentRow.Cells[17].Value.ToString());
            
            if ((Kindpaient <= 4) || (Kindpaient > 80))
                Kindpaient2 = 1;

            if (Kindpaient == 5) 
                Kindpaient2 = 5;

            if (Kindpaient == 65)
                Kindpaient2 = 65;

            if (Kindpaient == 75)
                Kindpaient2 = 75;

            if (DLUtilsobj.tariffsobj.selecttariffcash(yearj, Kindpaient2) == false)
            {
                zarib = 0;
                feranshiz = 0;
            }
            else
            {

                SqlDataReader DataSource;
                DLUtilsobj.tariffsobj.Dbconnset(true);
                DataSource = DLUtilsobj.tariffsobj.tariffsclientdataset.ExecuteReader();
                DataSource.Read();                
                zarib = int.Parse(DataSource["Zarib"].ToString());
                feranshiz = int.Parse(DataSource["feranshiz"].ToString());
                DLUtilsobj.tariffsobj.Dbconnset(false);
                //--------------
            }

            //*********************چاپ نوبت            
            PrintRecipe_cash_f PrintRecipe_cash_frm = new PrintRecipe_cash_f();
            PrintRecipe_cash_frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()); 
            PrintRecipe_cash_frm.zarib = zarib;
            PrintRecipe_cash_frm.feranshiz = feranshiz;
            PrintRecipe_cash_frm.ipadress = ipadress;
            PrintRecipe_cash_frm.ShowDialog();
            //**********************
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Report6_health6_F Report6_health6_Frm = new Report6_health6_F();
            Report6_health6_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
            Report6_health6_Frm.ipadress = ipadress;            
            Report6_health6_Frm.ShowDialog();

        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Report6_health6_2_F Report6_health6_2_Frm = new Report6_health6_2_F();
            Report6_health6_2_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
            Report6_health6_2_Frm.ipadress = ipadress;
            Report6_health6_2_Frm.ShowDialog();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Report6_health6_child_F Report6_health6_child_Frm = new Report6_health6_child_F();
            Report6_health6_child_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
            Report6_health6_child_Frm.ipadress = ipadress;
            Report6_health6_child_Frm.ShowDialog();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Screen_print_F Screen_print_Frm = new Screen_print_F();
            Screen_print_Frm.ipadress = ipadress;
            Screen_print_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
            Screen_print_Frm.pk_dent_Screen2 = "0";
            Screen_print_Frm.kind = 1;
            Screen_print_Frm.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Screen_print2_F Screen_print2_Frm = new Screen_print2_F();
            Screen_print2_Frm.ipadress = ipadress;
            Screen_print2_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
            Screen_print2_Frm.pk_dent_Screen2 = "0";
            Screen_print2_Frm.kind = 2;
            Screen_print2_Frm.ShowDialog();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ins_Button_Click(navBarItem23, e);
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button6_Click(navBarItem25,e);
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button7_Click(navBarItem24, e);
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button4_Click(navBarItem26, e);
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button8_Click(navBarItem17, e);
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //--------------- مشاهده مدارک اسکن شده 
        }
       

    }
}
