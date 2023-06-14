using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derpwings____v1._0
{
    public partial class save : Form
    {
        private Bitmap savingWhite;
        private Bitmap savingAs;
        private Bitmap bmpImage;
        private PictureBox pbSave;
        private int width, height;
        public save(Bitmap savingImage)
        {
            InitializeComponent();
            width = savingImage.Width;
            height = savingImage.Height;
            bmpImage = savingImage;
            pbSave = new PictureBox();
            pbSave = CreateNewPicture(width, height);
            canvasPanel.Controls.Add(pbSave);
            this.Controls.Add(canvasPanel);
        }
        private PictureBox CreateNewPicture(int width, int height) 
        {
            int max = 0;
            if (width > height)
                max = width / 256;
            if (height > width)
                max = height / 256;
            pbSave.MinimumSize = new Size(width / max, height / max);
            pbSave.MaximumSize = pbSave.MinimumSize;
            pbSave.Location = new Point(0,0);
            pbSave.Image = bmpImage;
            pbSave.SizeMode = PictureBoxSizeMode.StretchImage;
            return pbSave;
        }

        private void save_Load(object sender, EventArgs e)
        {
            //white canvas
            savingWhite = new Bitmap(bmpImage.Width, bmpImage.Height, PixelFormat.Format32bppRgb);
            using (Graphics g = Graphics.FromImage(savingWhite))
            {
                g.Clear(Color.White);
                g.DrawImage(bmpImage, 0, 0);
            }
            //initialize first choice
            pbSave.Image = savingWhite;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                pbSave.Image = savingWhite;
            }
            if (!checkBox1.Checked)
                checkBox2.Checked = true;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                pbSave.Image = bmpImage;
            }
            if (!checkBox2.Checked)
                checkBox1.Checked = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {
           Clipboard.SetImage(savingWhite);
            label1.Text = label1.Text + " ✓";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\12 - Terabyte Prog\Pictures\Saved Pictures\myimage.png";
            if (checkBox1.Checked)
                savingWhite.Save(filePath);
            if (checkBox2.Checked)
                bmpImage.Save(filePath);
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                savingAs = savingWhite;
            if (checkBox2.Checked)
                savingAs = bmpImage;
            savingDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                savingAs = savingWhite;
            if (checkBox2.Checked)
                savingAs = bmpImage;
            printDialog();
        }
        private void savingDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG image files (*.png)|*.png";
            saveDialog.FileName = "derpwings_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                savingAs.Save(saveDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Image saved as " + saveDialog.FileName +
                                "\n Thank you for drawing!");
            }
        }
        private void printDialog()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
                printDocument.Print();
            }
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = (Bitmap)savingAs;
            e.Graphics.DrawImage(bmp, new Point(0, 0));
        }
    }
}
