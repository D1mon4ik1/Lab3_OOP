using System;
using System.Windows.Forms;
namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "������ ������� ������������ �����: ";
            label2.Text = "ĳ���� �����: ";
            label3.Text = "����� �������: ";
            label4.Text = "������ ����������: ";
            label5.Text = "X: ";
            label6.Text = "Y: ";
            label7.Text = "Z: ";
            label8.Text = "����������: ";
            label9.Text = " ";
            button1.Text = "���������";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("���� �����, ������ �� �����.", "������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double realPart = double.Parse(textBox1.Text);
            double imaginaryPart = double.Parse(textBox2.Text);
            double x = double.Parse(textBox3.Text);
            double y = double.Parse(textBox4.Text);
            double z = double.Parse(textBox5.Text);

            Complex complex = new Complex(realPart, imaginaryPart);
            Vector3D vector = new Vector3D(x, y, z);

            double complexNorm = complex.CalculateNorm();
            double complexModulus = complex.CalculateModulus();
            double vectorNorm = vector.CalculateNorm();
            double vectorModulus = vector.CalculateModulus();

            label9.Text = $"����� ������������ �����: {complexNorm}\n ������ ������������ �����: " +
                $"{complexModulus}\n ����� �������: {vectorNorm}\n ������ �������: {vectorModulus}";

        }
        public abstract class Norm
        {
            public abstract double CalculateNorm();
            public abstract double CalculateModulus();
        }
        public class Complex : Norm
        {
            private double realPart;
            private double imaginaryPart;

            public Complex(double realPart, double imaginaryPart)
            {
                this.realPart = realPart;
                this.imaginaryPart = imaginaryPart;
            }

            public override double CalculateNorm()
            {
                return Math.Pow(Math.Sqrt((realPart * realPart) + (imaginaryPart * imaginaryPart)), 2);
            }

            public override double CalculateModulus()
            {
                return Math.Sqrt((realPart * realPart) + (imaginaryPart * imaginaryPart));
            }
        }

        public class Vector3D : Norm
        {
            private double x;
            private double y;
            private double z;

            public Vector3D(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public override double CalculateNorm()
            {
                 return Math.Max(Math.Abs(x), Math.Max(Math.Abs(y), Math.Abs(z)));
            }

            public override double CalculateModulus()
            {
                return Math.Sqrt((x * x) + (y * y) + (z * z));
            }
        }

    }
}
