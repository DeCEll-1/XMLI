using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using XMLI;

namespace XMLIOpener
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string xmliFilePath = Environment.GetCommandLineArgs()[1];

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLI.XMLI));

            XMLI.XMLI xmli = new XMLI.XMLI();

            using (StreamReader sr = new StreamReader(xmliFilePath))
            {
                xmli = (XMLI.XMLI)xmlSerializer.Deserialize(sr);
            }

            Bitmap bmp = new Bitmap(xmli.width,xmli.height);

            foreach (var pixel in xmli.pixels)
            {
                bmp.SetPixel(pixel.x, pixel.y, Color.FromArgb(pixel.r, pixel.g, pixel.b));

            }

            pb_Display.Image = bmp;
        }
    }
}
