using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Clock
{
    public partial class Form3 : Form
    {
        private Stopwatch stopWatch;
        public Form3()
        {
                InitializeComponent();
                
         }

            private void timer1_Tick(object sender, EventArgs e)
            {
            this.label1.Text = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);
            }

            private void button1_Click(object sender, EventArgs e)
            {
            stopWatch.Start();
        }

            private void button2_Click(object sender, EventArgs e)
            {
            stopWatch.Stop()
;        }

            private void button3_Click(object sender, EventArgs e)
        {
            stopWatch.Reset();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
        }
    }
}
        

    
