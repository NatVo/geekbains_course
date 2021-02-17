using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_7
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int rand_num;

        bool game_flag = false;
        string steps;
        public Form1()
        {
            InitializeComponent();
            //

            //labelOutput.Text = "0";
            //labelCountx2.Text = "0";
            //labelCount1.Text = "0";
            buttonCancel.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumSteps()
        {
            int counter_1 = 0;
            int counter_2 = 0;
            while (rand_num  > 0)
            {
                if (rand_num % 2 == 0)
                {
                    rand_num /= 2;
                    counter_1 += 1;
                }
                else 
                {
                    rand_num -= 1;
                    counter_2 += 1;
                }

            }

            labelCountx2.Text = labelCountx2.Text + "   возможное наим. число ходов x2: " + counter_1.ToString();
            labelCount1.Text = labelCount1.Text + "   возможное наим. число ходов +1: " + counter_2.ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (toolStripMenuItem1.Selected)
            {
                labelOutput.Text = (int.Parse(labelOutput.Text) * 2).ToString();
                labelCountx2.Text = (int.Parse(labelCountx2.Text) + 1).ToString();
                steps += "x";

            }


            if (toolStripMenuItem2.Selected)
            {
                labelOutput.Text = (int.Parse(labelOutput.Text) + 1).ToString();
                labelCount1.Text = (int.Parse(labelCount1.Text) + 1).ToString();
                steps += "-";
            }

            if (game_flag && int.Parse(labelOutput.Text) == rand_num)
            {
                NumSteps();
                buttonReset.Hide();
                buttonCancel.Hide();
                buttonPlay.Hide();
                labelGameOver.Text = "Игра закончена!";
                toolStripMenuItem1.Enabled = false;
                toolStripMenuItem2.Enabled = false;


            }
        }

        public void buttonReset_Click(object sender, EventArgs e)
        {
            SetNull();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (steps[steps.Length - 1] == 'x')
                {
                    labelOutput.Text = (int.Parse(labelOutput.Text) / 2).ToString();
                    labelCountx2.Text = (int.Parse(labelCountx2.Text) - 1).ToString();
                }
                else
                {
                    labelOutput.Text = (int.Parse(labelOutput.Text) - 1).ToString();
                    labelCount1.Text = (int.Parse(labelCount1.Text) - 1).ToString();
                }
                steps = steps.Remove(steps.Length - 1);
            }
            
            catch
            { }


        }

        private void SetNull()
        {
            labelOutput.Text = "0";
            labelCountx2.Text = "0";
            labelCount1.Text = "0";

            steps = "";
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            game_flag = true;
            SetNull();

            rand_num = random.Next(1, 1000);
            labelNumber.Text = "Конечное число: " + rand_num.ToString();
            buttonCancel.Show();
        }
    }
}
