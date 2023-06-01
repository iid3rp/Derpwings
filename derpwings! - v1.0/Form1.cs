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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            
        }
        
        public bool formCreated = false;
        

        public void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();

            if (form2 == null)
            {
                // If there aren't any open instances of Form2, create a new one
                form2 = new Form2();
                form2.Show();
            }
            else
            {
                // If there is an open instance of Form2, activate it to bring it to the front
                form2.Activate();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iid3rp/derpwings-v2.0/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
