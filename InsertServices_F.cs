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
    public partial class InsertServices_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        public Dentaltooth_f Dentaltooth_frm;
        public Dentaltooth_Introducion_f Dentaltooth_Introducion_frm;

        int str1 = 0;
        int i, j,k,j2 = 0;
        public int usercodexml;
        public int insertForm;
        public string visitdate;
        string deleteddate;
        public string idperson;
        public int fkvdfamily, persno, turnno, planvisitcode, turnid;
        public int acessleveltemp = 0;
        public byte kind = 1;
        public InsertServices_F()
        {
            InitializeComponent();
        }

        public bool loaddata()
        {
            if (kind==1)
              DLUtilsobj.Servicesobj.selectInsServices();
            if (kind == 2)
              DLUtilsobj.Servicesobj.selectInsServices_cost();

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

            }

            return true;
        }

        public bool loaddata3()
        {
            DLUtilsobj.introductionsobj.selectIntroductionsServices();
            SqlDataReader DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(true);
            DataSource = DLUtilsobj.introductionsobj.introductionsclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.introductionsobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت";
                radGridView1.Columns[0].Width = 30;
                radGridView1.Columns[1].HeaderText = "نام خدمت";
                radGridView1.Columns[1].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            }

            return true;
        }
        public bool loaddatahistory(int fkvdfamily, string visitdate)
        {
            DLUtilsobj.Servicesobj.serviceshistory(fkvdfamily, visitdate);
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            radGridView3.DataSource = DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(false);


            if (radGridView3.RowCount > 0)
            {
                radGridView3.Columns[0].HeaderText = "کد خدمت";
                radGridView3.Columns[1].HeaderText = "نام خدمت";
                radGridView3.Columns[2].HeaderText = "دندان ";
                radGridView3.Columns[3].HeaderText = " نام پزشک";
                radGridView3.Columns[4].HeaderText = "تاریخ ویزیت ";
                radGridView3.Columns[5].HeaderText = "  نوع ";
                radGridView3.Columns[6].IsVisible = false;
                radGridView3.Columns[7].IsVisible = false;

            }

            return true;
        }

        public bool loaddatainsServices(int fkvdfamily, string visitdate)
        {
            /*
                    DLUtilsobj.costconfirmobj.selectCostConfirm(fkvdfamily, visitdate);
                    SqlDataReader DataSource;
                    DLUtilsobj.costconfirmobj.Dbconnset(true);
                    DataSource = DLUtilsobj.costconfirmobj.CostConfirmclientdataset.ExecuteReader();
                    radGridView2.DataSource = DataSource;
                    DLUtilsobj.costconfirmobj.Dbconnset(false);


                    if (radGridView2.RowCount > 0)
                    {
                        radGridView2.Columns[0].HeaderText = "کد ";
                        radGridView2.Columns[1].HeaderText = "نام خدمت";
                        radGridView2.Columns[2].HeaderText = "نام دندان";
                        radGridView2.Columns[3].HeaderText = "  تصویر دندان";
                
                    }
                    */
            return true;
        }

        private void InsertServices_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            Dentaltooth_frm = new Dentaltooth_f();
          

            if (insertForm<3)
            loaddata();
            else if (insertForm ==3)
            loaddata3();

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
                if (insertForm == 1)
                {
                    //****  insert into costconfirm
                    Dentaltooth_frm.ShowDialog();
                    listView1.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Dentaltooth_frm.toothid.ToString());
                    listView1.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());

                    //i = i + 1;

                    //****  insert into costconfirm
                }

                if (insertForm == 2)
                {
                    //****  insert into doctorsservices 
                    Dentaltooth_frm.ShowDialog();
                    listView1.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Dentaltooth_frm.toothid.ToString());
                    listView1.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                }

                if (insertForm == 3)
                {
                    //****  insert into introduction
                    Dentaltooth_Introducion_frm = new Dentaltooth_Introducion_f();
                    Dentaltooth_Introducion_frm.ShowDialog();
                  
                    listView2.Items.Add(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    i = listView2.Items.Count - 1;
                    listView2.Items[i].SubItems.Add(Dentaltooth_Introducion_frm.listBox1.Items[0].ToString());
                    listView2.Items[i].SubItems.Add(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    j = Dentaltooth_Introducion_frm.listBox1.Items.Count;
                    k=1;
                    while ( k<j )
                    {
                        listView2.Items[i].SubItems.Add(Dentaltooth_Introducion_frm.listBox1.Items[k].ToString());
                        k=k+1;

                    }

                    while ( k<=5 )
                    { 
                        listView2.Items[i].SubItems.Add("200");
                        k = k + 1;
                    }
                    Dentaltooth_Introducion_frm.Dispose();
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

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                {
                    listView1.Items[j].Remove();
                    j = listView1.SelectedItems[0].Index;
                }
                   
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if ((insertForm == 1) || (insertForm == 3))
                this.Close();

            if (insertForm == 2)
            {

                i = 0;
                while (i <= listView1.Items.Count - 1)
                {
                    DLUtilsobj.recipeobj.InsertdoctorsService(idperson, persno, fkvdfamily, int.Parse(listView1.Items[i].SubItems[2].Text), byte.Parse(listView1.Items[i].SubItems[1].Text), usercodexml, planvisitcode, turnno, turnid, 1, usercodexml, visitdate, DateTime.Now.ToShortTimeString(), Environment.MachineName);

                    i = i + 1;
                }


                //DLUtilsobj.recipeobj.ChangeStatus_recipe(turnid, 2);
                this.Close();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            j = listView1.SelectedItems[0].Index;
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            
              if  (radGridView3.RowCount > 0)
            {
                int a = int.Parse(radGridView3.CurrentRow.Cells[7].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

            
                if ((acessleveltemp==1) && (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 3))
                {
                    DLUtilsobj.recipeobj.deletedoctorsService(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 58, Environment.MachineName, a);
                    MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                    loaddatahistory(fkvdfamily, visitdate);
                }

                if ((acessleveltemp == 1) && (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 2))
                {
                    DLUtilsobj.introductionsobj.deleteIntroduction(a);
                    DLUtilsobj.introductionsobj.deleteIntroductionComment(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 46, Environment.MachineName, a);
                    MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                    loaddatahistory(fkvdfamily, visitdate);
                }

                    //-----------------------

                else  if ((acessleveltemp > 1) && (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 3) && (radGridView3.CurrentRow.Cells[4].Value.ToString() == persianDateTimePicker2.Value.ToString().Substring(0,10)))
                    {
                        DLUtilsobj.recipeobj.deletedoctorsService(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 58, Environment.MachineName, a);
                        MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                        loaddatahistory(fkvdfamily, visitdate);
                     }

                    else  if ((acessleveltemp > 1) &&  (int.Parse(radGridView3.CurrentRow.Cells[6].Value.ToString()) == 2) && (radGridView3.CurrentRow.Cells[4].Value.ToString() == persianDateTimePicker2.Value.ToString().Substring(0, 10)))
                    { 
                        DLUtilsobj.introductionsobj.deleteIntroduction(a);
                        DLUtilsobj.introductionsobj.deleteIntroductionComment(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 46, Environment.MachineName, a);
                        MessageBox.Show("خدمات انتخاب شده حذف گردید", "اطلاعات", MessageBoxButtons.OK);
                        loaddatahistory(fkvdfamily, visitdate);
                    }
                   else if ((acessleveltemp > 1) && (radGridView3.CurrentRow.Cells[4].Value.ToString() != persianDateTimePicker2.Value.ToString().Substring(0, 10)))
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
    }
}