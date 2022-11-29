using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace joccunavetespatialealieninvasion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int modanimNEx = 1;
        List<glont> gloante = new List<glont>();
        List<navaextraterestra> naveextraterestre = new List<navaextraterestra>();
        glont curentglont = null;

        int i = -1;


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (navamea1.Left > 50)
            {
                navamea1.Left = e.X;
            }
            else
            {
                navamea1.Left = 51;
            }


            if (navamea1.Left < 600)
            {
                navamea1.Left = e.X;
            }
            else
            {
                navamea1.Left = 599;
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            i++;
            gloante.Add(new glont());
            Controls.Add(gloante[i]);
            gloante[i].Left = e.X;
            gloante[i].Top = 463;
            gloante[i].Show();
            gloante[i].l = e.X + 21;
            //necesita adaugarea unui thread separat fata de threadul actual
            gloante[i].animate();
            curentglont = gloante[i];
            Thread.Sleep(1);

        }

        public void viewalienships()
        {
            int k = -1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    naveextraterestre.Add(new navaextraterestra());
                    Controls.Add(naveextraterestre[++k]);
                    naveextraterestre[k].Left =i * 60 ;
                    naveextraterestre[k].Top = j * 30 - 25;
                    naveextraterestre[k].Show();
                    
                }
            }
        }

        public void animateNExLeft()
        {
            int k = naveextraterestre.Count;

            for (int i = 0; i < k; i++)
            {
                naveextraterestre[i].Left -= 10;
            }
        }

        public void animateNExRight()
        {
            int k = naveextraterestre.Count;

            for (int i = 0; i < k; i++)
            {
                naveextraterestre[i].Left+=10;
            }
        }

        public void animateallNEx()
        {
           // for (; ; )
           // {
                if (modanimNEx == 1)
                {
                    animateNExRight();
                    if (naveextraterestre[81].Left > 590) { modanimNEx = 0; }
                }
                else
                {
                    animateNExLeft();
                    if (naveextraterestre[0].Left < 10) { modanimNEx = 1; }
                }
                Thread.Sleep(2);
          //  }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        public bool isNExHited()
        {
            bool lovit = false;
            for(int i = 0 ; i< naveextraterestre.Count ; i++)
            {
                try
                {
                    if (curentglont.Top <= naveextraterestre[i].Top + naveextraterestre[i].Height 
                        && curentglont.Top >= naveextraterestre[i].Top 
                        && curentglont.Left <= naveextraterestre[i].Left + naveextraterestre[i].Width 
                        && curentglont.Left >= naveextraterestre[i].Left)
                    {
                        lovit = true;
                        naveextraterestre[i].Dispose();
                    }
                }
                catch { }

            }
            return lovit;
        }


        private void button1_Click(object sender, EventArgs e)
        {


            viewalienships();
            timer1.Start();

            //necesita un thread nou
            //private delegate void nume (type paramname);
            //use invokerequires
            //udse invoke 
            //use backgroundworker 
            // .dowork
            // .runworkercompleted
            // .runworkerasync
            //ThreadStart ts = new ThreadStart(animateallNEx);
            //Thread thr0 = new Thread(ts);
            //thr0.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            animateallNEx();
            isNExHited();
        }
    }
}
