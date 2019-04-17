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

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 300, 60, -Math.PI / 2,2);
        }

        private Graphics graphics;
        double th;
        double th1;
        double th2;
        
        double per1;
        double per2 ;//长度

        void drawCayleyTree(int n,double x0,double y0,double leng,double th,int k)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1,k);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2,k);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(
                Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            per1 = double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            per2 = double.Parse(textBox2.Text);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            th = double.Parse(trackBar1.Value.ToString());
            th1 = 2*th * Math.PI / 180;
            th2 = 3*th * Math.PI / 180;
        }
    }
}
