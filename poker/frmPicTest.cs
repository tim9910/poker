using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace poker
{
    public partial class frmPicTest : Form
    {
        public frmPicTest()
        {
            InitializeComponent();
        }

        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int picNum = random.Next(1, 53);            
            picTest.Image = GetImage($"pic{picNum}");
            lblNum.Text = picNum.ToString();
        }
    }
}
