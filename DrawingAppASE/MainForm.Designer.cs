namespace DrawingAppASE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MultiLineButton = new System.Windows.Forms.Button();
            this.SingleLineButton = new System.Windows.Forms.Button();
            this.MultiLineBox = new System.Windows.Forms.TextBox();
            this.SingleLineBox = new System.Windows.Forms.TextBox();
            this.paintBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MultiLineButton
            // 
            this.MultiLineButton.Location = new System.Drawing.Point(12, 428);
            this.MultiLineButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MultiLineButton.Name = "MultiLineButton";
            this.MultiLineButton.Size = new System.Drawing.Size(338, 34);
            this.MultiLineButton.TabIndex = 0;
            this.MultiLineButton.Text = "Draw";
            this.MultiLineButton.UseVisualStyleBackColor = true;
            this.MultiLineButton.Click += new System.EventHandler(this.MultiLineButton_Click);
            // 
            // SingleLineButton
            // 
            this.SingleLineButton.Location = new System.Drawing.Point(766, 422);
            this.SingleLineButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SingleLineButton.Name = "SingleLineButton";
            this.SingleLineButton.Size = new System.Drawing.Size(110, 34);
            this.SingleLineButton.TabIndex = 1;
            this.SingleLineButton.Text = "Draw";
            this.SingleLineButton.UseVisualStyleBackColor = true;
            this.SingleLineButton.Click += new System.EventHandler(this.SingleLineButton_Click);
            // 
            // MultiLineBox
            // 
            this.MultiLineBox.Location = new System.Drawing.Point(12, 12);
            this.MultiLineBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MultiLineBox.Multiline = true;
            this.MultiLineBox.Name = "MultiLineBox";
            this.MultiLineBox.Size = new System.Drawing.Size(338, 396);
            this.MultiLineBox.TabIndex = 2;
            // 
            // SingleLineBox
            // 
            this.SingleLineBox.Location = new System.Drawing.Point(382, 428);
            this.SingleLineBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SingleLineBox.Name = "SingleLineBox";
            this.SingleLineBox.Size = new System.Drawing.Size(366, 30);
            this.SingleLineBox.TabIndex = 3;
            this.SingleLineBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SingleLineBox_KeyDown);
            // 
            // paintBox
            // 
            this.paintBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.paintBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paintBox.Location = new System.Drawing.Point(382, 12);
            this.paintBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.paintBox.Name = "paintBox";
            this.paintBox.Size = new System.Drawing.Size(506, 396);
            this.paintBox.TabIndex = 4;
            this.paintBox.TabStop = false;
            this.paintBox.Paint += new System.Windows.Forms.PaintEventHandler(this.paintBox_Paint);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 468);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(108, 31);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(138, 468);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(96, 31);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(950, 518);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.paintBox);
            this.Controls.Add(this.SingleLineBox);
            this.Controls.Add(this.MultiLineBox);
            this.Controls.Add(this.SingleLineButton);
            this.Controls.Add(this.MultiLineButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MultiLineButton;
        private System.Windows.Forms.Button SingleLineButton;
        private System.Windows.Forms.TextBox MultiLineBox;
        private System.Windows.Forms.TextBox SingleLineBox;
        private System.Windows.Forms.PictureBox paintBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
    }
}

