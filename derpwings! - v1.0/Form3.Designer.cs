﻿namespace derpwings____v1._0
{
    partial class Form3
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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bColoresH = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bColoresH)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(16, 637);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(362, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Value = 20;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // canvasPanel
            // 
            this.canvasPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.canvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasPanel.Controls.Add(this.hScrollBar1);
            this.canvasPanel.Controls.Add(this.tSize);
            this.canvasPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canvasPanel.ForeColor = System.Drawing.Color.Transparent;
            this.canvasPanel.Location = new System.Drawing.Point(48, 12);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(1310, 709);
            this.canvasPanel.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::derpwings____v1._0.Properties.Resources.erasersetting;
            this.pictureBox2.Location = new System.Drawing.Point(2, 133);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::derpwings____v1._0.Properties.Resources.pencilsettings;
            this.pictureBox1.Location = new System.Drawing.Point(2, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.brushDClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "save \r\n:333";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tSize
            // 
            this.tSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tSize.AutoSize = true;
            this.tSize.BackColor = System.Drawing.Color.Transparent;
            this.tSize.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSize.ForeColor = System.Drawing.Color.Gray;
            this.tSize.Location = new System.Drawing.Point(28, 614);
            this.tSize.Name = "tSize";
            this.tSize.Size = new System.Drawing.Size(97, 23);
            this.tSize.TabIndex = 5;
            this.tSize.Text = "Size: 10 px.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 62);
            this.label1.TabIndex = 14;
            this.label1.Text = "clear\r\ncan\r\nvas\r\n>:(\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bColoresH
            // 
            this.bColoresH.BackColor = System.Drawing.Color.Red;
            this.bColoresH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bColoresH.Location = new System.Drawing.Point(2, 179);
            this.bColoresH.Name = "bColoresH";
            this.bColoresH.Size = new System.Drawing.Size(40, 40);
            this.bColoresH.TabIndex = 16;
            this.bColoresH.TabStop = false;
            this.bColoresH.Click += new System.EventHandler(this.bColoresH_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 54);
            this.label3.TabIndex = 17;
            this.label3.Text = "pre\r\nview\r\nbox\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::derpwings____v1._0.Properties.Resources.bgdarkmode;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bColoresH);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.canvasPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.Text = "Derpwing Process!";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Resize += new System.EventHandler(this.Form3_Resize);
            this.canvasPanel.ResumeLayout(false);
            this.canvasPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bColoresH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Label tSize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox bColoresH;
        private System.Windows.Forms.Label label3;
    }
}