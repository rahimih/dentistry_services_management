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
    public partial class InsertRadioServices_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public Dentaltooth_f Dentaltooth_frm;        

        int str1 = 0;
        int i, j,k,j2 = 0;
        public int usercodexml;
        public int insertForm;
        public string visitdate;
        string deleteddate;
        public string idperson;
        public int fkvdfamily, persno, turnno, planvisitcode, turnid;
        public int acessleveltemp = 0;
        public int validcenterzone;
        Int64 code;
        public InsertRadioServices_F()
        {
            InitializeComponent();
        }

        public bool loaddata()
        {
            DLUtilsobj.Servicesobj.selectRadioInsServices();
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[0].Width = 30;
                radGridView1.Columns[1].HeaderText = "نام خدمت";
                radGridView1.Columns[1].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].IsVisible = false;

            }

            return true;
        }

        public bool loaddatahistory(int fkvdfamily, string visitdate)
        {
            DLUtilsobj.Servicesobj.servicesRadiohistory(fkvdfamily, visitdate);
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView3.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView3.RowCount > 0)
            {
                radGridView3.Columns[0].HeaderText = "کد ";
                radGridView3.Columns[1].HeaderText = "نام خدمت";
                radGridView3.Columns[2].HeaderText = "دندان ";
                radGridView3.Columns[3].HeaderText = " نام پزشک";
                radGridView3.Columns[4].HeaderText = "تاریخ ویزیت ";
                radGridView3.Columns[5].IsVisible=false;
                

            }

            return true;
        }

     

        private void InsertServices_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            Dentaltooth_frm = new Dentaltooth_f();
          

            loaddata();
        
            loaddatahistory(fkvdfamily, visitdate);



        }

        private void InsertServices_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (radGridView1.CurrentRow.Cells[2].Value.ToString() == "1")
                {
                   // Dentaltooth_frm.ShowDialog();
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add("100");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    listView2.Items[i].SubItems.Add("0");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[2].Value.ToString());
                    
                }

                if (radGridView1.CurrentRow.Cells[2].Value.ToString() == "2")
                {
                    Dentaltooth_frm.ShowDialog();
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add(Dentaltooth_frm.toothid.ToString());
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    listView2.Items[i].SubItems.Add("0");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[2].Value.ToString());
                }

                if (radGridView1.CurrentRow.Cells[2].Value.ToString() == "3")
                {
                    //Dentaltooth_frm.ShowDialog();
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add("100");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    listView2.Items[i].SubItems.Add("1");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[2].Value.ToString());
                }


                if (radGridView1.CurrentRow.Cells[2].Value.ToString() == "4")
                {
                    //Dentaltooth_frm.ShowDialog();
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add("100");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    listView2.Items[i].SubItems.Add("2");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[2].Value.ToString());
                }

                if (radGridView1.CurrentRow.Cells[2].Value.ToString() == "5")
                {
                    //Dentaltooth_frm.ShowDialog();
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add("100");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    listView2.Items[i].SubItems.Add("0");
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[2].Value.ToString());
                }


              }
              
          }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(180));
            Fromdateeng_dateTimePicker.Value = result;
            persianDateTimePicker1.Value = Fromdateeng_dateTimePicker.Value;
            loaddatahistory(fkvdfamily, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"));
        }

   

        private void Ins_Button_Click(object sender, EventArgs e)
        {

             code=DLUtilsobj.recipeobj.insertRadio_Services_request(idperson, persno, fkvdfamily,persianDateTimePicker1.Value.ToString("yyyy/MM/dd" ),DateTime.Now.ToShortTimeString(),usercodexml,validcenterzone,1,1,usercodexml,Environment.MachineName);

                i = 0;
                while (i <= listView2.Items.Count - 1)
                {
                    DLUtilsobj.recipeobj.insertRadio_Services_request_Detail(code, byte.Parse(listView2.Items[i].SubItems[4].Text), int.Parse(listView2.Items[i].SubItems[2].Text), byte.Parse(listView2.Items[i].SubItems[1].Text), byte.Parse(listView2.Items[i].SubItems[3].Text), 1);

                    i = i + 1;
                }


                //DLUtilsobj.recipeobj.ChangeStatus_recipe(turnid, 2);
                this.Close();            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }


        private void Del_Button_Click(object sender, EventArgs e)
        {
            
              if  (radGridView3.RowCount > 0)
            {
                int a = int.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

            
                if ((acessleveltemp==1) && (int.Parse(radGridView3.CurrentRow.Cells[5].Value.ToString()) == 1))
                {
                    DLUtilsobj.recipeobj.deleteradioRequestService(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 64, Environment.MachineName, a);
                    MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                    loaddatahistory(fkvdfamily, visitdate);
                }
             
                    //-----------------------
                    else  if ((acessleveltemp > 1) &&  (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 1) && (radGridView3.CurrentRow.Cells[4].Value.ToString() == persianDateTimePicker2.Value.ToString().Substring(0, 10)))
                    { 
                        DLUtilsobj.recipeobj.deleteradioRequestService(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 64, Environment.MachineName, a);
                        MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                        loaddatahistory(fkvdfamily, visitdate);
                    }
                   else if (((acessleveltemp > 1) && (radGridView3.CurrentRow.Cells[4].Value.ToString() != persianDateTimePicker2.Value.ToString().Substring(0, 10))) || (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 2))
                        MessageBox.Show("شما مجاز به حذف این خدمت نمی باشید.", "اطلاعات", MessageBoxButtons.OK);
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

        private void listView2_Enter(object sender, EventArgs e)
        {
            j2 = listView2.SelectedItems[0].Index;
        }
    }
}