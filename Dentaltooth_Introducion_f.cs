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
    public partial class Dentaltooth_Introducion_f : Form
    {
        int i=0, j=0;
        public Dentaltooth_Introducion_f()
        {
            InitializeComponent();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox7.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("7");
                i=i+1;
            }

               if ((checkBox7.Checked == true) && (i > 5))
               {
                   MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                   checkBox7.Checked = false;
               }


               else if (checkBox7.Checked == false)
               {

                   listBox1.Items.Remove("7");
                   i = i - 1;
               } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if ((checkBox1.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("1");
                i=i+1;
            }
            
            if ((checkBox1.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox1.Checked = false;
            }


            else if (checkBox1.Checked == false)
            { 

                listBox1.Items.Remove("1");
                i=i-1;
            } 

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox2.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("2");
                i=i+1;
            }
            
            if ((checkBox2.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox2.Checked = false;
            }


            else if (checkBox2.Checked == false)
            { 

                listBox1.Items.Remove("2");
                i=i-1;
            } 
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox3.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("3");
                i=i+1;
            }
            
            if ((checkBox3.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox3.Checked = false;
            }


            else if (checkBox3.Checked == false)
            { 

                listBox1.Items.Remove("3");
                i=i-1;
            } 
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox4.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("4");
                i=i+1;
            }
            
            if ((checkBox4.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox4.Checked = false;
            }


            else if (checkBox4.Checked == false)
            { 

                listBox1.Items.Remove("4");
                i=i-1;
            } 
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox5.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("5");
                i=i+1;
            }
            
            if ((checkBox5.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox5.Checked = false;
            }


            else if (checkBox5.Checked == false)
            { 

                listBox1.Items.Remove("5");
                i=i-1;
            } 
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox6.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("6");
                i=i+1;
            }
            
            if ((checkBox6.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox6.Checked = false;
            }


            else if (checkBox6.Checked == false)
            { 

                listBox1.Items.Remove("6");
                i=i-1;
            } 
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox8.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("8");
                i=i+1;
            }
            
            if ((checkBox8.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox8.Checked = false;
            }


            else if (checkBox8.Checked == false)
            { 

                listBox1.Items.Remove("8");
                i=i-1;
            } 
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox9.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("9");
                i=i+1;
            }
            
            if ((checkBox9.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox9.Checked = false;
            }


            else if (checkBox9.Checked == false)
            { 

                listBox1.Items.Remove("9");
                i=i-1;
            } 
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox10.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("10");
                i=i+1;
            }
            
            if ((checkBox10.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox10.Checked = false;
            }


            else if (checkBox10.Checked == false)
            { 

                listBox1.Items.Remove("10");
                i=i-1;
            } 
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox11.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("11");
                i=i+1;
            }
            
            if ((checkBox11.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox11.Checked = false;
            }


            else if (checkBox11.Checked == false)
            { 

                listBox1.Items.Remove("11");
                i=i-1;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox12.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("12");
                i=i+1;
            }
            
            if ((checkBox12.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox12.Checked = false;
            }


            else if (checkBox12.Checked == false)
            { 

                listBox1.Items.Remove("12");
                i=i-1;
            } 
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox13.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("13");
                i=i+1;
            }
            
            if ((checkBox13.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox13.Checked = false;
            }


            else if (checkBox13.Checked == false)
            { 

                listBox1.Items.Remove("13");
                i=i-1;
            } 
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox14.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("14");
                i=i+1;
            }
            
            if ((checkBox14.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox14.Checked = false;
            }


            else if (checkBox14.Checked == false)
            { 

                listBox1.Items.Remove("14");
                i=i-1;
            } 
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox15.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("15");
                i=i+1;
            }
            
            if ((checkBox15.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox15.Checked = false;
            }


            else if (checkBox15.Checked == false)
            { 

                listBox1.Items.Remove("15");
                i=i-1;
            } 
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox16.Checked == true) && (i<=5))
            {
                listBox1.Items.Add("16");
                i=i+1;
            }
            
            if ((checkBox16.Checked == true) && (i>5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox16.Checked = false;
            }


            else if (checkBox16.Checked == false)
            { 

                listBox1.Items.Remove("16");
                i=i-1;
            }
        }

        private void Dentaltooth_Introducion_f_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add("100");
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox17.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("17");
                i = i + 1;
            }

            if ((checkBox17.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox17.Checked = false;
            }


            else if (checkBox17.Checked == false)
            {

                listBox1.Items.Remove("17");
                i = i - 1;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox18.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("18");
                i = i + 1;
            }

            if ((checkBox18.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox18.Checked = false;
            }


            else if (checkBox18.Checked == false)
            {

                listBox1.Items.Remove("18");
                i = i - 1;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox19.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("19");
                i = i + 1;
            }

            if ((checkBox19.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox19.Checked = false;
            }


            else if (checkBox19.Checked == false)
            {

                listBox1.Items.Remove("19");
                i = i - 1;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox20.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("20");
                i = i + 1;
            }

            if ((checkBox20.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox20.Checked = false;
            }


            else if (checkBox20.Checked == false)
            {

                listBox1.Items.Remove("20");
                i = i - 1;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox21.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("21");
                i = i + 1;
            }

            if ((checkBox21.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox21.Checked = false;
            }


            else if (checkBox21.Checked == false)
            {

                listBox1.Items.Remove("21");
                i = i - 1;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox22.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("22");
                i = i + 1;
            }

            if ((checkBox22.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox22.Checked = false;
            }


            else if (checkBox22.Checked == false)
            {

                listBox1.Items.Remove("22");
                i = i - 1;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox23.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("23");
                i = i + 1;
            }

            if ((checkBox23.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox23.Checked = false;
            }


            else if (checkBox23.Checked == false)
            {

                listBox1.Items.Remove("23");
                i = i - 1;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox24.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("24");
                i = i + 1;
            }

            if ((checkBox24.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox24.Checked = false;
            }


            else if (checkBox24.Checked == false)
            {

                listBox1.Items.Remove("24");
                i = i - 1;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox25.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("25");
                i = i + 1;
            }

            if ((checkBox25.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox25.Checked = false;
            }


            else if (checkBox25.Checked == false)
            {

                listBox1.Items.Remove("25");
                i = i - 1;
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox27.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("27");
                i = i + 1;
            }

            if ((checkBox27.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox27.Checked = false;
            }


            else if (checkBox27.Checked == false)
            {

                listBox1.Items.Remove("27");
                i = i - 1;
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox28.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("28");
                i = i + 1;
            }

            if ((checkBox28.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox28.Checked = false;
            }


            else if (checkBox28.Checked == false)
            {

                listBox1.Items.Remove("28");
                i = i - 1;
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox29.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("29");
                i = i + 1;
            }

            if ((checkBox29.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox29.Checked = false;
            }


            else if (checkBox29.Checked == false)
            {

                listBox1.Items.Remove("29");
                i = i - 1;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox30.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("30");
                i = i + 1;
            }

            if ((checkBox30.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox30.Checked = false;
            }


            else if (checkBox30.Checked == false)
            {

                listBox1.Items.Remove("30");
                i = i - 1;
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox31.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("31");
                i = i + 1;
            }

            if ((checkBox31.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox31.Checked = false;
            }


            else if (checkBox31.Checked == false)
            {

                listBox1.Items.Remove("31");
                i = i - 1;
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox32.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("32");
                i = i + 1;
            }

            if ((checkBox32.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox32.Checked = false;
            }


            else if (checkBox32.Checked == false)
            {

                listBox1.Items.Remove("32");
                i = i - 1;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox26.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("26");
                i = i + 1;
            }

            if ((checkBox26.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox26.Checked = false;
            }


            else if (checkBox26.Checked == false)
            {

                listBox1.Items.Remove("26");
                i = i - 1;
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox33.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("33");
                i = i + 1;
            }

            if ((checkBox33.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox33.Checked = false;
            }


            else if (checkBox33.Checked == false)
            {

                listBox1.Items.Remove("33");
                i = i - 1;
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox34.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("34");
                i = i + 1;
            }

            if ((checkBox34.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox34.Checked = false;
            }


            else if (checkBox34.Checked == false)
            {

                listBox1.Items.Remove("34");
                i = i - 1;
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox35.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("35");
                i = i + 1;
            }

            if ((checkBox35.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox35.Checked = false;
            }


            else if (checkBox35.Checked == false)
            {

                listBox1.Items.Remove("35");
                i = i - 1;
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox36.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("36");
                i = i + 1;
            }

            if ((checkBox36.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox36.Checked = false;
            }


            else if (checkBox36.Checked == false)
            {

                listBox1.Items.Remove("36");
                i = i - 1;
            }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox37.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("37");
                i = i + 1;
            }

            if ((checkBox37.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox37.Checked = false;
            }


            else if (checkBox37.Checked == false)
            {

                listBox1.Items.Remove("37");
                i = i - 1;
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox38.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("38");
                i = i + 1;
            }

            if ((checkBox38.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox38.Checked = false;
            }


            else if (checkBox38.Checked == false)
            {

                listBox1.Items.Remove("38");
                i = i - 1;
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox39.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("39");
                i = i + 1;
            }

            if ((checkBox39.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox39.Checked = false;
            }


            else if (checkBox39.Checked == false)
            {

                listBox1.Items.Remove("39");
                i = i - 1;
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox40.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("40");
                i = i + 1;
            }

            if ((checkBox40.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox40.Checked = false;
            }


            else if (checkBox40.Checked == false)
            {

                listBox1.Items.Remove("40");
                i = i - 1;
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox41.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("41");
                i = i + 1;
            }

            if ((checkBox41.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox41.Checked = false;
            }


            else if (checkBox41.Checked == false)
            {

                listBox1.Items.Remove("41");
                i = i - 1;
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox42.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("42");
                i = i + 1;
            }

            if ((checkBox42.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox42.Checked = false;
            }


            else if (checkBox42.Checked == false)
            {

                listBox1.Items.Remove("42");
                i = i - 1;
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox43.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("43");
                i = i + 1;
            }

            if ((checkBox43.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox43.Checked = false;
            }


            else if (checkBox43.Checked == false)
            {

                listBox1.Items.Remove("43");
                i = i - 1;
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox44.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("44");
                i = i + 1;
            }

            if ((checkBox44.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox44.Checked = false;
            }


            else if (checkBox44.Checked == false)
            {

                listBox1.Items.Remove("44");
                i = i - 1;
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox45.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("45");
                i = i + 1;
            }

            if ((checkBox45.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox45.Checked = false;
            }


            else if (checkBox45.Checked == false)
            {

                listBox1.Items.Remove("45");
                i = i - 1;
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox46.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("46");
                i = i + 1;
            }

            if ((checkBox46.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox46.Checked = false;
            }


            else if (checkBox46.Checked == false)
            {

                listBox1.Items.Remove("46");
                i = i - 1;
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox47.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("47");
                i = i + 1;
            }

            if ((checkBox47.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox47.Checked = false;
            }


            else if (checkBox47.Checked == false)
            {

                listBox1.Items.Remove("47");
                i = i - 1;
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox48.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("48");
                i = i + 1;
            }

            if ((checkBox48.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox48.Checked = false;
            }


            else if (checkBox48.Checked == false)
            {

                listBox1.Items.Remove("48");
                i = i - 1;
            }
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox49.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("49");
                i = i + 1;
            }

            if ((checkBox49.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox49.Checked = false;
            }


            else if (checkBox49.Checked == false)
            {

                listBox1.Items.Remove("49");
                i = i - 1;
            }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox50.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("50");
                i = i + 1;
            }

            if ((checkBox50.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox50.Checked = false;
            }


            else if (checkBox50.Checked == false)
            {

                listBox1.Items.Remove("50");
                i = i - 1;
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox51.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("51");
                i = i + 1;
            }

            if ((checkBox51.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox51.Checked = false;
            }


            else if (checkBox51.Checked == false)
            {

                listBox1.Items.Remove("51");
                i = i - 1;
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox52.Checked == true) && (i <= 5))
            {
                listBox1.Items.Add("52");
                i = i + 1;
            }

            if ((checkBox52.Checked == true) && (i > 5))
            {
                MessageBox.Show("شما مجاز به انتخاب فقط 5 دندان می باشید.", "اخطار", MessageBoxButtons.OK);
                checkBox52.Checked = false;
            }


            else if (checkBox52.Checked == false)
            {

                listBox1.Items.Remove("52");
                i = i - 1;
            }
        }
    }
}
