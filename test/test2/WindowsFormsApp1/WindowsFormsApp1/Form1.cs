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
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.MinimumSize = new Size(400, 400);
            this.MaximumSize = new Size(400, 400);
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Handles the 1 event of the button1_MouseLeave control. Changes color when removed mouse.
        /// </summary>
        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Lime;
        }
        /// <summary>
        /// Handles the MouseEnter event of the button1 control. Changes color and position when hovering mouse.
        /// </summary>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Location = new System.Drawing.Point((Control.MousePosition.X + 1000) % 300, (Control.MousePosition.Y + 1000) % 300);
            this.button2.Location = new System.Drawing.Point((Control.MousePosition.X + 1000) % 300, (Control.MousePosition.Y + 1000) % 300);
            this.button1.BackColor = Color.Red;
        }
        /// <summary>
        /// Handles the MouseEnter event of the button2 control. Сhanges position when hovering mouse.
        /// </summary>
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Location = new System.Drawing.Point((Control.MousePosition.X + 1000) % 300 , (Control.MousePosition.Y + 1000) % 300);
            this.button2.Location = new System.Drawing.Point((Control.MousePosition.X + 1000) % 300, (Control.MousePosition.Y + 1000) % 300);
        }
    }
}