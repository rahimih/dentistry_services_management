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
      
    public partial class CostConfirm_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        public InsertServices_F InsertServices_Frm;

        public int a,i;
        public int usercodexml;
        public int temppersno;
        public int idemployeetype;
        public string idperson, ipadress;
        public int relationorderno;
        public int persno;
        string insertdate;
        Int64 costconfirmcodee;
        public int fk_nesbat;
        public int Pk_ValidCenterZone;
        public int id;
        string tempcommentdate;
        string tempservicesdate;
        string visitdate,costconfirmdate;
        Int64 costconfirmheadcode;
        public bool edit = false;
        public int doctorscode;
        Boolean closing = false;
        public CostConfirm_f()
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
  

        private void CostConfirm_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            InsertServices_Frm.Dispose();
            if (closing == true)
            {
                InsertServices_Frm.Dentaltooth_frm.Dispose();
            }
            
            this.Dispose();
            
        }

        private void CostConfirm_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            InsertServices_Frm = new InsertServices_F();


            doctors_comboBox.DisplayMember = "Lname";
            doctors_comboBox.ValueMember = "usercode";
            doctors_comboBox.DataSource = dentistryEntitiescontext.TblUsers.Where(p => p.GroupCode == 2).ToList();
            if (edit == true)
            { 
                doctors_comboBox.SelectedValue = doctorscode;
                doctors_comboBox.Enabled = false;
            }

        }

    
        private void edit_Button_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;

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

        private void comboBox2_KeyDown_1(object sender, KeyEventArgs e)
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
                {
                    label22.Text = DataSource["BirthDate"].ToString();
               
                    label25.Text = ((persianDateTimePicker2.Value.Year) - (int.Parse(label22.Text.Substring(0, 4)))).ToString();
                }
                else
                    label25.Text = "-";


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



                if (DataSource["TblValidCenterZone_Id"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["TblValidCenterZone_Id"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0)
            {
                MessageBox.Show("جهت تایید هزینه لطفا مراجعه کننده را انتخاب نمائید","خطا",MessageBoxButtons.OK);
            }
            else
            {
                closing = true;
           // InsertServices_Frm.usercodexml = usercodetemp;
            InsertServices_Frm.kind = 2;
            InsertServices_Frm.insertForm = 1;
            InsertServices_Frm.fkvdfamily = int.Parse(comboBox2.SelectedValue.ToString());
         
            DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(30));
            InsertServices_Frm.Fromdateeng_dateTimePicker.Value = result;
            InsertServices_Frm.persianDateTimePicker1.Value = Fromdateeng_dateTimePicker.Value;
            InsertServices_Frm.visitdate = InsertServices_Frm.persianDateTimePicker1.Value.ToString("yyyy/MM/dd");

            InsertServices_Frm.ShowDialog();


            listView1.Items.Clear();
            foreach (ListViewItem item in InsertServices_Frm.listView1.Items)
            {
                listView1.Items.Add((ListViewItem)item.Clone());
             
            }


            }
       
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

            else if (comboBox2.Items.Count > 0)
            { 

                if (listView1.Items.Count==0)
                  MessageBox.Show(" لیست خدمات را وارد نمائید", "warning", MessageBoxButtons.OK);
                else
                { 

           visitdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"); 
            costconfirmdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            costconfirmheadcode = DLUtilsobj.costconfirmobj.InsertCostconfirm_head(idperson, temppersno, int.Parse(comboBox2.SelectedValue.ToString()), visitdate, Doctorsname_comboBox.Text, costconfirmdate, DateTime.Now.ToShortTimeString(), int.Parse(doctors_comboBox.SelectedValue.ToString()), usercodexml, Environment.MachineName);
            
               i = 0;
               while (i <= listView1.Items.Count - 1)
               {
                   DLUtilsobj.costconfirmobj.InsertCostconfirm_Detail(costconfirmheadcode,int.Parse(listView1.Items[i].SubItems[2].Text), byte.Parse(listView1.Items[i].SubItems[1].Text));
                   i = i + 1;
               }

              // DLUtilsobj.recipeobj.InsertdoctorsService(idperson, temppersno, int.Parse(comboBox2.SelectedValue.ToString()), 33, 100, int.Parse(doctors_comboBox.SelectedValue.ToString()), 0, 0, 0, 1, usercodexml, visitdate, DateTime.Now.ToShortTimeString(), Environment.MachineName);
               MessageBox.Show(" تایید هزینه بیمار فوق ثبت گردید.", "information", MessageBoxButtons.OK);
               listView1.Items.Clear();
               InsertServices_Frm.listView1.Items.Clear();
               if (edit == true)
                   this.Close();
              }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void Doctorsname_comboBox_KeyDown(object sender, KeyEventArgs e)
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

        private void doctors_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
