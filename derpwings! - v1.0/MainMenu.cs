using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derpwings____v1._0
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent(); 
            
        }
        
        public bool formCreated = false;
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iid3rp/derpwings-v2.0/");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CreateCanvas createCanvas = new CreateCanvas();
            createCanvas.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/1EtJyX1VFsYoZWHtCzJ6nPjpidUnLVuDAhuEDeMUrgsM/edit?usp=sharing");
        }
    }
}
