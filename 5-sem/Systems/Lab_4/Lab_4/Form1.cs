using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
        private void button1_Click(object sender, EventArgs e) //start
        {
            int res_line = FindWords();

            panel_input.Visible = false;
            panel_about.Visible = true;
            button4.Visible = true;

            if (res_line != -1)
                label_result.Text = "затрачено " + myStopwatch.ElapsedMilliseconds.ToString() + " миллисекунд" + "\n" + "Строка №" + res_line;
            else
                label_result.Text = "затрачено " + myStopwatch.ElapsedMilliseconds.ToString() + " миллисекунд" + "\n" + "Результат не найден";
        }
        int FindWords()
        {
            string[] words = { textBox3.Text, textBox2.Text, textBox1.Text };
            string[] file = File.ReadAllLines(Path.Combine(Application.StartupPath, "Text.txt"));
            myStopwatch.Reset();
            myStopwatch.Start();
            int line_num = 0;
            foreach (string line in file)
            {
                line_num++;
                string[] line_words = line.Split(' ', ',', ';', '.');
                for (int i = 0; i < line_words.Length; i++) 
                    if(line_words[i] == "")
                    {
                        for (int j = i; j < line_words.Length - 1; j++)
                        {
                            line_words[j] = line_words[j + 1];

                            if (j == line_words.Length - 2)
                                line_words[j+1] = "";
                        }
                    }
                for (int i = 2; i < line_words.Length; i++)
                {
                    if (line_words[i - 2] == words[0] &&
                        line_words[i - 1] == words[1] &&
                        line_words[i] == words[2])
                    {
                        myStopwatch.Stop();
                        return line_num;
                    }
                }
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e) //exit
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //About
        {
            panel_input.Visible = false;
            panel_about.Visible = true;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_input.Visible = true;
            panel_about.Visible = false;
            button4.Visible = false;
        }
    }
}
