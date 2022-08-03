
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Encoder = System.Drawing.Imaging.Encoder;

namespace DigiBugzy.Core.Helpers
{
    public static class ImageHelpers
    {

        public static void CompressAndSaveImage(Image image, string fileName, long quality)
        {
            var parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

            var imageEncoder = GetEncoder(image.RawFormat);
            image.Save(fileName, imageEncoder, parameters);

        }

        public static void CompressAndSaveImage(Image image, string fileName, long quality, ImageFormat imageFormat)
        {
            var parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

            var imageEncoder = GetEncoder(imageFormat);
            image.Save(fileName, imageEncoder, parameters);
        }


        public static void CompressImage(string soucePath, string destPath, int quality)
        {
            var fileName = Path.GetFileName(soucePath);
            destPath = destPath + "\\" + fileName;

            using var bmp1 = new Bitmap(soucePath);
            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            var qualityEncoder = Encoder.Quality;

            var myEncoderParameters = new EncoderParameters(1);

            var myEncoderParameter = new EncoderParameter(qualityEncoder, quality);

            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(destPath, jpgEncoder, myEncoderParameters);
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        // ImageConverter object used to convert byte arrays containing JPEG or PNG file images into 
        //  Bitmap objects. This is static and only gets instantiated once.
        private static readonly ImageConverter ImageConverter = new();


        /// <summary>
        /// Converts image into Byte array
        /// </summary>
        /// <param name="theImage"></param>
        /// <returns>byte array image of a PNG file containing the image</returns>
        // <returns></returns>
        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using var memoryStream = new MemoryStream();
            theImage.Save(memoryStream, ImageFormat.Png);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Converts Byte Array ino image
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            var bm = (Bitmap)ImageConverter.ConvertFrom(byteArray);

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

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using var graphics = Graphics.FromImage(destImage);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }

            return destImage;
        }
    }
}
