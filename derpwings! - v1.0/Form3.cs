using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            cUpdate();
            tRed.Text = hScrollBar3.Value.ToString();

        }
        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate();
            tGreen.Text = hScrollBar4.Value.ToString();
        }
        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate();
            tBlue.Text = hScrollBar5.Value.ToString();
        }
        private void hScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            cUpdate();
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

}

}

