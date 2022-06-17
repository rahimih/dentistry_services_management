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
    public partial class Users_f : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        int str1 = 0;
        public int usercodexml;
        string persiantitle, engtitle;
        int status;
        public Users_f()
        {
            InitializeComponent();
        }

      
        private bool loaddata()
        {
            DLUtilsobj.usercheckingobj.viewusers();
            SqlDataReader DataSource;
            DLUtilsobj.usercheckingobj.Dbconnset(true);
            DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.usercheckingobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد ";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[2].HeaderText = "نام";
                radGridView1.Columns[3].HeaderText = "فامیل";
                radGridView1.Columns[4].HeaderText = "کد ملی";
                radGridView1.Columns[5].HeaderText = "نام انگلیسی";
                radGridView1.Columns[6].HeaderText = "نوع کاربر";
                radGridView1.Columns[7].HeaderText = "تلفن";
                radGridView1.Columns[8].HeaderText = "موبایل";

            }
            return true;

        }
        private void name_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void status_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Users_f_Load(object sender, EventArgs e)
        {
            dentistryEntitiescontext = new dentistryEntities();
            DLUtilsobj = new DLibraryUtils.DLUtils();

            status_comboBox.DisplayMember = "GroupName";
            status_comboBox.ValueMember = "GroupCode";

            comboBox1.DisplayMember = "specialityKind1";
            comboBox1.ValueMember = "specialityKindCode";

            comboBox2.DisplayMember = "Speciality1";
            comboBox2.ValueMember = "specialityCode";

            status_comboBox.DataSource = dentistryEntitiescontext.userKinds.ToList();
            comboBox1.DataSource = dentistryEntitiescontext.specialityKinds.ToList();
            comboBox2.DataSource = dentistryEntitiescontext.Specialities.ToList();


            loaddata();
        }

        private void Users_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();

   
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                cancel_button.Enabled = true;
                personelnumber_textbox.Focus();
                edit_Button.Enabled = false;
                Del_Button.Enabled = false;

            }
            else if (panel2.Enabled == true)
            {
                //error cheking.................

                if (Fname_textBox.Text == " ")
                
                    MessageBox.Show("لطفا نام  را وارد نمائید", "خطا", MessageBoxButtons.OK);
                    
                if (Lname_textBox.Text== " ")
                    
                    MessageBox.Show("لطفا نام خانوادگی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                if (personelnumber_textbox.Text == " ")

                    MessageBox.Show("لطفا شماره پرسنلی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                if (SN_textBox.Text == " ")

                    MessageBox.Show("لطفا کد ملی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                if (textBox1.Text == " ")

                    MessageBox.Show("لطفا شماره نظام پزشکی را وارد نمائید", "خطا", MessageBoxButtons.OK);

                else
                {

                    if (byte.Parse(status_comboBox.SelectedValue.ToString()) == 2)
                    { 
                        persiantitle = "دکتر ";
                        engtitle = "Dr";
                    }
                    else
                    {
                        persiantitle = " ";
                        engtitle = " ";
                    }


                    TblUser TblUsertable = new TblUser
                    {
                       personalNO = int.Parse(personelnumber_textbox.Text),
                       SN = SN_textBox.Text,
                       GroupCode = byte.Parse(status_comboBox.SelectedValue.ToString()),
                       Fname = Fname_textBox.Text,
                       Lname = Lname_textBox.Text,
                       DoctorNO = (textBox1.Text),
                       specialityCode = byte.Parse(comboBox2.SelectedValue.ToString()),
                       specialityKindCode = byte.Parse(comboBox1.SelectedValue.ToString()),
                       
                       Active = true,
                       EnglishName= Englishname_textBox.Text,
                       title = " ",
                       PersianTitle =" " ,
                       phone = textBox2.Text,
                       mobile = textBox3.Text ,
                       comment = textBox4.Text
                    
                    };

                    dentistryEntitiescontext.TblUsers.Add(TblUsertable);
                    dentistryEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    MessageBox.Show("جهت ایجاد نام کاربری لطفا شخص مورد نظر را انتخاب نموده و کلید ویرایش را فشار دهید.", "Information", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 11, Environment.MachineName, 0);
                    //***************
                    personelnumber_textbox.Text = "";
                    SN_textBox.Text = "";
                    Fname_textBox.Text = "";
                    Lname_textBox.Text = "";
                    Englishname_textBox.Text = "";
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

            if (radGridView1.RowCount > 0)
            {
                username_textBox.Enabled = true;
                Password_textBox.Enabled = true;
                Confirmpass_textBox.Enabled = true;
                Del_Button.Enabled = false;
                Ins_Button.Enabled = false;
                radGridView1.Enabled = false;
                cancel_button.Enabled = true;
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                TblUser tblusertable = dentistryEntitiescontext.TblUsers.First(i => i.UserCode == a);



                str1 = str1 + 1;

                if ((panel2.Enabled == false) && (str1 % 2 != 0))
                {
                    panel2.Enabled = true;

                    personelnumber_textbox.Text = tblusertable.personalNO.ToString();
                    SN_textBox.Text = tblusertable.SN.ToString();
                    status_comboBox.SelectedValue= byte.Parse(tblusertable.GroupCode.ToString());
                    Fname_textBox.Text = tblusertable.Fname.ToString();
                    Lname_textBox.Text = tblusertable.Lname.ToString();
                    Englishname_textBox.Text = tblusertable.EnglishName.ToString();
                    textBox1.Text = tblusertable.DoctorNO.ToString();
                    comboBox2.SelectedValue = byte.Parse(tblusertable.specialityCode.ToString());
                    comboBox1.SelectedValue = byte.Parse(tblusertable.specialityKindCode.ToString());
                    textBox2.Text = tblusertable.phone.ToString();
                    textBox3.Text = tblusertable.mobile.ToString();
                    textBox4.Text = tblusertable.comment.ToString();

                    if (DLUtilsobj.usercheckingobj.viewacesslevel(a) == true)
                    {
                        AcessLevel AcessLeveltable = dentistryEntitiescontext.AcessLevels.First(i => i.UserCode == a);
                        username_textBox.Text = AcessLeveltable.UserName.ToString();
                        Password_textBox.Text = AcessLeveltable.Password.ToString();
                        Confirmpass_textBox.Text = Password_textBox.Text;
                        status = 2;

                    }
                    else
                        status = 1;

                }




                if ((panel2.Enabled == true) && (str1 % 2 == 0))
                {

                    if (Password_textBox.Text != Confirmpass_textBox.Text)

                        MessageBox.Show(" رمز عبور وارد شده با هم همخوانی ندارد. ", "خطا", MessageBoxButtons.OK);

                    else if (Fname_textBox.Text == " ")

                        MessageBox.Show("لطفا نام  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else if (Lname_textBox.Text == " ")

                        MessageBox.Show("لطفا نام خانوادگی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else if (personelnumber_textbox.Text == " ")

                        MessageBox.Show("لطفا شماره پرسنلی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else if (SN_textBox.Text == " ")

                        MessageBox.Show("لطفا کد ملی  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else if ((username_textBox.Enabled == true) && (username_textBox.Text == ""))

                        MessageBox.Show("لطفا  نام کاربری  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else if ((Password_textBox.Enabled == true) && (Password_textBox.Text == ""))

                        MessageBox.Show("لطفا  رمز عبور  را وارد نمائید", "خطا", MessageBoxButtons.OK);

                    else
                    {

                        if (MessageBox.Show("اطلاعات مورد نظر ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            tblusertable.personalNO = int.Parse(personelnumber_textbox.Text);
                            tblusertable.SN = SN_textBox.Text;
                            tblusertable.GroupCode = byte.Parse(status_comboBox.SelectedValue.ToString());
                            tblusertable.Fname = Fname_textBox.Text;
                            tblusertable.Lname = Lname_textBox.Text;
                            tblusertable.EnglishName = Englishname_textBox.Text;
                            tblusertable.DoctorNO = textBox1.Text;
                            tblusertable.specialityCode = byte.Parse(comboBox2.SelectedValue.ToString());
                            tblusertable.specialityKindCode = byte.Parse(comboBox1.SelectedValue.ToString());
                            tblusertable.phone = textBox2.Text;
                            tblusertable.mobile = textBox3.Text;
                            tblusertable.comment = textBox4.Text;

                            if (status == 2)
                            {

                                AcessLevel AcessLeveltable = dentistryEntitiescontext.AcessLevels.First(i => i.UserCode == a);

                                AcessLeveltable.UserName = username_textBox.Text;
                                AcessLeveltable.Password = Password_textBox.Text;
                                dentistryEntitiescontext.SaveChanges();
                            }

                            if (status == 1)
                            {
                                AcessLevel AcessLeveltable = new AcessLevel
                            {
                                UserCode = a,
                                AcessLevel1 = byte.Parse(status_comboBox.SelectedValue.ToString()),
                                UserName = username_textBox.Text,
                                Password = Password_textBox.Text,
                            };
                                dentistryEntitiescontext.AcessLevels.Add(AcessLeveltable);
                                dentistryEntitiescontext.SaveChanges();
                            }


                            str1 = 0;



                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 12, Environment.MachineName, 0);

                            //***************************
                            loaddata();

                            //***************************
                            //***************
                            personelnumber_textbox.Text = "";
                            SN_textBox.Text = "";
                            Fname_textBox.Text = "";
                            Lname_textBox.Text = "";
                            Englishname_textBox.Text = "";
                            username_textBox.Text = "";
                            Password_textBox.Text = "";
                            Confirmpass_textBox.Text = "";

                            //******************

                            Del_Button.Enabled = true;
                            Ins_Button.Enabled = true;
                            radGridView1.Enabled = true;
                            cancel_button.Enabled = false;
                        }
                    }

                }
            }
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
                personelnumber_textbox.Text = "";
                SN_textBox.Text = "";
                Fname_textBox.Text = "";
                Lname_textBox.Text = "";
                Englishname_textBox.Text = "";
                username_textBox.Text = "";
                Password_textBox.Text = "";
                Confirmpass_textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


                //******************
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void personelnumber_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
