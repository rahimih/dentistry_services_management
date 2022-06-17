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
    public partial class MedicalRestView_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public int usercodexml, temppersno;
        public string ipadress;
        byte serachkind = 1;
        public MedicalRestView_f()
        {
            InitializeComponent();
        }

        private bool loaddata(string string1, string string2)
        {
            DLUtilsobj.medicalrestobj.medicalrestselect(string1, string2);
            SqlDataReader DataSource;
            DLUtilsobj.medicalrestobj.Dbconnset(true);
            DataSource = DLUtilsobj.medicalrestobj.medicalrestlientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.medicalrestobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام بیمار";
                radGridView1.Columns[3].HeaderText = "تاریخ شروع";
                radGridView1.Columns[4].HeaderText = "تاریخ  پایان";
                radGridView1.Columns[5].HeaderText = "تاریخ برگشت به کار ";
                radGridView1.Columns[6].HeaderText = " تعداد روز ";
                radGridView1.Columns[7].HeaderText = " پزشک ارجاع دهنده";
                radGridView1.Columns[8].HeaderText = " تاریخ صدور  ";
                radGridView1.Columns[9].HeaderText = "  ساعت صدور  ";
                radGridView1.Columns[10].HeaderText = "  توضیحات";
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;

            }

            return true;
        }

        private bool loaddata_persno(int persno)
        {
            DLUtilsobj.medicalrestobj.medicalrestselect_persno(persno);
            SqlDataReader DataSource;
            DLUtilsobj.medicalrestobj.Dbconnset(true);
            DataSource = DLUtilsobj.medicalrestobj.medicalrestlientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.medicalrestobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام بیمار";
                radGridView1.Columns[3].HeaderText = "تاریخ شروع";
                radGridView1.Columns[4].HeaderText = "تاریخ  پایان";
                radGridView1.Columns[5].HeaderText = "تاریخ برگشت به کار ";
                radGridView1.Columns[6].HeaderText = " تعداد روز ";
                radGridView1.Columns[7].HeaderText = " پزشک ارجاع دهنده";
                radGridView1.Columns[8].HeaderText = " تاریخ صدور  ";
                radGridView1.Columns[9].HeaderText = "  ساعت صدور  ";
                radGridView1.Columns[10].HeaderText = "  توضیحات";
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;

            }

            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            MedicalRest_f MedicalRest_frm = new MedicalRest_f();
            MedicalRest_frm.usercodexml = usercodexml;
            MedicalRest_frm.ShowDialog();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.medicalrestobj.deletemedicalrest(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 52, Environment.MachineName, a);
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

                MedicalRest_f MedicalRest_frm = new MedicalRest_f();
                MedicalRest_frm.usercodexml = usercodexml;
                MedicalRest_frm.ipadress = ipadress;
                //-----------------
                MedicalRest_frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
                MedicalRest_frm.textBox1.Enabled = false;

                temppersno = int.Parse(MedicalRest_frm.textBox1.Text);
                MedicalRest_frm.comboBox2.DataSource = dentistryEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                MedicalRest_frm.comboBox2.DisplayMember = "fullname2";
                MedicalRest_frm.comboBox2.ValueMember = "Pk_vdfamily";

                MedicalRest_frm.comboBox2.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString());
                MedicalRest_frm.comboBox2.Enabled = false;
              
                //***************
                if (MedicalRest_frm.comboBox2.Items.Count > 0)
                {
                    DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString()));
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


                MedicalRest_frm.persianDateTimePicker1.Value = DLUtilsobj.doctorsworktimeobj.shamsitomiladi(radGridView1.CurrentRow.Cells[4].Value.ToString());
                MedicalRest_frm.persianDateTimePicker2.Value = DLUtilsobj.doctorsworktimeobj.shamsitomiladi(radGridView1.CurrentRow.Cells[3].Value.ToString());
                MedicalRest_frm.persianDateTimePicker3.Value = DLUtilsobj.doctorsworktimeobj.shamsitomiladi(radGridView1.CurrentRow.Cells[5].Value.ToString());

                MedicalRest_frm.comboBox1.SelectedIndex =int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                MedicalRest_frm.numericUpDown1.Value =Convert.ToByte(radGridView1.CurrentRow.Cells[6].Value.ToString());
                MedicalRest_frm.DOCTORSCODE = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                MedicalRest_frm.textBox2.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                MedicalRest_frm.medicalrestcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                 

                MedicalRest_frm.persianDateTimePicker2.Focus();
                MedicalRest_frm.Ins_Button.Enabled = false;
                MedicalRest_frm.edit_Button.Visible = true;
                MedicalRest_frm.cancel_button.Visible = true;
                MedicalRest_frm.EDIT = true;
                MedicalRest_frm.ShowDialog();

                      if (serachkind==1)
                         loaddata(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    else if (serachkind==2)
                        loaddata_persno(int.Parse(textBox1.Text));
                
                
              
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        } 

        }
    

