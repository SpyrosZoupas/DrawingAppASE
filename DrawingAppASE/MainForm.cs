using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DrawingAppASE
{
    public partial class MainForm : Form
    {
        readonly Bitmap OutputBitmap;

        public MainForm()
        {
            InitializeComponent();
            OutputBitmap = new Bitmap(506, 396);
        }

        private void MultiLineButton_Click(object sender, EventArgs e)
        {

        }

        private void SingleLineButton_Click(object sender, EventArgs e)
        {
            string commandTyped = SingleLineBox.Text.Trim().ToLower();
            Pen pen = new Pen(Color.Red);
            Graphics graphics = Graphics.FromImage(OutputBitmap);
            switch (commandTyped)
            {
                case "line":
                    graphics.DrawLine(pen, 0, 0, 100, 100);
                    break;
                case "square":
                    graphics.DrawRectangle(pen, 0, 0, 100, 100);
                    break;
                case "circle":
                    graphics.DrawEllipse(pen, 0, 0, 100, 100);
                    break;
            }

            SingleLineBox.Clear();
            Refresh();
        }

        private void MultiLineBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("MultiLineKey pressed");
            }
        }

        private void SingleLineBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("SingleLineKey pressed");
                string commandTyped = SingleLineBox.Text.Trim().ToLower();
                Pen pen = new Pen(Color.Red);
                Graphics graphics = Graphics.FromImage(OutputBitmap);
                switch (commandTyped)
                {
                    case "line":
                        graphics.DrawLine(pen, 0, 0, 100, 100);
                        break;
                    case "square":
                        graphics.DrawRectangle(pen, 0, 0, 100, 100);
                        break;
                    case "circle":
                        graphics.DrawEllipse(pen, 0, 0, 100, 100);
                        break;                 
                }

                SingleLineBox.Clear();
                Refresh();
            }
        }

        private void paintBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
            
        }
    }
}
