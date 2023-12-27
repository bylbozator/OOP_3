using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string selectedFunction = "e^x"; // по умолчанию выбрана функция e^x
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
                MessageBox.Show("Некорректный ввод данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Получение исходных данных из TextBox
             x = Convert.ToDouble(textBox1.Text);
             y = Convert.ToDouble(textBox2.Text);
             z = Convert.ToDouble(textBox3.Text);
            
            // Вычисление значения функции
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

            // Ввод исходных данных и значения функции в окно результатов
            textBox4.Text = "Результаты работы программы: " + Environment.NewLine;
            textBox4.Text += "При X = " + textBox1.Text + Environment.NewLine;
            textBox4.Text += "При Y = " + textBox2.Text + Environment.NewLine;
            textBox4.Text += "При Z = " + textBox3.Text + Environment.NewLine;
            textBox4.Text += "F(X) = " + fx.ToString() + Environment.NewLine;

            // Вычисление минимума и максимума
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
            // если Max равно 0
            if (Max == 0)
            {
                // Вывод сообщения о том, что значение не существует
                textBox4.Text += "Значениея не существует" + Environment.NewLine;
                return;
            }
            // Вычисление выражения
            double n = Min / Max;

            // Вывод результата
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
            // Очистка всех TextBox            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
