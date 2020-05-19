using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фоновая_6._1
{
    public partial class Form1 : Form
    {
        private int WidthButton; // К сожалению, не нашел другого способа сохранить длину кнопки
        public Form1()
        {
            InitializeComponent();
            WidthButton = button1.Size.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Location.X - 10 > 0) button2.Left = button2.Location.X - 10;
            else 
            {
                if (button2.Location.X == 0) button2.Left = Form1.ActiveForm.Size.Width - button2.Size.Width - 16 ; //вычитаю рамки окна, каждая равна 8 
                else button2.Left = 0; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Size.Width - 2 > 0) button1.Width = button1.Size.Width - 2;
            else button1.Width = WidthButton;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
