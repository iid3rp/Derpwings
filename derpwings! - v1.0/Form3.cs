﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derpwings____v1._0
{
    public partial class Form3 : Form
    {
        private PictureBox pbCtrl;
        static Bitmap brushImage = Properties.Resources.pain;
        private TextureBrush textureBrush = new TextureBrush(brushImage);
        private Point _previousPoint;



        public Form3(int hs1, int hs2)
        {
            InitializeComponent();
            int cWidth = hs1, cHeight = hs2;
            pbCtrl = new PictureBox();
            CreatePictureBox(pbCtrl);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 5, 35);
            this.Controls.Add(pbCtrl);
            PictureBox pictureBox4 = new PictureBox();

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront();
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront();
        }
        private void CreatePictureBox(PictureBox pbCtrl)
        {
            Bitmap bmpImage = new Bitmap(1920, 1080);
            pbCtrl.MinimumSize = new Size(1000, 600);
            pbCtrl.MaximumSize = pbCtrl.MinimumSize;
            pbCtrl.SizeModeChanged += PbCtrl_SizeModeChanged;
            pbCtrl.BackColor = Color.White;
            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                g.Clear(Color.White);
            }
            pbCtrl.Image = bmpImage;
            pbCtrl.Paint += new PaintEventHandler(PictureBoxPaint);
            pbCtrl.MouseDown += new MouseEventHandler(PictureBoxMouseDown);
            pbCtrl.MouseMove += new MouseEventHandler(PictureBoxMouseMove);
            pbCtrl.MouseUp += new MouseEventHandler(PictureBoxMouseUp);

            
        }
        
        private void PbCtrl_SizeModeChanged(object sender, EventArgs e)
        {
            // Get the original size of the image
            int originalWidth = ((PictureBox)sender).Image.Width;
            int originalHeight = ((PictureBox)sender).Image.Height;

            // Calculate the new size based on the aspect ratio of the image
            int newWidth, newHeight;
            if (originalWidth > originalHeight)
            {
                newWidth = 1000;
                newHeight = (int)((double)originalHeight / originalWidth * 1000);
            }
            else
            {
                newWidth = (int)((double)originalWidth / originalHeight * 600);
                newHeight = 600;
            }

            // Set the size of the PictureBox control
            ((PictureBox)sender).Size = new Size(newWidth, newHeight);
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tSize.Text = hScrollBar1.Value.ToString() + " px.";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel colorSection = new Panel();
            colorSection.Show();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate(); bUpdate();
            tRed.Text = hScrollBar3.Value.ToString();

        }
        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate(); bUpdate();
            tGreen.Text = hScrollBar4.Value.ToString();
        }
        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate(); bUpdate();
            tBlue.Text = hScrollBar5.Value.ToString();
        }
        private void hScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate(); bUpdate();
            tAlpha.Text = hScrollBar6.Value.ToString() + '%';
        }

        private void cUpdate()
        {
            int cRed = hScrollBar3.Value;
            int cGreen = hScrollBar4.Value;
            int cBlue = hScrollBar5.Value;
            int cAlpha = hScrollBar6.Value;
            Color colores = (Color.FromArgb(cRed, cGreen, cBlue));
            colorbase.BackColor = colores;
        }
        private void bUpdate()
        {
            int bRed = hScrollBar3.Value;
            int bGreen = hScrollBar4.Value;
            int bBlue = hScrollBar5.Value;
            int bAlpha = hScrollBar6.Value;
            Color bColores = (Color.FromArgb(bRed, bGreen, bBlue));
            Graphics g = Graphics.FromImage(brushImage);
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = pbCtrl.CreateGraphics())
                {
                    _previousPoint = e.Location;
                } 
            }// ...
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = pbCtrl.CreateGraphics())
                {
                    g.DrawLine(new Pen(textureBrush, hScrollBar1.Value), _previousPoint, e.Location);
                }
                _previousPoint = e.Location;
            }// ...
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            // ...
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string fileName = "painted_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            using (Bitmap bmp = new Bitmap(pbCtrl.Width, pbCtrl.Height))
            {
                pbCtrl.DrawToBitmap(bmp, pbCtrl.ClientRectangle);
                bmp.Save(fileName, ImageFormat.Png);
            }
            MessageBox.Show("Image saved as " + fileName);
        }
    }

}

