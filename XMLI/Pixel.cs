using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLI
{
    public class Pixel
    {

        public Pixel() { }
        public Pixel(int x, int y, Color color)
        {
            this.x = x; this.y = y;
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
        }

        public int x;
        public int y;
        public byte r;
        public byte g;
        public byte b;
    }
}
