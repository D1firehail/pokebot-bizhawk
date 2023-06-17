using OpenCvSharp;
using System.Drawing;
using System.IO;

namespace Pokebot_Sharp
{
    public static class ImageHelper
    {
        public static Bitmap GetBitmapFromBytes(byte[] bytes)
        {
            using (var imgStream = new MemoryStream(bytes))
            {
                return new Bitmap(imgStream);
            }
        }

        public static Mat GetMatFromBytes(byte[] bytes)
        {
            return Mat.FromImageData(bytes, ImreadModes.Color);
        }
    }
}
