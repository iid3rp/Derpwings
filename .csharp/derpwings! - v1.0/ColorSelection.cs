using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derpwings____v1._0
{
    public partial class ColorSelection : Form
    {
        private Color bColores;
        private int bAlpha, bRed, bGreen, bBlue;
        private float c1 = .25f, c2 = .375f, c3 = .5f,
                      c4 = .625f, c5 = .75f, c6 = .875f;
        public ColorSelection(Color Form4bColores)
        {
            InitializeComponent();
            bColores = Form4bColores;
            bColoresPrev.BackColor = bColores;
            alpha.Value = bColores.A; bAlpha = bColores.A;
            red.Value = bColores.R; bRed = bColores.R;
            green.Value = bColores.G; bGreen = bColores.G;
            blue.Value = bColores.B; bBlue = bColores.B;
            cUpdate();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o1.BackColor; exit();
        }
        private void pictureBox1o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o2.BackColor; exit();
        }
        private void pictureBox1o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o3.BackColor; exit();
        }
        private void pictureBox1o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o4.BackColor; exit();
        }
        private void pictureBox1o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o5.BackColor; exit();
        }
        private void pictureBox1o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o6.BackColor; exit();
        }
        private void pictureBox1o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o7.BackColor; exit();
        }
        private void pictureBox1o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1o8.BackColor; exit();
        }
        private void pictureBox2o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o1.BackColor; exit();
        }
        private void pictureBox2o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o2.BackColor; exit();
        }
        private void pictureBox2o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o3.BackColor; exit();
        }
        private void pictureBox2o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o4.BackColor; exit();
        }
        private void pictureBox2o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o5.BackColor; exit();
        }
        private void pictureBox2o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o6.BackColor; exit();
        }
        private void pictureBox2o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o7.BackColor; exit();
        }
        private void pictureBox2o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox2o8.BackColor; exit();
        }
        private void pictureBox3o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o1.BackColor; exit();
        }
        private void pictureBox3o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o2.BackColor; exit();
        }
        private void pictureBox3o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o3.BackColor; exit();
        }
        private void pictureBox3o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o4.BackColor; exit();
        }
        private void pictureBox3o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o5.BackColor; exit();
        }
        private void pictureBox3o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o6.BackColor; exit();
        }
        private void pictureBox3o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o7.BackColor; exit();
        }
        private void pictureBox3o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3o8.BackColor; exit();
        }
        private void pictureBox4o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o1.BackColor; exit();
        }
        private void pictureBox4o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o2.BackColor; exit();
        }
        private void pictureBox4o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o3.BackColor; exit();
        }
        private void pictureBox4o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o4.BackColor; exit();
        }
        private void pictureBox4o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o5.BackColor; exit();
        }
        private void pictureBox4o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o6.BackColor; exit();
        }
        private void pictureBox4o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o7.BackColor; exit();
        }
        private void pictureBox4o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox4o8.BackColor; exit();
        }
        private void pictureBox5o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o1.BackColor; exit();
        }
        private void pictureBox5o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o2.BackColor; exit();
        }
        private void pictureBox5o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o3.BackColor; exit();
        }
        private void pictureBox5o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o4.BackColor; exit();
        }
        private void pictureBox5o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o5.BackColor; exit();
        }
        private void pictureBox5o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o6.BackColor; exit();
        }
        private void pictureBox5o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o7.BackColor; exit();
        }
        private void pictureBox5o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox5o8.BackColor; exit();
        }
        private void pictureBox6o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o1.BackColor; exit();
        }
        private void pictureBox6o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o2.BackColor; exit();
        }
        private void pictureBox6o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o3.BackColor; exit();
        }
        private void pictureBox6o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o4.BackColor; exit();
        }
        private void pictureBox6o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o5.BackColor; exit();
        }
        private void pictureBox6o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o6.BackColor; exit();
        }
        private void pictureBox6o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o7.BackColor; exit();
        }
        private void pictureBox6o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox6o8.BackColor; exit();
        }
        private void pictureBox7o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o1.BackColor; exit();
        }
        private void pictureBox7o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o2.BackColor; exit();
        }
        private void pictureBox7o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o3.BackColor; exit();
        }
        private void pictureBox7o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o4.BackColor; exit();
        }
        private void pictureBox7o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o5.BackColor; exit();
        }
        private void pictureBox7o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o6.BackColor; exit();
        }
        private void pictureBox7o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o7.BackColor; exit();
        }
        private void pictureBox7o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox7o8.BackColor; exit();
        }
        private void pictureBox8o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o1.BackColor; exit();
        }
        private void pictureBox8o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o2.BackColor; exit();
        }
        private void pictureBox8o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o3.BackColor; exit();
        }
        private void pictureBox8o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o4.BackColor; exit();
        }
        private void pictureBox8o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o5.BackColor; exit();
        }
        private void pictureBox8o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o6.BackColor; exit();
        }
        private void pictureBox8o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o7.BackColor; exit();
        }
        private void pictureBox8o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox8o8.BackColor; exit();
        }
        private void pictureBox9o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o1.BackColor; exit();
        }
        private void pictureBox9o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o2.BackColor; exit();
        }
        private void pictureBox9o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o3.BackColor; exit();
        }
        private void pictureBox9o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o4.BackColor; exit();
        }
        private void pictureBox9o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o5.BackColor; exit();
        }
        private void pictureBox9o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o6.BackColor; exit();
        }
        private void pictureBox9o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o7.BackColor; exit();
        }
        private void pictureBox9o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox9o8.BackColor; exit();
        }
        private void pictureBox10o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o1.BackColor; exit();
        }
        private void pictureBox10o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o2.BackColor; exit();
        }
        private void pictureBox10o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o3.BackColor; exit();
        }
        private void pictureBox10o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o4.BackColor; exit();
        }
        private void pictureBox10o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o5.BackColor; exit();
        }
        private void pictureBox10o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o6.BackColor; exit();
        }
        private void pictureBox10o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o7.BackColor; exit();
        }
        private void pictureBox10o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox10o8.BackColor; exit();
        }
        private void pictureBox11o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o1.BackColor; exit();
        }
        private void pictureBox11o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o2.BackColor; exit();
        }
        private void pictureBox11o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o3.BackColor; exit();
        }
        private void pictureBox11o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o4.BackColor; exit();
        }
        private void pictureBox11o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o5.BackColor; exit();
        }
        private void pictureBox11o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o6.BackColor; exit();
        }
        private void pictureBox11o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o7.BackColor; exit();
        }
        private void pictureBox11o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox11o8.BackColor; exit();
        }
        private void pictureBox12o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o1.BackColor; exit();
        }
        private void pictureBox12o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o2.BackColor; exit();
        }
        private void pictureBox12o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o3.BackColor; exit();
        }
        private void pictureBox12o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o4.BackColor; exit();
        }
        private void pictureBox12o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o5.BackColor; exit();
        }
        private void pictureBox12o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o6.BackColor; exit();
        }
        private void pictureBox12o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o7.BackColor; exit();
        }
        private void pictureBox12o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox12o8.BackColor; exit();
        }
        private void pictureBox13o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o1.BackColor; exit();
        }
        private void pictureBox13o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o2.BackColor; exit();
        }
        private void pictureBox13o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o3.BackColor; exit();
        }
        private void pictureBox13o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o4.BackColor; exit();
        }
        private void pictureBox13o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o5.BackColor; exit();
        }
        private void pictureBox13o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o6.BackColor; exit();
        }
        private void pictureBox13o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o7.BackColor; exit();
        }
        private void pictureBox13o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox13o8.BackColor; exit();
        }
        private void pictureBox14o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o1.BackColor; exit();
        }
        private void pictureBox14o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o2.BackColor; exit();
        }

        private void hScrollBarhue_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void hScrollBarsat_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBarhue_Scroll(sender, e);
        }

        private void hScrollBarbright_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBarhue_Scroll(sender, e);
        }

        private void pictureBox14o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o3.BackColor; exit();
        }
        private void pictureBox14o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o4.BackColor; exit();
        }
        private void pictureBox14o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o5.BackColor; exit();
        }
        private void pictureBox14o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o6.BackColor; exit();
        }
        private void pictureBox14o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o7.BackColor; exit();
        }
        private void pictureBox14o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox14o8.BackColor; exit();
        }

        private void pictureBox15o1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o1.BackColor; exit();
        }
        private void pictureBox15o2_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o2.BackColor; exit();
        }
        private void pictureBox15o3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o3.BackColor; exit();
        }
        private void pictureBox15o4_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o4.BackColor; exit();
        }
        private void pictureBox15o5_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o5.BackColor; exit();
        }
        private void pictureBox15o6_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o6.BackColor; exit();
        }
        private void pictureBoxa1_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa1.BackColor; exit();
        }
        private void pictureBoxa2_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa2.BackColor; exit();
        }

        private void pictureBoxa4_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa4.BackColor; exit();
        }

        private void pictureBoxa5_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa5.BackColor; exit();
        }

        private void pictureBoxc1_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc1.BackColor; exit();
        }

        private void pictureBoxc2_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc2.BackColor; exit();
        }

        private void pictureBoxc3_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc3.BackColor; exit();
        }

        private void pictureBoxc4_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc4.BackColor; exit();
        }

        private void pictureBoxc5_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc5.BackColor; exit();
        }

        private void pictureBoxa6_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa6.BackColor; exit();
        }

        private void pictureBoxc6_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxc6.BackColor; exit();
        }

        private void pictureBoxa3_Click(object sender, EventArgs e)
        {
            bColores = pictureBoxa3.BackColor; exit();
        }

        private void pictureBox15o7_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o7.BackColor; exit();
        }
        private void pictureBox15o8_Click(object sender, EventArgs e)
        {
            bColores = pictureBox15o8.BackColor; exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bColores = pictureBox1.BackColor; exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bColores = pictureBox3.BackColor; exit();
        }

        private void ColorSelection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Call the method to close the form
                exit();
            }
        }

        public void exit() //VERY IMPORTANT!!
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public Color bColoresPicker()
        {
            return bColores;
        }

        private void label3_Click(object sender, EventArgs e)
        {

            bColores = bColoresPrev.BackColor; exit();
        }

        private void red_Scroll(object sender, ScrollEventArgs e)
        {
            bRed = red.Value; cUpdate();
        }

        private void green_Scroll(object sender, ScrollEventArgs e)
        {
            bGreen = green.Value; cUpdate();
        }

        private void blue_Scroll(object sender, ScrollEventArgs e)
        {
            bBlue = blue.Value; cUpdate();
        }

        private void alpha_Scroll(object sender, ScrollEventArgs e)
        {
            bAlpha = alpha.Value; cUpdate();
            label8.Text = (String)("Opacity:" + ((int)(bAlpha / 2.55)).ToString() + '%');
        }
        private void cUpdate()
        {
            bColores = (Color.FromArgb(bAlpha, bRed, bGreen, bBlue));
            bColoresPrev.BackColor = bColores;
            label8.Text = (String)("Opacity:" + ((int)(bAlpha / 2.55)).ToString() + '%');


            pictureBoxa1.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c1), (int)(bColores.G + (255 - bColores.G) * c1), (int)(bColores.B + (255 - bColores.B) * c1));
            pictureBoxa2.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c2), (int)(bColores.G + (255 - bColores.G) * c2), (int)(bColores.B + (255 - bColores.B) * c2));
            pictureBoxa3.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c3), (int)(bColores.G + (255 - bColores.G) * c3), (int)(bColores.B + (255 - bColores.B) * c3));
            pictureBoxa4.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c4), (int)(bColores.G + (255 - bColores.G) * c4), (int)(bColores.B + (255 - bColores.B) * c4));
            pictureBoxa5.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c5), (int)(bColores.G + (255 - bColores.G) * c5), (int)(bColores.B + (255 - bColores.B) * c5));
            pictureBoxa6.BackColor = Color.FromArgb((int)(bColores.R + (255 - bColores.R) * c6), (int)(bColores.G + (255 - bColores.G) * c6), (int)(bColores.B + (255 - bColores.B) * c6));

            pictureBoxc1.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c1), (int)(bColores.G - bColores.G * c1), (int)(bColores.B - bColores.B * c1));
            pictureBoxc2.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c2), (int)(bColores.G - bColores.G * c2), (int)(bColores.B - bColores.B * c2));
            pictureBoxc3.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c3), (int)(bColores.G - bColores.G * c3), (int)(bColores.B - bColores.B * c3));
            pictureBoxc4.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c4), (int)(bColores.G - bColores.G * c4), (int)(bColores.B - bColores.B * c4));
            pictureBoxc5.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c5), (int)(bColores.G - bColores.G * c5), (int)(bColores.B - bColores.B * c5));
            pictureBoxc6.BackColor = Color.FromArgb((int)(bColores.R - bColores.R * c6), (int)(bColores.G - bColores.G * c6), (int)(bColores.B - bColores.B * c6));


        }

            
        
    }
}
