using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0522._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // High 버튼 클릭
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 1);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Low 버튼 클릭
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);        // 흘러가게 하는 코드임

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 0);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chart1.Series[0].Points.Count > 100)
                chart1.Series[0].Points.RemoveAt(0);

            Random random = new Random();

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm:ss.fff"), random.NextDouble()*10.0);

            if (chart1.Series[1].Points.Count > 50)
                chart1.Series[1].Points.RemoveAt(0);

            chart1.Series[1].Points.AddXY(DateTime.Now.ToString("HH:mm:ss.fff"), random.NextDouble() * 10.0);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
