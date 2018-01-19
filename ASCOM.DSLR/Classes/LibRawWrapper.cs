using ASCOM.DSLR.Native;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ASCOM.DSLR.Classes
{
    public class LibRawWrapper
    {
        private T GetStructure<T>(IntPtr ptr)
         where T : struct
        {
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }

        private IntPtr LoadRaw(string fileName)
        {
            IntPtr data = NativeMethods.libraw_init(LibRaw_constructor_flags.LIBRAW_OPIONS_NO_DATAERR_CALLBACK);
            //NativeMethods.libraw_set_exifparser_handler(data, exif_parser_callback, data);
            NativeMethods.libraw_open_file(data, fileName);
            NativeMethods.libraw_unpack(data);
            NativeMethods.libraw_raw2image(data);
            NativeMethods.libraw_subtract_black(data);

            return data;
        }

        public int[,,] ReadAndDebayerRaw(string fileName)
        {
            IntPtr data = LoadRaw(fileName);
            NativeMethods.libraw_dcraw_process(data);

            var dataStructure = GetStructure<libraw_data_t>(data);
            ushort width = dataStructure.sizes.iwidth;
            ushort height = dataStructure.sizes.iheight;

            var pixels = new int[width, height, 3];

            for (int rc = 0; rc < height * width; rc++)
            {
                var r = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8);
                var g = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8 + 2);
                var b = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8 + 4);

                int row = rc / width;
                int col = rc - width * row;
                int rowReversed = height - row - 1;
                pixels[col, rowReversed, 0] = b;
                pixels[col, rowReversed, 1] = g;
                pixels[col, rowReversed, 2] = r;
            }
            NativeMethods.libraw_close(data);

            return pixels;
        }

        public int[,,] ReadJpeg(string fileName)
        {
            Bitmap img = new Bitmap(fileName);
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);
            IntPtr ptr = data.Scan0;
            int bytesCount = Math.Abs(data.Stride) * img.Height;
            var result = new int[img.Width, img.Height, 3];

            byte[] bytesArray = new byte[bytesCount];
            Marshal.Copy(ptr, bytesArray, 0, bytesCount);
            img.UnlockBits(data);

            var width = img.Width;
            var height = img.Height;

            for (int rc = 0; rc < width * height; rc++)
            {
                var r = bytesArray[rc * 3];
                var g = bytesArray[rc * 3 + 1];
                var b = bytesArray[rc * 3 + 2];

                int row = rc / width;
                int col = rc - width * row;

                var rowReversed = height - row - 1;
                result[col, rowReversed, 0] = b;
                result[col, rowReversed, 1] = g;
                result[col, rowReversed, 2] = r;
            }

            return result;
        }

        private void exif_parser_callback(IntPtr context, int tag, int type, int len, uint ord, IntPtr ifp)
        {

        }

        public int[,] ReadRaw(string fileName)
        {
            IntPtr data = LoadRaw(fileName);

            var dataStructure = GetStructure<libraw_data_t>(data);


            var pixels = new int[dataStructure.sizes.iwidth, dataStructure.sizes.iheight];
            ushort width = dataStructure.sizes.iwidth;
            ushort height = dataStructure.sizes.iheight;

            for (int rc = 0; rc < width * height; rc++)
            {
                var r = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8);
                var g = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8 + 2);
                var b = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8 + 4);
                var g2 = (ushort)Marshal.ReadInt16(dataStructure.image, rc * 8 + 6);
                
                int row = rc / width;
                int col = rc - width * row;
          
                if (row % 2 == 0 && col % 2 == 0)
                {
                    pixels[col, row] = r;
                }
                else if (row % 2 == 0 && col % 2 == 1)
                {
                    pixels[col, row] = g;
                }
                else if (row % 2 == 1 && col % 2 == 0)
                {
                    pixels[col, row] = g2;
                }
                else if (row % 2 == 1 && col % 2 == 1)
                {
                    pixels[col, row] = b;
                }

            }
            NativeMethods.libraw_close(data);

            return pixels;
        }
    }
}
