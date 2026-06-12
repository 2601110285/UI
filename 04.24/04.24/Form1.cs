using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _04._24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double elapsedTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            textBox1.Text = (elapsedTime*0.005).ToString("F2") + "초 경과";
            label1.Text = (elapsedTime*0.005).ToString("F2") + "초 경과";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox1.Text = (elapsedTime*0.005).ToString("F2") + "초 일시정지";
            label1.Text = (elapsedTime*0.005).ToString("F2") + "초 일시정지";
            
            if (textBox2.Text == "2.00")
                textBox2.Text = "성공"; 
            else
                textBox2.Text = "실패";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox1.Text = " ";
            label1.Text = " ";
            elapsedTime = 0;
            textBox2.Text = " ";
        }
    }
}
