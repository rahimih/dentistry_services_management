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
    public partial class ReferOut_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public ReferOut_printview_F ReferOut_printview_Frm;
        public Int64 referoutcode;
        byte ReferCauseCode=0;
        public string ipadressp;                
        public int usercodexml;
        int temppersno;
        public int idemployeetype;
        public string idperson;
        public int relationorderno;
        public int persno;               
        public int fk_nesbat;
        public int Pk_ValidCenterZone;
        public int id;
        public int doctorscode;
        public ReferOut_F()
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
            richTextBox1.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox1.Clear();
            ReferCauseCode = 0;
           
            DoctorsCode_comboBox.SelectedIndex = 0;
                    
            return true;
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    temppersno = int.Parse(textBox1.Text);
                    comboBox1.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                    comboBox1.DisplayMember = "fullname2";
                    comboBox1.ValueMember = "Pk_vdfamily";
                    SendKeys.Send("{tab}");


                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(comboBox1.SelectedValue.ToString()));
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
                {
                    label22.Text = DataSource["BirthDate"].ToString();
                    label25.Text = ((ServicesdatepersianDateTimePicker.Value.Year) - (int.Parse(label22.Text.Substring(0, 4)))).ToString();
                }
                else
                    label25.Text = "-";


                label23.Text = DataSource["persno"].ToString();
                persno = int.Parse(DataSource["persno"].ToString());
                idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                if (idemployeetype == 1)
                {
                    label24.Text = "شاغل";
                    
                }
                if (idemployeetype == 5)
                {
                    label24.Text = "بازنشسته";
                    
                }

                if (DataSource["id"] != DBNull.Value)
                    id = int.Parse(DataSource["id"].ToString());
                else
                    id = 0;

                if ((idemployeetype == 1) && (id == 28))
                    


                if (DataSource["TblValidCenterZone_Id"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["TblValidCenterZone_Id"].ToString());
                else
                    Pk_ValidCenterZone = 0;

                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60) && (id == 28))
                    


                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60) && (id != 28))
                    


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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ReferOut_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            ReferOut_printview_Frm = new ReferOut_printview_F();
        
            DoctorsCode_comboBox.DisplayMember = "Lname";
            DoctorsCode_comboBox.ValueMember = "usercode";

            DoctorsCode_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            
            textBox1.Focus();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
              if (comboBox1.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

              if (checkBox1.Checked==true)
                 ReferCauseCode=1;
            else if (checkBox2.Checked==true)
                 ReferCauseCode=2;
             else if (checkBox3.Checked==true)
                 ReferCauseCode=3;
            else  if (checkBox4.Checked==true)
                 ReferCauseCode=4;

                if (ReferCauseCode==0)
                {
                    MessageBox.Show("لطفا علت ار جاع را مشخص نمائید", "warning", MessageBoxButtons.OK);
                }

            else if ((comboBox1.Items.Count > 0) && (ReferCauseCode > 0))
            {
                //****************
                referoutcode = DLUtilsobj.referingobj.insert_referout(idperson, persno, int.Parse(comboBox1.SelectedValue.ToString()), label26.Text, ServicesdatepersianDateTimePicker.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), int.Parse(DoctorsCode_comboBox.SelectedValue.ToString()), richTextBox1.Text, ReferCauseCode, textBox2.Text, usercodexml, Environment.MachineName);
                MessageBox.Show(" فرم ارجاع با شماره " + " ' " + referoutcode.ToString() + " ' " + " صادر گردید " , "information", MessageBoxButtons.OK);
                cleardata();

                ReferOut_printview_Frm.referoutcode = referoutcode;
                ReferOut_printview_Frm.ipadress = ipadressp;
                ReferOut_printview_Frm.ShowDialog();
                textBox1.Focus();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                textBox2.Enabled = false;
            }
        

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                textBox2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                textBox2.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                textBox2.Enabled = true;
            }
        }
    }
}
