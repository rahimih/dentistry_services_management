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
    public partial class ConsultView_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int usercodexml, temppersno;
        public string ipadress;
        byte serachkind = 1;
        public ConsultView_f()
        {
            InitializeComponent();
        }

        private bool loaddata(string string1, string string2)
        {
            DLUtilsobj.consultobj.Consultselect(string1, string2);
            SqlDataReader DataSource;
            DLUtilsobj.consultobj.Dbconnset(true);
            DataSource = DLUtilsobj.consultobj.Consultclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.consultobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام بیمار";
                radGridView1.Columns[3].HeaderText = " جهت ";
                radGridView1.Columns[4].HeaderText = "پزشک صادر کننده  ";
                radGridView1.Columns[5].HeaderText = "  دندان";
                radGridView1.Columns[6].HeaderText = " پزشک مشاور  ";
                radGridView1.Columns[7].HeaderText = " تاریخ صدور  ";
                radGridView1.Columns[8].HeaderText = "  ساعت صدور  ";
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;

            }

            return true;
        }

        private bool loaddata_persno(int persno)
        {
            DLUtilsobj.consultobj.Consultselect_persno(persno);
            SqlDataReader DataSource;
            DLUtilsobj.consultobj.Dbconnset(true);
            DataSource = DLUtilsobj.consultobj.Consultclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.consultobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام بیمار";
                radGridView1.Columns[3].HeaderText = " جهت ";
                radGridView1.Columns[4].HeaderText = "پزشک صادر کننده  ";
                radGridView1.Columns[5].HeaderText = "  دندان";
                radGridView1.Columns[6].HeaderText = " پزشک مشاور  ";
                radGridView1.Columns[7].HeaderText = " تاریخ صدور  ";
                radGridView1.Columns[8].HeaderText = "  ساعت صدور  ";
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;

            }

            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Consult_f Consult_frm = new Consult_f();
            Consult_frm.usercodexml = usercodexml;
            Consult_frm.ShowDialog();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.consultobj.deleteconsult(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 55, Environment.MachineName, a);
                    if (serachkind==1)
                         loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    else if (serachkind==2)
                        loaddata_persno(int.Parse(textBox1.Text));

                }
            }
        }

        private void MedicalRestView_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void MedicalRestView_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            serachkind = 1;
            loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else

                serachkind = 2;
                loaddata_persno(int.Parse(textBox1.Text));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

                if ((radGridView1.RowCount > 0))
            {

                Consult_f Consult_frm = new Consult_f();
                Consult_frm.usercodexml = usercodexml;
                Consult_frm.ipadress = ipadress;
                //-----------------
                Consult_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
                Consult_frm.textBox1.Enabled = false;

                temppersno = int.Parse(Consult_frm.textBox1.Text);
                Consult_frm.comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                Consult_frm.comboBox2.DisplayMember = "fullname2";
                Consult_frm.comboBox2.ValueMember = "Pk_vdfamily";

                Consult_frm.comboBox2.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                Consult_frm.comboBox2.Enabled = false;
              
                //***************
                if (Consult_frm.comboBox2.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString()));
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

                Consult_frm.DOCTORSCODE = int.Parse(radGridView1.CurrentRow.Cells[10].Value.ToString());
                Consult_frm.consultdoctorscode = int.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString());
                Consult_frm.servicescode = int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                Consult_frm.comboBox1.SelectedIndex = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                Consult_frm.edittoohid = byte.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());
                Consult_frm.consultcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                 
               
                Consult_frm.Ins_Button.Enabled = false;
                Consult_frm.edit_Button.Visible = true;
                Consult_frm.cancel_button.Visible = true;
                Consult_frm.cancel_button.Enabled = true;
                Consult_frm.EDIT = true;
                Consult_frm.ShowDialog();

                      if (serachkind==1)
                         loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    else if (serachkind==2)
                        loaddata_persno(int.Parse(textBox1.Text));
                
                
              
            }
        }


        } 

        }
    

