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
        private List<string> commands;
       

        public MainForm()
        {
            InitializeComponent();
            OutputBitmap = new Bitmap(xBitMapSize, yBitMapSize);
            pen = new Pen(Color.Red);
            commands = new List<string>();
        }

        public void MultiLineButton_Click(object sender, EventArgs e)
        {
            ProcessMultiLine();
        }

        private void SingleLineButton_Click(object sender, EventArgs e)
        {
            ProcessSingleLine();
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
        }

        /// <summary>
        /// Method gets called when user clicks the save button
        /// Saves the program currently written in the program box as a text file
        /// </summary>
        private void SaveText()
        {
            var textToSave = MultiLineBox.Text;
            var path = "C:\\Save\\program.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(textToSave);
            sw.Close();
        }

        /// <summary>
        /// Method gets called when user clicks the load button
        /// Loads the previously saved program onto the program box
        /// </summary>
        private void LoadText()
        {
            var path = "C:\\Save\\program.txt";
            StreamReader sw = new StreamReader(path);
            var loadedText = sw.ReadToEnd();
            MultiLineBox.Text = loadedText;
            sw.Close();
        }

        /// <summary>
        /// Method gets called when the user enters the command "run" into the command line
        /// separates and adds each line of the program box in commands List
        /// cclls ParseAction to parse List of commands and call them  or inform the user in case of error
        /// </summary>
        private void ProcessMultiLine()
        {
            commands.AddRange(MultiLineBox.Text.Replace('\r', ' ').Trim().ToLower().Split('\n'));
            graphics = Graphics.FromImage(OutputBitmap);
            Parser.ParseAction(graphics, pen, commands);
            Refresh();
            commands.Clear();
        }

        /// <summary>
        /// Method gets called when command line button or enter is pressed when user is typing in command line
        /// if command is run calls ProcessMultiLine() to run commands on program box
        /// else calls ParseAction to parse command in command line and call it or inform the user in case of error
        /// </summary>
        private void ProcessSingleLine()
        {
            if (SingleLineBox.Text.Trim().ToLower() == "run")
            {
                ProcessMultiLine();
                SingleLineBox.Clear();
            }
            else
            {
                commands.Add(SingleLineBox.Text.Trim().ToLower());
                graphics = Graphics.FromImage(OutputBitmap);
                try
                {
                    Parser.ParseAction(graphics, pen, commands);
                } catch (ArgumentException)
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: Parameter has to be an integer");
                }
                SingleLineBox.Clear();
                Refresh();
                commands.Clear();
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
    }
}
