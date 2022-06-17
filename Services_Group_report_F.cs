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
    public partial class Services_Group_report_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int i, j,k,l;
        public int usercode;
        public string cdate;
        Int64 Services_Group_code_report;
        public Services_Group_report_F()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {

            //---------listView1            
            DLUtilsobj.Servicesobj.selectInsServices();
            SqlDataReader DataSource;
            DLUtilsobj.Servicesobj.Dbconnset(true);
            DataSource = DLUtilsobj.Servicesobj.Servicesclientdataset.ExecuteReader();
            while (DataSource.Read())
            {
                listView1.Items.Add(DataSource["Services_detail_Code"].ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(DataSource["Services_detail_Name"].ToString());
            }
            DLUtilsobj.Servicesobj.Dbconnset(false);


         /*   //---------listview2
            DLUtilsobj.usercheckingobj.viewdentistfamily();
            //SqlDataReader DataSource2;
            DLUtilsobj.usercheckingobj.Dbconnset(true);
            DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
            k = 0;
            while (DataSource.Read())
            {
                listView2.Items.Add(DataSource["Dentist_code"].ToString());
                i = listView2.Items.Count - 1;
                listView2.Items[i].SubItems.Add(DataSource["drname"].ToString());
                listView2.Items[i].SubItems.Add("*");
                if (DataSource["status"].ToString()=="True")
                    listView2.Items[i].SubItems.Add("فعال");
                else
                    listView2.Items[i].SubItems.Add("غیر فعال");
                listView2.Items[i].SubItems.Add(DataSource["status"].ToString());

                k = k + 1;
            }

            DLUtilsobj.usercheckingobj.Dbconnset(false);
          */ 

            return true;
        }

        private void Family_dentist_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
            //listView2.MultiSelect = false;
            loaddata();  
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) { return; }
            if (listView1.SelectedItems.Count == 0) { return; }
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
                listView2.Items.Add(item);
            } 

           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count == 0) { return; }
            if (listView2.SelectedItems.Count == 0) { return; }

            foreach (ListViewItem item in listView2.SelectedItems)
            {
                if (item.Index > k-1)
                {
                    listView2.Items.Remove(item);
                    listView1.Items.Add(item);
                }
            } 

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام گروه را وارد نمائید", "Warning", MessageBoxButtons.OK);
                { return; }
            }

            else
            {
                Services_Group_code_report = DLUtilsobj.Servicesobj.insert_servicesgroup_report(textBox1.Text);


                if (listView2.Items.Count == 0) { return; }
                j = listView2.Items.Count - 1;
                for (i = k; i <= j; i++)
                {
                    DLUtilsobj.Servicesobj.insert_servicesgroup_detail_report(Services_Group_code_report, listView2.Items[i].SubItems[0].Text);
                }

                MessageBox.Show(" لیست انتخابی ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }
                         
            
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
             if (listView2.SelectedItems.Count == 0) { return; }
            l = listView2.SelectedItems[0].Index;
            if (listView2.Items[l].SubItems[4].Text == "False")
                DLUtilsobj.familydentistobj.changestatus(listView2.Items[l].SubItems[0].Text,1);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) { return; }
            l = listView2.SelectedItems[0].Index;
            if (listView2.Items[l].SubItems[4].Text == "True")
                DLUtilsobj.familydentistobj.changestatus(listView2.Items[l].SubItems[0].Text, 0);
        }
    }
}
