using System.Drawing;

namespace ImageToASCII
{
    class Program
    {
        private const double WIDTH_OFFSET = 3;
        private const int MAX_WIDTH = 500;
        private static void Main()
        {
            Console.Write("Enter image path: ");
            string path = Console.ReadLine();

            Bitmap bitmap = new Bitmap(path);

            bitmap = resizeBitmap(bitmap);
            bitmap.ToGrayscale();

            Console.Clear();
            ImageToASCIIConverter converter = new ImageToASCIIConverter(bitmap);
            char[][] rows = converter.Convert();

            foreach (var row in rows)
            {
                Console.WriteLine(row);
            }

            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
        }

        public static Bitmap resizeBitmap(Bitmap bitmap)
        {
            double newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
            return bitmap;
        }
    }
}