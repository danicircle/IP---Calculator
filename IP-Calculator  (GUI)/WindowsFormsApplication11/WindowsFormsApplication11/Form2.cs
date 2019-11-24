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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectangleShape2.Width += 5;
            if (rectangleShape2.Width >= 622) 
            {
                timer1.Stop();
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide();
            }

        }

       

        
    }
}
