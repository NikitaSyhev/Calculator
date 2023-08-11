using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calulator
{
    public partial class Form1 : Form
    {

        public string mathSign;
        public string number1;
        public bool flagNumber2Start;
        public double result;
        public Form1()
        {
            InitializeComponent();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Width = screenWidth / 4;
            this.Height = screenHeight / 5;
            flagNumber2Start = false;
        }

      
        private void btnSign_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            mathSign = button.Text;
            number1 = display.Text;
            flagNumber2Start = true;

        }

        private void numberBtn_Click(object sender, EventArgs e)
        {
            if (flagNumber2Start)
            {
                flagNumber2Start = false;
                display.Text = "";
            }
            Button button = (Button)sender;
            display.Text = display.Text + button.Text;
           
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double numberCalc1, numberCalc2;
            numberCalc1 = Convert.ToDouble(number1);
            numberCalc2 = Convert.ToDouble(display.Text);
            mathematicalAction(numberCalc1, numberCalc2);
            flagNumber2Start = true;
            display.Text = result.ToString();

        }


        private double mathematicalAction(double number1, double number2)
        {
            switch (mathSign)
            {
                case "+":
                    result = number1 + number2; break;
                case "-":
                    result = number1 - number2; break;
                case "*":
                    result = number1 * number2; break;
                case "/":
                    result = number1 / number2; break;       
            }
            return result;
        }
    }
}
