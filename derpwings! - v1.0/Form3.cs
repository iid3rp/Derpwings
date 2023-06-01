using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derpwings____v1._0
{
    public partial class Form3 : Form
    {
        private static PictureBox pbCtrl, dpPen = new PictureBox();//canvas
        private Point prevPos;
        private Point curPos; // the positions of your mouse to paint
        private Bitmap bitmap; //bitmap of the pen
        private TextureBrush brush; //texture brush of the pen
        private Pen pen; //pen used to paint on the canvas
        public Form3(int hs1, int hs2)
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            pbCtrl = CreatePictureBox(hs1, hs2);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 5, 35);
            this.Controls.Add(pbCtrl);
            PictureBox pictureBox4 = new PictureBox();
            
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront();
            //create a picturebox to resemble the pen itself
            PictureBox dpPen = new PictureBox();
            // Create a new Bitmap with the same size as the PictureBox
            bitmap = new Bitmap(dpPen.Width, dpPen.Height, PixelFormat.Format32bppArgb);
            // Set the background of the Bitmap to the same color as the PictureBox
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(pbCtrl.BackColor);
            }
            // Create a new TextureBrush with the Bitmap
            brush = new TextureBrush(bitmap);
            // Create a new Pen with the TextureBrush
            pen = new Pen(brush, 10f);

            // Modify the Pen properties to make the brush smooth with rounded corners and ends
            pen.LineJoin = LineJoin.Round;
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront();
        }
        private PictureBox CreatePictureBox(int hs1, int hs2)
        {
            Bitmap bmpImage = new Bitmap(hs1, hs2);
            int Width = hs1, Height = hs2;
            int newWidth = 0, newHeight = 0;
            if (Width > Height)
            {
                newWidth = 1000;
                newHeight = newWidth * (Height / newWidth);
                
            }
            else if (Width < Height)
            {
                newHeight = 563;
                newWidth = 563 * (Width / newHeight);
                
            }
            pbCtrl.MinimumSize = new Size(1000, 563);
            pbCtrl.MaximumSize = pbCtrl.MinimumSize;
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

            return pbCtrl;
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
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            prevPos = e.Location;
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            // Set the current mouse position
            curPos = e.Location;

            // Draw a line from the previous mouse position to the current position
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(pen, prevPos, curPos);
            }

            // Update the previous mouse position to the current position
            prevPos = curPos;

        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            prevPos = e.Location;
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, Point.Empty);
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel3.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
       
    }

}

