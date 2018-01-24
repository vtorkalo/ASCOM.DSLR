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

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_COLOR(IntPtr data, int row, int col);
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_data_t
    {
        public IntPtr image;
        public libraw_image_sizes_t sizes;
        public libraw_iparams_t idata;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_iparams_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string guard;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string make;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string model;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string software;

        public uint raw_count;

        public uint dng_version;

        public uint is_foveon;

        public int colors;

        public uint filters;


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 * 6)]
        public char[] xtrans;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 * 6)]
        public char[] xtrans_abs; 

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cdesc;

        
        //      unsigned xmplen; - TODO add c#
        //      char* xmpdata;
    }

        [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_image_sizes_t
    {
        public ushort raw_height;

        public ushort raw_width;

        public ushort height;

        public ushort width;

        public ushort top_margin;

        public ushort left_margin;

        public ushort iheight;

        public ushort iwidth;

        public uint raw_pitch;

        public double pixel_aspect;

        public int flip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 4)]
        public int[] mask;

    }
}
