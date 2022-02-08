using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            view_matrix_1 = new Label[3, 3];
            view_matrix_1[0,0] = label1;
            view_matrix_1[0,1] = label2;
            view_matrix_1[0,2] = label3;
            view_matrix_1[1,0] = label4;
            view_matrix_1[1,1] = label5;
            view_matrix_1[1,2] = label6;
            view_matrix_1[2,0] = label7;
            view_matrix_1[2,1] = label8;
            view_matrix_1[2,2] = label9;

            view_matrix_2 = new Label[3, 3];
            view_matrix_2[0, 0] = label10;
            view_matrix_2[0, 1] = label11;
            view_matrix_2[0, 2] = label12;
            view_matrix_2[1, 0] = label13;
            view_matrix_2[1, 1] = label14;
            view_matrix_2[1, 2] = label15;
            view_matrix_2[2, 0] = label16;
            view_matrix_2[2, 1] = label17;
            view_matrix_2[2, 2] = label18;
        }
        Label[,] view_matrix_1;
        Label[,] view_matrix_2;
        Random random = new Random();

        void FirstThreadFunc()
        {
            int[,] matrix_buff = new int[3, 3];
            
            int sum_buf = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    matrix_buff[i, j] = random.Next(-10, 10);
                    sum_buf += matrix_buff[i, j];
                }

            matrix = matrix_buff;
            sum = sum_buf;

            first_thread.Abort();
        }
        void SecondThreadFunc()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix_res[i, j] = matrix[i, j] + matrix[i, i];
            second_thread.Abort();
        }

        int sum = 0;
        int[,] matrix;
        int[,] matrix_res;


        Thread first_thread;
        Thread second_thread;
        private void button1_Click(object sender, EventArgs e) //Start
        {
            matrix = new int[3, 3];
            first_thread = new Thread(new ThreadStart(FirstThreadFunc));
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e) //exit
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e) //about
        {
            FormInfo form = new FormInfo();
            form.ShowDialog();
        } //done

        private void button4_Click(object sender, EventArgs e) //request
        {
            if (first_thread.IsAlive)
                return;

            matrix_res = new int[3, 3];
            second_thread = new Thread(new ThreadStart(SecondThreadFunc));
            second_thread.Start();

            int check_sum = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    view_matrix_1[i, j].Text = matrix[i, j].ToString();
                    check_sum += matrix[i, j];
                }

            if (check_sum == sum)
                label20.Text = "Данные достоверны";
            else
                label20.Text = "Данные не достоверны";

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    view_matrix_2[i, j].Text = matrix_res[i, j].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (first_thread.IsAlive)
                return;

            first_thread = new Thread(new ThreadStart(FirstThreadFunc));
            first_thread.Start();
        }
    }
}
