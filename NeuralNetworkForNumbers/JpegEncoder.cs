using System.Linq;
using System.Drawing;
using System.IO;

namespace NeuralNetworkForNumbers
{
    static class JpegEncoder
    {
        public static int[,] Encode(string path, int rows, int columns)
        {
            int[,] result = new int[rows, columns];
            Bitmap bitmap = ConvertToBitmap(path);


            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    result[i, j] = bitmap.GetPixel(i, j).B;

            return result;
        }

        private static Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = File.Open(fileName, FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            return bitmap;
        }
    }
}
