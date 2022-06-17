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
    public partial class Consult_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public Dentaltooth_f Dentaltooth_frm;

        public int a, i;
        public int usercodexml;
        public int temppersno, relationorderno;
        public int idemployeetype;
        public string idperson, ipadress;
        public int persno;
        string insertdate;
        public int consultcode;
        public int fk_nesbat;
        public int Pk_ValidCenterZone;
        public int id;
        public bool EDIT = false;
        public bool EDIT2 = false;
        public int DOCTORSCODE,consultdoctorscode,servicescode;
        byte toohid = 100;
        public byte edittoohid;
        public Consult_f()
        {
            InitializeComponent();
        }
        private bool cleardata()
        {

            label18.Text = "-";
            label19.Text = "-";
            label20.Text = "-";
            label21.Text = "-";
            label22.Text = "-";
            label23.Text = "-";
            label24.Text = "-";
            label25.Text = "-";
            label26.Text = "-";
            textBox1.Text = "";


            return true;
        }

        public bool loaddent_tooth(int toothid)
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

                if (DataSource["NesbatDesc"] != DBNull.Value)
                    label19.Text = DataSource["NesbatDesc"].ToString();

                if (DataSource["companyname"] != DBNull.Value)
                    label20.Text = DataSource["companyname"].ToString();

                if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                    label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                if (DataSource["BirthDate"] != DBNull.Value)
                    label22.Text = DataSource["BirthDate"].ToString();

                label23.Text = DataSource["persno"].ToString();
                persno = int.Parse(DataSource["persno"].ToString());
                idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                if (idemployeetype == 1)

                    label24.Text = "شاغل";

                if (idemployeetype == 5)

                    label24.Text = "بازنشسته";


                if (DataSource["id"] != DBNull.Value)
                    id = int.Parse(DataSource["id"].ToString());
                else
                    id = 0;



                if (DataSource["Pk_ValidCenterZone"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["Pk_ValidCenterZone"].ToString());
                else
                    Pk_ValidCenterZone = 0;




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

            }
        }

        private void Consult_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();


            doctors_comboBox.DisplayMember = "Lname";
            doctors_comboBox.ValueMember = "usercode";
            doctors_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();

            DoctorsCode_comboBox.DisplayMember = "Lname";
            DoctorsCode_comboBox.ValueMember = "usercode";
            DoctorsCode_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();


          /*  ServicesCode_comboBox.DisplayMember = "Services_detail_Name";
            ServicesCode_comboBox.ValueMember = "Services_detail_Code";
            ServicesCode_comboBox.DataSource = dentistryEntitiescontext.Services_detail.OrderBy(p => p.Services_detail_Name).ToList();
           */

            ServicesCode_comboBox.DisplayMember = "Recipe_Desc";
            ServicesCode_comboBox.ValueMember = "RecipeServices_code";
            ServicesCode_comboBox.DataSource = dentistryEntitiescontext.RecipeServices.ToList();
            


            comboBox1.SelectedIndex = 0;

            if (EDIT == true)
            {
                DoctorsCode_comboBox.SelectedValue = DOCTORSCODE;
                doctors_comboBox.SelectedValue = consultdoctorscode;
                ServicesCode_comboBox.SelectedValue = servicescode;
                loaddent_tooth(edittoohid);

            }

              if (EDIT2 == true)
            
                DoctorsCode_comboBox.SelectedValue = DOCTORSCODE;
        }

        private void Consult_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dentaltooth_frm = new Dentaltooth_f();
            Dentaltooth_frm.ShowDialog();
            loaddent_tooth(Dentaltooth_frm.toothid);
            toohid = Convert.ToByte(Dentaltooth_frm.toothid); 
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
             if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

             else if (comboBox2.Items.Count > 0)
             {
               
                 consult consulttable = new consult

                 {
                     Idperson = idperson,
                     Persno = persno,
                     Fkvdfamily = int.Parse(comboBox2.SelectedValue.ToString()),
                     Icd10code = comboBox1.SelectedIndex,
                     Servicescode = int.Parse(ServicesCode_comboBox.SelectedValue.ToString()),
                     ToothID = toohid,
                     introductionDate = persianDateTimePicker4.Value.ToString("yyyy/MM/dd"),
                     introductionTime = DateTime.Now.ToShortTimeString(),
                     ConsultDoctors = int.Parse(doctors_comboBox.SelectedValue.ToString()),
                     Doctorscode = int.Parse(DoctorsCode_comboBox.SelectedValue.ToString()),
                     usercode = usercodexml,
                     deleted =false
                 };

                 dentistryEntitiescontext.consults.Add(consulttable);
                 dentistryEntitiescontext.SaveChanges();
                 MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                 cleardata();
                 if (EDIT2 == true)
                     this.Close();
             }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            consult consulttable = dentistryEntitiescontext.consults.First(i => i.consultCode == consultcode);

            if (MessageBox.Show("تغییرات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {



                     consulttable.Icd10code = comboBox1.SelectedIndex;
                     consulttable.Servicescode = int.Parse(ServicesCode_comboBox.SelectedValue.ToString());
                     consulttable.ToothID = toohid;
                     consulttable.introductionDate = persianDateTimePicker4.Value.ToString("yyyy/MM/dd");
                     consulttable.introductionTime = DateTime.Now.ToShortTimeString();
                     consulttable.ConsultDoctors = int.Parse(doctors_comboBox.SelectedValue.ToString());
                     consulttable.Doctorscode = int.Parse(DoctorsCode_comboBox.SelectedValue.ToString());
                    
                     dentistryEntitiescontext.SaveChanges();
                     DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 54, Environment.MachineName, consultcode);
                     this.Close();
            }
        }
    }
}
