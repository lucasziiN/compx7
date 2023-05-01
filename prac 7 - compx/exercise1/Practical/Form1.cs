using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        //The minimum number of hours to display
        const int MIN_HOURS = 1;
        //The maximum number of hours to display
        const int MAX_HOURS = 24;
        //The number of days to display
        const int NUM_DAYS = 7;

        public Form1()
        {
            InitializeComponent();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DrawSquare(Graphics paper, float x, float y, float width, float height, Color color)
        {
            Brush br2 = new SolidBrush(color);
            Pen pen2 = new Pen(Color.Black);
            paper.FillRectangle(br2, x, y, width, height);
            paper.DrawRectangle(pen2, x, y, width, height);
        }
        
        private void DrawRow(Graphics paper, float y, float square_width, float square_height)
        {
            float x = 0;
            for (int cols = 1 ; cols <= NUM_DAYS; cols++)
            {
                if (cols>=6)
                {
                    DrawSquare(paper, x, y, square_width, square_height, Color.LightBlue);
                }
                else
                {
                    DrawSquare(paper, x, y, square_width, square_height, Color.White);
                }
                x += square_width;
            }
        }

        private void drawPlannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics paper = pictureBoxDisplay.CreateGraphics();
                Pen pen1 = new Pen(Color.Black, 3);
                Brush br1 = new SolidBrush(Color.White);
                Brush br2 = new SolidBrush(Color.LightBlue);
                int num_hours = int.Parse(textBoxNumHours.Text);
                float x = 0;
                float y = 0;
                float appt_width = pictureBoxDisplay.Width / NUM_DAYS;
                float appt_height = pictureBoxDisplay.Height / num_hours;
                
                if (num_hours >= MIN_HOURS && num_hours <= MAX_HOURS)
                {
                    for (int rows = 1; rows <=num_hours; rows++)
                    {
                        DrawRow(paper, y, appt_width, appt_height);
                        y += appt_height;
                        /*for (int cols = 1; cols <=NUM_DAYS; cols++)
                        {
                            if (cols>=6)
                            {
                                paper.FillRectangle(br2, x, y, appt_width, appt_height);
                                paper.DrawRectangle(pen1, x, y, appt_width, appt_height);
                            }
                            else
                            {
                                paper.FillRectangle(br1, x, y, appt_width, appt_height);
                                paper.DrawRectangle(pen1, x, y, appt_width, appt_height);
                            }
                            x += appt_width;
                        }
                        x = 0;*/
                    }
                    //DrawSquare(paper, 0, 0, 500, 500, Color.White);
                }
                else
                {
                    MessageBox.Show("Error. Value not valid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
