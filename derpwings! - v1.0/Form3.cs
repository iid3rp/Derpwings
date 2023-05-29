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
        private int cWidth, cHeight;
        public Form3()
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            CreatePictureBox(pbCtrl);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 2, 35);
            this.Controls.Add(pbCtrl); 
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
            
            pbCtrl.MinimumSize = new Size(1000, 600);
            pbCtrl.MaximumSize = pbCtrl.MinimumSize;
            pbCtrl.SizeModeChanged += PbCtrl_SizeModeChanged;
            pbCtrl.BackColor = Color.White;
            Bitmap bmpImage = new Bitmap(cWidth, cHeight);
            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                g.Clear(Color.White);
            }
            pbCtrl.Image = bmpImage;
        }

        // Event handler for the SizeModeChanged event of the PictureBox control
        private void PbCtrl_SizeModeChanged(object sender, EventArgs e)
        {
            // Get the original size of the image
            int originalWidth = ((PictureBox)sender).Image.Width;
            int originalHeight = ((PictureBox)sender).Image.Height;

            // Calculate the new size based on the aspect ratio of the image
            int newWidth;
            int newHeight;
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

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            tOpacity.Text = hScrollBar2.Value.ToString() + "%";
        }
    }

}

