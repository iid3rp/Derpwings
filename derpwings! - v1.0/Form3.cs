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
        private Color bColores = (Color.FromArgb(255, 0, 0));
        private float brushSize = 10f;
        private SolidBrush sBrush; //the solid brush used to draw
        private List<PointF> points = new List<PointF>();//point list
        private GraphicsPath path = new GraphicsPath(); //the path
        private Bitmap bmpImage; // the bitmap used to paint
        public Form3(int hs1, int hs2)
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            pbCtrl = CreatePictureBox(hs1, hs2);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 5, 0);
            canvasPanel.Controls.Add(pbCtrl);
            this.Controls.Add(canvasPanel);
            bUpdate();
        }
        private void brushBoxPaint(object sender, PaintEventArgs e)
        {
        }
        private PictureBox CreatePictureBox(int hs1, int hs2)
        {
            bmpImage = new Bitmap(hs1, hs2);
            pbCtrl.MinimumSize = new Size(hs1, hs2);
            pbCtrl.MaximumSize = pbCtrl.MinimumSize;
            pbCtrl.BackColor = Color.White;
            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                g.Clear(Color.White);
            }
            pbCtrl.Image = bmpImage;
            pbCtrl.MouseDown += new MouseEventHandler(PictureBoxMouseDown);
            pbCtrl.MouseMove += new MouseEventHandler(PictureBoxMouseMove);
            pbCtrl.MouseUp += new MouseEventHandler(PictureBoxMouseUp);

            return pbCtrl;
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
            lastPoint = e.Location;
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                    float halfBrushSize = brushSize / 2f;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.FillEllipse(sBrush, e.X - halfBrushSize, e.Y - halfBrushSize, brushSize, brushSize);
                    g.DrawLine(new Pen(sBrush, brushSize), lastPoint, e.Location);
                    lastPoint = e.Location;

                pbCtrl.Invalidate(new Rectangle(e.X - (int)(brushSize * 2), e.Y - (int)(brushSize * 2), (int)(brushSize * 4), (int)(brushSize * 4)));
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            pbCtrl.Invalidate(new Rectangle(e.X - (int)(brushSize * 2), e.Y - (int)(brushSize * 2), (int)(brushSize * 4), (int)(brushSize * 4)));
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
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            canvasPanel.SendToBack();
            pbCtrl.BringToFront(); //already set
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            canvasPanel.SendToBack();
            pbCtrl.BringToFront(); //already set
        }
    }

}

