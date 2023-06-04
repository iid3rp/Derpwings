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
        private Bitmap bmpImage; // the bitmap used to paint
        private bool isDrawing = false;
        private int scrollX = 0; // Initialize scroll position to 0
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
            pbCtrl.Paint += new PaintEventHandler(PictureBoxPaint);
            pbCtrl.MouseDown += new MouseEventHandler(PictureBoxMouseDown);
            pbCtrl.MouseMove += new MouseEventHandler(PictureBoxMouseMove);
            pbCtrl.MouseUp += new MouseEventHandler(PictureBoxMouseUp);

            return pbCtrl;
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tSize.Text = "Size: " + hScrollBar1.Value.ToString() + " px.";
            brushSize = hScrollBar1.Value;
            bUpdate();
        }
        private void bUpdate()
        {
            colorbase.BackColor = bColores;
            sBrush = new SolidBrush(color: bColores);
        }
        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(scrollX, 0);
        }
        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = e.Location;
                isDrawing = true;
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(pbCtrl.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.FillEllipse(sBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    g.DrawLine(new Pen(sBrush, brushSize), lastPoint, e.Location);
                }

                lastPoint = e.Location;
                pbCtrl.Invalidate();
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
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

        private void colorbase_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.FromArgb(255, 0, 0); // Set the initial color to Red

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bColores = colorDialog.Color;
                bUpdate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pbCtrl.Image = new Bitmap(pbCtrl.Width, pbCtrl.Height);
        }
    }

}

