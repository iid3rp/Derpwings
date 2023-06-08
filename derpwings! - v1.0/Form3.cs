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

        private PictureBox pbCtrl;//canvas and the brushp

        private Point lastPoint; //pen used to paint on the canvas
        private Color bColores = (Color.FromArgb(255, 255, 0, 0));
        private float brushSize = 10f;

        //bitmaps
        private Bitmap bmpImage; // the eraser of the canvas
        private Bitmap white; //white bg bitmap

        private bool isDrawing = false, isEraser = false, isEyedropper = false;


        //brushes!!!
        private SolidBrush sBrush; //the solid brush used to draw
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
        private void PictureBoxMouseDown(object sender, MouseEventArgs e) //when i hold the mouse
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                lastPoint = e.Location;
                isDrawing = true;
            }
            if (e.Button == MouseButtons.Right)
            {
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
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillEllipse(sBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                        g.DrawLine(new Pen(sBrush, brushSize), lastPoint, e.Location);
                    }
                lastPoint = e.Location;
                pbCtrl.Invalidate(); //pbReview.Invalidate();
            }
            if (isEraser)
            {
                // Only draw when the left mouse button is down
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    using (Graphics g = Graphics.FromImage(bmpImage))
                    {
                        int halfSize = (int) brushSize / 2;

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
                                    int distance = (int) Math.Sqrt(Math.Pow(x - e.X, 2) + Math.Pow(y - e.Y, 2));
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
            white = new Bitmap(pbCtrl.Width, pbCtrl.Height, PixelFormat.Format32bppRgb);
            using(Graphics g = Graphics.FromImage(white))
            {
                g.DrawImage(bmpImage, 0, 0);
            }
            savingDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isEraser = false; bUpdate();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            
            pbCtrl.BringToFront(); //already set
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            
            pbCtrl.BringToFront(); //already set

        }
        private void label1_Click(object sender, EventArgs e)
        {
            pbCtrl.Image = new Bitmap(pbCtrl.Width, pbCtrl.Height);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            white = new Bitmap(pbCtrl.Width, pbCtrl.Height, PixelFormat.Format32bppRgb);
            using (Graphics g = Graphics.FromImage(white))
            {
                g.Clear(Color.White);
            }
            using (Graphics g = Graphics.FromImage(white))
            {
                g.DrawImage(bmpImage, 0, 0);
            }
           
            savingDialog();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sBrush = new SolidBrush(Color.Transparent);
            isEraser = true;
        }

        private void bColoresH_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            DialogResult r = Form4.ShowDialog();

            if (r == DialogResult.OK) 
            {
                bColores = Form4.bColoresPicker();
                bUpdate();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            isEyedropper = true;
        }

        private void savingDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG image files (*.png)|*.png";
            saveDialog.FileName = "painted_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                white.Save(saveDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Image saved as " + saveDialog.FileName);
            }
        }
    }

}

