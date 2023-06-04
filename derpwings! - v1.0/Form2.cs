using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using derpwings____v1._0;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derpwings____v1._0
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            int cWidth = hScrollBar1.Value, cHeight = hScrollBar2.Value;
        } 
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tWidth.Text = hScrollBar1.Value.ToString();
        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            tHeight.Text = hScrollBar2.Value.ToString();
        }
        private void tWidth_TextChanged(object sender, EventArgs e)
        {
            int wValue;
            if (int.TryParse(tWidth.Text, out wValue)) // parse the text to an integer
            {
                if (wValue > 10000)
                {
                    tWidth.Text = "10000";
                    wValue = hScrollBar1.Maximum;
                }
                else
                    hScrollBar1.Value = wValue; // update the scrollbar value
            }
            else
            {
                tWidth.Text = hScrollBar1.Value.ToString();
            }
            
        }
        private void tHeight_TextChanged(object sender, EventArgs e)
        {
            int hValue;
            if (int.TryParse(tHeight.Text, out hValue)) // parse the text to an integer
            {
                if (hValue > 10000)
                {
                    tHeight.Text = "10000";
                    hValue = hScrollBar2.Maximum;
                }
                else
                    hScrollBar2.Value = hValue; // update the scrollbar value
            }
            else
            {
                tHeight.Text = hScrollBar2.Value.ToString();
            }
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int hs1 = hScrollBar1.Value, hs2 = hScrollBar2.Value;
            Form form3 = new Form3(hs1, hs2); // create an instance of Form3
            form3.ShowDialog(); // show Form3;
            this.Close();   
        } 
    }  
}
