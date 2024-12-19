using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P230611988
{
    public partial class StartForm1 : Form
    {
        public StartForm1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Hide();
            //button2.Enabled = false;
            //button1.Hide();
            //button1.Enabled = false;
            MainForm mainform = new MainForm();
            mainform.StartPosition = FormStartPosition.CenterScreen;
            //mainform.Height = Screen.PrimaryScreen.Bounds.Height;
            mainform.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button2.Enabled = false;
            button1.Hide();
            button1.Enabled = false;
            this.Close();
        }
    }
}
