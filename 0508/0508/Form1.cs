using _0508.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0508
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2();
            child.SetTextBox(textBox1);
            child.SetMyTextBoxText("Form1에서 수정");
            child.ShowDialog();
            MessageBox.Show("TEST");
        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> strings = new List<string>();

            foreach (var item in groupBox1.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Checked)
                    {
                        strings.Add(checkBox.Text);
                    }
                }

            }
            MessageBox.Show(string.Join(" ", strings));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strings = "";

            foreach (var item in Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton checkBox = (RadioButton)item;
                    if (checkBox.Checked)
                    {
                        strings = checkBox.Text;
                        break;
                    }
                }
            }
            MessageBox.Show(string.Join(" ", strings));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.Add(new product() { Name = "사과", Price = 5000 });
            productBindingSource.Add(new product() { Name = "포도", Price = 10000 });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string name = ((product)comboBox1.Items[index]).Name;
            int price = ((product)comboBox1.Items[index]).Price;
            MessageBox.Show("항목 : " + name + "\t 가격 : " + price);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if(index < 0)
               return;

            productBindingSource1.Add(listBox1.Items[index]);
            productBindingSource1.Items.RemoveAt(index);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;

            if (index < 0)
                return;

            productBindingSource.Add(listBox2.Items[index].ToString());
            bindingSource.RemoveAt(index);
        }
    }
}
