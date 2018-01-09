using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public static int Map(int value, int fromSource, int toSource, int fromTarget, int toTarget)
        {
           var  val = ((double)value - fromSource) / ((double)toSource - fromSource) * ((double)toTarget - fromTarget) + (double)fromTarget;

            return (int)val;
        }

        public static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
        {
            var val = (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
            return val;
        }


        private void Start()
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.BackgroundImage = bmp;

            double w = 50;
            double h = (w * panel1.Height) / panel1.Width;

            int maxiterations = 100;


            for (int j = 0; j < panel1.Height; j++)
            {

                for (int i = 0; i < panel1.Width; i++)
                {
                    var a = Map(j, 0, panel1.Height, -2.5, 2.5);
                    var b = Map(i, 0, panel1.Width, -2.5, 2.5);
                    var ca = a;
                    var cb = b;

                    var n = 0;
                    while (n < maxiterations)
                    {
                        var aa = a * a - b * b;
                        var bb = 2 * a * b;
                        a = aa + ca;
                        b = bb + cb;
                        if (a * a + b * b > 16)
                        {
                            break;
                        }
                        n++;
                    }

                    if (n == maxiterations)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                    {
                      
                        Color col = Color.FromArgb(Map(n, 0, maxiterations, 0, 255),10,10);
                        bmp.SetPixel(i, j, col);
                        
                    }
                }
            }

        }
    }
}
