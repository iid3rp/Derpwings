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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derpwings____v1._0
{
    public partial class Form3 : Form
    {

        private PictureBox pbCtrl;//canvas and the brushp

        private Point location;
        private Point lastPoint; //pen used to paint on the canvas
        private Color bColores = (Color.FromArgb(255, 255, 0, 0));
        private bool isFill = false;
        //bitmaps
        private Bitmap bmpImage; // the eraser of the canvas

        private bool isDrawing = false, isEraser = false;


        //brushes!!!
        private SolidBrush sBrush; //the solid brush used to draw
        private bool
            Smoothing = true, Dline = true,
            Particle = false, Triangle = false,
            Ellipse = true, Rectangle = false;

        private float brushSize = 10f;
        private int stability = 0;
        public Form3(int hs1, int hs2) //initialization for pbCtrl
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            pbCtrl = CreatePictureBox(hs1, hs2);
            pbCtrl.Location = new Point(0, 0);
            canvasPanel.Controls.Add(pbCtrl);
            this.Controls.Add(canvasPanel);

            bUpdate();
        }
        private PictureBox CreatePictureBox(int hs1, int hs2) //creation of pbCtrl
        { 
            //this is for the canvas
            bmpImage = new Bitmap(hs1, hs2, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                g.Clear(Color.Transparent);
            }
            pbCtrl.MinimumSize = new Size(hs1, hs2);
            pbCtrl.MaximumSize = pbCtrl.MinimumSize;
            pbCtrl.BackColor = Color.Transparent;
            pbCtrl.Image = bmpImage;
            pbCtrl.MouseClick += new MouseEventHandler(PictureBoxClick);
            pbCtrl.MouseDown += new MouseEventHandler(PictureBoxMouseDown);
            pbCtrl.MouseMove += new MouseEventHandler(PictureBoxMouseMove);
            pbCtrl.MouseUp += new MouseEventHandler(PictureBoxMouseUp);

            return pbCtrl;
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e) //brush size
        {
            tSize.Text = "Size: " + hScrollBar1.Value.ToString() + " px.";
            brushSize = hScrollBar1.Value;
            bUpdate();
        }
        private void bUpdate() //brush color
        {
            bColoresH.BackColor = bColores;
            sBrush = new SolidBrush(color: bColores);
        }
        
        //CANVAS RELATED!!!!!
        private void PictureBoxClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isFill)
                {
                    location = e.Location;
                    Color targetColor = ((Bitmap)pbCtrl.Image).GetPixel(location.X, location.Y);
                    Color replacementColor = bColores;
                    FillBucket(location, targetColor, replacementColor);
                    isFill = false;
                }
                else
                {
                    using (Graphics g = Graphics.FromImage(pbCtrl.Image))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillEllipse(sBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    pbCtrl.Invalidate();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                bColores = bmpImage.GetPixel(e.X, e.Y); bUpdate();
            }
        }
        private void PictureBoxMouseDown(object sender, MouseEventArgs e) //when i hold the mouse
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                lastPoint = e.Location;
                isDrawing = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                bColores = bmpImage.GetPixel(e.X, e.Y); bUpdate();
                isEraser = true;
            }
        }
        //when i hold and move the mouse
        private void PictureBoxMouseMove(object sender, MouseEventArgs e) 
        {
            if (isDrawing)
            {
                if (e.Button == MouseButtons.Left)
                    using (Graphics g = Graphics.FromImage(pbCtrl.Image))
                    {
                        if (Smoothing)
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                        if (Ellipse)
                            g.FillEllipse(sBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                        if (Rectangle)
                            g.FillRectangle(sBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                        if (Dline)
                            g.DrawLine(new Pen(sBrush, brushSize), lastPoint, e.Location);                   
                    }
                lastPoint = e.Location;
                pbCtrl.Invalidate();
            }
            if (isEraser)
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    // Only draw when the left mouse button is down
                    using (Graphics g = Graphics.FromImage(bmpImage))
                    {
                        int halfSize = (int)brushSize / 2;
                        // Define a rectangle that represents the bounds of the bitmap
                        Rectangle bitmapBounds = new Rectangle(0, 0, bmpImage.Width, bmpImage.Height);

                        // Calculate the rectangle of pixels to erase based on the eraser brush position and size
                        Rectangle eraseBounds = new Rectangle(
                            Math.Max(0, e.X - halfSize),
                            Math.Max(0, e.Y - halfSize),
                            Math.Min(halfSize * 2, bmpImage.Width - e.X + halfSize),
                            Math.Min(halfSize * 2, bmpImage.Height - e.Y + halfSize)
                        );
                        // Only set the pixels to transparent if the eraser brush is not completely outside the bounds of the bitmap
                        if (bitmapBounds.IntersectsWith(eraseBounds))
                        {
                            for (int x = eraseBounds.Left; x <= eraseBounds.Right; x++)
                            {
                                for (int y = eraseBounds.Top; y <= eraseBounds.Bottom; y++)
                                {
                                    int distance = (int)Math.Sqrt(Math.Pow(x - e.X, 2) + Math.Pow(y - e.Y, 2));
                                    if (distance <= halfSize)
                                    {
                                        bmpImage.SetPixel(x, y, Color.Transparent);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void PictureBoxMouseUp(object sender, MouseEventArgs e) //wehn i release the mouse
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                isDrawing = false;
                isEraser = false;
            }
            if (e.Button == MouseButtons.Right)
                isEraser = false;
        }

        private void label2_Click(object sender, EventArgs e) //saving the image
        {
            Bitmap savingImage = bmpImage;
            Form save = new save(savingImage);
            DialogResult sv = save.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isEraser = false; bUpdate();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        private void Form3_Resize(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            isFill = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pbCtrl.Image = new Bitmap(pbCtrl.Width, pbCtrl.Height);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void brushDClick(object sender, MouseEventArgs e)
        {
            bool
            bSmoothing = Smoothing, bDline = Dline,
            bParticle = Particle, bTriangle = Triangle,
            bEllipse = Ellipse, bRectangle = Rectangle;
            int bStability = stability;
            float bBrushSize = brushSize;
            Form5 Form5 = new Form5(bSmoothing, bDline, bParticle,
                bStability, bBrushSize, bTriangle, 
                 bEllipse, bRectangle);

             DialogResult b = Form5.ShowDialog();
            if (b == DialogResult.OK)
            {
                Smoothing = Form5.bSmoothing();
                Dline = Form5.bDLine();
                Particle = Form5.bParticle();
                Ellipse = Form5.bEllipse();
                Rectangle = Form5.bRectangle();
                Triangle = Form5.bTriangle();
                stability = Form5.bStability();
                brushSize = Form5.bBrushSize();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sBrush = new SolidBrush(Color.Transparent);
            isEraser = true;
        }

        private void bColoresH_Click(object sender, EventArgs e)
        {
            Color Form4bColores = bColores;
            Form4 Form4 = new Form4(Form4bColores);
            DialogResult r = Form4.ShowDialog();

            if (r == DialogResult.OK) 
            {
                bColores = Form4.bColoresPicker();
                bUpdate();
            }
        }
        private void FillBucket(Point location, Color targetColor, Color replacementColor)
        {
            // Create a Bitmap object from the bmpImage
            Bitmap bmp = new Bitmap(bmpImage);

            // Determine the number of parts to split the image into
            int numPartsX = (int)Math.Ceiling((double)bmp.Width / pbCtrl.Width);
            int numPartsY = (int)Math.Ceiling((double)bmp.Height / pbCtrl.Height);

            // Loop through each part of the image and fill it
            for (int i = 0; i < numPartsX; i++)
            {
                for (int j = 0; j < numPartsY; j++)
                {
                    // Define the bounds of the current part in the image
                    int startX = i * pbCtrl.Width;
                    int startY = j * pbCtrl.Height;
                    int width = Math.Min(pbCtrl.Width, bmp.Width - startX);
                    int height = Math.Min(pbCtrl.Height, bmp.Height - startY);
                    Rectangle partRect = new Rectangle(startX, startY, width, height);

                    // Clone the current part of the image
                    Bitmap part = bmp.Clone(partRect, bmp.PixelFormat);

                    // Fill the current part of the image
                    FillPixel(part, location, targetColor, replacementColor);

                    // Draw the modified part back into the overall image
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(part, new Point(startX, startY));
                    }
                }
            }

            // Update the pbCtrl Image with the modified Bitmap
            pbCtrl.Image = new Bitmap(bmp);
            bmp.Dispose();
        }

        private void FillPixel(Bitmap bmp, Point location, Color targetColor, Color replacementColor)
        {
            // Get the color of the pixel at the specified location
            Color pixelColor = bmp.GetPixel(location.X, location.Y);

            // Check if the pixel color matches the target color
            if (pixelColor.ToArgb() == targetColor.ToArgb())
            {
                // Set the pixel color to the replacement color
                bmp.SetPixel(location.X, location.Y, replacementColor);

                // Check neighboring pixels for the same color
                if (location.X > 0) FillPixel(bmp, new Point(location.X - 1, location.Y), targetColor, replacementColor); // Check left neighbor
                if (location.X < bmp.Width - 1) FillPixel(bmp, new Point(location.X + 1, location.Y), targetColor, replacementColor); // Check right neighbor
                if (location.Y > 0) FillPixel(bmp, new Point(location.X, location.Y - 1), targetColor, replacementColor); // Check top neighbor
                if (location.Y < bmp.Height - 1) FillPixel(bmp, new Point(location.X, location.Y + 1), targetColor, replacementColor); // Check bottom neighbor
            }
        }
    }

}

