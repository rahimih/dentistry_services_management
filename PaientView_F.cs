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
using System.IO;
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export; 


namespace PIHO_DENTIST_SOFTWARE
{
     
    public partial class PaientView_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public PrintRecipe_f PrintRecipe_Frm;
        public int usercodexml;
        public string turndate;
        public int doctorscode;
        public byte turnstatus,kind;
        public byte turnstatus2;
        public string ipadress;
        public string doctorsname, cdate;
        private bool exportVisualSettings;
        public PaientView_F()
        {
            InitializeComponent();
        }

         private bool loaddata1(int doctorscode, string turndate, byte statuscode,byte kind)
        {
            DLUtilsobj.recipeobj.selectPaientList(doctorscode, turndate, statuscode,kind);
            SqlDataReader DataSource;
            DLUtilsobj.recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.recipeobj.Recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.recipeobj.Dbconnset(false);


            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره نوبت";
                radGridView1.Columns[2].HeaderText = "ساعت مراجعه";
                radGridView1.Columns[3].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[4].HeaderText = "نام مراجعه کننده ";
                radGridView1.Columns[5].HeaderText = "نسبت";
                radGridView1.Columns[6].HeaderText = "نوع نوبت";
                radGridView1.Columns[7].HeaderText = "وضعیت استخدام ";
                radGridView1.Columns[8].HeaderText = "علت مراجعه";
                radGridView1.Columns[9].HeaderText = "وضعیت نوبت";
                radGridView1.Columns[10].HeaderText = " تلفن";
                radGridView1.Columns[11].HeaderText = "دندان";
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;


            }

            return true;
        }

         private bool loaddata2(int doctorscode, string turndate, byte statuscode,byte kind)
         {
             DLUtilsobj.recipeobj.selectPaientList(doctorscode, turndate, statuscode,kind);
             SqlDataReader DataSource;
             DLUtilsobj.recipeobj.Dbconnset(true);
             DataSource = DLUtilsobj.recipeobj.Recipeclientdataset.ExecuteReader();
             radGridView1.DataSource = DataSource;
             DLUtilsobj.recipeobj.Dbconnset(false);


             if (radGridView1.RowCount > 0)
             {
                 radGridView1.Columns[0].HeaderText = "ردیف";
                 radGridView1.Columns[1].HeaderText = "شماره نوبت";
                 radGridView1.Columns[2].HeaderText = "ساعت مراجعه";
                 radGridView1.Columns[3].HeaderText = "شماره پرسنلی";
                 radGridView1.Columns[4].HeaderText = "نام مراجعه کننده ";
                 radGridView1.Columns[5].HeaderText = "نسبت";
                 radGridView1.Columns[6].HeaderText = "نوع نوبت";
                 radGridView1.Columns[7].HeaderText = "وضعیت استخدام ";
                 radGridView1.Columns[8].HeaderText = "علت مراجعه";
                 radGridView1.Columns[9].HeaderText = "وضعیت نوبت";
                 radGridView1.Columns[10].HeaderText = " تلفن";
                 radGridView1.Columns[11].HeaderText = "دندان";
                 radGridView1.Columns[12].IsVisible = false;
                 radGridView1.Columns[13].IsVisible = false;
                 radGridView1.Columns[14].IsVisible = false;
                 radGridView1.Columns[15].IsVisible = false;

                 

             }

             return true;
         }
        private void PaientView_F_Load(object sender, EventArgs e)
        {
             DLUtilsobj = new DLibraryUtils.DLUtils();
             PrintRecipe_Frm = new PrintRecipe_f();

            if (turnstatus==0)
            loaddata1(doctorscode,turndate,turnstatus,kind);
            
           else if (turnstatus==1)
            loaddata2(doctorscode, turndate, turnstatus,kind);
           
        }

        private void PaientView_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                if (turnstatus == 0)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
                else if  (turnstatus == 1)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());

                if (turnstatus2 == 6)
                    MessageBox.Show("این نوبت قبلا حذف گردیده است", "Warning", MessageBoxButtons.OK);
                else
                {
                    var result = MessageBox.Show("آیا مایل به کنسل کردن نوبت می باشید؟", "تائیدیه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 4);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 62, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                        if (turnstatus == 0)
                            loaddata1(doctorscode, turndate, turnstatus,kind);
                        else if (turnstatus == 1)
                            loaddata2(doctorscode, turndate, turnstatus,kind);
                    }

                }

            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {

           if (radGridView1.RowCount > 0)
           {
               if (turnstatus == 0)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
                else if  (turnstatus == 1)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());

               if (turnstatus2 == 6)
                   MessageBox.Show("این نوبت قبلا حذف گردیده است", "Warning", MessageBoxButtons.OK);
               else 
               {
                var result = MessageBox.Show("آیا مایل به حذف نوبت می باشید؟", "تائیدیه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 6);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 61, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                   if (turnstatus==0)
                     loaddata1(doctorscode,turndate,turnstatus,kind);
                   else if (turnstatus==1)
                     loaddata2(doctorscode, turndate, turnstatus,kind);
                 }
                
                }

            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                
            if (turnstatus == 0)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
                else if  (turnstatus == 1)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());

                if (turnstatus2 >=3)
                   MessageBox.Show("شما مجاز به چاپ نوبت کنسل شده یا حذف شده نمی باشید.","Error",MessageBoxButtons.OK);
                else if (turnstatus2 <=3)
                {
                PrintRecipe_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                PrintRecipe_Frm.ipadress = ipadress;
                PrintRecipe_Frm.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (radGridView1.RowCount > 0)
            {

                if (turnstatus == 0)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
                else if  (turnstatus == 1)
                turnstatus2 = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());

                if (turnstatus2 == 6)
                    MessageBox.Show("این نوبت قبلا حذف گردیده است", "Warning", MessageBoxButtons.OK);
                else
                {
                    var result = MessageBox.Show("آیا مایل به کنسل کردن نوبت می باشید؟", "تائیدیه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DLUtilsobj.recipeobj.ChangeStatus_recipe(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 5);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 63, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                        if (turnstatus == 0)
                            loaddata1(doctorscode, turndate, turnstatus,kind);
                        else if (turnstatus == 1)
                            loaddata2(doctorscode, turndate, turnstatus,kind);
                    }
                 }
              }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (radGridView1.RowCount > 0)
            {

                PrintPreviewDialog dialog = new PrintPreviewDialog();

                radPrintDocument1.RightHeader = "نام پزشک : " + doctorsname;
                radPrintDocument1.MiddleHeader = "تاریخ ویزیت : " + cdate;
                dialog.Document = this.radPrintDocument1;
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
             

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reporting20_view reporting20_viewfrm = new reporting20_view();
            reporting20_viewfrm.doctorscode_name = doctorscode;
            reporting20_viewfrm.DoctorsCode = doctorscode;
            reporting20_viewfrm.Turndate = turndate;
            reporting20_viewfrm.turnstatus = turnstatus;
            reporting20_viewfrm.kind = kind;

            reporting20_viewfrm.ipadress = ipadress;
            reporting20_viewfrm.ShowDialog();
        }

    
        }
             
    } 


        