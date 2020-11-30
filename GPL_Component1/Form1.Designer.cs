namespace GPL_Component1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.commandInputBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorPickBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.penTrackBar = new System.Windows.Forms.TrackBar();
            this.circleButtonSelect = new System.Windows.Forms.Button();
            this.rectangleBtnSelect = new System.Windows.Forms.Button();
            this.squareBtnSelect = new System.Windows.Forms.Button();
            this.triangleBtnSelect = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.penButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penTrackBar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(552, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.runButton_Click);
            // 
            // commandInputBox
            // 
            this.commandInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.commandInputBox.Location = new System.Drawing.Point(3, 27);
            this.commandInputBox.Name = "commandInputBox";
            this.commandInputBox.Size = new System.Drawing.Size(529, 26);
            this.commandInputBox.TabIndex = 2;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.IndianRed;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.resetButton.Location = new System.Drawing.Point(657, 23);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(96, 34);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.resetButton);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.commandInputBox);
            this.panel2.Location = new System.Drawing.Point(16, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 84);
            this.panel2.TabIndex = 4;
            // 
            // colorPickBtn
            // 
            this.colorPickBtn.Image = global::GPL_Component1.Properties.Resources.paint_bucket;
            this.colorPickBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.colorPickBtn.Location = new System.Drawing.Point(39, 15);
            this.colorPickBtn.Name = "colorPickBtn";
            this.colorPickBtn.Size = new System.Drawing.Size(90, 34);
            this.colorPickBtn.TabIndex = 5;
            this.colorPickBtn.Text = "Pick Color";
            this.colorPickBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.colorPickBtn.UseVisualStyleBackColor = true;
            this.colorPickBtn.Click += new System.EventHandler(this.colorPickBtn_Click);
            // 
            // penTrackBar
            // 
            this.penTrackBar.Location = new System.Drawing.Point(39, 104);
            this.penTrackBar.Minimum = 1;
            this.penTrackBar.Name = "penTrackBar";
            this.penTrackBar.Size = new System.Drawing.Size(104, 45);
            this.penTrackBar.TabIndex = 6;
            this.penTrackBar.Value = 1;
            this.penTrackBar.ValueChanged += new System.EventHandler(this.penTrackBar_ValueChanged);
            // 
            // circleButtonSelect
            // 
            this.circleButtonSelect.Image = global::GPL_Component1.Properties.Resources.circle;
            this.circleButtonSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.circleButtonSelect.Location = new System.Drawing.Point(39, 319);
            this.circleButtonSelect.Name = "circleButtonSelect";
            this.circleButtonSelect.Size = new System.Drawing.Size(88, 34);
            this.circleButtonSelect.TabIndex = 7;
            this.circleButtonSelect.Text = "Circle";
            this.circleButtonSelect.UseVisualStyleBackColor = true;
            this.circleButtonSelect.Click += new System.EventHandler(this.circleButtonSelect_Click);
            // 
            // rectangleBtnSelect
            // 
            this.rectangleBtnSelect.Image = global::GPL_Component1.Properties.Resources.rectangle;
            this.rectangleBtnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rectangleBtnSelect.Location = new System.Drawing.Point(39, 209);
            this.rectangleBtnSelect.Name = "rectangleBtnSelect";
            this.rectangleBtnSelect.Size = new System.Drawing.Size(87, 36);
            this.rectangleBtnSelect.TabIndex = 8;
            this.rectangleBtnSelect.Text = "Rectangle";
            this.rectangleBtnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rectangleBtnSelect.UseVisualStyleBackColor = true;
            this.rectangleBtnSelect.Click += new System.EventHandler(this.rectangleBtnSelect_Click);
            // 
            // squareBtnSelect
            // 
            this.squareBtnSelect.Image = global::GPL_Component1.Properties.Resources.square;
            this.squareBtnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.squareBtnSelect.Location = new System.Drawing.Point(39, 265);
            this.squareBtnSelect.Name = "squareBtnSelect";
            this.squareBtnSelect.Size = new System.Drawing.Size(87, 37);
            this.squareBtnSelect.TabIndex = 9;
            this.squareBtnSelect.Text = "Square";
            this.squareBtnSelect.UseVisualStyleBackColor = true;
            this.squareBtnSelect.Click += new System.EventHandler(this.squareBtnSelect_Click);
            // 
            // triangleBtnSelect
            // 
            this.triangleBtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.triangleBtnSelect.Image = global::GPL_Component1.Properties.Resources.triangle;
            this.triangleBtnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.triangleBtnSelect.Location = new System.Drawing.Point(39, 369);
            this.triangleBtnSelect.Name = "triangleBtnSelect";
            this.triangleBtnSelect.Size = new System.Drawing.Size(88, 37);
            this.triangleBtnSelect.TabIndex = 10;
            this.triangleBtnSelect.Text = "Triangle";
            this.triangleBtnSelect.UseVisualStyleBackColor = false;
            this.triangleBtnSelect.Click += new System.EventHandler(this.triangleBtnSelect_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.penButton);
            this.panel3.Controls.Add(this.circleButtonSelect);
            this.panel3.Controls.Add(this.triangleBtnSelect);
            this.panel3.Controls.Add(this.penTrackBar);
            this.panel3.Controls.Add(this.colorPickBtn);
            this.panel3.Controls.Add(this.squareBtnSelect);
            this.panel3.Controls.Add(this.rectangleBtnSelect);
            this.panel3.Location = new System.Drawing.Point(810, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 437);
            this.panel3.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(51, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Fill";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // penButton
            // 
            this.penButton.Image = global::GPL_Component1.Properties.Resources.pen;
            this.penButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.penButton.Location = new System.Drawing.Point(39, 155);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(87, 34);
            this.penButton.TabIndex = 12;
            this.penButton.Text = "Pen";
            this.penButton.UseVisualStyleBackColor = true;
            this.penButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(16, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(772, 331);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "FIle";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::GPL_Component1.Properties.Resources.upload_file;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::GPL_Component1.Properties.Resources.diskette;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(978, 521);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penTrackBar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox commandInputBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button colorPickBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar penTrackBar;
        private System.Windows.Forms.Button circleButtonSelect;
        private System.Windows.Forms.Button rectangleBtnSelect;
        private System.Windows.Forms.Button squareBtnSelect;
        private System.Windows.Forms.Button triangleBtnSelect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button penButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

