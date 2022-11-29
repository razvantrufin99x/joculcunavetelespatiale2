using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace joccunavetespatialealieninvasion
{
    public partial class glont : UserControl
    {
        public glont()
        {
            InitializeComponent();
        }
        int t = 462;
        public int l = 0;

        public void animate()
        {
            while (t > -25)
            {
                t -= 25;

                Top = t;
                Left = l;
                Thread.Sleep(5);
                Refresh();
            };
            if (t <= -25)
            {
                this.Dispose();
            }
        }
        private void glont_Load(object sender, EventArgs e)
        {
            

        }
    }
}
