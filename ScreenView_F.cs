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
    public partial class ScreenView_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        ListViewItem foundItem;
        public int usercodexml;
        public string ipadress;
        public Int32 turnid;
        public Int64 Dentscreen2;
        int temppersno, fkvdfamily=-1, idemployeetype,id;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat;
       // bool  firstLoad2,firstLoad3, firstLoad4, firstLoad5, firstLoad6,firstLoad7  = false;
        int LI=0,activepage=1;
        int countlist,i_list;

        
        
        public ScreenView_F()
        {
            InitializeComponent();
        }

        
        private void Screen_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            //---------------
            DLUtilsobj.screenobj.selectChiefcomplain(fkvdfamily);
            SqlDataReader DataSource;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView1_1.DataSource = DataSource;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView1_1.RowCount > 0)
            {
              
                radGridView1_1.Columns[0].HeaderText = "ردیف";
                radGridView1_1.Columns[1].HeaderText = "تاریخ";
                radGridView1_1.Columns[3].HeaderText = "نام پزشک";
                radGridView1_1.Columns[0].Width = 20;
                radGridView1_1.Columns[1].Width = 50;
                radGridView1_1.Columns[2].Width = 150;
                radGridView1_1.Columns[3].Width = 80;
            }
            //---------------

        }

    
        private void tabPage2_Enter(object sender, EventArgs e)
        {


             activepage = 2;
            DLUtilsobj.screenobj.selectGraphy_comment(fkvdfamily);
            SqlDataReader DataSource2_1;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource2_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView2_1.DataSource = DataSource2_1;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView2_1.RowCount > 0)
            {
                

                radGridView2_1.Columns[0].HeaderText = "ردیف";
                radGridView2_1.Columns[1].HeaderText = "تاریخ";
                radGridView2_1.Columns[5].HeaderText = "نام پزشک";
                radGridView2_1.Columns[0].Width = 20;
                radGridView2_1.Columns[1].Width = 50;
                radGridView2_1.Columns[2].Width = 80;
                radGridView2_1.Columns[3].Width = 80;
                radGridView2_1.Columns[4].Width = 80;
                radGridView2_1.Columns[5].Width = 80;

            }
            //*******************************
            DLUtilsobj.screenobj.selectGraphy_needed(fkvdfamily);
            SqlDataReader DataSource2_2;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource2_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView2_2.DataSource = DataSource2_2;
            DLUtilsobj.screenobj.Dbconnset(false);


            if (radGridView2_2.RowCount > 0)
            {
                radGridView2_2.Columns[0].HeaderText = "ردیف";
                radGridView2_2.Columns[1].HeaderText = "تاریخ";
                radGridView2_2.Columns[5].IsVisible = false;
            }
           
       


        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {

            activepage = 3;    
            DLUtilsobj.screenobj.selectRestorativeTx_Comment(fkvdfamily);
                SqlDataReader DataSource3_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource3_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3_1.DataSource = DataSource3_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView3_1.RowCount > 0)
                {
                   
                    radGridView3_1.Columns[0].HeaderText = "ردیف";
                    radGridView3_1.Columns[1].HeaderText = "تاریخ";
                    radGridView3_1.Columns[3].HeaderText = "نام پزشک";

                }
                //*******************************
                DLUtilsobj.screenobj.selectRestorative(fkvdfamily);
                SqlDataReader DataSource3_2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource3_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3_2.DataSource = DataSource3_2;
                DLUtilsobj.screenobj.Dbconnset(false);

                //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 5);
                SqlDataReader DataSource3_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource3_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3_3.DataSource = DataSource3_3;
                DLUtilsobj.screenobj.Dbconnset(false);

             
            
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {

                activepage = 4;
                DLUtilsobj.screenobj.selectRCT_Comment(fkvdfamily);
                SqlDataReader DataSource4_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource4_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView4_1.DataSource = DataSource4_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView4_1.RowCount > 0)
                {
                    radGridView4_1.Columns[0].HeaderText = "ردیف";
                    radGridView4_1.Columns[1].HeaderText = "تاریخ";
                    radGridView4_1.Columns[3].HeaderText = "نام پزشک";
                }
                //*******************************
                DLUtilsobj.screenobj.selectRCT(fkvdfamily);
                SqlDataReader DataSource4_2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource4_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView4_2.DataSource = DataSource4_2;
                DLUtilsobj.screenobj.Dbconnset(false);

               //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 4);
                SqlDataReader DataSource4_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource4_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView4_3.DataSource = DataSource4_3;
                DLUtilsobj.screenobj.Dbconnset(false);


        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {

                activepage = 5;
                DLUtilsobj.screenobj.selectExt_Sx_Comment(fkvdfamily);
                SqlDataReader DataSource5_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource5_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView5_1.DataSource = DataSource5_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView5_1.RowCount > 0)
                {
                    
                    radGridView5_1.Columns[0].HeaderText = "ردیف";
                    radGridView5_1.Columns[1].HeaderText = "تاریخ";
                    radGridView5_1.Columns[4].HeaderText = "نام پزشک";


                }
                //*******************************
                DLUtilsobj.screenobj.selectDentalSurgery(fkvdfamily);
                SqlDataReader DataSource5_2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource5_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView5_2.DataSource = DataSource5_2;
                DLUtilsobj.screenobj.Dbconnset(false);

                  //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 3);
                SqlDataReader DataSource5_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource5_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView5_3.DataSource = DataSource5_3;
                DLUtilsobj.screenobj.Dbconnset(false);
            
        }
        private void tabPage6_Enter(object sender, EventArgs e)
        {

                activepage = 6;
                DLUtilsobj.screenobj.selectPerio_tx_Comment(fkvdfamily);
                SqlDataReader DataSource6_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource6_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView6_1.DataSource = DataSource6_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView6_1.RowCount > 0)
                {
                   

                    radGridView6_1.Columns[0].HeaderText = "ردیف";
                    radGridView6_1.Columns[1].HeaderText = "تاریخ";
                    radGridView6_1.Columns[5].HeaderText = "نام پزشک";
                    radGridView6_1.Columns[0].Width = 20;
                    radGridView6_1.Columns[1].Width = 50;
                    radGridView6_1.Columns[2].Width = 80;
                    radGridView6_1.Columns[3].Width = 80;
                    radGridView6_1.Columns[4].Width = 80;
                    radGridView6_1.Columns[5].Width = 80;

                }
                //*******************************
                DLUtilsobj.screenobj.selectPerioTx(fkvdfamily);
                SqlDataReader DataSource6_2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource6_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView6_2.DataSource = DataSource6_2;
                DLUtilsobj.screenobj.Dbconnset(false);

                if (radGridView6_2.RowCount > 0)
                {
                    radGridView6_2.Columns[0].HeaderText = "ردیف";
                    radGridView6_2.Columns[1].HeaderText = "تاریخ";
                    radGridView6_2.Columns[5].IsVisible = false;
                }

                //-------------------------
         
              //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 2);
                SqlDataReader DataSource6_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource6_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView6_3.DataSource = DataSource6_3;
                DLUtilsobj.screenobj.Dbconnset(false);

            
        }
        private void tabPage7_Enter(object sender, EventArgs e)
        {

                activepage = 7;    
                DLUtilsobj.screenobj.selectOther_Comment(fkvdfamily);
                SqlDataReader DataSource7_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource7_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView7_1.DataSource = DataSource7_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView7_1.RowCount > 0)
                {
                   
                    radGridView7_1.Columns[0].HeaderText = "ردیف";
                    radGridView7_1.Columns[1].HeaderText = "تاریخ";
                    radGridView7_1.Columns[5].HeaderText = "نام پزشک";
                    radGridView7_1.Columns[0].Width = 20;
                    radGridView7_1.Columns[1].Width = 50;
                    radGridView7_1.Columns[2].Width = 80;
                    radGridView7_1.Columns[3].Width = 80;
                    radGridView7_1.Columns[4].Width = 80;
                    radGridView7_1.Columns[5].Width = 80;

                }
                //*******************************
                DLUtilsobj.screenobj.selectOther(fkvdfamily);
                SqlDataReader DataSource7_2;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource7_2 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView7_2.DataSource = DataSource7_2;
                DLUtilsobj.screenobj.Dbconnset(false);


                if (radGridView7_2.RowCount > 0)
                {
                    radGridView7_2.Columns[0].HeaderText = "ردیف";
                    radGridView7_2.Columns[1].HeaderText = "تاریخ";
                    radGridView7_2.Columns[5].IsVisible = false;
                }

                //-------------------------
          
             //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 1);
                SqlDataReader DataSource7_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource7_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView7_3.DataSource = DataSource7_3;
                DLUtilsobj.screenobj.Dbconnset(false);
            
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBox2.Items.Count > 0) && (comboBox2.SelectedIndex>0))
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
                
                if (activepage==1) 
                tabPage1_Enter(tabPage1, e);

                if (activepage == 2)
                    tabPage2_Enter(tabPage2, e);

                if (activepage == 3)
                    tabPage3_Enter(tabPage3, e);

                if (activepage == 4)
                    tabPage4_Enter(tabPage4, e);

                if (activepage == 5)
                    tabPage5_Enter(tabPage5, e);

                if (activepage == 6)
                    tabPage6_Enter(tabPage6, e);

                if (activepage == 7)
                    tabPage7_Enter(tabPage7, e);



            }

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            activepage = 1;
            //---------------
            DLUtilsobj.screenobj.selectChiefcomplain(fkvdfamily);
            SqlDataReader DataSource;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView1_1.DataSource = DataSource;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView1_1.RowCount > 0)
            {

                radGridView1_1.Columns[0].HeaderText = "ردیف";
                radGridView1_1.Columns[1].HeaderText = "تاریخ";
                radGridView1_1.Columns[3].HeaderText = "نام پزشک";
                radGridView1_1.Columns[0].Width = 20;
                radGridView1_1.Columns[1].Width = 50;
                radGridView1_1.Columns[2].Width = 150;
                radGridView1_1.Columns[3].Width = 80;
            }
            //---------------
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Screen_print3_F Screen_print3_Frm = new Screen_print3_F();
            Screen_print3_Frm.ipadress = ipadress;
            Screen_print3_Frm.fkvdfamily = fkvdfamily;
            Screen_print3_Frm.pk_dent_Screen2 = radGridView1_1.CurrentRow.Cells[0].Value.ToString();
            Screen_print3_Frm.kind = 3;
            Screen_print3_Frm.ShowDialog();
        }
   
    }
}
