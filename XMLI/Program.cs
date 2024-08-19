using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imageFilePath = args[0];
            Bitmap image = new Bitmap(imageFilePath);


            int width = image.Width;
            int height = image.Height;

            XMLI resultImage = new XMLI();

            resultImage.width = width;
            resultImage.height = height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    resultImage.pixels.
                    Add(
                        new Pixel(
                            x,
                            y,
                            image.GetPixel(x, y)
                        )
                    );
                }
            }




            XmlSerializer serializer = new XmlSerializer(typeof(XMLI));

            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resultImage);

            using (StreamWriter sw = new StreamWriter(imageFilePath + ".xmli"))
            {
                sw.Write(writer.ToString());
            }

        }
    }
}
