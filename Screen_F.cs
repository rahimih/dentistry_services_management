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
    public partial class Screen_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        SqlDataReader datareader1;
        SqlDataReader DataSource;
        ListViewItem foundItem;
        public int usercodexml;
        public string ipadress,idperson;
        public Int32 fkvdfamily,persno;
        public Int32 turn_no;
        public Int64 Dentscreen2,turnid,planvst;
        public string Dentscreen2temp;
        bool  firstLoad2,firstLoad3, firstLoad4, firstLoad5, firstLoad6,firstLoad7  = false;
        int IllnessHistory = 0, Pregnant = 0, BMTStatus = 1, Outmouth = 1, TMJ = 1, mucousmouth = 1, PeriodentalStatus = 1, Prosthodonti = 1, Occlusion = 0, dentalneed = 100, gharbalgari=0;
        int needlerning =0 , needborosazh = 0, needfeloride = 0, needjerm = 0, needfishorsilant = 0;
        int LI=0;
        int countlist,i_list;
        Int64 returncodeill;
        byte Doctors_Consult=0, Dentist_Consult=0;
        string Dentalsurgery_text, Restorative_Txtext, RCT_text, PA_text, OtherRadioGraphy_text, OCCL_text, Emergency_TX_text, OrupPatho_text, OtherFinding_text, ChiefComplain_text, Curettage_text, Periotx_text, CL_text, Extraction_text, textBox11, textBox41;
        string specialitykindcode;

        
        
        public Screen_F()
        {
            InitializeComponent();
        }


        private bool loaddent_tooth(int toothid)
        {
            DLUtilsobj.planvisitobj.selectdentaltooth(toothid);
            SqlDataReader DataSource1;
            DLUtilsobj.planvisitobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.planvisitobj.planvisitclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.planvisitobj.Dbconnset(false);
            if (radGridView2.RowCount > 0)

                radGridView2.Columns[0].HeaderText = "---";

            return true;
        } 
        private void Screen_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            //---------------
            DLUtilsobj.screenobj.selectChiefcomplain(fkvdfamily);
            //SqlDataReader DataSource;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView1_1.DataSource = DataSource;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView1_1.RowCount > 0)
            {
                radGridView1_1.Rows.First();
                textBox520.Text = radGridView1_1.CurrentRow.Cells[2].Value.ToString();
                radGridView1_1.Columns[0].HeaderText = "ردیف";
                radGridView1_1.Columns[1].HeaderText = "تاریخ";
                radGridView1_1.Columns[3].HeaderText = "نام پزشک";
                radGridView1_1.Columns[0].Width = 20;
                radGridView1_1.Columns[1].Width = 50;
                radGridView1_1.Columns[2].Width = 150;
                radGridView1_1.Columns[3].Width = 80;
            }
            //---------------
            Dentscreen2temp = DLUtilsobj.screenobj.Ins_serach_screen1(fkvdfamily, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));

            if (Dentscreen2temp != "-1")
            {
            
                Dentscreen2 = Convert.ToInt64(Dentscreen2temp);
                DLUtilsobj.Screentempobj.selectdentscreen2(Dentscreen2);
                DLUtilsobj.Screentempobj.Dbconnset(true);
                datareader1 = DLUtilsobj.Screentempobj.Screenclientdataset.ExecuteReader();
                datareader1.Read();
                Dentalsurgery_textbox.Text = datareader1["DentalSurgeryComment"].ToString();                
                Restorative_TxtextBox.Text = datareader1["RestorativeTxComment"].ToString();
                RCT_textBox.Text = datareader1["RCTComment"].ToString();
                PA_textBox.Text = datareader1["PaComment"].ToString();
                OtherRadioGraphy_textBox.Text = datareader1["OtherRadioGraphyComment"].ToString();
                OCCL_textBox.Text = datareader1["OCCLComment"].ToString();
                Emergency_TX_textBox.Text = datareader1["EmergenyTxComment"].ToString();
                OrupPatho_textBox.Text = datareader1["OrupPathoComment"].ToString();
                OtherFinding_textBox.Text = datareader1["OtherFindingComment"].ToString();
                ChiefComplain_textbox.Text = datareader1["cheifcomplain"].ToString();
                Curettage_textBox.Text = datareader1["CurettageComment"].ToString();
                Periotx_textBox.Text = datareader1["PerioSxComment"].ToString();
                CL_textBox.Text = datareader1["ClComment"].ToString();
                Extraction_textbox.Text = datareader1["ExtractionComment"].ToString();

                IllnessHistory = int.Parse(datareader1["IllnessHistory"].ToString());
                Pregnant = int.Parse(datareader1["Pregnant"].ToString());
                BMTStatus = int.Parse(datareader1["BMTStatus"].ToString());
                Outmouth = int.Parse(datareader1["Outmouth"].ToString());
                TMJ = int.Parse(datareader1["TMJ"].ToString());
                mucousmouth = int.Parse(datareader1["mucousmouth"].ToString());
                PeriodentalStatus = int.Parse(datareader1["PeriodentalStatus"].ToString());
                Prosthodonti = int.Parse(datareader1["Prosthodonti"].ToString());
                Occlusion = int.Parse(datareader1["Occlusion"].ToString());
                needlerning = int.Parse(datareader1["needlerning"].ToString());
                needborosazh = int.Parse(datareader1["needborosazh"].ToString());
                needfeloride = int.Parse(datareader1["needfeloride"].ToString());
                needjerm = int.Parse(datareader1["needjerm"].ToString());
                needfishorsilant = int.Parse(datareader1["needfishorsilant"].ToString());
                dentalneed = int.Parse(datareader1["dentalneed"].ToString());
                gharbalgari = int.Parse(datareader1["gharbalgari"].ToString());
                if (datareader1["Doctors_Consult"].ToString() == "1")
                    Doctors_Consult = 1;
                else
                    Doctors_Consult = 0;
                textBox11 = datareader1["Doctors_Consult_text"].ToString();
                textBox1.Text = textBox11;
                if (datareader1["Dentist_Consult"].ToString() == "1")
                    Dentist_Consult = 1;
                else
                    Dentist_Consult = 0;

                textBox41 = datareader1["Dentist_Consult_text"].ToString();
                textBox4.Text = textBox41;

                DLUtilsobj.Screentempobj.Dbconnset(false);
                //*******************
               // MessageBox.Show(Doctors_Consult.ToString(), Dentist_Consult.ToString(), MessageBoxButtons.OK);
                if (IllnessHistory == 1)
                    checkBox10.Checked = true;
                if (gharbalgari == 1)
                    checkBox18.Checked = true;
                if (Doctors_Consult == 1)
                {
                    checkBox19.Checked = true;
                    textBox1.Text = textBox11 ;
                }
                if (Dentist_Consult == 1)
                {
                    checkBox20.Checked = true;
                    textBox4.Text = textBox41;
                }

                if (Pregnant == 1)
                    radioButton16.Checked = true;
                if (Pregnant == 2)
                    radioButton17.Checked = true;
                if (Pregnant == 3)
                    radioButton18.Checked = true;

                if (BMTStatus == 1)
                    radioButton1.Checked = true;
                if (BMTStatus == 2)
                    radioButton5.Checked = true;
                if (BMTStatus == 3)
                    radioButton6.Checked = true;
                
                if (Outmouth==1)
                    radioButton2.Checked = true;
                if (Outmouth==2)
                    radioButton7.Checked = true;

                if (TMJ == 1)
                    radioButton3.Checked = true;
                if (TMJ == 2)
                    radioButton9.Checked = true;
                if (TMJ == 3)
                    radioButton10.Checked = true;
                if (TMJ == 4)
                    radioButton11.Checked = true;
                
                if (mucousmouth == 1)
                    radioButton4.Checked = true;
                if (mucousmouth == 2)
                    radioButton8.Checked = true;

                if (Prosthodonti == 1)
                    radioButton15.Checked = true;
                if (Prosthodonti == 2)
                    radioButton14.Checked = true;
                if (Prosthodonti == 3)
                    radioButton13.Checked = true;
                if (Prosthodonti == 4)
                    radioButton12.Checked = true;

                if (Occlusion == 1)
                    radioButton22.Checked = true;
                if (Occlusion == 2)
                    radioButton21.Checked = true;
                if (Occlusion == 3)
                    radioButton20.Checked = true;

                if (PeriodentalStatus == 1)
                    radioButton19.Checked = true;
                if (PeriodentalStatus == 2)
                    radioButton23.Checked = true;
                if (PeriodentalStatus == 3)
                    radioButton24.Checked = true;
                if (PeriodentalStatus == 4)
                    radioButton25.Checked = true;
                if (PeriodentalStatus == 5)
                    radioButton26.Checked = true;

               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
              
              if (button1.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                  button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
              else if (button1.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                  button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

             // if (button1.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
           { 
             if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button1.Text;
             else
                ChiefComplain_textbox.Text = ChiefComplain_textbox.Text + "+" + button1.Text;
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button2.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button2.Text;
            else
                 ChiefComplain_textbox.Text = ChiefComplain_textbox.Text + "+" + button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button3.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button3.Text;
            else
                 ChiefComplain_textbox.Text = ChiefComplain_textbox.Text + "+" + button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button4.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button4.Text;
            else
                 ChiefComplain_textbox.Text = ChiefComplain_textbox.Text + "+" + button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button5.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button5.Text;
            else
                 ChiefComplain_textbox.Text = ChiefComplain_textbox.Text + "+" + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button6.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button6.Text;
            else 
                ChiefComplain_textbox.Text =ChiefComplain_textbox.Text+ "+" + button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button7.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            if (ChiefComplain_textbox.Text =="") 
               ChiefComplain_textbox.Text = button7.Text;
            else 
                ChiefComplain_textbox.Text =ChiefComplain_textbox.Text+ "+" + button7.Text;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            //Dentscreen2temp = DLUtilsobj.screenobj.Ins_serach_screen1(fkvdfamily, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));

            if (Dentscreen2temp == "-1")
            {
                Dentscreen2 = DLUtilsobj.screenobj.insertDentscreen2(usercodexml, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), turnid, fkvdfamily, Dentalsurgery_textbox.Text, Restorative_TxtextBox.Text, RCT_textBox.Text, PA_textBox.Text,
                OtherRadioGraphy_textBox.Text, OCCL_textBox.Text, Emergency_TX_textBox.Text, OrupPatho_textBox.Text, OtherFinding_textBox.Text, ChiefComplain_textbox.Text, Curettage_textBox.Text, Periotx_textBox.Text, CL_textBox.Text, " ", " ", " ", " ", Extraction_textbox.Text, IllnessHistory, Pregnant, BMTStatus, Outmouth, TMJ, mucousmouth, PeriodentalStatus, Prosthodonti, Occlusion, needlerning, needborosazh, needfeloride, needjerm, needfishorsilant, dentalneed, gharbalgari, Doctors_Consult, textBox1.Text, Dentist_Consult, textBox4.Text);
            }
            else
            {

                if (Doctors_Consult == 1)
                    textBox11 = textBox1.Text;
                else
                    textBox11 = "";

                
                if (Dentist_Consult == 1)
                    textBox41 = textBox4.Text;
                else
                    textBox41 = "";

                Dentscreen2 = Convert.ToInt64(Dentscreen2temp);
                DLUtilsobj.screenobj.updateDentscreen2(Dentscreen2, Dentalsurgery_textbox.Text, Restorative_TxtextBox.Text, RCT_textBox.Text, PA_textBox.Text,
                OtherRadioGraphy_textBox.Text, OCCL_textBox.Text, Emergency_TX_textBox.Text, OrupPatho_textBox.Text, OtherFinding_textBox.Text, ChiefComplain_textbox.Text, Curettage_textBox.Text, Periotx_textBox.Text, CL_textBox.Text, " ", " ", " ", " ", Extraction_textbox.Text, IllnessHistory, Pregnant, BMTStatus, Outmouth, TMJ, mucousmouth, PeriodentalStatus, Prosthodonti, Occlusion, needlerning, needborosazh, needfeloride, needjerm, needfishorsilant, dentalneed, gharbalgari, Doctors_Consult, textBox11, Dentist_Consult, textBox41);
            }
            
            //--------------insert into dentscreen1
            countlist = listView2.Items.Count - 1;
            i_list=0;
            while (i_list<=countlist)
            {
                DLUtilsobj.screenobj.insertDentscreen1(Dentscreen2, int.Parse(listView2.Items[i_list].SubItems[1].Text), int.Parse(listView2.Items[i_list].SubItems[2].Text), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), listView2.Items[i_list].SubItems[3].Text, listView2.Items[i_list].SubItems[4].Text, listView2.Items[i_list].SubItems[5].Text, listView2.Items[i_list].SubItems[6].Text, listView2.Items[i_list].SubItems[7].Text, listView2.Items[i_list].SubItems[8].Text, listView2.Items[i_list].SubItems[9].Text);
                i_list = i_list + 1;
            }

            //*************************

            if (Dentscreen2temp == "-1")
            {
                if (checkBox10.Checked==false) 
                DLUtilsobj.recipeobj.InsertdoctorsService(idperson, persno, fkvdfamily, 28, 100, usercodexml, planvst, turn_no, turnid, 1, usercodexml, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), Environment.MachineName);
                else
                {
                    specialitykindcode = DLUtilsobj.Screentempobj.retunnspecialitykindcode(usercodexml);
                   if (specialitykindcode=="1")
                    DLUtilsobj.recipeobj.InsertdoctorsService(idperson, persno, fkvdfamily, 176, 100, usercodexml, planvst, turn_no, turnid, 1, usercodexml, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), Environment.MachineName);
                   if (specialitykindcode == "2")
                    DLUtilsobj.recipeobj.InsertdoctorsService(idperson, persno, fkvdfamily, 177, 100, usercodexml, planvst, turn_no, turnid, 1, usercodexml, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), Environment.MachineName);
                }
            }
           //-----------------insert illnesshistory
            if (checkBox1.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 1) == false)
                DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 1);
            }

            if (checkBox2.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 2) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 2);
            }

            if (checkBox3.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 3) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 3);
            }

            if (checkBox4.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 4) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 4);
            }

             
            if (checkBox5.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 5) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 5);
            }

             
            if (checkBox6.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 6) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 6);
            }
            if (checkBox7.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 7) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 7);
            }
            if (checkBox8.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 8) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 8);
            }
            if (checkBox9.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 9) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 9);
            }
            if (checkBox17.Checked == true)
            {
                if (DLUtilsobj.Screentempobj.selectillnesshistory(Dentscreen2, 10) == false)
                    DLUtilsobj.screenobj.insertIllnessHistoryPaient(Dentscreen2, 10);
            }

            if (checkBox16.Checked == true)
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("لطفا نام بیماری را وارد نمائید","خطا",MessageBoxButtons.OK);
                }
                else
                {
                    returncodeill = DLUtilsobj.screenobj.insertillnesshistory(textBox2.Text);
                    DLUtilsobj.Screentempobj.insertIllnessHistoryPaient(Dentscreen2, returncodeill);
                }

            }
           //------------------
            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
            this.Close();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {

            if (firstLoad2==false)
         { 
            firstLoad2 = true;
       
            DLUtilsobj.screenobj.selectGraphy_comment(fkvdfamily);
            SqlDataReader DataSource2_1;
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource2_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView2_1.DataSource = DataSource2_1;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView2_1.RowCount > 0)
            {
                radGridView2_1.Rows.First();
                textBox522.Text = radGridView2_1.CurrentRow.Cells[2].Value.ToString();
                textBox523.Text = radGridView2_1.CurrentRow.Cells[3].Value.ToString();
                textBox521.Text = radGridView2_1.CurrentRow.Cells[4].Value.ToString();

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
           
           
            //---------------------
         /*
            int j = radGridView2_2.Rows.Count - 1;
            for (int i = 0; i <= j;i=i+1)

            {
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "4")
                {

                }


                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "5")
                    checkBox1_c5.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "7")
                    checkBox1_c7.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "8")
                    checkBox1_c8.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "9")
                    checkBox1_c9.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "10")
                    checkBox1_c10.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "11")
                    checkBox1_c11.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "12")
                    checkBox1_c12.Checked = true;
                if (radGridView2_2.Rows[i].Cells[5].Value.ToString() == "13")
                    checkBox1_c13.Checked = true;

            }
           */ 
        }


        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            if (firstLoad3 == false)
          { 
                firstLoad3 = true;

            
                DLUtilsobj.screenobj.selectRestorativeTx_Comment(fkvdfamily);
                SqlDataReader DataSource3_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource3_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView3_1.DataSource = DataSource3_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView3_1.RowCount > 0)
                {
                    radGridView3_1.Rows.First();
                    textBox3.Text = radGridView3_1.CurrentRow.Cells[2].Value.ToString();


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
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            if (firstLoad4 == false)
          {
                firstLoad4 = true;
            
                DLUtilsobj.screenobj.selectRCT_Comment(fkvdfamily);
                SqlDataReader DataSource4_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource4_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView4_1.DataSource = DataSource4_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView4_1.RowCount > 0)
                {
                    radGridView4_1.Rows.First();
                    textBox525.Text = radGridView4_1.CurrentRow.Cells[2].Value.ToString();


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
        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            if (firstLoad5 == false)
          {
                firstLoad5 = true;
            
                DLUtilsobj.screenobj.selectExt_Sx_Comment(fkvdfamily);
                SqlDataReader DataSource5_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource5_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView5_1.DataSource = DataSource5_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView5_1.RowCount > 0)
                {
                    radGridView5_1.Rows.First();
                    textBox220.Text = radGridView5_1.CurrentRow.Cells[2].Value.ToString();
                    textBox219.Text = radGridView5_1.CurrentRow.Cells[3].Value.ToString();


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
        }
        private void tabPage6_Enter(object sender, EventArgs e)
        {
            if (firstLoad6 == false)
         {
                firstLoad6 = true;
            
                DLUtilsobj.screenobj.selectPerio_tx_Comment(fkvdfamily);
                SqlDataReader DataSource6_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource6_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView6_1.DataSource = DataSource6_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView6_1.RowCount > 0)
                {
                    radGridView6_1.Rows.First();
                    textBox404.Text = radGridView6_1.CurrentRow.Cells[2].Value.ToString();
                    textBox405.Text = radGridView6_1.CurrentRow.Cells[3].Value.ToString();
                    textBox215.Text = radGridView6_1.CurrentRow.Cells[4].Value.ToString();

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
             /*
                int j = radGridView6_2.Rows.Count - 1;
                for (int i = 0; i <= j; i = i + 1)
                {

                    if (radGridView6_2.Rows[i].Cells[5].Value.ToString() == "22")
                        checkBox6_C22.Checked = true;
                    if (radGridView6_2.Rows[i].Cells[5].Value.ToString() == "17")
                        checkBox6_C17.Checked = true;
                    if (radGridView6_2.Rows[i].Cells[5].Value.ToString() == "23")
                        checkBox6_C23.Checked = true;
                    if (radGridView6_2.Rows[i].Cells[5].Value.ToString() == "24")
                        checkBox6_c24.Checked = true;


                }
                */
              //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 2);
                SqlDataReader DataSource6_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource6_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView6_3.DataSource = DataSource6_3;
                DLUtilsobj.screenobj.Dbconnset(false);

            }
        }
        private void tabPage7_Enter(object sender, EventArgs e)
        {
            if (firstLoad7 == false)
         {
                firstLoad7 = true;
            
                DLUtilsobj.screenobj.selectOther_Comment(fkvdfamily);
                SqlDataReader DataSource7_1;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource7_1 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView7_1.DataSource = DataSource7_1;
                DLUtilsobj.screenobj.Dbconnset(false);
                if (radGridView7_1.RowCount > 0)
                {
                    radGridView7_1.Rows.First();
                    textBox217.Text = radGridView7_1.CurrentRow.Cells[2].Value.ToString();
                    textBox218.Text = radGridView7_1.CurrentRow.Cells[3].Value.ToString();
                    textBox216.Text = radGridView7_1.CurrentRow.Cells[4].Value.ToString();

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
              /*
                int j = radGridView7_2.Rows.Count - 1;
                for (int i = 0; i <= j; i = i + 1)
                {

                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "14")
                        checkBox7_C14.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "15")
                        checkBox7_C15.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "16")
                        checkBox7_C16.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "18")
                        checkBox7_C18.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "19")
                        checkBox7_C19.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "20")
                        checkBox7_C20.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "26")
                        checkBox7_C26.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "27")
                        checkBox7_C27.Checked = true;
                    if (radGridView7_2.Rows[i].Cells[5].Value.ToString() == "28")
                        checkBox7_C28.Checked = true;

                }
               */ 

             //*****************************
                DLUtilsobj.screenobj.screen_historical(fkvdfamily, 1);
                SqlDataReader DataSource7_3;
                DLUtilsobj.screenobj.Dbconnset(true);
                DataSource7_3 = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
                radGridView7_3.DataSource = DataSource7_3;
                DLUtilsobj.screenobj.Dbconnset(false);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button8.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Periotx_textBox.Text == "")
                    Periotx_textBox.Text = button8.Text;
                else
                    Periotx_textBox.Text = Periotx_textBox.Text + "+" + button8.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button9.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button9.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Periotx_textBox.Text == "")
                    Periotx_textBox.Text = button9.Text;
                else
                    Periotx_textBox.Text = Periotx_textBox.Text + "+" + button9.Text;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button10.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button10.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button10.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Periotx_textBox.Text == "")
                    Periotx_textBox.Text = button10.Text;
                else
                    Periotx_textBox.Text = Periotx_textBox.Text + "+" + button10.Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button11.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button11.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button11.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Periotx_textBox.Text == "")
                    Periotx_textBox.Text = button11.Text;
                else
                    Periotx_textBox.Text = Periotx_textBox.Text + "+" + button11.Text;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button15.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button15.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button15.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Curettage_textBox.Text == "")
                    Curettage_textBox.Text = button15.Text;
                else
                    Curettage_textBox.Text = Curettage_textBox.Text + "+" + button15.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button14.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button14.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button14.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Curettage_textBox.Text == "")
                    Curettage_textBox.Text = button14.Text;
                else
                    Curettage_textBox.Text = Curettage_textBox.Text + "+" + button14.Text;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button13.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button13.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button13.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Curettage_textBox.Text == "")
                    Curettage_textBox.Text = button13.Text;
                else
                    Curettage_textBox.Text = Curettage_textBox.Text + "+" + button13.Text;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button12.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button12.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button12.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (Curettage_textBox.Text == "")
                    Curettage_textBox.Text = button12.Text;
                else
                    Curettage_textBox.Text = Curettage_textBox.Text + "+" + button12.Text;
            }
        }

        private void checkBox408_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox409_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBox6_C23.Checked;
        }

        private void checkBox1_c5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c5.Checked==true)
            {
                listView2.Items.Add("OPG");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OPG", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        

        private void checkBox1_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_1.Visible = checkBox1_1.Checked;
            textBox1_1.Focus();

            if (checkBox1_1.Checked == true)
            {
                listView2.Items.Add("PA1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
            
         
        }

        private void checkBox1_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_2.Visible = checkBox1_2.Checked;
            textBox1_2.Focus();

            if (checkBox1_2.Checked == true)
            {
                listView2.Items.Add("PA2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_3.Visible = checkBox1_3.Checked;
            textBox1_3.Focus();

            if (checkBox1_3.Checked == true)
            {
                listView2.Items.Add("PA3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
            
        }

        private void checkBox1_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_4.Visible = checkBox1_4.Checked;
            textBox1_4.Focus();

            if (checkBox1_4.Checked == true)
            {
                listView2.Items.Add("PA4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_5.Visible = checkBox1_5.Checked;
            textBox1_5.Focus();

            if (checkBox1_5.Checked == true)
            {
                listView2.Items.Add("PA5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_6.Visible = checkBox1_6.Checked;
            textBox1_6.Focus();

            if (checkBox1_6.Checked == true)
            {
                listView2.Items.Add("PA6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_7.Visible = checkBox1_7.Checked;
            textBox1_7.Focus();

            if (checkBox1_7.Checked == true)
            {
                listView2.Items.Add("PA7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_8.Visible = checkBox1_8.Checked;
            textBox1_8.Focus();

            if (checkBox1_8.Checked == true)
            {
                listView2.Items.Add("PA8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_9.Visible = checkBox1_9.Checked;
            textBox1_9.Focus();

            if (checkBox1_9.Checked == true)
            {
                listView2.Items.Add("PA9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_10.Visible = checkBox1_10.Checked;
            textBox1_10.Focus();

            if (checkBox1_10.Checked == true)
            {
                listView2.Items.Add("PA10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_11.Visible = checkBox1_11.Checked;
            textBox1_11.Focus();

            if (checkBox1_11.Checked == true)
            {
                listView2.Items.Add("PA11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_12.Visible = checkBox1_12.Checked;
            textBox1_12.Focus();

            if (checkBox1_12.Checked == true)
            {
                listView2.Items.Add("PA12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_13.Visible = checkBox1_13.Checked;
            textBox1_13.Focus();

            if (checkBox1_13.Checked == true)
            {
                listView2.Items.Add("PA13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_14.Visible = checkBox1_14.Checked;
            textBox1_14.Focus();

            if (checkBox1_14.Checked == true)
            {
                listView2.Items.Add("PA14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_15.Visible = checkBox1_15.Checked;
            textBox1_15.Focus();

            if (checkBox1_15.Checked == true)
            {
                listView2.Items.Add("PA15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_16.Visible = checkBox1_16.Checked;
            textBox1_16.Focus();

            if (checkBox1_16.Checked == true)
            {
                listView2.Items.Add("PA16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_17.Visible = checkBox1_17.Checked;
            textBox1_17.Focus();

            if (checkBox1_17.Checked == true)
            {
                listView2.Items.Add("PA17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_18.Visible = checkBox1_18.Checked;
            textBox1_18.Focus();

            if (checkBox1_18.Checked == true)
            {
                listView2.Items.Add("PA18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_19.Visible = checkBox1_19.Checked;
            textBox1_19.Focus();

            if (checkBox1_19.Checked == true)
            {
                listView2.Items.Add("PA19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_20.Visible = checkBox1_20.Checked;
            textBox1_20.Focus();

            if (checkBox1_20.Checked == true)
            {
                listView2.Items.Add("PA20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_21.Visible = checkBox1_21.Checked;
            textBox1_21.Focus();

            if (checkBox1_21.Checked == true)
            {
                listView2.Items.Add("PA21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_22.Visible = checkBox1_22.Checked;
            textBox1_22.Focus();

            if (checkBox1_22.Checked == true)
            {
                listView2.Items.Add("PA22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_23.Visible = checkBox1_23.Checked;
            textBox1_23.Focus();

            if (checkBox1_23.Checked == true)
            {
                listView2.Items.Add("PA23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_24.Visible = checkBox1_24.Checked;
            textBox1_24.Focus();

            if (checkBox1_24.Checked == true)
            {
                listView2.Items.Add("PA24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_25.Visible = checkBox1_25.Checked;
            textBox1_25.Focus();

            if (checkBox1_25.Checked == true)
            {
                listView2.Items.Add("PA25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_26.Visible = checkBox1_26.Checked;
            textBox1_26.Focus();

            if (checkBox1_26.Checked == true)
            {
                listView2.Items.Add("PA26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_27.Visible = checkBox1_27.Checked;
            textBox1_27.Focus();

            if (checkBox1_27.Checked == true)
            {
                listView2.Items.Add("PA27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_28.Visible = checkBox1_28.Checked;
            textBox1_28.Focus();

            if (checkBox1_28.Checked == true)
            {
                listView2.Items.Add("PA28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_29.Visible = checkBox1_29.Checked;
            textBox1_29.Focus();

            if (checkBox1_29.Checked == true)
            {
                listView2.Items.Add("PA29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_30.Visible = checkBox1_30.Checked;
            textBox1_30.Focus();

            if (checkBox1_30.Checked == true)
            {
                listView2.Items.Add("PA30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_31.Visible = checkBox1_31.Checked;
            textBox1_31.Focus();

            if (checkBox1_31.Checked == true)
            {
                listView2.Items.Add("PA31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_32.Visible = checkBox1_32.Checked;
            textBox1_32.Focus();

            if (checkBox1_32.Checked == true)
            {
                listView2.Items.Add("PA32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_33.Visible = checkBox1_33.Checked;
            textBox1_33.Focus();

            if (checkBox1_33.Checked == true)
            {
                listView2.Items.Add("PA33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_34.Visible = checkBox1_34.Checked;
            textBox1_34.Focus();

            if (checkBox1_34.Checked == true)
            {
                listView2.Items.Add("PA34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_35.Visible = checkBox1_35.Checked;
            textBox1_35.Focus();

            if (checkBox1_35.Checked == true)
            {
                listView2.Items.Add("PA35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_36.Visible = checkBox1_36.Checked;
            textBox1_36.Focus();

            if (checkBox1_36.Checked == true)
            {
                listView2.Items.Add("PA36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_37.Visible = checkBox1_37.Checked;
            textBox1_37.Focus();

            if (checkBox1_37.Checked == true)
            {
                listView2.Items.Add("PA37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_38.Visible = checkBox1_38.Checked;
            textBox1_38.Focus();

            if (checkBox1_38.Checked == true)
            {
                listView2.Items.Add("PA38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_39.Visible = checkBox1_39.Checked;
            textBox1_39.Focus();

            if (checkBox1_39.Checked == true)
            {
                listView2.Items.Add("PA39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_40.Visible = checkBox1_40.Checked;
            textBox1_40.Focus();

            if (checkBox1_40.Checked == true)
            {
                listView2.Items.Add("PA40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_41.Visible = checkBox1_41.Checked;
            textBox1_41.Focus();

            if (checkBox1_41.Checked == true)
            {
                listView2.Items.Add("PA41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_42.Visible = checkBox1_42.Checked;
            textBox1_42.Focus();

            if (checkBox1_42.Checked == true)
            {
                listView2.Items.Add("PA42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_43.Visible = checkBox1_43.Checked;
            textBox1_43.Focus();

            if (checkBox1_43.Checked == true)
            {
                listView2.Items.Add("PA43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_44.Visible = checkBox1_44.Checked;
            textBox1_44.Focus();

            if (checkBox1_44.Checked == true)
            {
                listView2.Items.Add("PA44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_45.Visible = checkBox1_45.Checked;
            textBox1_45.Focus();

            if (checkBox1_45.Checked == true)
            {
                listView2.Items.Add("PA45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_46.Visible = checkBox1_46.Checked;
            textBox1_46.Focus();

            if (checkBox1_46.Checked == true)
            {
                listView2.Items.Add("PA46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_47.Visible = checkBox1_47.Checked;
            textBox1_47.Focus();

            if (checkBox1_47.Checked == true)
            {
                listView2.Items.Add("PA47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_48.Visible = checkBox1_48.Checked;
            textBox1_48.Focus();

            if (checkBox1_48.Checked == true)
            {
                listView2.Items.Add("PA48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_49.Visible = checkBox1_49.Checked;
            textBox1_49.Focus();

            if (checkBox1_49.Checked == true)
            {
                listView2.Items.Add("PA49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_50.Visible = checkBox1_50.Checked;
            textBox1_50.Focus();

            if (checkBox1_50.Checked == true)
            {
                listView2.Items.Add("PA50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_51.Visible = checkBox1_51.Checked;
            textBox1_51.Focus();

            if (checkBox1_51.Checked == true)
            {
                listView2.Items.Add("PA51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_52.Visible = checkBox1_52.Checked;
            textBox1_52.Focus();

            if (checkBox1_52.Checked == true)
            {
                listView2.Items.Add("PA52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("PA52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_1.Visible = checkBox2_1.Checked;
            textBox2_1.Focus();

            if (checkBox2_1.Checked == true)
            {
                listView2.Items.Add("RST1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_2.Visible = checkBox2_2.Checked;
            textBox2_2.Focus();

            if (checkBox2_2.Checked == true)
            {
                listView2.Items.Add("RST2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_3.Visible = checkBox2_3.Checked;
            textBox2_3.Focus();

            if (checkBox2_3.Checked == true)
            {
                listView2.Items.Add("RST3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_4.Visible = checkBox2_4.Checked;
            textBox2_4.Focus();

            if (checkBox2_4.Checked == true)
            {
                listView2.Items.Add("RST4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_5.Visible = checkBox2_5.Checked;
            textBox2_5.Focus();

            if (checkBox2_5.Checked == true)
            {
                listView2.Items.Add("RST5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_6.Visible = checkBox2_6.Checked;
            textBox2_6.Focus();

            if (checkBox2_6.Checked == true)
            {
                listView2.Items.Add("RST6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_7.Visible = checkBox2_7.Checked;
            textBox2_7.Focus();

            if (checkBox2_7.Checked == true)
            {
                listView2.Items.Add("RST7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_8.Visible = checkBox2_8.Checked;
            textBox2_8.Focus();

            if (checkBox2_8.Checked == true)
            {
                listView2.Items.Add("RST8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_9.Visible = checkBox2_9.Checked;
            textBox2_9.Focus();

            if (checkBox2_9.Checked == true)
            {
                listView2.Items.Add("RST9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_10.Visible = checkBox2_10.Checked;
            textBox2_10.Focus();

            if (checkBox2_10.Checked == true)
            {
                listView2.Items.Add("RST10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_11.Visible = checkBox2_11.Checked;
            textBox2_11.Focus();

            if (checkBox2_11.Checked == true)
            {
                listView2.Items.Add("RST11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_12.Visible = checkBox2_12.Checked;
            textBox2_12.Focus();

            if (checkBox2_12.Checked == true)
            {
                listView2.Items.Add("RST12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_13.Visible = checkBox2_13.Checked;
            textBox2_13.Focus();

            if (checkBox2_13.Checked == true)
            {
                listView2.Items.Add("RST13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_14.Visible = checkBox2_14.Checked;
            textBox2_14.Focus();

            if (checkBox2_14.Checked == true)
            {
                listView2.Items.Add("RST14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_15.Visible = checkBox2_15.Checked;
            textBox2_15.Focus();

            if (checkBox2_15.Checked == true)
            {
                listView2.Items.Add("RST15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_16.Visible = checkBox2_16.Checked;
            textBox2_16.Focus();

            if (checkBox2_16.Checked == true)
            {
                listView2.Items.Add("RST16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_17.Visible = checkBox2_17.Checked;
            textBox2_17.Focus();

            if (checkBox2_17.Checked == true)
            {
                listView2.Items.Add("RST17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_18.Visible = checkBox2_18.Checked;
            textBox2_18.Focus();

            if (checkBox2_18.Checked == true)
            {
                listView2.Items.Add("RST18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_19.Visible = checkBox2_19.Checked;
            textBox2_19.Focus();

            if (checkBox2_19.Checked == true)
            {
                listView2.Items.Add("RST19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_20.Visible = checkBox2_20.Checked;
            textBox2_20.Focus();

            if (checkBox2_20.Checked == true)
            {
                listView2.Items.Add("RST20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_21.Visible = checkBox2_21.Checked;
            textBox2_21.Focus();

            if (checkBox2_21.Checked == true)
            {
                listView2.Items.Add("RST21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_22.Visible = checkBox2_22.Checked;
            textBox2_22.Focus();

            if (checkBox2_22.Checked == true)
            {
                listView2.Items.Add("RST22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_23.Visible = checkBox2_23.Checked;
            textBox2_23.Focus();

            if (checkBox2_23.Checked == true)
            {
                listView2.Items.Add("RST23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_24.Visible = checkBox2_24.Checked;
            textBox2_24.Focus();

            if (checkBox2_24.Checked == true)
            {
                listView2.Items.Add("RST24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_25.Visible = checkBox2_25.Checked;
            textBox2_25.Focus();

            if (checkBox2_25.Checked == true)
            {
                listView2.Items.Add("RST25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_26.Visible = checkBox2_26.Checked;
            textBox2_26.Focus();

            if (checkBox2_26.Checked == true)
            {
                listView2.Items.Add("RST26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_27.Visible = checkBox2_27.Checked;
            textBox2_27.Focus();

            if (checkBox2_27.Checked == true)
            {
                listView2.Items.Add("RST27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_28.Visible = checkBox2_28.Checked;
            textBox2_28.Focus();

            if (checkBox2_28.Checked == true)
            {
                listView2.Items.Add("RST28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_29.Visible = checkBox2_29.Checked;
            textBox2_29.Focus();

            if (checkBox2_29.Checked == true)
            {
                listView2.Items.Add("RST29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_30.Visible = checkBox2_30.Checked;
            textBox2_30.Focus();

            if (checkBox2_30.Checked == true)
            {
                listView2.Items.Add("RST30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_31.Visible = checkBox2_31.Checked;
            textBox2_31.Focus();

            if (checkBox2_31.Checked == true)
            {
                listView2.Items.Add("RST31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_32.Visible = checkBox2_32.Checked;
            textBox2_32.Focus();

            if (checkBox2_32.Checked == true)
            {
                listView2.Items.Add("RST32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_33.Visible = checkBox2_33.Checked;
            textBox2_33.Focus();

            if (checkBox2_33.Checked == true)
            {
                listView2.Items.Add("RST33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_34.Visible = checkBox2_34.Checked;
            textBox2_34.Focus();

            if (checkBox2_34.Checked == true)
            {
                listView2.Items.Add("RST34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_35.Visible = checkBox2_35.Checked;
            textBox2_35.Focus();

            if (checkBox2_35.Checked == true)
            {
                listView2.Items.Add("RST35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_36.Visible = checkBox2_36.Checked;
            textBox2_36.Focus();

            if (checkBox2_36.Checked == true)
            {
                listView2.Items.Add("RST36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_37.Visible = checkBox2_37.Checked;
            textBox2_37.Focus();

            if (checkBox2_37.Checked == true)
            {
                listView2.Items.Add("RST37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_38.Visible = checkBox2_38.Checked;
            textBox2_38.Focus();

            if (checkBox2_38.Checked == true)
            {
                listView2.Items.Add("RST38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_39.Visible = checkBox2_39.Checked;
            textBox2_39.Focus();

            if (checkBox2_39.Checked == true)
            {
                listView2.Items.Add("RST39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_40.Visible = checkBox2_40.Checked;
            textBox2_40.Focus();

            if (checkBox2_40.Checked == true)
            {
                listView2.Items.Add("RST40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_41.Visible = checkBox2_41.Checked;
            textBox2_41.Focus();

            if (checkBox2_41.Checked == true)
            {
                listView2.Items.Add("RST41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_42.Visible = checkBox2_42.Checked;
            textBox2_42.Focus();

            if (checkBox2_42.Checked == true)
            {
                listView2.Items.Add("RST42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_43.Visible = checkBox2_43.Checked;
            textBox2_43.Focus();

            if (checkBox2_43.Checked == true)
            {
                listView2.Items.Add("RST43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_44.Visible = checkBox2_44.Checked;
            textBox2_44.Focus();

            if (checkBox2_44.Checked == true)
            {
                listView2.Items.Add("RST44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_45.Visible = checkBox2_45.Checked;
            textBox2_45.Focus();

            if (checkBox2_45.Checked == true)
            {
                listView2.Items.Add("RST45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_46.Visible = checkBox2_46.Checked;
            textBox2_46.Focus();

            if (checkBox2_46.Checked == true)
            {
                listView2.Items.Add("RST46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_47.Visible = checkBox2_47.Checked;
            textBox2_47.Focus();

            if (checkBox2_47.Checked == true)
            {
                listView2.Items.Add("RST47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_48.Visible = checkBox2_48.Checked;
            textBox2_48.Focus();

            if (checkBox2_48.Checked == true)
            {
                listView2.Items.Add("RST48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_49.Visible = checkBox2_49.Checked;
            textBox2_49.Focus();

            if (checkBox2_49.Checked == true)
            {
                listView2.Items.Add("RST49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_50.Visible = checkBox2_50.Checked;
            textBox2_50.Focus();

            if (checkBox2_50.Checked == true)
            {
                listView2.Items.Add("RST50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_51.Visible = checkBox2_51.Checked;
            textBox2_51.Focus();

            if (checkBox2_51.Checked == true)
            {
                listView2.Items.Add("RST51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox2_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox2_52.Visible = checkBox2_52.Checked;
            textBox2_52.Focus();

            if (checkBox2_52.Checked == true)
            {
                listView2.Items.Add("RST52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox2_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RST52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_1.Visible = checkBox3_1.Checked;
            textBox3_1.Focus();

            if (checkBox3_1.Checked == true)
            {
                listView2.Items.Add("RCT1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_2.Visible = checkBox3_2.Checked;
            textBox3_2.Focus();

            if (checkBox3_2.Checked == true)
            {
                listView2.Items.Add("RCT2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_3.Visible = checkBox3_3.Checked;
            textBox3_3.Focus();

            if (checkBox3_3.Checked == true)
            {
                listView2.Items.Add("RCT3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_4.Visible = checkBox3_4.Checked;
            textBox3_4.Focus();

            if (checkBox3_4.Checked == true)
            {
                listView2.Items.Add("RCT4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_5.Visible = checkBox3_5.Checked;
            textBox3_5.Focus();

            if (checkBox3_5.Checked == true)
            {
                listView2.Items.Add("RCT5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_6.Visible = checkBox3_6.Checked;
            textBox3_6.Focus();

            if (checkBox3_6.Checked == true)
            {
                listView2.Items.Add("RCT6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_7.Visible = checkBox3_7.Checked;
            textBox3_7.Focus();

            if (checkBox3_7.Checked == true)
            {
                listView2.Items.Add("RCT7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_8.Visible = checkBox3_8.Checked;
            textBox3_8.Focus();

            if (checkBox3_8.Checked == true)
            {
                listView2.Items.Add("RCT8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_9.Visible = checkBox3_9.Checked;
            textBox3_9.Focus();

            if (checkBox3_9.Checked == true)
            {
                listView2.Items.Add("RCT9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_10.Visible = checkBox3_10.Checked;
            textBox3_10.Focus();

            if (checkBox3_10.Checked == true)
            {
                listView2.Items.Add("RCT10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_11.Visible = checkBox3_11.Checked;
            textBox3_11.Focus();

            if (checkBox3_11.Checked == true)
            {
                listView2.Items.Add("RCT11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_12.Visible = checkBox3_12.Checked;
            textBox3_12.Focus();

            if (checkBox3_12.Checked == true)
            {
                listView2.Items.Add("RCT12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_13.Visible = checkBox3_13.Checked;
            textBox3_13.Focus();

            if (checkBox3_13.Checked == true)
            {
                listView2.Items.Add("RCT13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_14.Visible = checkBox3_14.Checked;
            textBox3_14.Focus();

            if (checkBox3_14.Checked == true)
            {
                listView2.Items.Add("RCT14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_15.Visible = checkBox3_15.Checked;
            textBox3_15.Focus();

            if (checkBox3_15.Checked == true)
            {
                listView2.Items.Add("RCT15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_16.Visible = checkBox3_16.Checked;
            textBox3_16.Focus();

            if (checkBox3_16.Checked == true)
            {
                listView2.Items.Add("RCT16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_17.Visible = checkBox3_17.Checked;
            textBox3_17.Focus();

            if (checkBox3_17.Checked == true)
            {
                listView2.Items.Add("RCT17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_18.Visible = checkBox3_18.Checked;
            textBox3_18.Focus();

            if (checkBox3_18.Checked == true)
            {
                listView2.Items.Add("RCT18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_19.Visible = checkBox3_19.Checked;
            textBox3_19.Focus();

            if (checkBox3_19.Checked == true)
            {
                listView2.Items.Add("RCT19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_20.Visible = checkBox3_20.Checked;
            textBox3_20.Focus();

            if (checkBox3_20.Checked == true)
            {
                listView2.Items.Add("RCT20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_21.Visible = checkBox3_21.Checked;
            textBox3_21.Focus();

            if (checkBox3_21.Checked == true)
            {
                listView2.Items.Add("RCT21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_22.Visible = checkBox3_22.Checked;
            textBox3_22.Focus();

            if (checkBox3_22.Checked == true)
            {
                listView2.Items.Add("RCT22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_23.Visible = checkBox3_23.Checked;
            textBox3_23.Focus();

            if (checkBox3_23.Checked == true)
            {
                listView2.Items.Add("RCT23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_24.Visible = checkBox3_24.Checked;
            textBox3_24.Focus();

            if (checkBox3_24.Checked == true)
            {
                listView2.Items.Add("RCT24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_25.Visible = checkBox3_25.Checked;
            textBox3_25.Focus();

            if (checkBox3_25.Checked == true)
            {
                listView2.Items.Add("RCT25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_26.Visible = checkBox3_26.Checked;
            textBox3_26.Focus();

            if (checkBox3_26.Checked == true)
            {
                listView2.Items.Add("RCT26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_27.Visible = checkBox3_27.Checked;
            textBox3_27.Focus();

            if (checkBox3_27.Checked == true)
            {
                listView2.Items.Add("RCT27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_28.Visible = checkBox3_28.Checked;
            textBox3_28.Focus();

            if (checkBox3_28.Checked == true)
            {
                listView2.Items.Add("RCT28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_29.Visible = checkBox3_29.Checked;
            textBox3_29.Focus();

            if (checkBox3_29.Checked == true)
            {
                listView2.Items.Add("RCT29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_30.Visible = checkBox3_30.Checked;
            textBox3_30.Focus();

            if (checkBox3_30.Checked == true)
            {
                listView2.Items.Add("RCT30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_31.Visible = checkBox3_31.Checked;
            textBox3_31.Focus();

            if (checkBox3_31.Checked == true)
            {
                listView2.Items.Add("RCT31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_32.Visible = checkBox3_32.Checked;
            textBox3_32.Focus();
            if (checkBox3_32.Checked == true)
            {
                listView2.Items.Add("RCT32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_33.Visible = checkBox3_33.Checked;
            textBox3_33.Focus();

            if (checkBox3_33.Checked == true)
            {
                listView2.Items.Add("RCT33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_34.Visible = checkBox3_34.Checked;
            textBox3_34.Focus();

            if (checkBox3_34.Checked == true)
            {
                listView2.Items.Add("RCT34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_35.Visible = checkBox3_35.Checked;
            textBox3_35.Focus();

            if (checkBox3_35.Checked == true)
            {
                listView2.Items.Add("RCT35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_36.Visible = checkBox3_36.Checked;
            textBox3_36.Focus();

            if (checkBox3_36.Checked == true)
            {
                listView2.Items.Add("RCT36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_37.Visible = checkBox3_37.Checked;
            textBox3_37.Focus();

            if (checkBox3_37.Checked == true)
            {
                listView2.Items.Add("RCT37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_38.Visible = checkBox3_38.Checked;
            textBox3_38.Focus();

            if (checkBox3_38.Checked == true)
            {
                listView2.Items.Add("RCT38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_39.Visible = checkBox3_39.Checked;
            textBox3_39.Focus();

            if (checkBox3_39.Checked == true)
            {
                listView2.Items.Add("RCT39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_40.Visible = checkBox3_40.Checked;
            textBox3_40.Focus();

            if (checkBox3_40.Checked == true)
            {
                listView2.Items.Add("RCT40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_41.Visible = checkBox3_41.Checked;
            textBox3_41.Focus();

            if (checkBox3_41.Checked == true)
            {
                listView2.Items.Add("RCT41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_42.Visible = checkBox3_42.Checked;
            textBox3_42.Focus();

            if (checkBox3_42.Checked == true)
            {
                listView2.Items.Add("RCT42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_43.Visible = checkBox3_43.Checked;
            textBox3_43.Focus();

            if (checkBox3_43.Checked == true)
            {
                listView2.Items.Add("RCT43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_44.Visible = checkBox3_44.Checked;
            textBox3_44.Focus();

            if (checkBox3_44.Checked == true)
            {
                listView2.Items.Add("RCT44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_45.Visible = checkBox3_45.Checked;
            textBox3_45.Focus();

            if (checkBox3_45.Checked == true)
            {
                listView2.Items.Add("RCT45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_46.Visible = checkBox3_46.Checked;
            textBox3_46.Focus();

            if (checkBox3_46.Checked == true)
            {
                listView2.Items.Add("RCT46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_47.Visible = checkBox3_47.Checked;
            textBox3_47.Focus();

            if (checkBox3_47.Checked == true)
            {
                listView2.Items.Add("RCT47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_48.Visible = checkBox3_48.Checked;
            textBox3_48.Focus();

            if (checkBox3_48.Checked == true)
            {
                listView2.Items.Add("RCT48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_49.Visible = checkBox3_49.Checked;
            textBox3_49.Focus();

            if (checkBox3_49.Checked == true)
            {
                listView2.Items.Add("RCT49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_50.Visible = checkBox3_50.Checked;
            textBox3_50.Focus();

            if (checkBox3_50.Checked == true)
            {
                listView2.Items.Add("RCT50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_51.Visible = checkBox3_51.Checked;
            textBox3_51.Focus();

            if (checkBox3_51.Checked == true)
            {
                listView2.Items.Add("RCT51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox3_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox3_52.Visible = checkBox3_52.Checked;
            textBox3_52.Focus();

            if (checkBox3_52.Checked == true)
            {
                listView2.Items.Add("RCT52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox3_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("RCT52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_1.Visible = checkBox51_1.Checked;
            textBox51_1.Focus();


            if (checkBox51_1.Checked == true)
            {
                listView2.Items.Add("DTS1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_2.Visible = checkBox51_2.Checked;
            textBox51_2.Focus();

            if (checkBox51_2.Checked == true)
            {
                listView2.Items.Add("DTS2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_3.Visible = checkBox51_3.Checked;
            textBox51_3.Focus();

            if (checkBox51_3.Checked == true)
            {
                listView2.Items.Add("DTS3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_4.Visible = checkBox51_4.Checked;
            textBox51_4.Focus();

            if (checkBox51_4.Checked == true)
            {
                listView2.Items.Add("DTS4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_5.Visible = checkBox51_5.Checked;
            textBox51_5.Focus();

            if (checkBox51_5.Checked == true)
            {
                listView2.Items.Add("DTS5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_6.Visible = checkBox51_6.Checked;
            textBox51_6.Focus();

            if (checkBox51_6.Checked == true)
            {
                listView2.Items.Add("DTS6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_7.Visible = checkBox51_7.Checked;
            textBox51_7.Focus();

            if (checkBox51_7.Checked == true)
            {
                listView2.Items.Add("DTS7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_8.Visible = checkBox51_8.Checked;
            textBox51_8.Focus();

            if (checkBox51_8.Checked == true)
            {
                listView2.Items.Add("DTS8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_9.Visible = checkBox51_9.Checked;
            textBox51_9.Focus();

            if (checkBox51_9.Checked == true)
            {
                listView2.Items.Add("DTS9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_10.Visible = checkBox51_10.Checked;
            textBox51_10.Focus();

            if (checkBox51_10.Checked == true)
            {
                listView2.Items.Add("DTS10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_11.Visible = checkBox51_11.Checked;
            textBox51_11.Focus();

            if (checkBox51_11.Checked == true)
            {
                listView2.Items.Add("DTS11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_12.Visible = checkBox51_12.Checked;
            textBox51_12.Focus();

            if (checkBox51_12.Checked == true)
            {
                listView2.Items.Add("DTS12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_13.Visible = checkBox51_13.Checked;
            textBox51_13.Focus();

            if (checkBox51_13.Checked == true)
            {
                listView2.Items.Add("DTS13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_14.Visible = checkBox51_14.Checked;
            textBox51_14.Focus();

            if (checkBox51_14.Checked == true)
            {
                listView2.Items.Add("DTS14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_15.Visible = checkBox51_15.Checked;
            textBox51_15.Focus();
            if (checkBox51_15.Checked == true)
            {
                listView2.Items.Add("DTS15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_16.Visible = checkBox51_16.Checked;
            textBox51_16.Focus();

            if (checkBox51_16.Checked == true)
            {
                listView2.Items.Add("DTS16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_17.Visible = checkBox51_17.Checked;
            textBox51_17.Focus();
            if (checkBox51_17.Checked == true)
            {
                listView2.Items.Add("DTS17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_18.Visible = checkBox51_18.Checked;
            textBox51_18.Focus();

            if (checkBox51_18.Checked == true)
            {
                listView2.Items.Add("DTS18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_19.Visible = checkBox51_19.Checked;
            textBox51_19.Focus();

            if (checkBox51_19.Checked == true)
            {
                listView2.Items.Add("DTS19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_20.Visible = checkBox51_20.Checked;
            textBox51_20.Focus();

            if (checkBox51_20.Checked == true)
            {
                listView2.Items.Add("DTS20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_21.Visible = checkBox51_21.Checked;
            textBox51_21.Focus();

            if (checkBox51_21.Checked == true)
            {
                listView2.Items.Add("DTS21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_22.Visible = checkBox51_22.Checked;
            if (checkBox51_22.Checked == true)
            {
                listView2.Items.Add("DTS22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_23.Visible = checkBox51_23.Checked;
            textBox51_23.Focus();

            if (checkBox51_23.Checked == true)
            {
                listView2.Items.Add("DTS23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_24.Visible = checkBox51_24.Checked;
            textBox51_24.Focus();

            if (checkBox51_24.Checked == true)
            {
                listView2.Items.Add("DTS24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_25.Visible = checkBox51_25.Checked;
            textBox51_25.Focus();

            if (checkBox51_25.Checked == true)
            {
                listView2.Items.Add("DTS25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_26.Visible = checkBox51_26.Checked;
            textBox51_26.Focus();

            if (checkBox51_26.Checked == true)
            {
                listView2.Items.Add("DTS26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_27.Visible = checkBox51_27.Checked;
            textBox51_27.Focus();

            if (checkBox51_27.Checked == true)
            {
                listView2.Items.Add("DTS27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_28.Visible = checkBox51_28.Checked;
            textBox51_28.Focus();

            if (checkBox51_28.Checked == true)
            {
                listView2.Items.Add("DTS28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_29.Visible = checkBox51_29.Checked;
            textBox51_29.Focus();

            if (checkBox51_29.Checked == true)
            {
                listView2.Items.Add("DTS29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_30.Visible = checkBox51_30.Checked;
            textBox51_30.Focus();

            if (checkBox51_30.Checked == true)
            {
                listView2.Items.Add("DTS30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_31.Visible = checkBox51_31.Checked;
            textBox51_31.Focus();

            if (checkBox51_31.Checked == true)
            {
                listView2.Items.Add("DTS31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_32.Visible = checkBox51_32.Checked;
            textBox51_32.Focus();

            if (checkBox51_32.Checked == true)
            {
                listView2.Items.Add("DTS32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_33.Visible = checkBox51_33.Checked;
            textBox51_33.Focus();

            if (checkBox51_33.Checked == true)
            {
                listView2.Items.Add("DTS33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_34.Visible = checkBox51_34.Checked;
            textBox51_34.Focus();

            if (checkBox51_34.Checked == true)
            {
                listView2.Items.Add("DTS34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_35.Visible = checkBox51_35.Checked;
            textBox51_35.Focus();

            if (checkBox51_35.Checked == true)
            {
                listView2.Items.Add("DTS35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_36.Visible = checkBox51_36.Checked;
            textBox51_36.Focus();

            if (checkBox51_36.Checked == true)
            {
                listView2.Items.Add("DTS36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_37.Visible = checkBox51_37.Checked;
            textBox51_37.Focus();

            if (checkBox51_37.Checked == true)
            {
                listView2.Items.Add("DTS37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_38.Visible = checkBox51_38.Checked;
            textBox51_38.Focus();

            if (checkBox51_38.Checked == true)
            {
                listView2.Items.Add("DTS38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_39.Visible = checkBox51_39.Checked;
            textBox51_39.Focus();

            if (checkBox51_39.Checked == true)
            {
                listView2.Items.Add("DTS39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_40.Visible = checkBox51_40.Checked;
            textBox51_40.Focus();

            if (checkBox51_40.Checked == true)
            {
                listView2.Items.Add("DTS40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_41.Visible = checkBox51_41.Checked;
            textBox51_41.Focus();

            if (checkBox51_41.Checked == true)
            {
                listView2.Items.Add("DTS41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_42.Visible = checkBox51_42.Checked;
            textBox51_42.Focus();

            if (checkBox51_42.Checked == true)
            {
                listView2.Items.Add("DTS42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_43.Visible = checkBox51_43.Checked;
            textBox51_43.Focus();

            if (checkBox51_43.Checked == true)
            {
                listView2.Items.Add("DTS43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_44.Visible = checkBox51_44.Checked;
            textBox51_44.Focus();

            if (checkBox51_44.Checked == true)
            {
                listView2.Items.Add("DTS44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_45.Visible = checkBox51_45.Checked;
            textBox51_45.Focus();

            if (checkBox51_45.Checked == true)
            {
                listView2.Items.Add("DTS45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_46.Visible = checkBox51_46.Checked;
            textBox51_46.Focus();

            if (checkBox51_46.Checked == true)
            {
                listView2.Items.Add("DTS46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_47.Visible = checkBox51_47.Checked;
            textBox51_47.Focus();

            if (checkBox51_47.Checked == true)
            {
                listView2.Items.Add("DTS47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_48.Visible = checkBox51_48.Checked;
            textBox51_48.Focus();

            if (checkBox51_48.Checked == true)
            {
                listView2.Items.Add("DTS48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_49.Visible = checkBox51_49.Checked;
            textBox51_49.Focus();

            if (checkBox51_49.Checked == true)
            {
                listView2.Items.Add("DTS49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_50.Visible = checkBox51_50.Checked;
            textBox51_50.Focus();

            if (checkBox51_50.Checked == true)
            {
                listView2.Items.Add("DTS50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_51.Visible = checkBox51_51.Checked;
            textBox51_51.Focus();

            if (checkBox51_51.Checked == true)
            {
                listView2.Items.Add("DTS51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox51_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox51_52.Visible = checkBox51_52.Checked;
            textBox51_52.Focus();

            if (checkBox51_52.Checked == true)
            {
                listView2.Items.Add("DTS52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox51_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("DTS52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_1.Visible = checkBox52_1.Checked;
            textBox52_1.Focus();

            if (checkBox52_1.Checked == true)
            {
                listView2.Items.Add("EXT1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_2.Visible = checkBox52_2.Checked;
            textBox52_2.Focus();

            if (checkBox52_2.Checked == true)
            {
                listView2.Items.Add("EXT2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_3.Visible = checkBox52_3.Checked;
            textBox52_3.Focus();

            if (checkBox52_3.Checked == true)
            {
                listView2.Items.Add("EXT3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_4.Visible = checkBox52_4.Checked;
            textBox52_4.Focus();

            if (checkBox52_4.Checked == true)
            {
                listView2.Items.Add("EXT4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_5.Visible = checkBox52_5.Checked;
            textBox52_5.Focus();

            if (checkBox52_5.Checked == true)
            {
                listView2.Items.Add("EXT5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_6.Visible = checkBox52_6.Checked;
            textBox52_6.Focus();

            if (checkBox52_6.Checked == true)
            {
                listView2.Items.Add("EXT6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_7.Visible = checkBox52_7.Checked;
            textBox52_7.Focus();

            if (checkBox52_7.Checked == true)
            {
                listView2.Items.Add("EXT7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_8.Visible = checkBox52_8.Checked;
            textBox52_8.Focus();

            if (checkBox52_8.Checked == true)
            {
                listView2.Items.Add("EXT8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_9.Visible = checkBox52_9.Checked;
            textBox52_9.Focus();

            if (checkBox52_9.Checked == true)
            {
                listView2.Items.Add("EXT9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_10.Visible = checkBox52_10.Checked;
            textBox52_10.Focus();

            if (checkBox52_10.Checked == true)
            {
                listView2.Items.Add("EXT10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_11.Visible = checkBox52_11.Checked;
            textBox52_11.Focus();

            if (checkBox52_11.Checked == true)
            {
                listView2.Items.Add("EXT11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_12.Visible = checkBox52_12.Checked;
            textBox52_12.Focus();

            if (checkBox52_12.Checked == true)
            {
                listView2.Items.Add("EXT12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_13.Visible = checkBox52_13.Checked;
            textBox52_13.Focus();

            if (checkBox52_13.Checked == true)
            {
                listView2.Items.Add("EXT13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_14.Visible = checkBox52_14.Checked;
            textBox52_14.Focus();

            if (checkBox52_14.Checked == true)
            {
                listView2.Items.Add("EXT14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_15.Visible = checkBox52_15.Checked;
            textBox52_15.Focus();

            if (checkBox52_15.Checked == true)
            {
                listView2.Items.Add("EXT15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_16.Visible = checkBox52_16.Checked;
            textBox52_16.Focus();

            if (checkBox52_16.Checked == true)
            {
                listView2.Items.Add("EXT16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_17.Visible = checkBox52_17.Checked;
            textBox52_17.Focus();

            if (checkBox52_17.Checked == true)
            {
                listView2.Items.Add("EXT17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_18.Visible = checkBox52_18.Checked;
            textBox52_18.Focus();

            if (checkBox52_18.Checked == true)
            {
                listView2.Items.Add("EXT18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_19.Visible = checkBox52_19.Checked;
            textBox52_19.Focus();

            if (checkBox52_19.Checked == true)
            {
                listView2.Items.Add("EXT19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_20.Visible = checkBox52_20.Checked;
            textBox52_20.Focus();

            if (checkBox52_20.Checked == true)
            {
                listView2.Items.Add("EXT20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_21.Visible = checkBox52_21.Checked;
            textBox52_21.Focus();

            if (checkBox52_21.Checked == true)
            {
                listView2.Items.Add("EXT21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_22.Visible = checkBox52_22.Checked;
            textBox52_22.Focus();

            if (checkBox52_22.Checked == true)
            {
                listView2.Items.Add("EXT22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_23.Visible = checkBox52_23.Checked;
            textBox52_23.Focus();

            if (checkBox52_23.Checked == true)
            {
                listView2.Items.Add("EXT23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_24.Visible = checkBox52_24.Checked;
            textBox52_24.Focus();

            if (checkBox52_24.Checked == true)
            {
                listView2.Items.Add("EXT24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_25.Visible = checkBox52_25.Checked;
            textBox52_25.Focus();

            if (checkBox52_25.Checked == true)
            {
                listView2.Items.Add("EXT25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_26.Visible = checkBox52_26.Checked;
            textBox52_26.Focus();

            if (checkBox52_26.Checked == true)
            {
                listView2.Items.Add("EXT26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_27.Visible = checkBox52_27.Checked;
            textBox52_27.Focus();

            if (checkBox52_27.Checked == true)
            {
                listView2.Items.Add("EXT27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_28.Visible = checkBox52_28.Checked;
            textBox52_28.Focus();

            if (checkBox52_28.Checked == true)
            {
                listView2.Items.Add("EXT28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_29.Visible = checkBox52_29.Checked;
            textBox52_29.Focus();

            if (checkBox52_29.Checked == true)
            {
                listView2.Items.Add("EXT29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_30.Visible = checkBox52_30.Checked;
            textBox52_30.Focus();

            if (checkBox52_30.Checked == true)
            {
                listView2.Items.Add("EXT30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_31.Visible = checkBox52_31.Checked;
            textBox52_31.Focus();

            if (checkBox52_31.Checked == true)
            {
                listView2.Items.Add("EXT31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_32.Visible = checkBox52_32.Checked;
            textBox52_32.Focus();

            if (checkBox52_32.Checked == true)
            {
                listView2.Items.Add("EXT32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_33.Visible = checkBox52_33.Checked;
            textBox52_33.Focus();

            if (checkBox52_33.Checked == true)
            {
                listView2.Items.Add("EXT33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_34.Visible = checkBox52_34.Checked;
            textBox52_34.Focus();

            if (checkBox52_34.Checked == true)
            {
                listView2.Items.Add("EXT34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_35.Visible = checkBox52_35.Checked;
            textBox52_35.Focus();

            if (checkBox52_35.Checked == true)
            {
                listView2.Items.Add("EXT35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_36.Visible = checkBox52_36.Checked;
            textBox52_36.Focus();

            if (checkBox52_36.Checked == true)
            {
                listView2.Items.Add("EXT36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_37.Visible = checkBox52_37.Checked;
            textBox52_37.Focus();

            if (checkBox52_37.Checked == true)
            {
                listView2.Items.Add("EXT37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_38.Visible = checkBox52_38.Checked;
            textBox52_38.Focus();

            if (checkBox52_38.Checked == true)
            {
                listView2.Items.Add("EXT38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_39.Visible = checkBox52_39.Checked;
            textBox52_39.Focus();

            if (checkBox52_39.Checked == true)
            {
                listView2.Items.Add("EXT39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_40.Visible = checkBox52_40.Checked;
            textBox52_40.Focus();

            if (checkBox52_40.Checked == true)
            {
                listView2.Items.Add("EXT40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_41.Visible = checkBox52_41.Checked;
            textBox52_41.Focus();

            if (checkBox52_41.Checked == true)
            {
                listView2.Items.Add("EXT41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_42.Visible = checkBox52_42.Checked;
            textBox52_42.Focus();

            if (checkBox52_42.Checked == true)
            {
                listView2.Items.Add("EXT42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_43.Visible = checkBox52_43.Checked;
            textBox52_43.Focus();

            if (checkBox52_43.Checked == true)
            {
                listView2.Items.Add("EXT43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_44.Visible = checkBox52_44.Checked;
            textBox52_44.Focus();

            if (checkBox52_44.Checked == true)
            {
                listView2.Items.Add("EXT44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_45.Visible = checkBox52_45.Checked;
            textBox52_45.Focus();

            if (checkBox52_45.Checked == true)
            {
                listView2.Items.Add("EXT45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_46.Visible = checkBox52_46.Checked;
            textBox52_46.Focus();

            if (checkBox52_46.Checked == true)
            {
                listView2.Items.Add("EXT46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_47.Visible = checkBox52_47.Checked;
            textBox52_47.Focus();

            if (checkBox52_47.Checked == true)
            {
                listView2.Items.Add("EXT47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_48.Visible = checkBox52_48.Checked;
            textBox52_48.Focus();

            if (checkBox52_48.Checked == true)
            {
                listView2.Items.Add("EXT48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_49.Visible = checkBox52_49.Checked;
            textBox52_49.Focus();

            if (checkBox52_49.Checked == true)
            {
                listView2.Items.Add("EXT49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_50.Visible = checkBox52_50.Checked;
            textBox52_50.Focus();

            if (checkBox52_50.Checked == true)
            {
                listView2.Items.Add("EXT50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_51.Visible = checkBox52_51.Checked;
            textBox52_51.Focus();

            if (checkBox52_51.Checked == true)
            {
                listView2.Items.Add("EXT51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox52_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox52_52.Visible = checkBox52_52.Checked;
            textBox52_52.Focus();

            if (checkBox52_52.Checked == true)
            {
                listView2.Items.Add("EXT52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox52_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("EXT52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_1.Visible = checkBox6_1.Checked;
            textBox6_1.Focus();

            if (checkBox6_1.Checked == true)
            {
                listView2.Items.Add("CL1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_2.Visible = checkBox6_2.Checked;
            textBox6_2.Focus();

            if (checkBox6_2.Checked == true)
            {
                listView2.Items.Add("CL2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_3.Visible = checkBox6_3.Checked;
            textBox6_3.Focus();

            if (checkBox6_3.Checked == true)
            {
                listView2.Items.Add("CL3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_4.Visible = checkBox6_4.Checked;
            textBox6_4.Focus();

            if (checkBox6_4.Checked == true)
            {
                listView2.Items.Add("CL4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_5.Visible = checkBox6_5.Checked;
            textBox6_5.Focus();

            if (checkBox6_5.Checked == true)
            {
                listView2.Items.Add("CL5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_6.Visible = checkBox6_6.Checked;
            textBox6_6.Focus();

            if (checkBox6_6.Checked == true)
            {
                listView2.Items.Add("CL6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_7.Visible = checkBox6_7.Checked;
            textBox6_7.Focus();

            if (checkBox6_7.Checked == true)
            {
                listView2.Items.Add("CL7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_8.Visible = checkBox6_8.Checked;
            textBox6_8.Focus();

            if (checkBox6_8.Checked == true)
            {
                listView2.Items.Add("CL8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_9.Visible = checkBox6_9.Checked;
            textBox6_9.Focus();

            if (checkBox6_9.Checked == true)
            {
                listView2.Items.Add("CL9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_10.Visible = checkBox6_10.Checked;
            textBox6_10.Focus();

            if (checkBox6_10.Checked == true)
            {
                listView2.Items.Add("CL10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_11.Visible = checkBox6_11.Checked;
            textBox6_11.Focus();

            if (checkBox6_11.Checked == true)
            {
                listView2.Items.Add("CL11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_12.Visible = checkBox6_12.Checked;
            textBox6_12.Focus();

            if (checkBox6_12.Checked == true)
            {
                listView2.Items.Add("CL12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_13.Visible = checkBox6_13.Checked;
            textBox6_13.Focus();

            if (checkBox6_13.Checked == true)
            {
                listView2.Items.Add("CL13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_14.Visible = checkBox6_14.Checked;
            textBox6_14.Focus();

            if (checkBox6_14.Checked == true)
            {
                listView2.Items.Add("CL14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_15.Visible = checkBox6_15.Checked;
            textBox6_15.Focus();

            if (checkBox6_15.Checked == true)
            {
                listView2.Items.Add("CL15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_16.Visible = checkBox6_16.Checked;
            textBox6_16.Focus();

            if (checkBox6_16.Checked == true)
            {
                listView2.Items.Add("CL16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_17.Visible = checkBox6_17.Checked;
            textBox6_17.Focus();

            if (checkBox6_17.Checked == true)
            {
                listView2.Items.Add("CL17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_18.Visible = checkBox6_18.Checked;
            textBox6_18.Focus();
            if (checkBox6_18.Checked == true)
            {
                listView2.Items.Add("CL18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_19.Visible = checkBox6_19.Checked;
            textBox6_19.Focus();
            if (checkBox6_19.Checked == true)
            {
                listView2.Items.Add("CL19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_20.Visible = checkBox6_20.Checked;
            textBox6_20.Focus();

            if (checkBox6_20.Checked == true)
            {
                listView2.Items.Add("CL20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_21.Visible = checkBox6_21.Checked;
            textBox6_21.Focus();

            if (checkBox6_21.Checked == true)
            {
                listView2.Items.Add("CL21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_22.Visible = checkBox6_22.Checked;
            textBox6_22.Focus();

            if (checkBox6_22.Checked == true)
            {
                listView2.Items.Add("CL22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox6_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_23.Visible = checkBox6_23.Checked;
            textBox6_23.Focus();

            if (checkBox6_23.Checked == true)
            {
                listView2.Items.Add("CL23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_24.Visible = checkBox6_24.Checked;
            textBox6_24.Focus();

            if (checkBox6_24.Checked == true)
            {
                listView2.Items.Add("CL24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_25.Visible = checkBox6_25.Checked;
            textBox6_25.Focus();

            if (checkBox6_25.Checked == true)
            {
                listView2.Items.Add("CL25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_26.Visible = checkBox6_26.Checked;
            textBox6_26.Focus();

            if (checkBox6_26.Checked == true)
            {
                listView2.Items.Add("CL26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_27.Visible = checkBox6_27.Checked;
            textBox6_27.Focus();

            if (checkBox6_27.Checked == true)
            {
                listView2.Items.Add("CL27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_28.Visible = checkBox6_28.Checked;
            textBox6_28.Focus();

            if (checkBox6_28.Checked == true)
            {
                listView2.Items.Add("CL28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_29.Visible = checkBox6_29.Checked;
            textBox6_29.Focus();

            if (checkBox6_29.Checked == true)
            {
                listView2.Items.Add("CL29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_30.Visible = checkBox6_30.Checked;
            textBox6_30.Focus();

            if (checkBox6_30.Checked == true)
            {
                listView2.Items.Add("CL30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_31.Visible = checkBox6_31.Checked;
            textBox6_31.Focus();

            if (checkBox6_31.Checked == true)
            {
                listView2.Items.Add("CL31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox6_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox6_32.Visible = checkBox6_32.Checked;
            textBox6_32.Focus();

            if (checkBox6_32.Checked == true)
            {
                listView2.Items.Add("CL32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_1_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_1.Visible = checkBox7_1.Checked;
            textBox7_1.Focus();

            if (checkBox7_1.Checked == true)
            {
                listView2.Items.Add("OTH1");
                listView2.Items[LI].SubItems.Add("1");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_1.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_2_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_2.Visible = checkBox7_2.Checked;
            textBox7_2.Focus();

            if (checkBox7_2.Checked == true)
            {
                listView2.Items.Add("OTH2");
                listView2.Items[LI].SubItems.Add("2");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_2.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_3_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_3.Visible = checkBox7_3.Checked;
            textBox7_3.Focus();

            if (checkBox7_3.Checked == true)
            {
                listView2.Items.Add("OTH3");
                listView2.Items[LI].SubItems.Add("3");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_3.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_4_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_4.Visible = checkBox7_4.Checked;
            textBox7_4.Focus();

            if (checkBox7_4.Checked == true)
            {
                listView2.Items.Add("OTH4");
                listView2.Items[LI].SubItems.Add("4");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_4.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH4", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_5_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_5.Visible = checkBox7_5.Checked;
            textBox7_5.Focus();

            if (checkBox7_5.Checked == true)
            {
                listView2.Items.Add("OTH5");
                listView2.Items[LI].SubItems.Add("5");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_5.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH5", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_6_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_6.Visible = checkBox7_6.Checked;
            textBox7_6.Focus();

            if (checkBox7_6.Checked == true)
            {
                listView2.Items.Add("OTH6");
                listView2.Items[LI].SubItems.Add("6");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_6.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH6", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_7_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_7.Visible = checkBox7_7.Checked;
            textBox7_7.Focus();

            if (checkBox7_7.Checked == true)
            {
                listView2.Items.Add("OTH7");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH7", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_8_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_8.Visible = checkBox7_8.Checked;
            textBox7_8.Focus();

            if (checkBox7_8.Checked == true)
            {
                listView2.Items.Add("OTH8");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH8", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_9_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_9.Visible = checkBox7_9.Checked;
            textBox7_9.Focus();

            if (checkBox7_9.Checked == true)
            {
                listView2.Items.Add("OTH9");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH9", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_10_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_10.Visible = checkBox7_10.Checked;
            textBox7_10.Focus();

            if (checkBox7_10.Checked == true)
            {
                listView2.Items.Add("OTH10");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH10", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_11_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_11.Visible = checkBox7_11.Checked;
            textBox7_11.Focus();

            if (checkBox7_11.Checked == true)
            {
                listView2.Items.Add("OTH11");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH11", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_12_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_12.Visible = checkBox7_12.Checked;
            textBox7_12.Focus();

            if (checkBox7_12.Checked == true)
            {
                listView2.Items.Add("OTH12");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH12", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_13_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_13.Visible = checkBox7_13.Checked;
            textBox7_13.Focus();

            if (checkBox7_13.Checked == true)
            {
                listView2.Items.Add("OTH13");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH13", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_14_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_14.Visible = checkBox7_14.Checked;
            textBox7_14.Focus();
            if (checkBox7_14.Checked == true)
            {
                listView2.Items.Add("OTH14");
                listView2.Items[LI].SubItems.Add("14");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_14.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH14", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_15_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_15.Visible = checkBox7_15.Checked;
            textBox7_15.Focus();

            if (checkBox7_15.Checked == true)
            {
                listView2.Items.Add("OTH15");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH15", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_16_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_16.Visible = checkBox7_16.Checked;
            textBox7_16.Focus();

            if (checkBox7_16.Checked == true)
            {
                listView2.Items.Add("OTH16");
                listView2.Items[LI].SubItems.Add("16");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_16.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH16", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_17_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_17.Visible = checkBox7_17.Checked;
            textBox7_17.Focus();

            if (checkBox7_17.Checked == true)
            {
                listView2.Items.Add("OTH17");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH17", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_18_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_18.Visible = checkBox7_18.Checked;
            textBox7_18.Focus();

            if (checkBox7_18.Checked == true)
            {
                listView2.Items.Add("OTH18");
                listView2.Items[LI].SubItems.Add("18");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_18.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH18", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_19_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_19.Visible = checkBox7_19.Checked;
            textBox7_19.Focus();

            if (checkBox7_19.Checked == true)
            {
                listView2.Items.Add("OTH19");
                listView2.Items[LI].SubItems.Add("19");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_19.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH19", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_20_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_20.Visible = checkBox7_20.Checked;
            textBox7_20.Focus();

            if (checkBox7_20.Checked == true)
            {
                listView2.Items.Add("OTH20");
                listView2.Items[LI].SubItems.Add("20");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_20.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH20", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_21_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_21.Visible = checkBox7_21.Checked;
            textBox7_21.Focus();

            if (checkBox7_21.Checked == true)
            {
                listView2.Items.Add("OTH21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_21.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH21", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_22_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_22.Visible = checkBox7_22.Checked;
            textBox7_22.Focus();

            if (checkBox7_22.Checked == true)
            {
                listView2.Items.Add("OTH22");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH22", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_23_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_23.Visible = checkBox7_23.Checked;
            textBox7_23.Focus();

            if (checkBox7_23.Checked == true)
            {
                listView2.Items.Add("OTH23");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH23", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_24_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_24.Visible = checkBox7_24.Checked;
            textBox7_24.Focus();

            if (checkBox7_24.Checked == true)
            {
                listView2.Items.Add("OTH24");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH24", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_25_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_25.Visible = checkBox7_25.Checked;
            textBox7_25.Focus();

            if (checkBox7_25.Checked == true)
            {
                listView2.Items.Add("OTH25");
                listView2.Items[LI].SubItems.Add("25");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_25.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH25", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_26_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_26.Visible = checkBox7_26.Checked;
            textBox7_26.Focus();

            if (checkBox7_26.Checked == true)
            {
                listView2.Items.Add("OTH26");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH26", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_27_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_27.Visible = checkBox7_27.Checked;
            textBox7_27.Focus();

            if (checkBox7_27.Checked == true)
            {
                listView2.Items.Add("OTH27");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH27", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_28_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_28.Visible = checkBox7_28.Checked;
            textBox7_28.Focus();

            if (checkBox7_28.Checked == true)
            {
                listView2.Items.Add("OTH28");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH28", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_29_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_29.Visible = checkBox7_29.Checked;
            textBox7_29.Focus();

            if (checkBox7_29.Checked == true)
            {
                listView2.Items.Add("OTH29");
                listView2.Items[LI].SubItems.Add("29");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_29.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH29", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_30_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_30.Visible = checkBox7_30.Checked;
            textBox7_30.Focus();

            if (checkBox7_30.Checked == true)
            {
                listView2.Items.Add("OTH30");
                listView2.Items[LI].SubItems.Add("30");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_30.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH30", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_31_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_31.Visible = checkBox7_31.Checked;
            textBox7_31.Focus();

            if (checkBox7_31.Checked == true)
            {
                listView2.Items.Add("OTH31");
                listView2.Items[LI].SubItems.Add("31");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_31.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH31", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_32_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_32.Visible = checkBox7_32.Checked;
            textBox7_32.Focus();

            if (checkBox7_32.Checked == true)
            {
                listView2.Items.Add("OTH32");
                listView2.Items[LI].SubItems.Add("32");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_32.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH32", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_33_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_33.Visible = checkBox7_33.Checked;
            textBox7_33.Focus();
            if (checkBox7_33.Checked == true)
            {
                listView2.Items.Add("OTH33");
                listView2.Items[LI].SubItems.Add("33");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_33.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH33", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_34_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_34.Visible = checkBox7_34.Checked;
            textBox7_34.Focus();

            if (checkBox7_34.Checked == true)
            {
                listView2.Items.Add("OTH34");
                listView2.Items[LI].SubItems.Add("34");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_34.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH34", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_35_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_35.Visible = checkBox7_35.Checked;
            textBox7_35.Focus();

            if (checkBox7_35.Checked == true)
            {
                listView2.Items.Add("OTH35");
                listView2.Items[LI].SubItems.Add("35");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_35.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH35", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_36_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_36.Visible = checkBox7_36.Checked;
            textBox7_36.Focus();

            if (checkBox7_36.Checked == true)
            {
                listView2.Items.Add("OTH36");
                listView2.Items[LI].SubItems.Add("36");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_36.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH36", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_37_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_37.Visible = checkBox7_37.Checked;
            textBox7_37.Focus();

            if (checkBox7_37.Checked == true)
            {
                listView2.Items.Add("OTH37");
                listView2.Items[LI].SubItems.Add("37");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_37.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH37", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_38_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_38.Visible = checkBox7_38.Checked;
            textBox7_38.Focus();
            if (checkBox7_38.Checked == true)
            {
                listView2.Items.Add("OTH38");
                listView2.Items[LI].SubItems.Add("38");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_38.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH38", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_39_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_39.Visible = checkBox7_39.Checked;
            textBox7_39.Focus();
            if (checkBox7_39.Checked == true)
            {
                listView2.Items.Add("OTH39");
                listView2.Items[LI].SubItems.Add("39");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_39.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH39", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_40_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_40.Visible = checkBox7_40.Checked;
            textBox7_40.Focus();
            if (checkBox7_40.Checked == true)
            {
                listView2.Items.Add("OTH40");
                listView2.Items[LI].SubItems.Add("40");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_40.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH40", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_41_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_41.Visible = checkBox7_41.Checked;
            textBox7_41.Focus();
            if (checkBox7_41.Checked == true)
            {
                listView2.Items.Add("OTH41");
                listView2.Items[LI].SubItems.Add("41");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_41.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH41", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_42_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_42.Visible = checkBox7_42.Checked;
            textBox7_42.Focus();
            if (checkBox7_42.Checked == true)
            {
                listView2.Items.Add("OTH42");
                listView2.Items[LI].SubItems.Add("42");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_42.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH42", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_43_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_43.Visible = checkBox7_43.Checked;
            textBox7_43.Focus();
            if (checkBox7_43.Checked == true)
            {
                listView2.Items.Add("OTH43");
                listView2.Items[LI].SubItems.Add("43");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_43.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH43", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_44_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_44.Visible = checkBox7_44.Checked;
            textBox7_44.Focus();

            if (checkBox7_44.Checked == true)
            {
                listView2.Items.Add("OTH44");
                listView2.Items[LI].SubItems.Add("44");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_44.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH44", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_45_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_45.Visible = checkBox7_45.Checked;
            textBox7_45.Focus();

            if (checkBox7_45.Checked == true)
            {
                listView2.Items.Add("OTH45");
                listView2.Items[LI].SubItems.Add("45");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_45.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH45", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_46_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_46.Visible = checkBox7_46.Checked;
            textBox7_46.Focus();

            if (checkBox7_46.Checked == true)
            {
                listView2.Items.Add("OTH46");
                listView2.Items[LI].SubItems.Add("46");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_46.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH46", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_47_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_47.Visible = checkBox7_47.Checked;
            textBox7_47.Focus();

            if (checkBox7_47.Checked == true)
            {
                listView2.Items.Add("OTH47");
                listView2.Items[LI].SubItems.Add("47");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_47.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH47", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_48_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_48.Visible = checkBox7_48.Checked;
            textBox7_48.Focus();

            if (checkBox7_48.Checked == true)
            {
                listView2.Items.Add("OTH48");
                listView2.Items[LI].SubItems.Add("48");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_48.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH48", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_49_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_49.Visible = checkBox7_49.Checked;
            textBox7_49.Focus();

            if (checkBox7_49.Checked == true)
            {
                listView2.Items.Add("OTH49");
                listView2.Items[LI].SubItems.Add("49");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_49.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH49", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_50_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_50.Visible = checkBox7_50.Checked;
            textBox7_50.Focus();

            if (checkBox7_50.Checked == true)
            {
                listView2.Items.Add("OTH50");
                listView2.Items[LI].SubItems.Add("50");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_50.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH50", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_51_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_51.Visible = checkBox7_51.Checked;
            textBox7_51.Focus();

            if (checkBox7_51.Checked == true)
            {
                listView2.Items.Add("OTH51");
                listView2.Items[LI].SubItems.Add("51");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_51.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH51", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_52_CheckedChanged(object sender, EventArgs e)
        {
            textBox7_52.Visible = checkBox7_52.Checked;
            textBox7_52.Focus();

            if (checkBox7_52.Checked == true)
            {
                listView2.Items.Add("OTH52");
                listView2.Items[LI].SubItems.Add("52");
                listView2.Items[LI].SubItems.Add("21");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_52.Checked == false)
            {
                foundItem = listView2.FindItemWithText("OTH52", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox1_c7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c7.Checked == true)
            {
                listView2.Items.Add("BW LEFT");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("7");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c7.Checked == false)
            {
                foundItem = listView2.FindItemWithText("BW LEFT", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_c8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c8.Checked == true)
            {
                listView2.Items.Add("BW RIGHT");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("8");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c8.Checked == false)
            {
                foundItem = listView2.FindItemWithText("BW RIGHT", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
   
        }

        private void checkBox1_c13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c13.Checked == true)
            {
                listView2.Items.Add("Cephalometry");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("13");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c13.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Cephalometry", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_c9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c9.Checked == true)
            {
                listView2.Items.Add("CtScan");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("9");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c9.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CtScan", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_c10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c10.Checked == true)
            {
                listView2.Items.Add("MRI");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("10");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c10.Checked == false)
            {
                foundItem = listView2.FindItemWithText("MRI", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_c11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c11.Checked == true)
            {
                listView2.Items.Add("TMJ");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("11");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c11.Checked == false)
            {
                foundItem = listView2.FindItemWithText("TMJ", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox1_c12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_c12.Checked == true)
            {
                listView2.Items.Add("SioloGraphy");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("12");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox1_c12.Checked == false)
            {
                foundItem = listView2.FindItemWithText("SioloGraphy", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox6_C22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6_C22.Checked == true)
            {
                listView2.Items.Add("Scaling");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("22");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_C22.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Scaling", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox6_C17_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = checkBox6_C17.Checked;

            if (checkBox6_C17.Checked == true)
            {
                listView2.Items.Add("Perio SX");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("17");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_C17.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Perio SX", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox6_C23_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBox6_C23.Checked;
            if (checkBox6_C23.Checked == true)
            {
                listView2.Items.Add("Curettage");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("23");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_C23.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Curettage", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }

        }

        private void checkBox6_c24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6_c24.Checked == true)
            {
                listView2.Items.Add("CL");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("24");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox6_c24.Checked == false)
            {
                foundItem = listView2.FindItemWithText("CL", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

 

        private void checkBox7_C15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7_C15.Checked == true)
            {
                listView2.Items.Add("Ortho Tx");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("15");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_C15.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Ortho Tx", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

 

  

   

   

        private void checkBox7_C26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7_C26.Checked == true)
            {
                listView2.Items.Add("Orup Patho1");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("26");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_C26.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Orup Patho1", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_C27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7_C27.Checked == true)
            {
                listView2.Items.Add("Orup Patho2");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("27");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_C27.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Orup Patho2", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void checkBox7_C28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7_C28.Checked == true)
            {
                listView2.Items.Add("Orup Patho3");
                listView2.Items[LI].SubItems.Add("100");
                listView2.Items[LI].SubItems.Add("28");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                listView2.Items[LI].SubItems.Add("NULL");
                LI = LI + 1;
            }
            else if (checkBox7_C28.Checked == false)
            {
                foundItem = listView2.FindItemWithText("Orup Patho3", false, 0);
                listView2.Items.Remove(foundItem);
                LI = LI - 1;
            }
        }

        private void textBox1_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA1", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_1.Text;
        }

        private void textBox1_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA2", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_2.Text;
        }

        private void textBox1_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA3", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_3.Text;
        }

        private void textBox1_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA4", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_4.Text;
        }

        private void textBox1_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA5", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_5.Text;
        }

        private void textBox1_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA6", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_6.Text;
        }

        private void textBox1_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA7", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_7.Text;
        }

        private void textBox1_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA8", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_8.Text;
        }

        private void textBox1_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA9", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_9.Text;
        }

        private void textBox1_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA10", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_10.Text;
        }

        private void textBox1_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA11", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_11.Text;
        }

        private void textBox1_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA12", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_12.Text;
        }

        private void textBox1_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA13", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_13.Text;
        }

        private void textBox1_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA14", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_14.Text;
        }

        private void textBox1_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA15", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_15.Text;
        }

        private void textBox1_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA16", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_16.Text;
        }

        private void textBox1_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA17", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_17.Text;
        }

        private void textBox1_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA18", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_18.Text;
        }

        private void textBox1_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA19", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_19.Text;
        }

        private void textBox1_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA20", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_20.Text;
        }

        private void textBox1_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA21", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_21.Text;
        }

        private void textBox1_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA22", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_22.Text;
        }

        private void textBox1_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA23", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_23.Text;
        }

        private void textBox1_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA24", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_24.Text;
        }

        private void textBox1_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA25", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_25.Text;
        }

        private void textBox1_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA26", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_26.Text;
        }

        private void textBox1_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA27", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_27.Text;
        }

        private void textBox1_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA28", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_28.Text;
        }

        private void textBox1_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA29", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_29.Text;
        }

        private void textBox1_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA30", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_30.Text;
        }

        private void textBox1_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA31", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_31.Text;
        }

        private void textBox1_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA32", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_32.Text;
        }

        private void textBox1_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA33", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_33.Text;
        }

        private void textBox1_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA34", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_34.Text;
        }

        private void textBox1_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA35", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_35.Text;
        }

        private void textBox1_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA36", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_36.Text;
        }

        private void textBox1_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA37", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_37.Text;
        }

        private void textBox1_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA38", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_38.Text;
        }

        private void textBox1_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA39", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_39.Text;
        }

        private void textBox1_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA40", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_40.Text;
        }

        private void textBox1_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA41", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_41.Text;
        }

        private void textBox1_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA42", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_42.Text;
        }

        private void textBox1_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA43", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_43.Text;
        }

        private void textBox1_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA44", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_44.Text;
        }

        private void textBox1_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA45", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_45.Text;
        }

        private void textBox1_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA46", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_46.Text;
        }

        private void textBox1_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA47", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_47.Text;
        }

        private void textBox1_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA48", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_48.Text;
        }

        private void textBox1_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA49", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_49.Text;
        }

        private void textBox1_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA50", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_50.Text;
        }

        private void textBox1_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA51", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_51.Text;
        }

        private void textBox1_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("PA52", false, 0);
            listView2.Items[foundItem.Index].SubItems[3].Text = textBox1_52.Text;
        }

        private void textBox2_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST1", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_1.Text;
        }

        private void textBox2_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST2", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_2.Text;
        }

        private void textBox2_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST3", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_3.Text;
        }

        private void textBox2_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST4", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_4.Text;
        }

        private void textBox2_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST5", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_5.Text;
        }

        private void textBox2_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST6", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_6.Text;
        }

        private void textBox2_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST7", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_7.Text;
        }

        private void textBox2_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST8", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_8.Text;
        }

        private void textBox2_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST9", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_9.Text;
        }

        private void textBox2_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST10", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_10.Text;
        }

        private void textBox2_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST11", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_11.Text;
        }

        private void textBox2_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST12", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_12.Text;
        }

        private void textBox2_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST13", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_13.Text;
        }

        private void textBox2_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST14", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_14.Text;
        }

        private void textBox2_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST15", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_15.Text;
        }

        private void textBox2_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST16", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_16.Text;
        }

        private void textBox2_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST17", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_17.Text;
        }

        private void textBox2_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST18", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_18.Text;
        }

        private void textBox2_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST19", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_19.Text;
        }

        private void textBox2_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST20", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_20.Text;
        }

        private void textBox2_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST21", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_21.Text;
        }

        private void textBox2_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST22", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_22.Text;
        }

        private void textBox2_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST23", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_23.Text;
        }

        private void textBox2_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST24", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_24.Text;
        }

        private void textBox2_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST25", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_25.Text;
        }

        private void textBox2_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST26", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_26.Text;
        }

        private void textBox2_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST27", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_27.Text;
        }

        private void textBox2_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST28", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_28.Text;
        }

        private void textBox2_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST29", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_29.Text;
        }

        private void textBox2_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST30", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_30.Text;
        }

        private void textBox2_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST31", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_31.Text;
        }

        private void textBox2_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST32", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_32.Text;
        }

        private void textBox2_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST33", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_33.Text;
        }

        private void textBox2_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST34", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_34.Text;
        }

        private void textBox2_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST35", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_35.Text;
        }

        private void textBox2_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST36", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_36.Text;
        }

        private void textBox2_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST37", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_37.Text;
        }

        private void textBox2_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST38", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_38.Text;
        }

        private void textBox2_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST39", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_39.Text;
        }

        private void textBox2_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST40", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_40.Text;
        }

        private void textBox2_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST41", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_41.Text;
        }

        private void textBox2_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST42", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_42.Text;
        }

        private void textBox2_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST43", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_43.Text;
        }

        private void textBox2_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST44", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_44.Text;
        }

        private void textBox2_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST45", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_45.Text;
        }

        private void textBox2_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST46", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_46.Text;
        }

        private void textBox2_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST47", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_47.Text;
        }

        private void textBox2_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST48", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_48.Text;
        }

        private void textBox2_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST49", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_49.Text;
        }

        private void textBox2_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST50", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_50.Text;
        }

        private void textBox2_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST51", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_51.Text;
        }

        private void textBox2_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RST52", false, 0);
            listView2.Items[foundItem.Index].SubItems[4].Text = textBox2_52.Text;
        }

        private void textBox3_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT1", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_1.Text;
        }

        private void textBox3_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT2", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_2.Text;
        }

        private void textBox3_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT3", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_3.Text;
        }

        private void textBox3_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT4", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_4.Text;
        }

        private void textBox3_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT5", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_5.Text;
        }

        private void textBox3_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT6", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_6.Text;
        }

        private void textBox3_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT7", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_7.Text;
        }

        private void textBox3_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT8", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_8.Text;
        }

        private void textBox3_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT9", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_9.Text;
        }

        private void textBox3_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT10", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_10.Text;
        }

        private void textBox3_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT11", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_11.Text;
        }

        private void textBox3_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT12", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_12.Text;
        }

        private void textBox3_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT13", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_13.Text;
        }

        private void textBox3_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT14", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_14.Text;
        }

        private void textBox3_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT15", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_15.Text;
        }

        private void textBox3_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT16", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_16.Text;
        }

        private void textBox3_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT17", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_17.Text;
        }

        private void textBox3_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT18", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_18.Text;
        }

        private void textBox3_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT19", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_19.Text;
        }

        private void textBox3_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT20", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_20.Text;
        }

        private void textBox3_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT21", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_21.Text;
        }

        private void textBox3_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT22", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_22.Text;
        }

        private void textBox3_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT23", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_23.Text;

        }

        private void textBox3_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT24", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_24.Text;
        }

        private void textBox3_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT25", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_25.Text;
        }

        private void textBox3_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT26", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_26.Text;
        }

        private void textBox3_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT27", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_27.Text;
        }

        private void textBox3_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT28", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_28.Text;
        }

        private void textBox3_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT29", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_29.Text;
        }

        private void textBox3_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT30", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_30.Text;
        }

        private void textBox3_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT31", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_31.Text;
        }

        private void textBox3_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT32", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_32.Text;
        }

        private void textBox3_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT33", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_33.Text;
        }

        private void textBox3_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT34", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_34.Text;
        }

        private void textBox3_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT35", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_35.Text;
        }

        private void textBox3_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT36", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_36.Text;
        }

        private void textBox3_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT37", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_37.Text;
        }

        private void textBox3_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT38", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_38.Text;
        }

        private void textBox3_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT39", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_39.Text;
        }

        private void textBox3_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT40", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_40.Text;
        }

        private void textBox3_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT41", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_41.Text;
        }

        private void textBox3_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT42", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_42.Text;
        }

        private void textBox3_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT43", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_43.Text;
        }

        private void textBox3_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT44", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_44.Text;
        }

        private void textBox3_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT45", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_45.Text;
        }

        private void textBox3_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT46", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_46.Text;
        }

        private void textBox3_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT47", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_47.Text;
        }

        private void textBox3_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT48", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_48.Text;
        }

        private void textBox3_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT49", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_49.Text;
        }

        private void textBox3_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT50", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_50.Text;
        }

        private void textBox3_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT51", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_51.Text;
        }

        private void textBox3_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("RCT52", false, 0);
            listView2.Items[foundItem.Index].SubItems[5].Text = textBox3_52.Text;
        }

        private void textBox51_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS1", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_1.Text;
        }

        private void textBox51_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS2", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_2.Text;
        }

        private void textBox51_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS3", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_3.Text;
        }

        private void textBox51_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS4", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_4.Text;
        }

        private void textBox51_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS5", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_5.Text;
        }

        private void textBox51_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS6", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_6.Text;
        }

        private void textBox51_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS7", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_7.Text;
        }

        private void textBox51_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS8", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_8.Text;
        }

        private void textBox51_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS9", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_9.Text;
        }

        private void textBox51_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS10", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_10.Text;
        }

        private void textBox51_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS11", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_11.Text;
        }

        private void textBox51_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS12", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_12.Text;
        }

        private void textBox51_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS13", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_13.Text;
        }

        private void textBox51_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS14", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_14.Text;
        }

        private void textBox51_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS15", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_15.Text;
        }

        private void textBox51_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS16", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_16.Text;
        }

        private void textBox51_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS17", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_17.Text;
        }

        private void textBox51_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS18", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_18.Text;
        }

        private void textBox51_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS19", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_19.Text;
        }

        private void textBox51_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS20", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_20.Text;
        }

        private void textBox51_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS21", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_21.Text;
        }

        private void textBox51_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS22", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_22.Text;
        }

        private void textBox51_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS23", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_23.Text;
        }

        private void textBox51_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS24", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_24.Text;
        }

        private void textBox51_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS25", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_25.Text;
        }

        private void textBox51_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS26", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_26.Text;
        }

        private void textBox51_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS27", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_27.Text;
        }

        private void textBox51_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS28", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_28.Text;
        }

        private void textBox51_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS29", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_29.Text;
        }

        private void textBox51_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS30", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_30.Text;
        }

        private void textBox51_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS31", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_31.Text;
        }

        private void textBox51_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS32", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_32.Text;
        }

        private void textBox51_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS33", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_33.Text;
        }

        private void textBox51_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS34", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_34.Text;
        }

        private void textBox51_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS35", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_35.Text;
        }

        private void textBox51_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS36", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_36.Text;
        }

        private void textBox51_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS37", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_37.Text;
        }

        private void textBox51_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS38", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_38.Text;
        }

        private void textBox51_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS39", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_39.Text;
        }

        private void textBox51_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS40", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_40.Text;
        }

        private void textBox51_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS41", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_41.Text;
        }

        private void textBox51_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS42", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_42.Text;
        }

        private void textBox51_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS43", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_43.Text;
        }

        private void textBox51_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS44", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_44.Text;
        }

        private void textBox51_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS45", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_45.Text;
        }

        private void textBox51_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS46", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_46.Text;
        }

        private void textBox51_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS47", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_47.Text;
        }

        private void textBox51_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS48", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_48.Text;
        }

        private void textBox51_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS49", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_49.Text;
        }

        private void textBox51_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS50", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_50.Text;
        }

        private void textBox51_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS51", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_51.Text;
        }

        private void textBox51_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("DTS52", false, 0);
            listView2.Items[foundItem.Index].SubItems[6].Text = textBox51_52.Text;
        }

        private void textBox52_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT1", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_1.Text;
        }

        private void textBox52_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT2", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_2.Text;
        }

        private void textBox52_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT3", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_3.Text;
        }

        private void textBox52_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT4", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_4.Text;
        }

        private void textBox52_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT5", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_5.Text;
        }

        private void textBox52_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT6", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_6.Text;
        }

        private void textBox52_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT7", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_7.Text;
        }

        private void textBox52_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT8", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_8.Text;

        }

        private void textBox52_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT9", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_9.Text;
        }

        private void textBox52_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT10", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_10.Text;
        }

        private void textBox52_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT11", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_11.Text;
        }

        private void textBox52_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT12", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_12.Text;
        }

        private void textBox52_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT13", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_13.Text;
        }

        private void textBox52_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT14", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_14.Text;
        }

        private void textBox52_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT15", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_15.Text;
        }

        private void textBox52_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT16", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_16.Text;
        }

        private void textBox52_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT17", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_17.Text;
        }

        private void textBox52_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT18", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_18.Text;
        }

        private void textBox52_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT19", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_19.Text;
        }

        private void textBox52_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT20", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_20.Text;
        }

        private void textBox52_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT21", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_21.Text;
        }

        private void textBox52_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT22", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_22.Text;
        }

        private void textBox52_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT23", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_23.Text;
        }

        private void textBox52_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT24", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_24.Text;
        }

        private void textBox52_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT25", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_25.Text;
        }

        private void textBox52_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT26", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_26.Text;
        }

        private void textBox52_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT27", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_27.Text;
        }

        private void textBox52_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT28", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_28.Text;
        }

        private void textBox52_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT29", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_29.Text;
        }

        private void textBox52_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT30", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_30.Text;
        }

        private void textBox52_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT31", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_31.Text;
        }

        private void textBox52_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT32", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_32.Text;
        }

        private void textBox52_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT33", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_33.Text;
        }

        private void textBox52_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT34", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_34.Text;
        }

        private void textBox52_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT35", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_35.Text;
        }

        private void textBox52_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT36", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_36.Text;
        }

        private void textBox52_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT37", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_37.Text;
        }

        private void textBox52_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT38", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_38.Text;
        }

        private void textBox52_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT39", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_39.Text;
        }

        private void textBox52_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT40", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_40.Text;
        }

        private void textBox52_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT41", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_41.Text;
        }

        private void textBox52_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT42", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_42.Text;
        }

        private void textBox52_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT43", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_43.Text;
        }

        private void textBox52_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT44", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_44.Text;
        }

        private void textBox52_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT45", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_45.Text;
        }

        private void textBox52_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT46", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_46.Text;
        }

        private void textBox52_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT47", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_47.Text;
        }

        private void textBox52_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT48", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_48.Text;
        }

        private void textBox52_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT49", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_49.Text;
        }

        private void textBox52_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT50", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_50.Text;
        }

        private void textBox52_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT51", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_51.Text;
        }

        private void textBox52_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("EXT52", false, 0);
            listView2.Items[foundItem.Index].SubItems[7].Text = textBox52_52.Text;
        }

        private void textBox6_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL1", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_1.Text;
        }

        private void textBox6_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL2", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_2.Text;
        }

        private void textBox6_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL3", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_3.Text;
        }

        private void textBox6_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL4", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_4.Text;
        }

        private void textBox6_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL5", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_5.Text;
        }

        private void textBox6_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL6", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_6.Text;
        }

        private void textBox6_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL7", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_7.Text;
        }

        private void textBox6_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL8", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_8.Text;
        }

        private void textBox6_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL9", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_9.Text;
        }

        private void textBox6_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL10", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_10.Text;
        }

        private void textBox6_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL11", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_11.Text;
        }

        private void textBox6_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL12", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_12.Text;
        }

        private void textBox6_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL13", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_13.Text;
        }

        private void textBox6_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL14", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_14.Text;
        }

        private void textBox6_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL15", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_15.Text;
        }

        private void textBox6_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL16", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_16.Text;
        }

        private void textBox6_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL17", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_17.Text;
        }

        private void textBox6_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL18", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_18.Text;
        }

        private void textBox6_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL19", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_19.Text;
        }

        private void textBox6_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL20", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_20.Text;
        }

        private void textBox6_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL21", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_21.Text;
        }

        private void textBox6_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL22", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_22.Text;
        }

        private void textBox6_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL23", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_23.Text;
        }

        private void textBox6_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL24", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_24.Text;
        }

        private void textBox6_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL25", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_25.Text;
        }

        private void textBox6_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL26", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_26.Text;
        }

        private void textBox6_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL27", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_27.Text;
        }

        private void textBox6_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL28", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_28.Text;
        }

        private void textBox6_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL29", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_29.Text;
        }

        private void textBox6_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL30", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_30.Text;
        }

        private void textBox6_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL31", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_31.Text;
        }

        private void textBox6_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("CL32", false, 0);
            listView2.Items[foundItem.Index].SubItems[8].Text = textBox6_32.Text;
        }

        private void textBox7_1_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH1", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_1.Text;
        }

        private void textBox7_2_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH2", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_2.Text;
        }

        private void textBox7_3_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH3", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_3.Text;
        }

        private void textBox7_4_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH4", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_4.Text;
        }

        private void textBox7_5_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH5", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_5.Text;
        }

        private void textBox7_6_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH6", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_6.Text;
        }

        private void textBox7_7_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH7", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_7.Text;
        }

        private void textBox7_8_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH8", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_8.Text;
        }

        private void textBox7_9_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH9", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_9.Text;
        }

        private void textBox7_10_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH10", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_10.Text;
        }

        private void textBox7_11_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH11", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_11.Text;
        }

        private void textBox7_12_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH12", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_12.Text;
        }

        private void textBox7_13_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH13", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_13.Text;
        }

        private void textBox7_14_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH14", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_14.Text;
        }

        private void textBox7_15_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH15", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_15.Text;
        }

        private void textBox7_16_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH16", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_16.Text;
        }

        private void textBox7_17_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH17", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_17.Text;
        }

        private void textBox7_18_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH18", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_18.Text;
        }

        private void textBox7_19_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH19", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_19.Text;
        }

        private void textBox7_20_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH20", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_20.Text;
        }

        private void textBox7_21_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH21", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_21.Text;
        }

        private void textBox7_22_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH22", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_22.Text;
        }

        private void textBox7_23_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH23", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_23.Text;
        }

        private void textBox7_24_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH24", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_24.Text;
        }

        private void textBox7_25_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH25", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_25.Text;
        }

        private void textBox7_26_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH26", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_26.Text;
        }

        private void textBox7_27_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH27", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_27.Text;
        }

        private void textBox7_28_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH28", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_28.Text;
        }

        private void textBox7_29_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH29", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_29.Text;
        }

        private void textBox7_30_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH30", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_30.Text;
        }

        private void textBox7_31_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH31", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_31.Text;
        }

        private void textBox7_32_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH32", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_32.Text;
        }

        private void textBox7_33_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH33", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_33.Text;
        }

        private void textBox7_34_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH34", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_34.Text;
        }

        private void textBox7_35_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH35", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_35.Text;
        }

        private void textBox7_36_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH36", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_36.Text;
        }

        private void textBox7_37_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH37", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_37.Text;
        }

        private void textBox7_38_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH38", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_38.Text;
        }

        private void textBox7_39_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH39", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_39.Text;
        }

        private void textBox7_40_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH40", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_40.Text;
        }

        private void textBox7_41_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH41", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_41.Text;
        }

        private void textBox7_42_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH42", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_42.Text;
        }

        private void textBox7_43_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH43", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_43.Text;
        }

        private void textBox7_44_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH44", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_44.Text;
        }

        private void textBox7_45_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH45", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_45.Text;
        }

        private void textBox7_46_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH46", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_46.Text;
        }

        private void textBox7_47_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH47", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_47.Text;
        }

        private void textBox7_48_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH48", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_48.Text;
        }

        private void textBox7_49_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH49", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_49.Text;
        }

        private void textBox7_50_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH50", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_50.Text;
        }

        private void textBox7_51_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH51", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_51.Text;
        }

        private void textBox7_52_Leave(object sender, EventArgs e)
        {
            foundItem = listView2.FindItemWithText("OTH52", false, 0);
            listView2.Items[foundItem.Index].SubItems[9].Text = textBox7_52.Text;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void radGridView2_2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Delete)
            {
                if (radGridView2_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView2_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView2_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34 , Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);
                               
                    }
                }
            }

        }

        private void radGridView3_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView3_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView3_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView3_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);

                    }
                }
            }
        }

        private void radGridView4_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView4_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView4_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView4_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);

                    }
                }
            }
        }

        private void radGridView5_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView5_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView5_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView5_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);

                    }
                }
            }
        }

        private void radGridView6_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView6_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView6_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView6_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);

                    }
                }
            }
        }

        private void radGridView7_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView7_2.RowCount > 0)
                {
                    int a = int.Parse(radGridView7_2.CurrentRow.Cells[0].Value.ToString());

                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (radGridView7_2.CurrentRow.Cells[1].Value.ToString() == persianDateTimePicker1.Value.ToString().Substring(0, 10))
                        {
                            DLUtilsobj.screenobj.delete_screen1(a);
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 34, Environment.MachineName, a);
                        }
                        else
                            MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);

                    }
                }
            }
        }
  
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            Pregnant = 1;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            Pregnant = 2;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            Pregnant = 3;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BMTStatus = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            BMTStatus = 2;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            BMTStatus = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Outmouth = 1;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Outmouth = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            TMJ = 1;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            TMJ = 2;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            TMJ = 3;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            TMJ = 4;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            mucousmouth = 1;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            mucousmouth = 2;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            Prosthodonti = 1;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            Prosthodonti = 2;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            Prosthodonti = 3;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            Prosthodonti = 4;
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            Occlusion = 1;
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            Occlusion = 2;
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            Occlusion = 3;
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            PeriodentalStatus = 1;
         //   checkBox6_C22.Checked = false;
          //  checkBox6_C22_CheckedChanged(radioButton23, e);

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            PeriodentalStatus = 2;
            //checkBox6_C22.Checked = true;
            //checkBox6_C22_CheckedChanged(radioButton23,e);
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            PeriodentalStatus = 3;
            //checkBox6_C22.Checked = false;
            //checkBox6_C22_CheckedChanged(radioButton23, e);

        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            PeriodentalStatus = 4;
            //checkBox6_C22.Checked = false;
            //checkBox6_C22_CheckedChanged(radioButton23, e);

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            PeriodentalStatus = 5;
            //checkBox6_C22.Checked = false;
            //checkBox6_C22_CheckedChanged(radioButton23, e);

        }

      

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)

                IllnessHistory = 1;
            else
                IllnessHistory = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button19.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button19.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (OrupPatho_textBox.Text == "")
                    OrupPatho_textBox.Text = button19.Text;
                else
                    OrupPatho_textBox.Text = OrupPatho_textBox.Text + "+" + button19.Text;
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button18.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button18.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (OrupPatho_textBox.Text == "")
                    OrupPatho_textBox.Text = button18.Text;
                else
                    OrupPatho_textBox.Text = OrupPatho_textBox.Text + "+" + button18.Text;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button17.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button17.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (OrupPatho_textBox.Text == "")
                    OrupPatho_textBox.Text = button17.Text;
                else
                    OrupPatho_textBox.Text = OrupPatho_textBox.Text + "+" + button17.Text;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.FlatStyle == System.Windows.Forms.FlatStyle.Standard)
                button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            else if (button16.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                button16.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            // if (button8.FlatStyle == System.Windows.Forms.FlatStyle.Standard) 
            {
                if (OrupPatho_textBox.Text == "")
                    OrupPatho_textBox.Text = button16.Text;
                else
                    OrupPatho_textBox.Text = OrupPatho_textBox.Text + "+" + button16.Text;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
                needlerning = 1;
            else
                needlerning = 0;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
                needborosazh = 1;
            else
                needborosazh = 0;

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
                needfeloride = 1;
            else
                needfeloride = 0;

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
                needjerm = 1;
            else
                needjerm = 0;

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox15.Checked == true)
            {
                needfishorsilant = 1;
                button20.Enabled = true;
                radGridView2.Enabled = true;
            }
            else
            {
                needfishorsilant = 0;
                button20.Enabled = false;
                radGridView2.Enabled = false;
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Dentaltooth_f Dentaltooth_frm = new Dentaltooth_f();
            Dentaltooth_frm.ShowDialog();
            loaddent_tooth(Dentaltooth_frm.toothid);
            dentalneed = Dentaltooth_frm.toothid;
            Dentaltooth_frm.Dispose();
        }

      

      
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                textBox2.Enabled = true;
            }

            else
            {
                textBox2.Enabled = false;                

            }
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

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)

                gharbalgari = 1;
            else
                gharbalgari = 0;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox19.Checked;
            if (checkBox19.Checked == true)
            {
                Doctors_Consult = 1;
                textBox11 = textBox1.Text;
            }
            else
            {
                Doctors_Consult = 0;
                textBox11 = " ";
            }
                
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox20.Checked;            
            if (checkBox20.Checked == true)
            {
                Dentist_Consult = 1;
                textBox41 = textBox4.Text;
            }
                
            else
            {
                Dentist_Consult = 0;
                textBox41 = " ";
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            //-------------  حذف اسکرین

            if (MessageBox.Show("آیا مطمئن به حذف اسکرین انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)

                DLUtilsobj.Screentempobj.delete_dentscreen2(Int32.Parse(radGridView1_1.CurrentRow.Cells[0].Value.ToString()));
                

            //***************
            DLUtilsobj.screenobj.selectChiefcomplain(fkvdfamily);
            DLUtilsobj.screenobj.Dbconnset(true);
            DataSource = DLUtilsobj.screenobj.Screenclientdataset.ExecuteReader();
            radGridView1_1.DataSource = DataSource;
            DLUtilsobj.screenobj.Dbconnset(false);
            if (radGridView1_1.RowCount > 0)
            {
                radGridView1_1.Rows.First();
                textBox520.Text = radGridView1_1.CurrentRow.Cells[2].Value.ToString();
                radGridView1_1.Columns[0].HeaderText = "ردیف";
                radGridView1_1.Columns[1].HeaderText = "تاریخ";
                radGridView1_1.Columns[3].HeaderText = "نام پزشک";
                radGridView1_1.Columns[0].Width = 20;
                radGridView1_1.Columns[1].Width = 50;
                radGridView1_1.Columns[2].Width = 150;
                radGridView1_1.Columns[3].Width = 80;

            }

        }

    

        private void button22_Click(object sender, EventArgs e)
        {
            Report6_health6_F Report6_health6_Frm = new Report6_health6_F();
            Report6_health6_Frm.fkvdfamily = fkvdfamily;
            Report6_health6_Frm.pk_dent_Screen2 = Int32.Parse(radGridView1_1.CurrentRow.Cells[0].Value.ToString());
            Report6_health6_Frm.ipadress = ipadress;
            Report6_health6_Frm.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Report6_health6_2_F Report6_health6_2_Frm = new Report6_health6_2_F();
            Report6_health6_2_Frm.fkvdfamily = fkvdfamily;
            Report6_health6_2_Frm.pk_dent_Screen2 = Int32.Parse(radGridView1_1.CurrentRow.Cells[0].Value.ToString());
            Report6_health6_2_Frm.ipadress = ipadress;
            Report6_health6_2_Frm.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Report6_health6_child_F Report6_health6_child_Frm = new Report6_health6_child_F();
            Report6_health6_child_Frm.fkvdfamily = fkvdfamily;
            Report6_health6_child_Frm.pk_dent_Screen2 = int.Parse(radGridView1_1.CurrentRow.Cells[0].Value.ToString());
            Report6_health6_child_Frm.ipadress = ipadress;
            Report6_health6_child_Frm.ShowDialog();
        }

      
    }
}
