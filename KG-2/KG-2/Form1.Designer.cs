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
            this.panel1.SuspendLayout();
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
            this.btnZoomL.Location = new System.Drawing.Point(729, 43);
            this.btnZoomL.Name = "btnZoomL";
            this.btnZoomL.Size = new System.Drawing.Size(29, 23);
            this.btnZoomL.TabIndex = 1;
            this.btnZoomL.Text = "+";
            this.btnZoomL.UseVisualStyleBackColor = true;
            this.btnZoomL.Click += new System.EventHandler(this.btnZoomL_Click);
            // 
            // btnZoomS
            // 
            this.btnZoomS.Location = new System.Drawing.Point(764, 43);
            this.btnZoomS.Name = "btnZoomS";
            this.btnZoomS.Size = new System.Drawing.Size(29, 23);
            this.btnZoomS.TabIndex = 1;
            this.btnZoomS.Text = "-";
            this.btnZoomS.UseVisualStyleBackColor = true;
            this.btnZoomS.Click += new System.EventHandler(this.btnZoomS_Click);
            // 
            // btnRitateL
            // 
            this.btnRitateL.Location = new System.Drawing.Point(729, 72);
            this.btnRitateL.Name = "btnRitateL";
            this.btnRitateL.Size = new System.Drawing.Size(29, 23);
            this.btnRitateL.TabIndex = 1;
            this.btnRitateL.Text = "влево";
            this.btnRitateL.UseVisualStyleBackColor = true;
            this.btnRitateL.Click += new System.EventHandler(this.btnRitateL_Click);
            // 
            // btnRotateR
            // 
            this.btnRotateR.Location = new System.Drawing.Point(764, 72);
            this.btnRotateR.Name = "btnRotateR";
            this.btnRotateR.Size = new System.Drawing.Size(29, 23);
            this.btnRotateR.TabIndex = 1;
            this.btnRotateR.Text = "вправо";
            this.btnRotateR.UseVisualStyleBackColor = true;
            this.btnRotateR.Click += new System.EventHandler(this.btnRotateR_Click);
            // 
            // lstbxSquares
            // 
            this.lstbxSquares.FormattingEnabled = true;
            this.lstbxSquares.Location = new System.Drawing.Point(729, 124);
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
            this.chckbxPaintMode.Location = new System.Drawing.Point(18, 12);
            this.chckbxPaintMode.Name = "chckbxPaintMode";
            this.chckbxPaintMode.Size = new System.Drawing.Size(159, 17);
            this.chckbxPaintMode.TabIndex = 4;
            this.chckbxPaintMode.Text = "Растеризованные фигуры";
            this.chckbxPaintMode.UseVisualStyleBackColor = true;
            this.chckbxPaintMode.CheckedChanged += new System.EventHandler(this.chckbxPaintMode_CheckedChanged);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(741, 327);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(95, 23);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "выбрать цвет";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // chckbxMoveMode
            // 
            this.chckbxMoveMode.AutoSize = true;
            this.chckbxMoveMode.Location = new System.Drawing.Point(183, 12);
            this.chckbxMoveMode.Name = "chckbxMoveMode";
            this.chckbxMoveMode.Size = new System.Drawing.Size(138, 17);
            this.chckbxMoveMode.TabIndex = 6;
            this.chckbxMoveMode.Text = "Режим передвижения";
            this.chckbxMoveMode.UseVisualStyleBackColor = true;
            this.chckbxMoveMode.CheckedChanged += new System.EventHandler(this.chckbxMoveMode_CheckedChanged);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(741, 286);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(96, 35);
            this.btndelete.TabIndex = 7;
            this.btndelete.Text = "удалить фигуру";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // chkbxFill
            // 
            this.chkbxFill.AutoSize = true;
            this.chkbxFill.Location = new System.Drawing.Point(730, 101);
            this.chkbxFill.Name = "chkbxFill";
            this.chkbxFill.Size = new System.Drawing.Size(110, 17);
            this.chkbxFill.TabIndex = 6;
            this.chkbxFill.Text = "Заливка фигуры";
            this.chkbxFill.UseVisualStyleBackColor = true;
            this.chkbxFill.CheckedChanged += new System.EventHandler(this.chckbxMoveMode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 486);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.chkbxFill);
            this.Controls.Add(this.chckbxMoveMode);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.chckbxPaintMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstbxSquares);
            this.Controls.Add(this.btnRotateR);
            this.Controls.Add(this.btnRitateL);
            this.Controls.Add(this.btnZoomS);
            this.Controls.Add(this.btnZoomL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

