using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Воробьева Наталья
//Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, 
//а человек пытается его угадать за минимальное число попыток. Для ввода данных от человека используется элемент TextBox.
//Старайтесь разбивать программы на подпрограммы. 
//Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении.

namespace App_7_guess
{
    public partial class Form_Guess : Form
    {

        int rand_num;
        int counter = 5;
        public Form_Guess()
        {
            InitializeComponent();
            InitNum();
            labelCount.Text = counter.ToString();
        }

        private void InitNum()
        {
            Random random = new Random();
            rand_num = random.Next(1, 100);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            int input;

            if (!Int32.TryParse(textBoxInput.Text, out input))
            {
                labelError.Text = "Данные были введены некорректно!";
            }
            else
            {
                input = int.Parse(textBoxInput.Text);
                if (input == rand_num)
                {
                    labelError.ForeColor = System.Drawing.Color.Green;
                    labelError.Text = "Игра окончена, вы выиграли!";
                    buttonCheck.Enabled = false;
                }                    
                else if (input > rand_num)
                {
                    labelError.Text = "Вы ввели слишком большое число!";
                    counter -= 1;
                }
                else
                {
                    labelError.Text = "Вы ввели слишком маленькое число!";
                    counter -= 1;
                }


            }

            labelCount.Text = counter.ToString();
            if (counter <= 0)
            {
                labelError.Text = "Попытки закончились, вы проиграли!";
                buttonCheck.Enabled = false;
            }

        }
    }
}
