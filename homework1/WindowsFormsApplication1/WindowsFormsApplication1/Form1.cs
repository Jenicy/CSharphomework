using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i1, i2, i3;

        private void label2_Click(object sender, EventArgs e)
        {
            
        }


        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            i1 = int.Parse(textBox1.Text);
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            i2 = int.Parse(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i3 = i1 * i2;
            textBox3.Text = Convert.ToString(i3);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
