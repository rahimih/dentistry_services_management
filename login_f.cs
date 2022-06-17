using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using DLibraryUtils;

namespace PIHO_DENTIST_SOFTWARE
{
    public partial class login_f : Form
    {

        Main_f Main_Frm = new Main_f();
        public DLibraryUtils.DLUtils DLUtilsobj;
        string str1 = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        string str6 = "Y";
        
        public login_f()
       
        {
            InitializeComponent();
            
        }

        private void login_f_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            Application.Exit();
           
        }

        private void SwitchUser_label_Click(object sender, EventArgs e)
        {
            Username_label.Visible = true;
            Username_textBox.Text="";
            Username_textBox.Visible = true;
            SwitchUser_label.Visible = false;
            name_label.Visible = false;
            Username_textBox.Focus();
        }

        private void Enter_button_Click(object sender, EventArgs e)
        {

            if (Username_textBox.Visible == false)
            {
                Username_textBox.Text = str2;
                if (password_textBox.Text.ToString() == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }

            }

            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا نام عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }

            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() != "") && (password_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }

         

          if (((Username_textBox.Visible == false) && (password_textBox.Text.ToString() != "")) || ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() != "") && (password_textBox.ToString() != "")))
            {

                  if (DLUtilsobj.usercheckingobj.Userlogin_checking(Username_textBox.Text, password_textBox.Text) == true)
                {

                    SqlDataReader DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    DLUtilsobj.EventsLogobj.insertEventsLog(DataSource["usercode"].ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 1, Environment.MachineName, int.Parse(DataSource["usercode"].ToString()));
                    XmlTextWriter XmlWrt = new XmlTextWriter("login.xml", System.Text.Encoding.UTF8);
                    XmlWrt.Formatting = Formatting.Indented;
                    XmlWrt.WriteStartDocument();
                    XmlWrt.WriteStartElement("configuration");
                    XmlWrt.WriteStartElement("general");
                    XmlWrt.WriteElementString("usercode",DataSource["usercode"].ToString());
                    XmlWrt.WriteElementString("persno",DataSource["username"].ToString());
                    XmlWrt.WriteElementString("Name", DataSource["englishName"].ToString());
                    XmlWrt.WriteElementString("title", DataSource["title"].ToString());
                    XmlWrt.WriteEndElement();
                    XmlWrt.WriteEndDocument();
                    XmlWrt.Close();
                    Main_Frm.label1.Text =DataSource["title"].ToString()+" "+DataSource["englishName"].ToString();
                    Main_Frm.user_name = DataSource["Fname"].ToString() + " " + DataSource["Lname"].ToString();
                    Main_Frm.usercodetemp = int.Parse(DataSource["usercode"].ToString());
                    Main_Frm.accessleveltemp = int.Parse(DataSource["GroupCode"].ToString());                    
                    DataSource.Close();

                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                      //------------------
                    Main_Frm.sdate=DLUtilsobj.doctorsworktimeobj.getdate();
                      //-------------------names
                    Main_Frm.label3.Text = DLUtilsobj.usercheckingobj.getnames();
                      //-------------------
                    this.Hide();    
                    Main_Frm.ShowDialog();    
                }
                else 
                {
                    MessageBox.Show("نام یا رمز عبور اشتباه می باشد.", "خطا", MessageBoxButtons.OK);

                }
            }
            
            
          
                       
        }

        private void login_f_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
          
            XmlTextReader XmlRdr = new XmlTextReader("login.xml");

            while(!XmlRdr.EOF)

            {
    
              if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                switch (XmlRdr.Name)

            {

                case "usercode":

                    str1 = XmlRdr.ReadElementString();

                    break;

                 case "persno":

                        str2=XmlRdr.ReadElementString();

                        break;

                  case "Name":

                        str3=XmlRdr.ReadElementString();

                        break;

                  case "title":

                        str4 = XmlRdr.ReadElementString();

                        break;

                  
                  default:

                        XmlRdr.Read();

                        break;

            }

              else

                  XmlRdr.Read();

            }

            name_label.Text = str4+ ' '+str3;
            XmlRdr.Close();
        


        //---------------------- ipadress
                     XmlTextReader XmlRdr2 = new XmlTextReader("Dentist.xml");

            while(!XmlRdr2.EOF)

            {
    
              if (XmlRdr2.MoveToContent() == XmlNodeType.Element)

                switch (XmlRdr2.Name)

            {

                                
                    case "ipadress":

                        str5 = XmlRdr2.ReadElementString();

                        break;

                    case "recipedatecheck":

                        str6 = XmlRdr2.ReadElementString();

                        break;

                  default:

                        XmlRdr2.Read();

                        break;

            }

              else

                  XmlRdr2.Read();

            }
         
            Main_Frm.ipadress = str5;
            Main_Frm.recipedatecheck = str6;
            XmlRdr2.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            if (Username_textBox.Visible == false)
            {
                Username_textBox.Text = str2;
                if (password_textBox.Text.ToString() == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }

            }

            
            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا نام عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }

            else
            {
                if (DLUtilsobj.usercheckingobj.Userlogin_checking(Username_textBox.Text, password_textBox.Text) == true)
                {
                    SqlDataReader DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    ChangePassword_F ChangePassword_Frm = new ChangePassword_F();
                    ChangePassword_Frm.usercode = int.Parse(DataSource["usercode"].ToString());
                    DataSource.Close();
                    ChangePassword_Frm.ShowDialog();
                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                }
                else
                {
                    MessageBox.Show("نام یا رمز عبور اشتباه می باشد.", "خطا", MessageBoxButtons.OK);
                }

            }
        }

        private void Username_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                password_textBox.Focus();
            }
        }

        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Enter_button_Click(password_textBox, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Enter_button_Click(label2, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
