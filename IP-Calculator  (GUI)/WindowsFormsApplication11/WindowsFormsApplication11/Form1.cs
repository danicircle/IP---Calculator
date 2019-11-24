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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int SubnetSize;
                int subnet;
                int subnet2;
                int subnet3;
                int NoOfsubnets1;
                int NoOfsubnets2;
                int NoOfsubnets3;
                int hostperSubnets;
                int octet1 = int.Parse(textBox1.Text);
                int octet2 = int.Parse(textBox12.Text);
                int octet3 = int.Parse(textBox11.Text);
                int octet4 = int.Parse(textBox10.Text);

               

                //Host Bits And Subnet Bits

                int noOfMaskBits;
                int noOfHostBits;
                ClassBits obj2 = new ClassBits();
                noOfMaskBits = obj2.generateBits(int.Parse(textBox9.Text));
                noOfMaskBits += obj2.generateBits(int.Parse(textBox2.Text));
                noOfMaskBits += obj2.generateBits(int.Parse(textBox3.Text));
                noOfMaskBits += obj2.generateBits(int.Parse(textBox4.Text));
                textBox5.Text = noOfMaskBits.ToString();
                noOfHostBits = 32 - noOfMaskBits;
                textBox6.Text = noOfHostBits.ToString();



                DataTable table = new DataTable();
                table.Columns.Add("Network");
                table.Columns.Add("Mask");
                //table.Columns.Add("Subnet Size");
                table.Columns.Add("First Adress");
                table.Columns.Add("Last Last");
                table.Columns.Add("Broadcast");
                if (octet1 < 0 || octet1 > 255 || octet2 < 0 || octet2 > 255 || octet3 < 0 || octet3 > 255 || octet4 < 0 || octet4 > 255)
                {
                    MessageBox.Show("Please Enter Valid IP Address");
                }
                else
                {
                    if (octet1 > 191 && octet1 < 224)
                    {
                        //Number Of Subnets

                        ClassNoOfSubnets obj = new ClassNoOfSubnets();
                        NoOfsubnets3 = obj.getSubnets(int.Parse(textBox4.Text));
                        textBox7.Text = NoOfsubnets3.ToString();

                        subnet = 256 - int.Parse(textBox4.Text);


                        int num = 0;
                        int num2 = subnet;
                        int firstHost;
                        int lastHost;
                        int BroadCastAddress;
                        while (num != 256)
                        {

                            SubnetSize = num2;

                            firstHost = num + 1;
                            lastHost = num + num2 - 2;
                            BroadCastAddress = num + num2 - 1;
                            //kuc 
                            table.Rows.Add(octet1 + "." + octet2 + "." + octet3 + "." + num, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, octet1 + "." + octet2 + "." + octet3 + "." + firstHost, octet1 + "." + octet2 + "." + octet3 + "." + lastHost, octet1 + "." + octet2 + "." + octet3 + "." + BroadCastAddress);
                            num = num2 + num;
                            //Hosts Per Subnet

                            hostperSubnets = num2 - 2;
                            textBox8.Text = hostperSubnets.ToString();


                        }

                    }

                    else if (octet1 > 127 && octet1 < 192)
                    {
                        //Number Of Subnets

                        ClassNoOfSubnets obj = new ClassNoOfSubnets();

                        NoOfsubnets2 = obj.getSubnets(int.Parse(textBox3.Text));
                        NoOfsubnets3 = obj.getSubnets(int.Parse(textBox4.Text));
                        int result = NoOfsubnets2 * NoOfsubnets3;
                        textBox7.Text = result.ToString();

                        subnet = 256 - int.Parse(textBox3.Text);
                        subnet2 = 256 - int.Parse(textBox4.Text);
                        int octet3num = 0;
                        int octet3num2 = subnet;
                        int octet4num;
                        int octet4num2 = subnet2;
                        int firstHostOctet3;
                        int lastHostOctet3;
                        int firstHostOctet4;
                        int lastHostOctet4;
                        int BroadCastAddress;
                        while (octet3num != 256)
                        {
                            octet4num = 0;
                            while (octet4num != 256)
                            {
                                firstHostOctet3 = octet3num;
                                lastHostOctet3 = octet3num + octet3num2 - 1;
                                firstHostOctet4 = octet4num + 1;
                                lastHostOctet4 = octet4num + octet4num2 - 2;
                                BroadCastAddress = octet4num + octet4num2 - 1;

                                //Hosts Per Subnet

                                hostperSubnets = octet4num2 * octet3num2 - 2;
                                textBox8.Text = hostperSubnets.ToString();

                                SubnetSize = hostperSubnets + 2;
                                //
                                table.Rows.Add(octet1 + "." + octet2 + "." + octet3num + "." + octet4num, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, octet1 + "." + octet2 + "." + firstHostOctet3 + "." + firstHostOctet4, octet1 + "." + octet2 + "." + lastHostOctet3 + "." + lastHostOctet4, octet1 + "." + octet2 + "." + lastHostOctet3 + "." + BroadCastAddress);
                                octet4num = octet4num2 + octet4num;




                            }
                            octet3num = octet3num2 + octet3num;


                        }
                    }
                    else if (octet1 > -1 && octet1 < 128)
                    {
                        //Number Of Subnets

                        ClassNoOfSubnets obj = new ClassNoOfSubnets();
                        NoOfsubnets1 = obj.getSubnets(int.Parse(textBox2.Text));
                        NoOfsubnets2 = obj.getSubnets(int.Parse(textBox3.Text));
                        NoOfsubnets3 = obj.getSubnets(int.Parse(textBox4.Text));
                        int result = NoOfsubnets1 * NoOfsubnets2 * NoOfsubnets3;
                        textBox7.Text = result.ToString();


                        subnet = 256 - int.Parse(textBox2.Text);
                        subnet2 = 256 - int.Parse(textBox3.Text);
                        subnet3 = 256 - int.Parse(textBox4.Text);
                        int octet2num = 0;
                        int octet2num2 = subnet;
                        int octet3num;
                        int octet3num2 = subnet2;
                        int octet4num;
                        int octet4num2 = subnet3;
                        int firstHostOctet2;
                        int lastHostOctet2;
                        int firstHostOctet3;
                        int lastHostOctet3;
                        int firstHostOctet4;
                        int lastHostOctet4;
                        int BroadCastAddress;

                        while (octet2num != 256)
                        {
                            octet3num = 0;
                            while (octet3num != 256)
                            {
                                octet4num = 0;
                                while (octet4num != 256)
                                {
                                    firstHostOctet2 = octet2num;
                                    lastHostOctet2 = octet2num + octet2num2 - 1;
                                    firstHostOctet3 = octet3num;
                                    lastHostOctet3 = octet3num + octet3num2 - 1;
                                    firstHostOctet4 = octet4num + 1;
                                    lastHostOctet4 = octet4num + octet4num2 - 2;
                                    BroadCastAddress = octet4num + octet4num2 - 1;

                                    //Hosts Per Subnet

                                    hostperSubnets = octet4num2 * octet3num2 * octet2num2 - 2;
                                    textBox8.Text = hostperSubnets.ToString();

                                    SubnetSize = hostperSubnets + 2;
                                    //
                                    table.Rows.Add(octet1 + "." + octet2num + "." + octet3num + "." + octet4num, textBox9.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text, octet1 + "." + firstHostOctet2 + "." + firstHostOctet3 + "." + firstHostOctet4, octet1 + "." + lastHostOctet2 + "." + lastHostOctet3 + "." + lastHostOctet4, octet1 + "." + lastHostOctet2 + "." + lastHostOctet3 + "." + BroadCastAddress);
                                    octet4num = octet4num2 + octet4num;


                                }

                                octet3num = octet3num2 + octet3num;

                            }

                            octet2num = octet2num2 + octet2num;
                        }
                    }
                }
                dataGridView1.DataSource = table;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        
    }
}
