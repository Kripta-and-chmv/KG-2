namespace KG_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnZoomL = new System.Windows.Forms.Button();
            this.btnZoomS = new System.Windows.Forms.Button();
            this.btnRitateL = new System.Windows.Forms.Button();
            this.btnRotateR = new System.Windows.Forms.Button();
            this.lstbxSquares = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chckbxPaintMode = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.chckbxMoveMode = new System.Windows.Forms.CheckBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.chkbxFill = new System.Windows.Forms.CheckBox();
            this.chckbxColorOr = new System.Windows.Forms.CheckBox();
            this.chckbxColorNOr = new System.Windows.Forms.CheckBox();
            this.btnTex = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.AutoSize = true;
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(6, 6);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(680, 430);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseClick);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnZoomL
            // 
            this.btnZoomL.Location = new System.Drawing.Point(125, 31);
            this.btnZoomL.Name = "btnZoomL";
            this.btnZoomL.Size = new System.Drawing.Size(46, 42);
            this.btnZoomL.TabIndex = 1;
            this.btnZoomL.Text = "+";
            this.btnZoomL.UseVisualStyleBackColor = true;
            this.btnZoomL.Click += new System.EventHandler(this.btnZoomL_Click);
            // 
            // btnZoomS
            // 
            this.btnZoomS.Location = new System.Drawing.Point(177, 31);
            this.btnZoomS.Name = "btnZoomS";
            this.btnZoomS.Size = new System.Drawing.Size(47, 42);
            this.btnZoomS.TabIndex = 1;
            this.btnZoomS.Text = "-";
            this.btnZoomS.UseVisualStyleBackColor = true;
            this.btnZoomS.Click += new System.EventHandler(this.btnZoomS_Click);
            // 
            // btnRitateL
            // 
            this.btnRitateL.Location = new System.Drawing.Point(11, 31);
            this.btnRitateL.Name = "btnRitateL";
            this.btnRitateL.Size = new System.Drawing.Size(52, 42);
            this.btnRitateL.TabIndex = 1;
            this.btnRitateL.Text = "Left";
            this.btnRitateL.UseVisualStyleBackColor = true;
            this.btnRitateL.Click += new System.EventHandler(this.btnRitateL_Click);
            // 
            // btnRotateR
            // 
            this.btnRotateR.Location = new System.Drawing.Point(69, 31);
            this.btnRotateR.Name = "btnRotateR";
            this.btnRotateR.Size = new System.Drawing.Size(50, 42);
            this.btnRotateR.TabIndex = 1;
            this.btnRotateR.Text = "Right";
            this.btnRotateR.UseVisualStyleBackColor = true;
            this.btnRotateR.Click += new System.EventHandler(this.btnRotateR_Click);
            // 
            // lstbxSquares
            // 
            this.lstbxSquares.FormattingEnabled = true;
            this.lstbxSquares.Location = new System.Drawing.Point(732, 124);
            this.lstbxSquares.Name = "lstbxSquares";
            this.lstbxSquares.Size = new System.Drawing.Size(120, 95);
            this.lstbxSquares.TabIndex = 2;
            this.lstbxSquares.SelectedIndexChanged += new System.EventHandler(this.lstbxSquares_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.glControl1);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 438);
            this.panel1.TabIndex = 3;
            // 
            // chckbxPaintMode
            // 
            this.chckbxPaintMode.AutoSize = true;
            this.chckbxPaintMode.Location = new System.Drawing.Point(163, 7);
            this.chckbxPaintMode.Name = "chckbxPaintMode";
            this.chckbxPaintMode.Size = new System.Drawing.Size(87, 17);
            this.chckbxPaintMode.TabIndex = 4;
            this.chckbxPaintMode.Text = "Rasterization";
            this.chckbxPaintMode.UseVisualStyleBackColor = true;
            this.chckbxPaintMode.CheckedChanged += new System.EventHandler(this.chckbxPaintMode_CheckedChanged);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(858, 245);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(95, 40);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // chckbxMoveMode
            // 
            this.chckbxMoveMode.AutoSize = true;
            this.chckbxMoveMode.Location = new System.Drawing.Point(328, 7);
            this.chckbxMoveMode.Name = "chckbxMoveMode";
            this.chckbxMoveMode.Size = new System.Drawing.Size(132, 17);
            this.chckbxMoveMode.TabIndex = 6;
            this.chckbxMoveMode.Text = "Mode of transportation";
            this.chckbxMoveMode.UseVisualStyleBackColor = true;
            this.chckbxMoveMode.CheckedChanged += new System.EventHandler(this.chckbxMoveMode_CheckedChanged);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(857, 157);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(96, 38);
            this.btndelete.TabIndex = 7;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // chkbxFill
            // 
            this.chkbxFill.AutoSize = true;
            this.chkbxFill.Location = new System.Drawing.Point(858, 124);
            this.chkbxFill.Name = "chkbxFill";
            this.chkbxFill.Size = new System.Drawing.Size(75, 17);
            this.chkbxFill.TabIndex = 6;
            this.chkbxFill.Text = "Fill shapes";
            this.chkbxFill.UseVisualStyleBackColor = true;
            this.chkbxFill.CheckedChanged += new System.EventHandler(this.chckbxMoveMode_CheckedChanged);
            // 
            // chckbxColorOr
            // 
            this.chckbxColorOr.AutoSize = true;
            this.chckbxColorOr.Location = new System.Drawing.Point(732, 245);
            this.chckbxColorOr.Name = "chckbxColorOr";
            this.chckbxColorOr.Size = new System.Drawing.Size(42, 17);
            this.chckbxColorOr.TabIndex = 6;
            this.chckbxColorOr.Text = "OR";
            this.chckbxColorOr.UseVisualStyleBackColor = true;
            this.chckbxColorOr.CheckedChanged += new System.EventHandler(this.chckbxColorOr_CheckedChanged);
            // 
            // chckbxColorNOr
            // 
            this.chckbxColorNOr.AutoSize = true;
            this.chckbxColorNOr.Location = new System.Drawing.Point(732, 268);
            this.chckbxColorNOr.Name = "chckbxColorNOr";
            this.chckbxColorNOr.Size = new System.Drawing.Size(68, 17);
            this.chckbxColorNOr.TabIndex = 6;
            this.chckbxColorNOr.Text = "NOT OR";
            this.chckbxColorNOr.UseVisualStyleBackColor = true;
            this.chckbxColorNOr.CheckedChanged += new System.EventHandler(this.chckbxColorNOr_CheckedChanged);
            // 
            // btnTex
            // 
            this.btnTex.Location = new System.Drawing.Point(730, 318);
            this.btnTex.Name = "btnTex";
            this.btnTex.Size = new System.Drawing.Size(95, 38);
            this.btnTex.TabIndex = 8;
            this.btnTex.Text = "Open";
            this.btnTex.UseVisualStyleBackColor = true;
            this.btnTex.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rotation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Scaling:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(729, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Set of shapes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(729, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Color mixing:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(855, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Set color:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(729, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Download texture:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRotateR);
            this.groupBox1.Controls.Add(this.btnZoomL);
            this.groupBox1.Controls.Add(this.btnZoomS);
            this.groupBox1.Controls.Add(this.btnRitateL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(732, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 80);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTex);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.chckbxColorNOr);
            this.Controls.Add(this.chckbxColorOr);
            this.Controls.Add(this.chkbxFill);
            this.Controls.Add(this.chckbxMoveMode);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.chckbxPaintMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstbxSquares);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnZoomL;
        private System.Windows.Forms.Button btnZoomS;
        private System.Windows.Forms.Button btnRitateL;
        private System.Windows.Forms.Button btnRotateR;
        private System.Windows.Forms.ListBox lstbxSquares;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chckbxPaintMode;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.CheckBox chckbxMoveMode;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.CheckBox chkbxFill;
        private System.Windows.Forms.CheckBox chckbxColorOr;
        private System.Windows.Forms.CheckBox chckbxColorNOr;
        private System.Windows.Forms.Button btnTex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

