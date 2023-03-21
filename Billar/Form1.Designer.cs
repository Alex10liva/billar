namespace Billar
{
    partial class Billar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.PCT_Canvas2 = new System.Windows.Forms.PictureBox();
            this.PCT_Canvas1 = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.scoreLBL = new System.Windows.Forms.Label();
            this.sLBL = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panelBackground.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.Transparent;
            this.panelBackground.Controls.Add(this.panelCenter);
            this.panelBackground.Controls.Add(this.panelBottom);
            this.panelBackground.Controls.Add(this.panelTop);
            this.panelBackground.Controls.Add(this.panelRight);
            this.panelBackground.Controls.Add(this.panelLeft);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1582, 853);
            this.panelBackground.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.PCT_Canvas2);
            this.panelCenter.Controls.Add(this.PCT_Canvas1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(80, 50);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1422, 753);
            this.panelCenter.TabIndex = 4;
            this.panelCenter.SizeChanged += new System.EventHandler(this.panelCenter_SizeChanged);
            // 
            // PCT_Canvas2
            // 
            this.PCT_Canvas2.BackColor = System.Drawing.Color.Transparent;
            this.PCT_Canvas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_Canvas2.Location = new System.Drawing.Point(0, 0);
            this.PCT_Canvas2.Name = "PCT_Canvas2";
            this.PCT_Canvas2.Size = new System.Drawing.Size(1422, 753);
            this.PCT_Canvas2.TabIndex = 1;
            this.PCT_Canvas2.TabStop = false;
            this.PCT_Canvas2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseClick);
            this.PCT_Canvas2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseDown);
            this.PCT_Canvas2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseMove);
            this.PCT_Canvas2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseUp);
            // 
            // PCT_Canvas1
            // 
            this.PCT_Canvas1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PCT_Canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_Canvas1.Location = new System.Drawing.Point(0, 0);
            this.PCT_Canvas1.Name = "PCT_Canvas1";
            this.PCT_Canvas1.Size = new System.Drawing.Size(1422, 753);
            this.PCT_Canvas1.TabIndex = 0;
            this.PCT_Canvas1.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(80, 803);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1422, 50);
            this.panelBottom.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.scoreLBL);
            this.panelTop.Controls.Add(this.sLBL);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(80, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1422, 50);
            this.panelTop.TabIndex = 2;
            // 
            // scoreLBL
            // 
            this.scoreLBL.AutoSize = true;
            this.scoreLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLBL.ForeColor = System.Drawing.SystemColors.Control;
            this.scoreLBL.Location = new System.Drawing.Point(713, 13);
            this.scoreLBL.Name = "scoreLBL";
            this.scoreLBL.Size = new System.Drawing.Size(24, 28);
            this.scoreLBL.TabIndex = 1;
            this.scoreLBL.Text = "0";
            // 
            // sLBL
            // 
            this.sLBL.AutoSize = true;
            this.sLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sLBL.ForeColor = System.Drawing.SystemColors.Control;
            this.sLBL.Location = new System.Drawing.Point(648, 13);
            this.sLBL.Name = "sLBL";
            this.sLBL.Size = new System.Drawing.Size(64, 28);
            this.sLBL.TabIndex = 0;
            this.sLBL.Text = "Score";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1502, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(80, 853);
            this.panelRight.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(80, 853);
            this.panelLeft.TabIndex = 0;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Billar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Billar.Properties.Resources.wooden_floor;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panelBackground);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MinimumSize = new System.Drawing.Size(1277, 814);
            this.Name = "Billar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Billar_Load);
            this.panelBackground.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelBackground;
        private Panel panelCenter;
        private PictureBox PCT_Canvas1;
        private Panel panelBottom;
        private Panel panelTop;
        private Panel panelRight;
        private Panel panelLeft;
        private System.Windows.Forms.Timer Timer;
        private PictureBox PCT_Canvas2;
        private Label sLBL;
        private Label scoreLBL;
    }
}