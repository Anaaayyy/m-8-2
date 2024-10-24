using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_8_2
{
    public partial class Form1 : Form
    {
        private double firstNumber;
        private string operation;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculatorButtons();
        }

        private void InitializeCalculatorButtons()
        {
            foreach (var control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (double.TryParse(buttonText, out _))
            {
                // Если нажата цифра, добавляем в текстовое поле
                txtDisplay.Text += buttonText;
            }
            else if (buttonText == "=")
            {
                CalculateResult();
            }
            else if (buttonText == "C")
            {
                txtDisplay.Clear(); // Очистка поля
            }
            else
            {
                SetOperation(buttonText);
            }
        }

        private void SetOperation(string op)
        {
            if (double.TryParse(txtDisplay.Text, out firstNumber))
            {
                operation = op;
                txtDisplay.Clear(); // Очищаем поле отображения для следующего числа
            }
        }

        private void CalculateResult()
        {
            if (double.TryParse(txtDisplay.Text, out double secondNumber))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Деление на ноль невозможно.");
                            return;
                        }
                        break;
                }

                txtDisplay.Text = result.ToString(); // Отображаем результат
            }
        }
    }
}
