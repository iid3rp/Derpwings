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
        private int pps, stability;
        private float brushsize;
        public Form5(bool bSmoothing,bool bDline,
            bool bParticle,int bPps,int bStability,
            float bBrushSize, bool bTriangle,
            bool bEllipse, bool bRectangle)
        {
            InitializeComponent();
            smoothing = bSmoothing; dLine = bDline; particle = bParticle; pps = bPps;
            triangle = bTriangle; ellipse = bEllipse;  rectangle = bRectangle;
            brushsize = bBrushSize; stability = bStability;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            ellipse = true; rectangle = false; triangle = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox1.BorderStyle = BorderStyle.None;
            rectangle = true; ellipse = false; triangle = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox1.BorderStyle = BorderStyle.None;
            triangle = true; ellipse = false; rectangle = false;
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
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                particle = true;
            if (!checkBox3.Checked)
                particle = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                if (int.TryParse(textBox1.Text, out pps)) // parse the text to an integer
                {
                    if (pps > 1000)
                    {
                        textBox1.Text = "10000";
                        pps = hScrollBar1.Maximum;
                    }
                    else
                        hScrollBar1.Value = pps; // update the scrollbar value
                }
                else
                {
                    textBox1.Text = hScrollBar1.Value.ToString();
                }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            stability = hScrollBar2.Value;
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            brushsize = hScrollBar3.Value;
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
        public int bPPS()
        {
            return pps;
        }
        public float bBrushSize()
        {
            return brushsize;
        }
    }
}
