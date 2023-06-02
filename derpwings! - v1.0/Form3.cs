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
        private Point prevPoint; //pen used to paint on the canvas
        private Color bColores = (Color.FromArgb(255, 0, 0));
        private float brushSize = 10f;
        private SolidBrush sBrush; //the solid brush used to draw
        private List<PointF> points = new List<PointF>();//point list
        private GraphicsPath path = new GraphicsPath(); //the path
        private Bitmap bmpImage;
        public Form3(int hs1, int hs2)
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            pbCtrl = CreatePictureBox(hs1, hs2);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 5, 35);
            this.Controls.Add(pbCtrl);
            bUpdate();
        }
        private void brushBoxPaint(object sender, PaintEventArgs e)
        {
        }
        private PictureBox CreatePictureBox(int hs1, int hs2)
        {
            bmpImage = new Bitmap(hs1, hs2);
            int Width = hs1, Height = hs2;
            int newWidth = hs1, newHeight = hs2;
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
        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            

        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tSize.Text = hScrollBar1.Value.ToString() + " px.";
            brushSize = hScrollBar1.Value;
            bUpdate();
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
            sBrush = new SolidBrush(color: bColores);
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (bmpImage == null)
            {
                bmpImage = new Bitmap(Width, Height);
            }

            points.Clear();
            points.Add(e.Location);
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            points.Add(e.Location);

            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                using (Brush brush = new SolidBrush(bColores))
                {
                    float halfBrushSize = brushSize / 2f;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        g.FillEllipse(brush, points[i].X - halfBrushSize, points[i].Y - halfBrushSize, brushSize, brushSize);
                        g.DrawLine(new Pen(brush, brushSize), points[i], points[i + 1]);
                    }
                }
            }
            pbCtrl.Invalidate(new Rectangle((int)points[points.Count - 2].X, (int)points[points.Count - 2].Y, (int)brushSize + 1, (int)brushSize + 1));
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (bmpImage != null)
            {
                using (Graphics g = Graphics.FromImage(bmpImage))
                {
                    using (Brush brush = new SolidBrush(bColores))
                    {
                        float halfBrushSize = brushSize / 2f;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        for (int i = 0; i < points.Count - 1; i++)
                        {
                            g.FillEllipse(brush, points[i].X - halfBrushSize, points[i].Y - halfBrushSize, brushSize, brushSize);
                            g.DrawLine(new Pen(brush, brushSize), points[i], points[i + 1]);
                        }
                    }
                }

                pbCtrl.Image = bmpImage;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG image files (*.png)|*.png";
            saveDialog.FileName = "painted_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                bmpImage.Save(saveDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Image saved as " + saveDialog.FileName);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel3.BringToFront();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront(); //already set
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            panel1.SendToBack();
            pbCtrl.BringToFront(); //already set
        }
    }

}

