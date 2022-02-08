using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Input
        const double a = 0;
        const double a0 = 1;
        const double a1 = 0;
        const double A = 0.5;

        const double b = 1;
        const double b0 = 1;
        const double b1 = 1;
        const double B = 5;
        #endregion  //Input

        double h;
        int n;


        public double P_x(double x)
        {
            return (2 * x - 1) / (2 * x + 1);
        }
        public double Q_x(double x)
        {
            return (-2) / (2 * x + 1);
        }
        public double F_x(double x)
        {
            return (x * x + x) / (2 * x + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            h = (b - a) / n;


            double u_0;
            double u_1;
            double v_0;
            double v_1;

            if (a0 != 0)
            {
                u_0 = -a1 / a0;
                u_1 = 1;

                v_0 = A / a0;
                v_1 = 0;
            }
            else if (a1 != 0)
            {
                u_1 = -a0 / a1;
                u_0 = 1;

                v_1 = A / a1;
                v_0 = 0;
            }

            List<double> z = new List<double>();
            List<double> u = new List<double>();

            List<double> v = new List<double>();
            List<double> z2 = new List<double>();

            u.Add(u_0);
            z.Add(u_1);

            v.Add(v_0);
            z2.Add(v_1);

            List<double> q_i = new List<double>();
            List<double> k_i = new List<double>();

            double cur_x;
            for (int i = 0; i < n-1; i++)
            {
                cur_x = a + h * i;
                q_i.Clear();
                k_i.Clear();

                //z' = -p*z-q*u

                //0
                q_i.Add(U(
                    cur_x, 
                    u[u.Count - 1], 
                    z[z.Count - 1]));
                k_i.Add(z[z.Count - 1]);

                //1
                q_i.Add(U(
                    cur_x + h / 2, 
                    u[u.Count - 1] + k_i[0] * h / 2, 
                    z[z.Count - 1] + q_i[0] * h / 2));
                k_i.Add(V(z[z.Count - 1] + q_i[0] * h / 2));

                //2
                q_i.Add(U(
                    cur_x + h / 2,
                    u[u.Count - 1] + k_i[1] * h / 2,
                    z[z.Count - 1] + q_i[1] * h / 2));
                k_i.Add(z[z.Count - 1] + q_i[1] * h / 2);

                //3
                q_i.Add(U(
                    cur_x + h,
                    u[u.Count - 1] + k_i[2] * h,
                    z[z.Count - 1] + q_i[2] * h));
                k_i.Add(z[z.Count - 1] + q_i[2] * h);

                z.Add(z[z.Count - 1] + (h / 6) * (q_i[0] + 2 * q_i[1] + 2 * q_i[2] + q_i[3]));
                u.Add(u[u.Count - 1] + (h / 6) * (k_i[0] + 2 * k_i[1] + 2 * k_i[2] + k_i[3]));
            }
            for (int i = 0; i < n - 1; i++)
            {
                cur_x = a + h * i;
                q_i.Clear();
                k_i.Clear();

                //z' = -p*z-q*u

                //0
                q_i.Add(U2(
                    cur_x,
                    v[v.Count - 1],
                    z2[z2.Count - 1]));
                k_i.Add(z2[z2.Count - 1]);

                //1
                q_i.Add(U2(
                    cur_x + h / 2,
                    v[v.Count - 1] + k_i[0] * h / 2,
                    z2[z2.Count - 1] + q_i[0] * h / 2));
                k_i.Add(V(z2[z2.Count - 1] + q_i[0] * h / 2));

                //2
                q_i.Add(U2(
                    cur_x + h / 2,
                    v[v.Count - 1] + k_i[1] * h / 2,
                    z2[z2.Count - 1] + q_i[1] * h / 2));
                k_i.Add(z2[z2.Count - 1] + q_i[1] * h / 2);

                //3
                q_i.Add(U2(
                    cur_x + h,
                    v[v.Count - 1] + k_i[2] * h,
                    z2[z2.Count - 1] + q_i[2] * h));
                k_i.Add(z2[z2.Count - 1] + q_i[2] * h);

                z2.Add(z2[z2.Count - 1] + (h / 6) * (q_i[0] + 2 * q_i[1] + 2 * q_i[2] + q_i[3]));
                v.Add(v[v.Count - 1] + (h / 6) * (k_i[0] + 2 * k_i[1] + 2 * k_i[2] + k_i[3]));
            }
            double C = (B - (b0 * v[v.Count - 1] + b1 * z2[z2.Count - 1])) /
                (b0 * u[u.Count - 1] + b1 * z[z.Count - 1]);

            List<double> res = new List<double>();


            chart1.Series.Clear();
            chart1.Series.Add("Exact");
            chart1.Series.Add("Calc");
            chart1.Series.Add("Analitic");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Color = Color.Aqua;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[2].Color = Color.Blue;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            double delta = (Analitic(b)) - ExactFunc(b);
            for (int i = 0; i < u.Count; i++) 
            {
                res.Add(C * u[i] + v[i]);

                //res[res.Count - 1] -= delta;

                listBox1.Items.Add(Math.Round(res[res.Count - 1], 3));
                listBox2.Items.Add(Math.Round(ExactFunc(a + i * h), 3));
                listBox3.Items.Add(Math.Round(Analitic(a + i * h), 3));
                listBox4.Items.Add(Math.Round(a + i * h, 3));
                chart1.Series[0].Points.AddXY(a + i * h, ExactFunc(a + i * h));
                chart1.Series[1].Points.AddXY(a + i * h, res[res.Count - 1]);
                chart1.Series[2].Points.AddXY(a + i * h, Analitic(a + i * h));
            }

        }
        public double Analitic(double x)
        {
            return (3 + x + 1.978 * x * (x - 1) - 0.4168 * x * x * (x - 1));
        }
        public double U(double x, double u, double z)
        {
            return (-P_x(x) * z - Q_x(x) * u);
        }
        public double U2(double x, double u, double z)
        {
            return (-P_x(x) * z - Q_x(x) * u + F_x(x));
        }
        public double ExactFunc(double x)
        {
            return (2 * x - 1 + Math.Exp(-x) + (x * x + 1) / 2);
        }
        public double V(double z)
        {
            return z;
        }
    }
}
