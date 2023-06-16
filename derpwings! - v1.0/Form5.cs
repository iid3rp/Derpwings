using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace derpwings____v1._0
{
    public partial class Form5 : Form
    {
        private bool smoothing, dLine, particle, triangle, ellipse, rectangle;
        private int stability;
        private float brushsize;
        public Form5(bool bSmoothing,bool bDline,
            bool bParticle,int bStability,
            float bBrushSize, bool bTriangle,
            bool bEllipse, bool bRectangle)
        {
            InitializeComponent();
            smoothing = bSmoothing; dLine = bDline; particle = bParticle;
            triangle = bTriangle; ellipse = bEllipse;  rectangle = bRectangle;
            brushsize = bBrushSize; stability = bStability;
            hScrollBar3.Value = (int)brushsize;
            if (ellipse)  
                isEllipse();
            if (rectangle)
                isRectangle();
            if (smoothing)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            if (dLine)
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isEllipse();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isRectangle();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                smoothing = true;
            if (!checkBox1.Checked)
                smoothing = false;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                dLine = true;
            if (!checkBox2.Checked)
                dLine = false;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            stability = hScrollBar2.Value;
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            brushsize = hScrollBar3.Value;
        }
        private void isEllipse()
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.None;
            ellipse = true; rectangle = false;
        }
        private void isRectangle()
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.None;
            ellipse = false; rectangle = true;
        }
        //RETURNING
        public bool bSmoothing()
        {
            return smoothing;
        }
        public bool bDLine()
        {
            return dLine;
        }
        public bool bParticle()
        {
            return particle;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool bEllipse()
        {
            return ellipse;
        }
        public bool bRectangle()
        {
            return rectangle;
        }
        public bool bTriangle()
        {
            return triangle;
        }
        public int bStability()
        {
            return stability;
        }
        public float bBrushSize()
        {
            return brushsize;
        }
    }
}
