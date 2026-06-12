using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0417
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        bool isPlusClicked = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            label1.Text += button.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            label2.Text += button.Text;
            firstNumber = double.Parse(label1.Text);
            label1.Text = "";
            isPlusClicked = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            //label1.Text += button.Text;
            if (isPlusClicked)
            {
                double secondNumber = double.Parse(label1.Text);
                double result = firstNumber + secondNumber;
                label2.Text = result.ToString();

                isPlusClicked = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            label2.Text += button.Text;
            firstNumber = double.Parse(label1.Text);
            label1.Text = "";
            isPlusClicked = true;
        }
    }
}
