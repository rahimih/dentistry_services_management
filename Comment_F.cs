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
    public partial class Comment_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        public byte kind;
        public Comment_F()
        {
            InitializeComponent();
        }
          private bool loaddata()
        {
            if (kind == 2)
                radGridView1.DataSource = dentistryEntitiescontext.Recipe_comment.ToList();
            else if (kind == 1)
                radGridView1.DataSource = dentistryEntitiescontext.Introduction_Comment.ToList();

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد ";
                radGridView1.Columns[1].HeaderText = " توضیحات";
                radGridView1.Columns[2].HeaderText = "وضعیت";
            }
            return true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                comment_textbox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {
                //error cheking.................

                if (comment_textbox.Text == " ")
                {
                    MessageBox.Show("لطفا  توضیحات را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }
                else
                {

                    if (kind == 2)
                    {
                        Recipe_comment  Recipe_Commenttable = new PIHO_DENTIST_SOFTWARE.Recipe_comment
                        {
                            Comment = comment_textbox.Text,
                            status = checkBox1.Checked
                        };

                        dentistryEntitiescontext.Recipe_comment.Add(Recipe_Commenttable);

                        dentistryEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 41, Environment.MachineName, 0);
                        //***************
                    }
                    else if (kind == 1)
                    {
                        Introduction_Comment Introduction_Commenttable = new PIHO_DENTIST_SOFTWARE.Introduction_Comment
                        {
                            Comment = comment_textbox.Text,
                            status = checkBox1.Checked
                        };

                        dentistryEntitiescontext.Introduction_Comment.Add(Introduction_Commenttable);

                        dentistryEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 38, Environment.MachineName, 0);
                    }
                    comment_textbox.Text = "";
                    checkBox1.Checked = false;
                
                    //******************
                    edit_Button.Enabled = true;
                    Del_Button.Enabled = true;
                    panel2.Enabled = false;

                    //******************
                    loaddata();

                    //***************************
                }
            }

        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            Del_Button.Enabled = false;
            Ins_Button.Enabled = false;
            radGridView1.Enabled = false;
            cancel_button.Enabled = true;

            int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

            if (kind==2)
            {
                
               Recipe_comment Recipe_Commenttable = dentistryEntitiescontext.Recipe_comment.First(i => i.id == a);

                  
            str1 = str1 + 1;

            if ((panel2.Enabled == false) && (str1 % 2 != 0))
            {
                panel2.Enabled = true;

                comment_textbox.Text = Recipe_Commenttable.Comment;
                checkBox1.Checked = Recipe_Commenttable.status.Value;
           
            }


            if ((panel2.Enabled == true) && (str1 % 2 == 0))
            {
                if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    Recipe_Commenttable.Comment = comment_textbox.Text;
                    Recipe_Commenttable.status = checkBox1.Checked;

                    dentistryEntitiescontext.SaveChanges();
                    str1 = 0;


                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 42, Environment.MachineName, 0);
                    //***************************
                    loaddata();

                    //***************************
                    //***************
                    comment_textbox.Text = "";
                    checkBox1.Checked = false;
                    //******************

                    Del_Button.Enabled = true;
                    Ins_Button.Enabled = true;
                    radGridView1.Enabled = true;
                    cancel_button.Enabled = false;
                }
                }
            }
                //----------------------------
                else  if (kind==1)
            { 
             
               Introduction_Comment Introduction_Commenttable = dentistryEntitiescontext.Introduction_Comment.First(i => i.Id == a);
            
            str1 = str1 + 1;

            if ((panel2.Enabled == false) && (str1 % 2 != 0))
            {
                panel2.Enabled = true;
          
                comment_textbox.Text = Introduction_Commenttable.Comment.ToString();
                checkBox1.Checked = Introduction_Commenttable.status.Value;
            
            }


            if ((panel2.Enabled == true) && (str1 % 2 == 0))
            {
                if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Introduction_Commenttable.Comment = comment_textbox.Text;
                    Introduction_Commenttable.status = checkBox1.Checked;

                    dentistryEntitiescontext.SaveChanges();
                    str1 = 0;

                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 39, Environment.MachineName, 0);

                    //***************************
                    loaddata();

                    //***************************
                    //***************
                    comment_textbox.Text = "";
                    checkBox1.Checked = false;
                    //******************

                    Del_Button.Enabled = true;
                    Ins_Button.Enabled = true;
                    radGridView1.Enabled = true;
                    cancel_button.Enabled = false;
                }
            }
            
                
            }
        }

        private void comment_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Comment_F_Load(object sender, EventArgs e)
        {
            dentistryEntitiescontext = new dentistryEntities();
            DLUtilsobj = new DLibraryUtils.DLUtils();
            loaddata();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_Button_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Del_Button_Click(toolStripMenuItem3, e);
        }

        private void Comment_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
           //***********************
            //****************  
          /*
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (DLUtilsobj.introductionsobj.selectIntroductioncommnet(a) == true)
                        MessageBox.Show("شما مجاز به حذف این توضیحات نمی باشید", "warning", MessageBoxButtons.OK);

                    else
                    {
                        DLUtilsobj.introductionsobj.deleteComment(a);
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, a);
                        loaddata();
                    }

                }
            }
            */
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == true)
            {
                panel2.Enabled = false;
                edit_Button.Enabled = true;
                Del_Button.Enabled = true;
                Ins_Button.Enabled = true;
                radGridView1.Enabled = true;
                str1 = 0;

                //***************
                //***************
                comment_textbox.Text = "";
                checkBox1.Checked = false;

                //******************

            }
        }

   
    }
}
