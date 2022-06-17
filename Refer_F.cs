using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLibraryUtils;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class Refer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml,fkvdfamily;
        public string ipadress;
        public string user_name;
        Int64 Refer_code;
        public Refer_F()
        {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
          
            
            Refer_code=DLUtilsobj.referingobj.insert_refer(fkvdfamily.ToString(), label23.Text, label22.Text, DateTime.Now.ToShortTimeString(), usercodexml.ToString());
           
            if (checkBox1.Checked == true)
               DLUtilsobj.referingobj.insert_Refer_status(Refer_code.ToString(), "1");
           
            if (checkBox2.Checked == true)
               DLUtilsobj.referingobj.insert_Refer_status(Refer_code.ToString(), "2");

            if (checkBox3.Checked == true)
                DLUtilsobj.referingobj.insert_Refer_status(Refer_code.ToString(), "3");

            if (checkBox4.Checked == true)
                DLUtilsobj.referingobj.insert_Refer_status(Refer_code.ToString(), "4");

            if (checkBox5.Checked == true)
                DLUtilsobj.referingobj.insert_Refer_status(Refer_code.ToString(), "5");

            MessageBox.Show(" اطلاعات ثبت گردید", "Information", MessageBoxButtons.OK);
            this.Close();

        }

        private void Refer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }
    }
}
