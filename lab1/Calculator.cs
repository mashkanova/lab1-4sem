using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public delegate void EventHandler(object sender, EventArgs e);
    public partial class Calculator : Form
    {
        Col col;
        int k;
        int save_result;
        public Calculator()
        {
            InitializeComponent();
            col = new Col();

        }
        private void FreeButtons()
        {
            button_plus.Enabled = true;
            button_min.Enabled = true;
            button_dev.Enabled = true;
            button_mult.Enabled = true;
            button_mod.Enabled = true;
            button_div.Enabled = true;
        }
        public void label1_Click(object sender, EventArgs e)
        {

        }
        public void button1_Click(object sender, EventArgs e)
        {
            col.Put_A(Convert.ToDouble(textBox1.Text));
            button_plus.Enabled = false;
            textBox1.Text = "";
        }
        public void button4_Click(object sender, EventArgs e)
        {
                col.Put_A(Convert.ToDouble(textBox1.Text));
            button_mult.Enabled = false;
            textBox1.Text = "";
        }
        public void button2_Click(object sender, EventArgs e)
        {
            col.Put_A(Convert.ToDouble(textBox1.Text));
            button_min.Enabled = false;
            textBox1.Text = "";
        }
        public void button3_Click(object sender, EventArgs e)
        {
            col.Put_A(Convert.ToDouble(textBox1.Text));
            button_dev.Enabled = false;

            textBox1.Text = "";
        }
        public void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;

        }

        public void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        public void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;

        }

        public void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;

        }

        public void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        public void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        public void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        public void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        public void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        public void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            col.Clear();
            FreeButtons();

            k = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            col.Put_A(Convert.ToDouble(textBox1.Text));
            button_mod.Enabled = false;

            textBox1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            col.Put_A(Convert.ToInt16(textBox1.Text));
            button_div.Enabled = false;

            textBox1.Text = "";
        }


        private void button19_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                k++;
                if (k == 1)                 
                textBox1.Text = col.MemoryShow().ToString();
                if (k == 2)
                {
                    col.Memory_Clear();
                    textBox1.Text = "";
                    k = 0;
                }
            }

        }

        public void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (!button_plus.Enabled)
                    textBox1.Text = col.Add(Convert.ToDouble(textBox1.Text)).ToString();

                if (!button_min.Enabled)
                    textBox1.Text = col.Sub(Convert.ToDouble(textBox1.Text)).ToString();

                if (!button_dev.Enabled)
                    textBox1.Text = col.Del(Convert.ToDouble(textBox1.Text)).ToString();

                if (!button_mult.Enabled)
                    textBox1.Text = col.Multy(Convert.ToDouble(textBox1.Text)).ToString();

                if (!button_mod.Enabled)
                    textBox1.Text = col.Mod(Convert.ToDouble(textBox1.Text)).ToString();

                if (!button_div.Enabled)
                    textBox1.Text = col.Div(Convert.ToInt16(textBox1.Text)).ToString();
                col.Clear();

                FreeButtons();

                k = 0;
            }
            catch 
            {
                Console.WriteLine("ERROR");
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            
        }
        private bool CanPress()
        {
            if (!button_plus.Enabled)
                return false;

            if (!button_min.Enabled)
                return false;

            return true;
        }

        private void butttonMSum_Click(object sender, EventArgs e)
        {
            col.M_Sum(Convert.ToDouble(textBox1.Text));
        }

        private void buttonMMinus_Click_1(object sender, EventArgs e)
        {
            col.M_Subtraction(Convert.ToDouble(textBox1.Text));
        }
    }
    class Col : ICol
    {
        private double a = 0;
        private double memory = 0;

        public void Put_A(double a)
        {
            this.a = a;
        }

        public void Clear()
        {
            a = 0;
        }
        public double Add(double b)
        {
            memory =a+ b;
            return a + b;
        }

        public double Sub(double b)
        {
            memory =a- b;
            return a -b;
        }

        public double Multy(double b)
        {
            memory =a* b;
            return a *b;
        }

        public double Del(double b)
        {
            memory = a/ b;
            return (int)(a/b);
        }

        public double Mod(double b)
        {
            memory =a% b;
            return a %b;
        }

        public double Div(double b)
        {
            try
            {
                memory = a / b;
            }
            catch (DivideByZeroException)
            {
            }
            return a / b;
        }
        public double MemoryShow()
        {
            return memory;
        } //показать содержимое регистра памяти

        public void Memory_Clear()
        {
            memory = 0.0;
        } //стереть содержимое регистра памяти

        // + - к регистру памяти

        public void M_Sum(double b)
        {
            memory += b;
        }

        public void M_Subtraction(double b)
        {
            memory -= b;
        } //вычитание


    }
}

