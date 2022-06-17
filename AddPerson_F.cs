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
    public partial class AddPerson_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        dentistryEntities dentistryEntitiescontext;
        bool sex2;
        string Id_temp;
        Guid Id_temp2;
        public AddPerson_F()
        {
            InitializeComponent();
        }

        private void AddPerson_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            dentistryEntitiescontext = new dentistryEntities();

            Kind_comboBox.DisplayMember = "EmployeeTypeDesc";
            Kind_comboBox.ValueMember = "id";
            Kind_comboBox.DataSource = dentistryEntitiescontext.TblEmployeetypes.Where(p => p.Display == true).ToList();

            Relation_comboBox.DisplayMember = "Description";
            Relation_comboBox.ValueMember = "id";
            Relation_comboBox.DataSource = dentistryEntitiescontext.TblRelations.ToList();

            Sex_comboBox.SelectedIndex = 0;

        }

        private void AddPerson_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            dentistryEntitiescontext.Dispose();
            this.Dispose();
        }

     

     

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Kind_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Kind_comboBox.SelectedIndex == 0) || (Kind_comboBox.SelectedIndex == 1))
                label1.Text = "کد ملی              ";

            if ((Kind_comboBox.SelectedIndex == 2) || (Kind_comboBox.SelectedIndex == 3))
                label1.Text = "شماره بیمه        ";

            if ((Kind_comboBox.SelectedIndex > 3))
                label1.Text = "شماره پرسنلی  ";
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (Persno_textbox.Text == "")
                MessageBox.Show("لطفا " + label1.Text + " را وارد نمائید", "", MessageBoxButtons.OK);

            if ((SN_textbox.Text == "") || (SN_textbox.TextLength < 10))
                MessageBox.Show("لطفا " + label8.Text + "  را به صورت صحیح وارد نمائید", "", MessageBoxButtons.OK);

            else
            {
                
                if (DLUtilsobj.persontblobj.selectpersno((SN_textbox.Text)) == true)
                {
                    MessageBox.Show(label8.Text + " وارد شده تکراری است.", "Information", MessageBoxButtons.OK);
                }
                

                if (DLUtilsobj.persontblobj.selectpersno_p(Persno_textbox.Text, byte.Parse(Relation_comboBox.SelectedValue.ToString())) == true)
                {
                    MessageBox.Show("شماره پرسنلی  وارد شده تکراری است.", "Information", MessageBoxButtons.OK);
                }
                    
                else
                {
                    if (Sex_comboBox.SelectedIndex == 0)
                        sex2 = false;
                    else
                        sex2 = true;

                        //**********************
                        PersonTbl PersonTbltemp = new PersonTbl
                        {
                            Id = Guid.NewGuid(),
                            PersNo = Int32.Parse(Persno_textbox.Text),
                            TblRelation_Id = byte.Parse(Relation_comboBox.SelectedValue.ToString()),
                            RelationOrderNo = 0,
                            NationalCode = SN_textbox.Text,
                            Fname = Fname_textbox.Text,
                            Lname = Lname_textbox.Text,
                            Sex = sex2,
                            BirthDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                            EmployeeInfoTbl_Id = (Kind_comboBox.SelectedValue.ToString() + " " + "&" + Persno_textbox.Text),
                            Mobile = Phone_textBox.Text,
                            Deleted = false,
                            TblValidCenter_Id = 6020,
                            TblValidCenterCity_Id = 50

                        };

                        Id_temp = (PersonTbltemp.Id.ToString());
                        dentistryEntitiescontext.PersonTbls.Add(PersonTbltemp);
                        dentistryEntitiescontext.SaveChanges();

                        //----------insert into employeeinfotbl
                        if (DLUtilsobj.persontblobj.checkEmployeeinfotbl(int.Parse(Persno_textbox.Text)) == false)
                        {
                            EmployeeInfoTbl EmployeeInfoTbltemp = new EmployeeInfoTbl
                            {
                                Id = (Kind_comboBox.SelectedValue.ToString() + " " + "&" + Persno_textbox.Text),
                                IdPerson = Guid.Parse(Id_temp),
                                TblCompany_Id = 0,
                                TblManagement_Id = 0,
                                TblSubCompany_Id = 0,
                                TblEmployeetype_Id = int.Parse(Kind_comboBox.SelectedValue.ToString()),
                                PersNo = Int32.Parse(Persno_textbox.Text)
                            };
                            dentistryEntitiescontext.EmployeeInfoTbls.Add(EmployeeInfoTbltemp);
                            dentistryEntitiescontext.SaveChanges();

                        }



                        MessageBox.Show("شخص مورد نظر ثبت گردید", "اطلاعات", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
        }

        private void Persno_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void SN_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Fname_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Lname_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Sex_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Relation_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                persianDateTimePicker2.Focus();
            }
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Phone_textBox.Focus();
            }
        }

        private void Kind_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Persno_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void SN_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Phone_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Ins_Button.Focus();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
