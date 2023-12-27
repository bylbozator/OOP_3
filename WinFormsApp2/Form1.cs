using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string selectedFunction = "e^x"; // �� ��������� ������� ������� e^x
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            double y;
            double z;
            if (!double.TryParse(textBox1.Text, out x) || !double.TryParse(textBox2.Text, out y) || !double.TryParse(textBox3.Text, out z))
            {
                MessageBox.Show("������������ ���� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ��������� �������� ������ �� TextBox
             x = Convert.ToDouble(textBox1.Text);
             y = Convert.ToDouble(textBox2.Text);
             z = Convert.ToDouble(textBox3.Text);
            
            // ���������� �������� �������
            double fx;
            switch (selectedFunction)
            {
                case "Sh":
                    fx = Math.Sinh(x);
                    break;
                case "x^2":
                    fx = x * x;
                    break;
                case "e^x":
                    fx = Math.Exp(x);
                    break;
                default:
                    fx = 0;
                    break;
            }

            // ���� �������� ������ � �������� ������� � ���� �����������
            textBox4.Text = "���������� ������ ���������: " + Environment.NewLine;
            textBox4.Text += "��� X = " + textBox1.Text + Environment.NewLine;
            textBox4.Text += "��� Y = " + textBox2.Text + Environment.NewLine;
            textBox4.Text += "��� Z = " + textBox3.Text + Environment.NewLine;
            textBox4.Text += "F(X) = " + fx.ToString() + Environment.NewLine;

            // ���������� �������� � ���������
            double Min;
            double Max;
            if (fx + y < y - z)
            {
                Min = fx + y;
            }
            else
            {
                Min = y - z;
            }
            if (fx > y)
            {
                Max = fx;
            }

            else
            {
                Max = y;
            }
            // ���� Max ����� 0
            if (Max == 0)
            {
                // ����� ��������� � ���, ��� �������� �� ����������
                textBox4.Text += "��������� �� ����������" + Environment.NewLine;
                return;
            }
            // ���������� ���������
            double n = Min / Max;

            // ����� ����������
            textBox4.Text += "N = " + n.ToString() + Environment.NewLine;
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedFunction = "Sh";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectedFunction = "x^2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selectedFunction = "e^x";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ������� ���� TextBox            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
