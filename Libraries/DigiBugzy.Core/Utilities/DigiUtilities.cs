
using System.Drawing;
using System.Drawing.Imaging;

namespace DigiBugzy.Core.Utilities
{
    /// <summary>
    /// Static class with small helper methods that are used on more than one place
    /// </summary>
    public static class DigiUtilities
    {

        #region Imaging

        // ImageConverter object used to convert byte arrays containing JPEG or PNG file images into 
        //  Bitmap objects. This is static and only gets instantiated once.
        private static readonly ImageConverter _imageConverter = new();


        //Converts image into Byte array
        // <returns>byte array image of a PNG file containing the image</returns>
        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using var memoryStream = new MemoryStream();
            theImage.Save(memoryStream, ImageFormat.Png);
            return memoryStream.ToArray();
        }

        //Converts Byte Array ino image
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (Math.Abs(bm.HorizontalResolution - (int)bm.HorizontalResolution) > 5 ||
                               Math.Abs(bm.VerticalResolution - (int)bm.VerticalResolution) > 5))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                    (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        #endregion
    }
}
