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
    public partial class Family_Dentist_Person_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int fk_vdfamily;
        public Family_Dentist_Person_view_F()
        {
            InitializeComponent();
        }

        private void Family_Dentist_Person_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            //*************
            DLUtilsobj.familydentistobj.Family_Dentist_Person_view(fk_vdfamily);
            SqlDataReader DataSource;
            DLUtilsobj.familydentistobj.Dbconnset(true);
            DataSource = DLUtilsobj.familydentistobj.familydentistclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.familydentistobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "از تاریخ";
                radGridView1.Columns[2].HeaderText = "تا تاریخ ";
                radGridView1.Columns[3].HeaderText = "نام دندان پزشک";                
            }
                

        }
    }
}
