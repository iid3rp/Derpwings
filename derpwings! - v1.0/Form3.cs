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
        private GraphicsPath brushPath = new GraphicsPath(); //path to change the shape of the brush

        //brushes
        private Brush brush1;
        private Brush brush2;
        private Brush currentBrush;

        public Form3(int hs1, int hs2) //initialization for pbCtrl
        {
            InitializeComponent();
            pbCtrl = new PictureBox();
            pbCtrl = CreatePictureBox(hs1, hs2);
            pbCtrl.Location = new Point((this.ClientSize.Width - pbCtrl.Width) / 5, 0);
            canvasPanel.Controls.Add(pbCtrl);
            this.Controls.Add(canvasPanel);
            bUpdate();

            //brush
            brush1 = new SolidBrush(color: bColores);
            brush2 = new SolidBrush (color: bColores);
        }
        private PictureBox CreatePictureBox(int hs1, int hs2) //creation of pbCtrl
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
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e) //brush size
        {
            tSize.Text = "Size: " + hScrollBar1.Value.ToString() + " px.";
            brushSize = hScrollBar1.Value;
            bUpdate();
        }
        private void bUpdate() //brush color
        {
            colorbase.BackColor = bColores;
            currentBrush = new SolidBrush(color: bColores);
        }
        
        //CANVAS RELATED!!!!!
        private void PictureBoxMouseDown(object sender, MouseEventArgs e) //when i hold the mouse
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = e.Location;
                isDrawing = true;
            }
        }
        private void PictureBoxMouseMove(object sender, MouseEventArgs e) //when i hold and move the mouse
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(pbCtrl.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.FillEllipse(currentBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    g.DrawLine(new Pen(currentBrush, brushSize), lastPoint, e.Location);
                }

                lastPoint = e.Location;
                pbCtrl.Invalidate();
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e) //wehn i release the mouse
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void label2_Click(object sender, EventArgs e) //saving the image
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

        private void colorbase_Click(object sender, EventArgs e) //color for the brush
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.FromArgb(255, 0, 0); // Set the initial color to Red

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bColores = colorDialog.Color;
                bUpdate(); //back to update the brush color
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pbCtrl.Image = new Bitmap(pbCtrl.Width, pbCtrl.Height);
        }

        //BRUSHES!!!!!
        private void label3_Click(object sender, EventArgs e)
        {
            brushPath.Reset();
            brushPath.AddEllipse(0, 0, 50, 50);
            currentBrush = brush1;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            brushPath.Reset();
            PointF[] points = new PointF[]
            {
                new PointF(50, 0),
                new PointF(60, 40),
                new PointF(100, 40),
                new PointF(70, 60),
                new PointF(80, 100),
                new PointF(50, 80),
                new PointF(20, 100),
                new PointF(30, 60),
                new PointF(0, 40),
                new PointF(40, 40)
            };
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);
            path.CloseFigure();
            currentBrush = brush2;
        }
    }

}

