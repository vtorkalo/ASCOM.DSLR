using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ASCOM.DSLR.Native
{

    [Flags]
    internal enum LibRaw_constructor_flags
    {
        LIBRAW_OPTIONS_NONE = 0,
        LIBRAW_OPIONS_NO_MEMERR_CALLBACK = 1,
        LIBRAW_OPIONS_NO_DATAERR_CALLBACK = 1 << 1
    }

    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_init(LibRaw_constructor_flags flags);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_open_file(IntPtr data, string fileName);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_unpack(IntPtr data);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_raw2image(IntPtr data);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_subtract_black(IntPtr data);


        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_close(IntPtr data);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_process(IntPtr lr);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_dcraw_make_mem_image(IntPtr data, out int errc);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_clear_mem(IntPtr processed);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libraw_set_exifparser_handler(IntPtr data, exif_parser_callback cb, IntPtr datap);
        

        public delegate void exif_parser_callback(IntPtr context, int tag, int type, int len, uint ord, IntPtr ifp);

     //   DllDef void libraw_set_exifparser_handler(libraw_data_t*, exif_parser_callback cb, void* datap);
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_data_t
    {
        //  public ushort image;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr image;



        public libraw_image_sizes_t sizes;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_image_sizes_t
    {
        /// <summary>Full height of RAW image (including the frame) in pixels.</summary>
        public ushort raw_height;

        /// <summary>Full width of RAW image (including the frame) in pixels.</summary>
        public ushort raw_width;

        /// <summary>Height of visible ("meaningful") part of the image (without the frame).</summary> 
        public ushort height;

        /// <summary>Width of visible ("meaningful") part of the image (without the frame).</summary>
        public ushort width;

        /// <summary>
        /// Coordinate of the top left corner of the frame (the second corner is
        /// calculated from the full size of the image and size of its visible part).
        /// </summary>
        public ushort top_margin;

        /// <summary>
        /// Coordinate of the top left corner of the frame (the second corner is
        /// calculated from the full size of the image and size of its visible part).
        /// </summary>
        public ushort left_margin;

        /// <summary>
        /// Height of the output image (may differ from height for cameras that require
        /// image rotation or have non-square pixels).
        /// </summary>
        public ushort iheight;

        /// <summary>
        /// Width of the output image (may differ from width for cameras that require
        /// image rotation or have non-square pixels).
        /// </summary>
        public ushort iwidth;

        /// <summary>
        /// Pixel width/height ratio. If it is not unity, scaling of the image along 
        /// one of the axes is required during output.
        /// </summary>
        public double pixel_aspect;

        /// <summary>
        /// Image orientation (
        ///     0 if does not require rotation;
        ///     3 if requires 180-deg rotation;
        ///     5 if 90 deg counterclockwise,
        ///     6 if 90 deg clockwise
        /// ).
        /// </summary>
        public int flip;

        /// <summary> Width (in pixels) of right part of masked pixels area.</summary>
        public ushort right_margin;

        /// <summary> Width (in pixels) of bottom part of masked pixels area.</summary>
        public ushort bottom_margin;
    }
}
