using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Lime;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Red;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Location = new System.Drawing.Point(Cursor.Position.X % this.Size.Height, Cursor.Position.Y % this.Size.Height);
            this.button2.Location = new System.Drawing.Point(Cursor.Position.X % this.Size.Height, Cursor.Position.Y % this.Size.Height);
        }
    }
}