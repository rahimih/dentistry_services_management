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
    public partial class PaientSearch_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        SqlDataReader DataSource;
        int temppersno, fkvdfamily, idemployeetype;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat;
        string insertdate;
        int id, planvist_code, doctorscode;

        public PaientSearch_f()
        {
            InitializeComponent();

        }
        private bool loaddata(int fkvdfamily,string turndate1,string turndate2)
        {
            DLUtilsobj.Servicesobj.InternalServicesHistory(fkvdfamily, turndate1, turndate2);
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "تاریخ مراجعه";
                radGridView1.Columns[1].HeaderText = "نام پزشک";
                radGridView1.Columns[2].HeaderText = "شماره نوبت";
                radGridView1.Columns[3].HeaderText = "زمان مراجعه";
                radGridView1.Columns[4].HeaderText = "وضعیت نوبت";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = " تاریخ اخذ نوبت";
                radGridView1.Columns[7].HeaderText = " کاربر صادر کننده نوبت";
                //radGridView1.Columns[8].HeaderText = " تاریخ حذف نوبت";
                radGridView1.Columns[8].HeaderText = " کاربر حذف کننده";




            }

            return true;
        }

        private bool loaddata_detail(int recipeid)
        {
            DLUtilsobj.Servicesobj.Internal_detailServicesHistory(recipeid);
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "شرح خدمت";
                radGridView2.Columns[1].HeaderText = " دندان";
           
              }

            return true;
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
                    label22.Text = DataSource["BirthDate"].ToString();

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

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
                loaddata(fkvdfamily, persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
        }

        private void PaientSearch_f_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
        }

        private void PaientSearch_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
                dentistryEntitiescontext.Dispose();
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
                loaddata_detail(int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString()));
        }
    }
}
