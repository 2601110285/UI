using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace UI0619
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
            // 자동운전 시작
            isAutoMode = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 자동운전 정지
            isAutoMode = false;
        }

        int autoStep;
        private void timer1_Tick(object sender, EventArgs e)
        {
            short sensor = 0;
            control.ReadDeviceBlock2("X0", 1, out sensor);

            if (isAutoMode)
            {
                short value = 0;

                // [0단계] 원점 복귀 (두 리프트 동시 상승 & 실린더 후진)
                if (autoStep == 0)
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0010; // C실린더 후진
                    value |= 0x0020; // 리프트A UP
                    value |= 0x0100; // 리프트B UP

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "시스템 원점 복귀 중... (두 리프트 상승)";

                    if (((int)(sensor) & 0x0008) != 0 && // B실린더 후진 완료
                        ((int)(sensor) & 0x0010) != 0 && // C실린더 후진 완료
                        ((int)(sensor) & 0x0040) != 0 && // 리프트A UP
                        ((int)(sensor) & 0x0100) != 0)   // 리프트B UP
                    {
                        autoStep = 1;
                    }
                }
                // [1단계] 원점 상태 유지 & 상자 감지 대기
                else if (autoStep == 1)
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0010; // C실린더 후진
                    value |= 0x0020; // 리프트A UP
                    value |= 0x0100; // 리프트B UP

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "상자 대기 중...";

                    if (((int)(sensor) & 0x0400) != 0) // 리프트A 상자 감지
                    {
                        short nextValue = 0;
                        nextValue |= 0x0002; // B실린더 전진
                        nextValue |= 0x0010; // C실린더 후진
                        nextValue |= 0x0020; // 리프트A UP
                        nextValue |= 0x0100; // 리프트B UP

                        control.WriteDeviceBlock2("Y0", 1, ref nextValue);
                        label1.Text = "B 실린더 전진";
                        autoStep = 2;
                    }
                }
                // [2단계] B실린더 전진 완료 -> B실린더 후진
                else if (autoStep == 2 && ((int)(sensor) & 0x0004) != 0)
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0010; // C실린더 후진
                    value |= 0x0020; // 리프트A UP
                    value |= 0x0100; // 리프트B UP

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "B 실린더 후진";
                    autoStep = 3;
                }
                // [3단계] B실린더 후진 완료 & 상자 안착 -> 두 리프트 동시에 DOWN
                else if (autoStep == 3 &&
                         ((int)(sensor) & 0x0008) != 0 && // B후진 완료
                         ((int)(sensor) & 0x0800) != 0)   // 상자가 리프트B에 도착
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0010; // C실린더 후진
                    value |= 0x0040; // 리프트A DOWN
                    value |= 0x0080; // 리프트B DOWN

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "두 리프트 동시 하강 중...";
                    autoStep = 4;
                }
                // [4단계] [변경] 두 리프트 모두 바닥에 도착 확인 -> C실린더 전진
                else if (autoStep == 4 &&
                         ((int)(sensor) & 0x0080) != 0 && // 리프트A 바닥 도착
                         ((int)(sensor) & 0x0200) != 0)   // 리프트B 바닥 도착
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0008; // C실린더 전진
                    value |= 0x0040; // 리프트A DOWN
                    value |= 0x0080; // 리프트B DOWN

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "C 실린더 전진";
                    autoStep = 5;
                }
                // [5단계] C실린더 전진 완료 -> C실린더 후진
                else if (autoStep == 5 && ((int)(sensor) & 0x0020) != 0)
                {
                    value |= 0x0004; // B실린더 후진
                    value |= 0x0010; // C실린더 후진
                    value |= 0x0040; // 리프트A DOWN
                    value |= 0x0080; // 리프트B DOWN

                    control.WriteDeviceBlock2("Y0", 1, ref value);
                    label1.Text = "C 실린더 후진";
                    autoStep = 6;
                }
                // [6단계] C실린더 후진 완료
                else if (autoStep == 6 && ((int)(sensor) & 0x0010) != 0)
                {
                    autoStep = 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // B실린더 전진
            short value = 0x01 << 1;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "B실린더 전진";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // B실린더 후진
            short value = 0x01 << 2;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "B실린더 후진";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // C실린더 전진
            short value = 0x01 << 3;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "C실린더 전진";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // C실린더 후진
            short value = 0x01 << 4;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "C실린더 후진";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 리프트A UP
            short value = 0x01 << 5;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "리프트A UP";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 리프트A DOWN
            short value = 0x01 << 6;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "리프트A DOWN";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 리프트B UP
            short value = 0x01 << 8;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "리프트B UP";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 리프트B DOWN
            short value = 0x01 << 7;
            control.WriteDeviceBlock2("Y0", 1, ref value);
            label1.Text = "리프트B DOWN";
        }
    }
}