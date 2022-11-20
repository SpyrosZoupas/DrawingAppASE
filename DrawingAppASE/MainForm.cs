using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DrawingAppASE
{
    public partial class MainForm : Form
    {
        private readonly Bitmap OutputBitmap;
        private const int xBitMapSize = 506;
        private const int yBitMapSize = 396;
        private Pen pen;
        private Graphics graphics;
       

        public MainForm()
        {
            InitializeComponent();
            OutputBitmap = new Bitmap(xBitMapSize, yBitMapSize);
            pen = new Pen(Color.Red);
        }

        public void MultiLineButton_Click(object sender, EventArgs e)
        {
            ProcessMultiLine();
        }

        private void SingleLineButton_Click(object sender, EventArgs e)
        {
            ProcessSingleLine();
        }

        private void MultiLineBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ProcessMultiLine();
            }
        }

        private void SingleLineBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessSingleLine();
            }
        }

        private void paintBox_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
            if (Parser.commands != null)
            {
                Parser.ParseAction(graphics, pen);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveText();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadText();
        }

        private void SaveText()
        {
            var textToSave = MultiLineBox.Text;
            var path = "C:\\Save\\test.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(textToSave);
            sw.Close();
        }

        private void LoadText()
        {
            var path = "C:\\Save\\test.txt";
            StreamReader sw = new StreamReader(path);
            var loadedText = sw.ReadToEnd();
            MultiLineBox.Text = loadedText;
            sw.Close();
        }

        private void ProcessMultiLine()
        {
            Parser.commands = new List<string>();
            Parser.commands.AddRange(MultiLineBox.Text.Replace('\r', ' ').Trim().ToLower().Split('\n'));
            MultiLineBox.Clear();
            Refresh();
            Parser.commands.Clear();
        }

        private void ProcessSingleLine()
        {
            Parser.commands = new List<string>();
            Parser.commands.Add(SingleLineBox.Text.Trim().ToLower());
            SingleLineBox.Clear();
            Refresh();
            Parser.commands.Clear();
        }
    }
}
