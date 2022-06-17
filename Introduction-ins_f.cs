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
using DLibraryUtils;


namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Introduction_ins_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public Dentaltooth_f Dentaltooth_frm;
        public introductionprint introductionprint_frm;
        public InsertServices_F InsertServices_Frm;
        public string ipadress;
        int i,j,k,j2;
        public int a;
        public int usercodexml;
        int temppersno;
        public int idemployeetype;
        public string idperson;
        public int relationorderno;
        public int persno;
        string insertdate;
        Int64 introductioncode;
        public int fk_nesbat;
        public int Pk_ValidCenterZone;
        public int id;
        string tempcommentdate;
        string tempservicesdate;
        byte toohid=100;
        public byte selectedindexk;
        public byte kind = 0;
        public bool edit = false;
        public int doctorscode;
        public Int32 turnid=0;
        Boolean closing = false;
        public Introduction_ins_f()
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
            OutCenter_comboBox.SelectedIndex = 0;
          
            DoctorsCode_comboBox.SelectedIndex = 0;
            Kind_comboBox.SelectedIndex = 0;
            
            ServicesdatepersianDateTimePicker.Enabled = false;
            
            /*
            j=0;
                while (j <= checkedListBox2.Items.Count - 1)
                {
                    checkedListBox1.SetItemChecked(int.Parse(checkedListBox2.Items[j].ToString()), false);
                    j = j + 1;
                }
             */ 

            return true;
        }
    
        private void Introduction_ins_f_Load(object sender, EventArgs e)
        {

          
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            introductionprint_frm = new introductionprint();
            InsertServices_Frm = new InsertServices_F();

            OutCenter_comboBox.DisplayMember = "outcentername";
            OutCenter_comboBox.ValueMember = "outcentercode";

          

            Kind_comboBox.DisplayMember = "IntroductionKind1";
            Kind_comboBox.ValueMember = "IntroductionKindCode";

            DoctorsCode_comboBox.DisplayMember = "Lname";
            DoctorsCode_comboBox.ValueMember = "usercode";


            OutCenter_comboBox.DataSource = dentistryEntitiescontext.outcenters.OrderBy(p => p.outcenterName).ToList();
          
            Kind_comboBox.DataSource = dentistryEntitiescontext.IntroductionKinds.OrderBy(p => p.IntroductionkindCode).ToList();
            DoctorsCode_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();

            if (edit == true)
            {
                DoctorsCode_comboBox.SelectedValue = doctorscode;
                DoctorsCode_comboBox.Enabled = false;
            }
      
         
            /*
            DLUtilsobj.introductionsobj.selectcommnet();
            SqlDataReader DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(true);
            DataSource = DLUtilsobj.introductionsobj.introductionsclientdataset.ExecuteReader();

            i = 0; 
            while (DataSource.Read())
         {
            checkedListBox1.Items.Add(DataSource["Comment"].ToString(), Convert.ToBoolean(DataSource["status"].ToString()));
            if (checkedListBox1.GetItemCheckState(i).ToString() !="Checked")
                checkedListBox2.Items.Add(i, false);
            i = i + 1;
          }

            
            DLUtilsobj.introductionsobj.Dbconnset(false);
             */ 
          
            textBox1.Focus();



            insertdate = IntroductionpersianDateTimePicker.Value.ToString("yyyy/MM/dd");

   
        }

        private void Introduction_ins_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            InsertServices_Frm.Dispose();
            if (closing == true)
            {
                InsertServices_Frm.Dentaltooth_Introducion_frm.Dispose();
            }

            this.Dispose();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            if (comboBox1.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            if (listView2.Items.Count== 0)
                MessageBox.Show("هیچ خدمتی جهت این معرفی نامه ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

            else if ((comboBox1.Items.Count > 0) && (listView2.Items.Count> 0))
            {
                tempservicesdate = ServicesdatepersianDateTimePicker.Value.ToString("yyyy/MM/dd");


                introductioncode = DLUtilsobj.introductionsobj.Insertintroduction_head(idperson, persno, int.Parse(comboBox1.SelectedValue.ToString()), label26.Text, int.Parse(OutCenter_comboBox.SelectedValue.ToString()), insertdate, DateTime.Now.ToShortTimeString(), int.Parse(DoctorsCode_comboBox.SelectedValue.ToString()), int.Parse(Kind_comboBox.SelectedValue.ToString()), usercodexml,turnid, Environment.MachineName);
                
                //-------------------- insert detail
                j = 0;
                k = listView2.Items.Count;
                while (j < k)
                {
                    DLUtilsobj.introductionsobj.Insertintroduction_Detail(introductioncode, int.Parse(listView2.Items[j].SubItems[2].Text), byte.Parse(listView2.Items[j].SubItems[1].Text), byte.Parse(listView2.Items[j].SubItems[3].Text), byte.Parse(listView2.Items[j].SubItems[4].Text), byte.Parse(listView2.Items[j].SubItems[5].Text), byte.Parse(listView2.Items[j].SubItems[6].Text));
                    j = j + 1;
                }

                //---------------------- insert comment
                /*
                i = 0;
                while (i <= checkedListBox1.Items.Count - 1)
                {

                    if (checkedListBox1.GetItemCheckState(i).ToString() == "Checked")
                        DLUtilsobj.introductionsobj.InsertIntroductionComment(introductioncode, i + 1);
                    i = i + 1;
                }
                 */ 

                MessageBox.Show(" معرفی نامه با شماره " + " ' " + introductioncode.ToString() + " ' " + " صادر گردید " + "\n" + "لطفا فرم معرفی نامه کارکنان  " + " ' " + Kind_comboBox.Text + " ' " + "را در پرینتر قرار دهید.", "information", MessageBoxButtons.OK);

                cleardata();
                listView2.Items.Clear();
                InsertServices_Frm.listView2.Items.Clear();

                introductionprint_frm.introductioncode = introductioncode;
                introductionprint_frm.ipadress = ipadress;
                introductionprint_frm.ShowDialog();
                textBox1.Focus();

                

            }
        }

        private void OutCenter_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ServicesCode_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void DoctorsCode_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void kind_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
               if (ServicesdatepersianDateTimePicker.Enabled==true)
                  SendKeys.Send("{tab}");
            }
        }

   

        public void textBox1_KeyDown(object sender, KeyEventArgs e)
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

  
        public void comboBox1_Leave(object sender, EventArgs e)
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
                persno =int.Parse(DataSource["persno"].ToString());
                idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                if (idemployeetype == 1)
                {
                    label24.Text = "شاغل";
                    Kind_comboBox.SelectedIndex = 0;
                }
                if (idemployeetype == 5)
                {
                    label24.Text = "بازنشسته";
                    Kind_comboBox.SelectedIndex = 1;
                }

                if (DataSource["id"] != DBNull.Value)
                    id = int.Parse(DataSource["id"].ToString());
                else
                    id = 0;

                if ((idemployeetype == 1) && (id==28))
                    Kind_comboBox.SelectedIndex = 3;


                if (DataSource["TblValidCenterZone_Id"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["TblValidCenterZone_Id"].ToString());
                else
                    Pk_ValidCenterZone = 0;

                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60) && (id==28))
                    Kind_comboBox.SelectedIndex = 3;


                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60) && (id!=28)) 
                    Kind_comboBox.SelectedIndex = 2;


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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click(toolStripMenuItem2, e);
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            //.......................

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

    

        

        private void OutCenter_comboBox_Enter(object sender, EventArgs e)
        {
            if (kind==1)
                Kind_comboBox.SelectedIndex = selectedindexk;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("جهت صدور معرفی نامه  لطفا مراجعه کننده را انتخاب نمائید", "خطا", MessageBoxButtons.OK);
            }
            else
            {
                closing = true;
                // InsertServices_Frm.usercodexml = usercodetemp;
                InsertServices_Frm.insertForm = 3;
                InsertServices_Frm.fkvdfamily = int.Parse(comboBox1.SelectedValue.ToString());

                DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(30));
                InsertServices_Frm.Fromdateeng_dateTimePicker.Value = result;
                InsertServices_Frm.persianDateTimePicker1.Value = Fromdateeng_dateTimePicker.Value;
                InsertServices_Frm.visitdate = InsertServices_Frm.persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                InsertServices_Frm.listView2.Visible = true;
                InsertServices_Frm.listView1.Visible = false;

                InsertServices_Frm.ShowDialog();


                listView2.Items.Clear();
                foreach (ListViewItem item in InsertServices_Frm.listView2.Items)
                {
                    listView2.Items.Add((ListViewItem)item.Clone());

                }


            }
       
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            j2 = listView2.SelectedItems[0].Index;
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView2.Items.Count > 0)
                    listView2.Items[j2].Remove();
            }
        }

    

    

   

    



    

    
    }
}
