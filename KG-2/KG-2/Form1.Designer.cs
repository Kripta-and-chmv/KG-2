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
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(39, 24);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(668, 431);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseClick);
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
            this.lstbxSquares.Location = new System.Drawing.Point(729, 149);
            this.lstbxSquares.Name = "lstbxSquares";
            this.lstbxSquares.Size = new System.Drawing.Size(120, 95);
            this.lstbxSquares.TabIndex = 2;
            this.lstbxSquares.SelectedIndexChanged += new System.EventHandler(this.lstbxSquares_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 486);
            this.Controls.Add(this.lstbxSquares);
            this.Controls.Add(this.btnRotateR);
            this.Controls.Add(this.btnRitateL);
            this.Controls.Add(this.btnZoomS);
            this.Controls.Add(this.btnZoomL);
            this.Controls.Add(this.glControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnZoomL;
        private System.Windows.Forms.Button btnZoomS;
        private System.Windows.Forms.Button btnRitateL;
        private System.Windows.Forms.Button btnRotateR;
        private System.Windows.Forms.ListBox lstbxSquares;
    }
}

