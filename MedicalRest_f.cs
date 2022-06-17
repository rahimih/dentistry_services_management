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
    public partial class MedicalRest_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
       
        public int a, i;
        public int usercodexml;
        public int temppersno, relationorderno;
        public int idemployeetype;
        public string idperson,ipadress;
        public int persno;
        string insertdate;
        public int medicalrestcode;
        public int fk_nesbat;
        public int Pk_ValidCenterZone;
        public int id;
        public bool EDIT = false;
        public bool EDIT2 = false;
        public int DOCTORSCODE;
        public MedicalRest_f()
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

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void MedicalRest_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
      

            doctors_comboBox.DisplayMember = "Lname";
            doctors_comboBox.ValueMember = "usercode";
            doctors_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            if (EDIT == true)
                doctors_comboBox.SelectedValue = DOCTORSCODE;

            if (EDIT2 == true)
            {
                doctors_comboBox.SelectedValue = DOCTORSCODE;
                doctors_comboBox.Enabled = false;
            }
            comboBox1.SelectedIndex = 0;

        }

        private void MedicalRest_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
          if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

          else if (comboBox2.Items.Count > 0)
          {
              Medicalrest Medicalresttable = new Medicalrest

              {
                 Idperson = idperson,
                 Persno = persno,
                 Fkvdfamily = int.Parse(comboBox2.SelectedValue.ToString()),
                 currentdate = persianDateTimePicker4.Value.ToString("yyyy/MM/dd"),
                 Currenttime =DateTime.Now.ToShortTimeString(),
                 Firstrestdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                 Endrestdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                 Returnworkdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd"),
                 Icd10code = int.Parse(comboBox1.SelectedIndex.ToString()),
                 Countofrest =  Convert.ToByte(numericUpDown1.Value),
                 Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString()),
                 usercode = usercodexml,
                 comment =textBox2.Text,
                 deleted = false
              };

              dentistryEntitiescontext.Medicalrests.Add(Medicalresttable);
              dentistryEntitiescontext.SaveChanges();
              MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
              cleardata();
          }
        }

        private void doctors_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

            Medicalrest Medicalresttable = dentistryEntitiescontext.Medicalrests.First(i => i.MedicalrestCode == medicalrestcode);

            if (MessageBox.Show("تغییرات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Medicalresttable.Firstrestdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Medicalresttable.Endrestdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                Medicalresttable.Returnworkdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Medicalresttable.Icd10code = int.Parse(comboBox1.SelectedIndex.ToString());
                Medicalresttable.Countofrest = Convert.ToByte(numericUpDown1.Value);
                Medicalresttable.Doctorscode = int.Parse(doctors_comboBox.SelectedValue.ToString());
                Medicalresttable.comment = textBox2.Text;
                dentistryEntitiescontext.SaveChanges();
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 51, Environment.MachineName, medicalrestcode);
                this.Close();
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
