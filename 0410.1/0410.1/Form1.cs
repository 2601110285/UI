using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0410._1
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();

            myButton.Text = "코드에서";
            int width = 600;
            myButton.Width = width;
            myButton.Width = 300;
            
            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                Controls.Add(btn);
                btn.Location = new Point(13, (13 + 23 + 3) * i);
                btn.Text = "동적생성" + i + "번째";
            }
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            textBox1.Text += "+";
            label1.Text += "+";
            
            Button btn = new Button();
            Controls.Add(btn);
            btn.Location = new Point(13, (13 + 23 + 3) * i);
            btn.Text = "동적생성" + i + "번째";
            i++;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
