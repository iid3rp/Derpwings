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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derpwings____v1._0
{
    public partial class BrushSection : Form
    {
        private bool smoothing, dLine, particle, triangle, ellipse, rectangle;
        private int stability;
        private float brushsize;
        public BrushSection(bool bSmoothing,bool bDline,
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
            textBox1.Text = brushsize.ToString();
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

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            brushsize = hScrollBar3.Value;
            textBox1.Text = hScrollBar3.Value.ToString();
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

        private void BrushSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int hValue;
            if (int.TryParse(textBox1.Text, out hValue)) // parse the text to an integer
            {
                if (hValue > 1000)
                {
                    textBox1.Text = "1000";
                    hValue = hScrollBar3.Maximum;
                }
                else
                    hScrollBar3.Value = hValue; // update the scrollbar value
            }
            else
            {
                textBox1.Text = hScrollBar3.Value.ToString();
            }
        }

        public bool bEllipse()
        {
            return ellipse;
        }
        public bool bRectangle()
        {
            return rectangle;
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
