using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int octet1 = int.Parse(textBox2.Text);
            int octet2 = int.Parse(textBox12.Text);
            int octet3 = int.Parse(textBox11.Text);
            int octet4 = int.Parse(textBox10.Text);
            string var1 = "A";
            string var2 = "B";
            string var3 = "C";
            string var4 = "D";
            string var5 = "E";

          /*while (octet1 >= 192 || octet1 <= 223)
          {
              textBox3.Text = var3.ToString();
              break;

          }
             */

            try
            {
 

                if (octet1 < 0 || octet1 > 255 || octet2 < 0 || octet2 > 255 || octet3 < 0 || octet3 > 255 || octet4 < 0 || octet4 > 255)
                {
                    MessageBox.Show("Please Enter Valid Address");
                }
                else
                {

                    ClassConversion obj = new ClassConversion();
                    for (int i = 7; i >= 0; i--)
                    {

                        int binary1 = obj.DecimalToBinary(octet1, i);
                        textBox1.Text = textBox1.Text + binary1.ToString();
                    }
                    textBox1.Text = textBox1.Text + ".";
                    ClassConversion obj2 = new ClassConversion();
                    for (int i = 7; i >= 0; i--)
                    {
                        int binary1 = obj2.DecimalToBinary(octet2, i);
                        textBox1.Text = textBox1.Text + binary1.ToString();
                    }
                    textBox1.Text = textBox1.Text + ".";
                    ClassConversion obj3 = new ClassConversion();
                    for (int i = 7; i >= 0; i--)
                    {
                        int binary1 = obj3.DecimalToBinary(octet3, i);
                        textBox1.Text = textBox1.Text + binary1.ToString();
                    }
                    textBox1.Text = textBox1.Text + ".";
                    ClassConversion obj4 = new ClassConversion();
                    for (int i = 7; i >= 0; i--)
                    {
                        int binary1 = obj4.DecimalToBinary(octet4, i);
                        textBox1.Text = textBox1.Text + binary1.ToString();
                    }

                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (octet1 <= 126)
            {
                textBox3.Text = var1.ToString();

            }
            else if (octet1 >= 192 && octet1 <= 223)
            {
                textBox3.Text = var3.ToString();
            }
            else if (octet1 >= 224 && octet1 <= 239)
            {
                textBox3.Text = var4.ToString();
            }
            else if (octet1 >= 240 && octet1 <= 255)
            {
                textBox3.Text = var5.ToString();
            }
            else
            {
                if (octet1 >= 127 && octet1 <= 191)
                {
                    textBox3.Text = var2.ToString();
                }
            }
           
            if(octet1 <= 10 && octet2 <= 255 && octet3 <= 255 && octet4 <=255 )
            {
                textBox4.Text = var1.ToString();
            }
            else if (octet1 == 172 && octet2 == 16  || octet2 <= 31 && octet3 <= 255 && octet4 <= 255)
            {
                textBox4.Text = var2.ToString();
            }
            else if (octet1 == 192 && octet2 == 168 && octet3 <= 255 && octet4 <= 255)
            {
                textBox4.Text = var3.ToString();
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();

        }
    }
}

