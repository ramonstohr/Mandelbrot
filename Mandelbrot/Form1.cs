using System.Drawing;
using System.Threading;
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
            double val = (double)(value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;

            return (int)val;
        }

        public static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
        {
            var val = (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
            return val;
        }

        Bitmap bmp;
        private void Start(int maxIterations = 100)
        {
            if (panel1.BackgroundImage != null)
                panel1.BackgroundImage.Dispose();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.BackgroundImage = bmp;


            for (int j = 0; j < panel1.Height; j++)
            {

                for (int i = 0; i < panel1.Width; i++)
                {
                    var a = Map(j, 0, panel1.Height, -2.5, 2.5);
                    var b = Map(i, 0, panel1.Width, -2.5, 2.5);
                    var ca = a;
                    var cb = b;

                    var n = 0;
                    while (n < maxIterations)
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

                    if (n == maxIterations)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                    {

                        Color col = Color.FromArgb(Map(n, 0, maxIterations, 0, 255), 10, 10);
                        bmp.SetPixel(i, j, col);

                    }
                }
            }

        }

        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            Start(trackBar1.Value);
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Start(i);
                this.Update();
            }
        }
    }
}
