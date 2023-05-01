using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticalTest
{
    public partial class Form1 : Form
    {
        //the width and height of each square
        const int SQUARE_SIZE = 50;

        //minimum and maximum board sizes
        const int MINIMUM_SIZE = 6;
        const int MAXIMUM_SIZE = 20;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics paper = pictureBoxDisplay.CreateGraphics();
                Pen pen1 = new Pen(Color.Black, 2);
                SolidBrush br1 = new SolidBrush(Color.LightPink);
                SolidBrush br2 = new SolidBrush(Color.LightBlue);

                int num_columns = int.Parse(textBox1.Text);

                float x = 0;
                float y = 0;

                if (num_columns >= MINIMUM_SIZE && num_columns<=MAXIMUM_SIZE)
                {
                    for (int cols = 1; cols <= num_columns; cols++)
                    {
                        for (int rows = 1; rows <= num_columns; rows++)
                        {
                            if (cols+rows==(num_columns+1)) /*|| (cols == rows))*/
                            {
                                paper.FillRectangle(br1, x, y, SQUARE_SIZE, SQUARE_SIZE);
                                paper.DrawRectangle(pen1, x,y,SQUARE_SIZE,SQUARE_SIZE);
                            }
                            else
                            {
                                paper.FillRectangle(br2, x, y, SQUARE_SIZE, SQUARE_SIZE);
                                paper.DrawRectangle(pen1, x, y, SQUARE_SIZE, SQUARE_SIZE);
                            }
                            x+=SQUARE_SIZE;
                        }
                        x=0;
                        y+=SQUARE_SIZE;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid size. Enter a value between 6 and 20");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
