using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class ChangePhone_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
           dentistryEntities dentistryEntitiescontext;
        public int usercode ;
        public int IdEmployeeType;
        public int fkvdfamily;
        public bool confirm = false;
        public ChangePhone_F()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("لطفا شماره تلفن جدید را وارد نمائید", "Information", MessageBoxButtons.OK);
            else
            {
                /*
                if (DLUtilsobj.recipeobj.checkpersoninfotbl(int.Parse(Persno_textbox.Text)) == false)
                {

                    PersonInfo PersonInfotemp = new PersonInfo
                {
                    //  Fk_Company = -1,
                    //  Fk_Management = 0,
                    //  Fk_subCompany = 0 ,
                    IdEmployeeType = IdEmployeeType,
                    persno = int.Parse(Persno_textbox.Text),
                    telephon = textBox2.Text,
                    DateTime = DateTime.Now
                };

                    dentistryEntitiescontext.PersonInfoes.Add(PersonInfotemp);
                    dentistryEntitiescontext.SaveChanges();
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercode.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 60, Environment.MachineName, int.Parse(Persno_textbox.Text));
                }

                else
                 * 
                {
                */
                    DLUtilsobj.recipeobj.UpdatePhoneNo(fkvdfamily, textBox2.Text);
                    MessageBox.Show("شماره تلفن فرد مورد نظر تغییر یافت", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercode.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 60, Environment.MachineName,fkvdfamily );
                    confirm = true;
                    this.Close();
                }
            //}
        }

        private void ChangePhone_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();
        }

        private void ChangePhone_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
