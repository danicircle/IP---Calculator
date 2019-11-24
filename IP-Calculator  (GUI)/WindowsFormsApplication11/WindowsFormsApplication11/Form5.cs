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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int subnet;
                int octet1 = int.Parse(textBox1.Text);
                int octet2 = int.Parse(textBox12.Text);
                int octet3 = int.Parse(textBox11.Text);
                int octet4 = int.Parse(textBox10.Text);

                if (octet1 < 0 || octet1 > 255 || octet2 < 0 || octet2 > 255 || octet3 < 0 || octet3 > 255 || octet4 < 0 || octet4 > 255)
                {
                    MessageBox.Show("Please Enter Valid IP Address");
                }
                else
                {
                    int noOfMaskBits;
                    int noOfHostBits;
                    ClassBits obj = new ClassBits();
                    noOfMaskBits = obj.generateBits(int.Parse(textBox9.Text));
                    noOfMaskBits += obj.generateBits(int.Parse(textBox2.Text));
                    noOfMaskBits += obj.generateBits(int.Parse(textBox3.Text));
                    noOfMaskBits += obj.generateBits(int.Parse(textBox4.Text));
                    textBox5.Text = noOfMaskBits.ToString();
                    noOfHostBits = 32 - noOfMaskBits;
                    textBox6.Text = noOfHostBits.ToString();

                    DataTable table = new DataTable();
                    table.Columns.Add("IP Address");
                    table.Columns.Add("Network Mask");
                    table.Columns.Add("Notes");
                    if (textBox9.Text == "255" && textBox2.Text == "255" && textBox3.Text == "255")
                    {
                        int counter = 0;
                        subnet = 256 - int.Parse(textBox4.Text);
                        table.Rows.Add(octet1 + "." + octet2 + "." + octet3 + "." + 0, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "Network Address");
                        for (int i = 1; i < subnet - 1; i++)
                        {
                            table.Rows.Add(octet1 + "." + octet2 + "." + octet3 + "." + i, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "");
                            counter++;
                        }

                        int hostpersubnet = counter;
                        textBox8.Text = hostpersubnet.ToString();
                        subnet = subnet - 1;
                        table.Rows.Add(octet1 + "." + octet2 + "." + octet3 + "." + subnet, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "Broadcast Address");
                    }
                    else if (textBox9.Text == "255" && textBox2.Text == "255")
                    {
                        int counter = 0;
                        subnet = 256 - int.Parse(textBox3.Text);

                        for (int i = 0; i < subnet; i++)
                        {
                            if (i == subnet - 1)
                            {
                                for (int j = 0; j <= 254; j++)
                                {
                                    if (counter == 0)
                                    {
                                        table.Rows.Add(octet1 + "." + octet2 + "." + 0 + "." + 0, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "Network Address");
                                    }
                                    else
                                    {
                                        table.Rows.Add(octet1 + "." + octet2 + "." + i + "." + j, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "");
                                    }
                                    counter++;

                                }
                            }
                            else
                            {
                                for (int j = 0; j <= 255; j++)
                                {
                                    if (counter == 0)
                                    {
                                        table.Rows.Add(octet1 + "." + octet2 + "." + 0 + "." + 0, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "Network Address");
                                    }
                                    else
                                    {
                                        table.Rows.Add(octet1 + "." + octet2 + "." + i + "." + j, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "");
                                    }
                                    counter++;

                                }
                            }

                        }

                        int hostpersubnet = counter - 1;
                        textBox8.Text = hostpersubnet.ToString();
                        subnet = subnet - 1;
                        table.Rows.Add(octet1 + "." + octet2 + "." + subnet + "." + 255, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "Broadcast Address");
                    }

                    else if (textBox9.Text == "255")
                    {
                        subnet = 256 - int.Parse(textBox2.Text);
                        for (int i = 0; i <= subnet; i++)
                        {
                            for (int j = 0; j <= 255; j++)
                            {
                                for (int k = 0; k <= 255; k++)
                                {
                                    table.Rows.Add(octet1 + "." + i + "." + j + "." + k, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, "");
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter valid Mask");
                    }

                    dataGridView1.DataSource = table;
                }
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
