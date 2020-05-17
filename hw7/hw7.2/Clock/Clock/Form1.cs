using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        private static DateTime _dateTime = DateTime.Now;
        int hour = _dateTime.Hour % 12;
        int minute = _dateTime.Minute;
        int secund = _dateTime.Second;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
