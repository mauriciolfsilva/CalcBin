using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CalculadoraBinário
{
    public partial class Form1 : Form
    {
        public bool canCal = false;

        public string a;
        public Form1()
        {
            Console.WriteLine(Calculador.MultBin("101","11"));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Convertor.BinToDec(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label1.Text = Convertor.BinToHex(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!canCal)
            {
                a = textBox1.Text;
                textBox1.Text = "";
                canCal = true;
            }

            else
            {
                label1.Text = Calculador.SomaBin(a, textBox1.Text);
                canCal = false;
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!canCal)
            {
                a = textBox1.Text;
                textBox1.Text = "";
                canCal = true;
            }

            else
            {
                label1.Text = Calculador.MultBin(a, textBox1.Text);
                canCal = false;
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!canCal)
            {
                a = textBox1.Text;
                textBox1.Text = "";
                canCal = true;
            }

            else
            {
                label1.Text = Calculador.SubBin(a, textBox1.Text);
                canCal = false;
                textBox1.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!canCal)
            {
                a = textBox1.Text;
                textBox1.Text = "";
                canCal = true;
            }

            else
            {
                label1.Text = Calculador.DivBin(a, textBox1.Text);
                canCal = false;
                textBox1.Text = "";
            }
        }

        private void Num_Click(object sender, EventArgs e)
        {
            Button digit = sender as Button;
            textBox1.Text += digit.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Regex.Replace(Convert.ToString(textBox1.Text), "[^0-1]", "");
        }
    }
}
