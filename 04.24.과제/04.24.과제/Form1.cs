using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04._24.과제
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyDesign();
        }

        private double elapsedTime = 0;

        private void ApplyDesign()
        {
            // ── Form ──
            this.Text = "⏱ 2초 챌린지";
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.ForeColor = Color.White;
            this.Size = new Size(420, 380);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("맑은 고딕", 10f, FontStyle.Regular);

            // ── 제목 Label ──
            Label titleLabel = new Label();
            titleLabel.Text = "⏱  2초 챌린지";
            titleLabel.Font = new Font("맑은 고딕", 18f, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(100, 200, 255);
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(380, 50);
            titleLabel.Location = new Point(20, 20);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(titleLabel);

            // ── 시간 표시 TextBox (textBox1) ──
            textBox1.Font = new Font("맑은 고딕", 20f, FontStyle.Bold);
            textBox1.BackColor = Color.FromArgb(30, 30, 50);
            textBox1.ForeColor = Color.FromArgb(100, 255, 180);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(360, 55);
            textBox1.Location = new Point(20, 85);
            textBox1.Text = "0.00초 경과";

            // ── 결과 표시 TextBox (textBox2) ──
            textBox2.Font = new Font("맑은 고딕", 16f, FontStyle.Bold);
            textBox2.BackColor = Color.FromArgb(30, 30, 50);
            textBox2.ForeColor = Color.FromArgb(255, 220, 80);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(360, 50);
            textBox2.Location = new Point(20, 155);
            textBox2.Text = "결과가 여기에 표시됩니다";

            // ── label1 숨기기 (textBox1으로 대체) ──
            label1.Visible = false;

            // ── 버튼 공통 스타일 ──
            StyleButton(button1, "▶  시작", Color.FromArgb(40, 160, 100), new Point(20, 230));
            StyleButton(button2, "⏸  정지", Color.FromArgb(200, 120, 30), new Point(150, 230));
            StyleButton(button3, "🔄  초기화", Color.FromArgb(160, 50, 80), new Point(280, 230));

            // ── 안내 label ──
            Label guideLabel = new Label();
            guideLabel.Text = "정확히 2.00초에 정지하면 성공!";
            guideLabel.Font = new Font("맑은 고딕", 9f, FontStyle.Regular);
            guideLabel.ForeColor = Color.FromArgb(150, 150, 180);
            guideLabel.AutoSize = false;
            guideLabel.Size = new Size(380, 30);
            guideLabel.Location = new Point(20, 300);
            guideLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(guideLabel);
        }

        private void StyleButton(Button btn, string text, Color baseColor, Point location)
        {
            btn.Text = text;
            btn.Size = new Size(115, 50);
            btn.Location = location;
            btn.BackColor = baseColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("맑은 고딕", 10f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // 호버 효과
            btn.MouseEnter += (s, e) =>
                btn.BackColor = ControlPaint.Light(baseColor, 0.3f);
            btn.MouseLeave += (s, e) =>
                btn.BackColor = baseColor;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            string t = (elapsedTime * 0.005).ToString("F2") + "초 경과";
            textBox1.Text = t;
            label1.Text = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBox2.Text = "측정 중...";
            textBox2.ForeColor = Color.FromArgb(255, 220, 80);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string t = (elapsedTime * 0.005).ToString("F2") + "초 일시정지";
            textBox1.Text = t;
            label1.Text = t;

            if (textBox1.Text.StartsWith("2.00"))
            {
                textBox2.Text = "🎉 성공!";
                textBox2.ForeColor = Color.FromArgb(100, 255, 150);
            }
            else
            {
                textBox2.Text = "❌ 실패 (" + (elapsedTime * 0.005).ToString("F2") + "초)";
                textBox2.ForeColor = Color.FromArgb(255, 100, 100);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox1.Text = "0.00초 경과";
            label1.Text = " ";
            elapsedTime = 0;
            textBox2.Text = "결과가 여기에 표시됩니다";
            textBox2.ForeColor = Color.FromArgb(255, 220, 80);
        }
    }
}
