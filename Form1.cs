using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        List <Button> buttons = new List<Button>();

        public EventHandler ShapeComboBox_SelectedIndexChanged { get; }

        public Form1()
        {
            InitializeComponent();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Width = screenWidth / 4;
            this.Height = screenHeight / 5;
            addButtonsToList();
            flagNumber2Start = false;
        }

        private void addButtonsToList()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
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
                display.Text = String.Empty;
            }
            Button button = (Button)sender;
            display.Text += button.Text;

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

        private void closeBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void selectForm(object sender, EventArgs e)
        {
            ComboBox shapeComboBox = (ComboBox)sender;
            string selectedShape = shapeComboBox.SelectedItem.ToString();
            switch (selectedShape)
            {
                case "Восьмигранник":
                    GraphicsPath path8Grannik = new GraphicsPath();
                    Point[] points = new Point[] {
        new Point(0, this.Height),
        new Point(this.Width, this.Height),
        new Point((int)(this.Width * 0.7), 0),
        new Point((int)(this.Width * 0.3), 0) };
                    Point[] pointsButtons = new Point[]
   {
        new Point(0, button1.Height),
        new Point(button1.Width, button1.Height),
        new Point((int)(button1.Width * 0.8), 0),
        new Point((int)(button1.Width * 0.2), 0)
   };
                    path8Grannik.AddPolygon(points);
                    this.Region = new Region(path8Grannik);
                    this.BackColor = Color.Red;
                    path8Grannik.AddPolygon(pointsButtons);
                    foreach (var item in buttons)
                    {
                        item.Region = new Region(path8Grannik);
                    }
                   

                    break;
                case "Эллипс":
                    GraphicsPath pathEllips = new GraphicsPath();
                    pathEllips.AddEllipse(0, 0, this.Width, this.Height);
                    this.Region = new Region(pathEllips);
                    this.BackColor = Color.Green;
                    pathEllips.AddEllipse(0, 0, button1.Width, button1.Height);
                    foreach (var item in buttons)
                    {
                        item.Region = new Region(pathEllips);
                    }

                    break;
                case "Трапеция":
                    GraphicsPath pathTrapezia = new GraphicsPath();
                    Point[] pointsTrapezia = new Point[]
                    {
        new Point(0, this.Height),
        new Point(this.Width, this.Height),
        new Point((int)(this.Width * 0.8), 0),
        new Point((int)(this.Width * 0.2), 0)
                    };
                    Point[] pointsButton2 = new Point[]
   {
        new Point(0, button1.Height),
        new Point(button1.Width, button1.Height),
        new Point((int)(button1.Width * 0.8), 0),
        new Point((int)(button1.Width * 0.2), 0)
   };
                    pathTrapezia.AddPolygon(pointsTrapezia);
                    this.Region = new Region(pathTrapezia);
                    this.BackColor= Color.Yellow;
                    pathTrapezia.AddPolygon(pointsButton2);
                    foreach (var item in buttons)
                    {
                        item.Region = new Region(pathTrapezia);
                    }


                    break;
                default: ;
                    break;
            }
        }
    }
}
