using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ACTMULTILIB_K;

namespace _0612
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();
        bool isAutoMode = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 연결
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
            // 시작
            isAutoMode = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 정지
            isAutoMode = false;
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    // 전진
        //    short value = 0x01 << 2;        // Y01 (1 의미 2)
        //    control.WriteDeviceBlock2("Y0", 1, ref value);
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    // 후진
        //    short value = 0x01 << 3;        // Y02 (2 의미 4)
        //    control.WriteDeviceBlock2("Y0", 1, ref value);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            short sensor = 0;
            control.ReadDeviceBlock2("X0", 1, out sensor);

            if (((int)(sensor) & 0x04) != 0)
                label1.Text = "전진";

            if (((int)(sensor) & 0x08) != 0)
                label1.Text = "후진";

            if (isAutoMode)
            {
                if (((int)(sensor) & 0x0400) != 0)
                {
                    short value = 0x0002;
                    control.WriteDeviceBlock2("Y0", 1, ref value);
                }
                else if (((int)(sensor) & 0x0800) != 0)
                {
                    short value = 0x0008;
                    control.WriteDeviceBlock2("Y0", 1, ref value);
                }
            }
        }
    }
}
