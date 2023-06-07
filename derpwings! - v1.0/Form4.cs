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
    public partial class Form4 : Form
    {
        private Color bColores;
        public Form4()
        {
            InitializeComponent();
            this.bColores = new Color();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1o1_Click(object sender, EventArgs e)
        {
            bColores = Color.FromArgb(51, 0, 0);
        }
    }
}
