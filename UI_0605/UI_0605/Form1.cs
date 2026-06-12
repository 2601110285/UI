using ACTMULTILIB_K;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace UI_0605
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("연결되었습니다.");
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("연결 실패하였습니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 전진

            short value = 0x01 << 1;        // Y01 (1 의미 2)
            control.WriteDeviceBlock2("Y0", 1, ref value);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 후진

            short value = 0x01 << 2;        // Y02 (2 의미 4)
            control.WriteDeviceBlock2("Y0", 1, ref value);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short sensor = 0;
            control.ReadDeviceBlock2("XO", 1, out sensor);

            if (((int)(sensor) & 0x04) != 0)
            {
                pictureBox1.ImageLocation = "./cylinderon.png";

                label1.Text = "전진";

                if (chart1.Series[0].Points.Count > 50)
                    chart1.Series[0].Points.RemoveAt(0);

                chart1.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), 1);
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
            else
            {
                pictureBox1.ImageLocation = "./cylinderoff.png";

                label1.Text = "후진";

                if (chart1.Series[0].Points.Count > 50)
                    chart1.Series[0].Points.RemoveAt(0);        // 흘러가게 하는 코드임

                chart1.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), 0);
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
        }
    }
}