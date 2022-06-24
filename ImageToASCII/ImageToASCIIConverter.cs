using System.Drawing;

namespace ImageToASCII
{
    public class ImageToASCIIConverter
    {
        private readonly char[] table = new char[] {'.', ',', ':', '+', '*', '?', '%', 'S', '#', '@'};
        private Bitmap bitmap;

        public ImageToASCIIConverter(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public char[][] Convert()
        {
            char[][] result = new char[bitmap.Height][];

            for (int y = 0; y < bitmap.Height; y++)
            {
                result[y] = new char[bitmap.Width];
                for (int x = 0; x < bitmap.Width; x++)
                {
                    result[y][x] = table[(int)Map(bitmap.GetPixel(x, y).R, 0, 255, 0, table.Length - 1)];
                }
            }

            return result;
        }

        public float Map(float valueToMap, float start1, float stop1, float start2, float stop2) => (valueToMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
    }
}