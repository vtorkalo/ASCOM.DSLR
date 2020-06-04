using System;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using ASCOM.Utilities;
using System.Net;
using System.Runtime.CompilerServices;

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

        public const string DllPath32 = "SDK/X86/libraw";

        public const string DllPath64 = "SDK/X64/libraw";

        //public const string DllPath = "SDK/X64/libraw";
        //public const string DllPath = "libraw";

        [DllImport(DllPath32, EntryPoint = "libraw_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_init_32(LibRaw_constructor_flags flags);

        [DllImport(DllPath64, EntryPoint = "libraw_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_init_64(LibRaw_constructor_flags flags);
        
        public static IntPtr libraw_init(LibRaw_constructor_flags flags)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_init_32(flags) : libraw_init_64(flags);
        }
        
        [DllImport(DllPath32, EntryPoint = "libraw_open_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_open_file_32(IntPtr data, string fileName);

        [DllImport(DllPath64, EntryPoint = "libraw_open_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_open_file_64(IntPtr data, string fileName);

        public static int libraw_open_file(IntPtr data, string fileName)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_open_file_32(data, fileName) : libraw_open_file_64(data, fileName);
        }
        
        [DllImport(DllPath32, EntryPoint = "libraw_unpack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_unpack_32(IntPtr data);

        [DllImport(DllPath64, EntryPoint = "libraw_unpack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_unpack_64(IntPtr data);

        public static int libraw_unpack(IntPtr data)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_unpack_32(data) : libraw_unpack_64(data);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_raw2image", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_raw2image_32(IntPtr data);

        [DllImport(DllPath64, EntryPoint = "libraw_raw2image", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_raw2image_64(IntPtr data);

        public static int libraw_raw2image(IntPtr data)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_raw2image_32(data) : libraw_raw2image_64(data);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_subtract_black", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_subtract_black_32(IntPtr data);

        [DllImport(DllPath64, EntryPoint = "libraw_subtract_black", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_subtract_black_64(IntPtr data);

        public static int libraw_subtract_black(IntPtr data)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_subtract_black_32(data) : libraw_subtract_black_64(data);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_close_32(IntPtr data);
                
        [DllImport(DllPath64, EntryPoint = "libraw_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_close_64(IntPtr data);

        public static int libraw_close(IntPtr data)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_close_32(data) : libraw_close_64(data);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_dcraw_process", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_process_32(IntPtr lr);

        [DllImport(DllPath64, EntryPoint = "libraw_dcraw_process", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_process_64(IntPtr lr);

        public static int libraw_dcraw_process(IntPtr lr)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_dcraw_process_32(lr) : libraw_dcraw_process_64(lr);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_dcraw_make_mem_image", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_dcraw_make_mem_image_32(IntPtr data, out int errc);

        [DllImport(DllPath64, EntryPoint = "libraw_dcraw_make_mem_image", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_dcraw_make_mem_image_64(IntPtr data, out int errc);

        public static IntPtr libraw_dcraw_make_mem_image(IntPtr data, out int errc)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_dcraw_make_mem_image_32(data, out errc) : libraw_dcraw_make_mem_image_64(data, out errc);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_dcraw_clear_mem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_clear_mem_32(IntPtr processed);

        [DllImport(DllPath64, EntryPoint = "libraw_dcraw_clear_mem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_dcraw_clear_mem_64(IntPtr processed);

        public static int libraw_dcraw_clear_mem(IntPtr processed)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_dcraw_clear_mem_32(processed) : libraw_dcraw_clear_mem_64(processed);
        }

        [DllImport(DllPath32, EntryPoint = "libraw_set_exifparser_handler", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_set_exifparser_handler_32(IntPtr data, exif_parser_callback cb, IntPtr datap);

        [DllImport(DllPath64, EntryPoint = "libraw_set_exifparser_handler", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libraw_set_exifparser_handler_64(IntPtr data, exif_parser_callback cb, IntPtr datap);

        public static IntPtr libraw_dcraw_clear_mem(IntPtr data, exif_parser_callback cb, IntPtr datap)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_set_exifparser_handler_32(data, cb, datap) : libraw_set_exifparser_handler_64(data, cb, datap);
        }

        public delegate IntPtr exif_parser_callback(IntPtr context, int tag, int type, int len, uint ord, IntPtr ifp);

        [DllImport(DllPath32, EntryPoint = "libraw_COLOR", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_COLOR_32(IntPtr data, int row, int col);

        [DllImport(DllPath64, EntryPoint = "libraw_COLOR", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_COLOR_64(IntPtr data, int row, int col);

        public static int libraw_COLOR(IntPtr data, int row, int col)
        {
            return IntPtr.Size == 4 /* 64bit */ ? libraw_COLOR_32(data, row, col) : libraw_COLOR_64(data, row, col);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_data_t
    {
        public IntPtr image;
        public libraw_image_sizes_t sizes;
        public libraw_iparams_t idata;
        public libraw_lensinfo_t lens;
        public libraw_makernotes_t makernotes;
        public libraw_shootinginfo_t shootinginfo;
        public libraw_output_params_t oparams;
        public uint progress_flags;
        public uint process_warnings;
        public libraw_colordata_t color;
        libraw_imgother_t other;
        // libraw_thumbnail_t thumbnail;
        //libraw_rawdata_t rawdata;
        //IntPtr* parent_class;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_colordata_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10000)] short[] curve;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4102)] uint[] cblack;
        public uint black;
        public uint data_maximum;
        public uint maximum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] int[] linear_max;
        float fmaximum;
        float fnorm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 8)] ushort[] white;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] cam_mul;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] pre_mul;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)] float[] cmatrix;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)] float[] ccm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)] float[] rgb_cam;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 3)] float[] cam_xyz;
        ph1_t phase_one_data;
        float flash_used;
        float canon_ev;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string model2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string UniqueCameraModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string LocalizedCameraModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string ImageUniqueID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)] string RawDataUniqueID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string OriginalRawFileName;
        IntPtr profile;
        uint profile_length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] uint[] black_stat;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] libraw_dng_color_t[] dng_color;
        libraw_dng_levels_t dng_levels;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256 * 4)] int[] WB_Coeffs;    /* R, G1, B, G2 coeffs */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 5)] float[] WBCT_Coeffs; /* CCT, than R, G1, B, G2 coeffs */
        int as_shot_wb_applied;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] libraw_P1_color_t[] P1_color;
        uint raw_bps; /* for Phase One, raw format */
        /* Phase One raw format values, makernotes tag 0x010e:
         * 0    Name unknown
         * 1    "RAW 1"
         * 2    "RAW 2"
         * 3    "IIQ L"
         * 4    Never seen
         * 5    "IIQ S"
         * 6    "IIQ S v.2"
         * 7    Never seen
         * 8    Name unknown
         */
        int ExifColorSpace;
    }

    

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_dng_color_t
    {
        uint parsedfields;
        ushort illuminant;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 4)] float[] calibration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 3)] float[] colormatrix;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)] float[] forwardmatrix;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_P1_color_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)] float[] romm_cam;
    }

    

    [StructLayout(LayoutKind.Sequential)]
    public struct ph1_t
    {
        int format, key_off, tag_21a;
        int t_black, split_col, black_col, split_row, black_row;
        float tag_210;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_dng_levels_t
    {
        uint parsedfields;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4102)] uint[] dng_cblack;
        uint dng_black;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4102)] uint[] dng_fcblack;
        uint dng_fblack;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] dng_whitelevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] default_crop; /* Origin and size */
        uint preview_colorspace;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] analogbalance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] asshotneutral;
        float baseline_exposure;
        float LineResponseLimit;
    }

    

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_shootinginfo_t
    {
        short DriveMode;
        short FocusMode;
        short MeteringMode;
        short AFPoint;
        short ExposureMode;
        short ImageStabilization;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string BodySerial;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] string InternalBodySerial; /* this may be PCB or sensor serial, depends on make/model*/
    }

    

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_internal_output_params_t
    {
        uint mix_green;
        uint raw_color;
        uint zero_is_bad;
        ushort shrink;
        ushort fuji_width;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_gps_info_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] float[] latitude;     /* Deg,min,sec */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] float[] longtitude;     /* Deg,min,sec */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] float[] gpstimestamp;     /* Deg,min,sec */
        float altitude;
        char altref, latref, longref, gpsstatus;
        char gpsparsed;
    }

    public struct libraw_imgother_t
    {
        float iso_speed;
        float shutter;
        float aperture;
        float focal_len;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] timestamp;
        uint shot_order;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] uint[] gpsdata;
        libraw_gps_info_t parsed_gps;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] char[] desc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] artist;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] analogbalance;
    }


[StructLayout(LayoutKind.Sequential)]
    public struct libraw_metadata_common_t {
    float FlashEC;
    float FlashGN;
    float CameraTemperature;
    float SensorTemperature;
    float SensorTemperature2;
    float LensTemperature;
    float AmbientTemperature;
    float BatteryTemperature;
    float exifAmbientTemperature;
    float exifHumidity;
    float exifPressure;
    float exifWaterDepth;
    float exifAcceleration;
    float exifCameraElevationAngle;
    float real_ISO;
    float exifExposureIndex;
    ushort ColorSpace;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] char[] firmware;
}



    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_output_params_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] greybox;   /* -A  x1 y1 x2 y2 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] cropbox;   /* -B x1 y1 x2 y2 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] double[] aber;        /* -C */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] double[] gamm;        /* -g */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] user_mul;     /* -r mul0 mul1 mul2 mul3 */
        uint shot_select;  /* -s */
        float bright;          /* -b */
        float threshold;       /*  -n */
        int half_size;         /* -h */
        int four_color_rgb;    /* -f */
        int highlight;         /* -H */
        int use_auto_wb;       /* -a */
        int use_camera_wb;     /* -w */
        int use_camera_matrix; /* +M/-M */
        int output_color;      /* -o */
        IntPtr output_profile;  /* -o */
        IntPtr camera_profile;  /* -p */
        IntPtr bad_pixels;      /* -P */
        IntPtr dark_frame;      /* -K */
        int output_bps;        /* -4 */
        int output_tiff;       /* -T */
        int user_flip;         /* -t */
        int user_qual;         /* -q */
        int user_black;        /* -k */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] int[] user_cblack;
        int user_sat; /* -S */

        int med_passes; /* -m */
        float auto_bright_thr;
        float adjust_maximum_thr;
        int no_auto_bright;  /* -W */
        int use_fuji_rotate; /* -j */
        int green_matching;
        /* DCB parameters */
        int dcb_iterations;
        int dcb_enhance_fl;
        int fbdd_noiserd;
        int exp_correc;
        float exp_shift;
        float exp_preser;
        /* Raw speed */
        int use_rawspeed;
        /* DNG SDK */
        int use_dngsdk;
        /* Disable Auto-scale */
        int no_auto_scale;
        /* Disable intepolation */
        int no_interpolation;
        /*  int x3f_flags; */
        /* Sony ARW2 digging mode */
        /* int sony_arw2_options; */
        uint raw_processing_options;
        uint max_raw_memory_mb;
        int sony_arw2_posterization_thr;
        /* Nikon Coolscan */
        float coolscan_nef_gamma;
        // TJH: [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] string p4shot_order;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] char[] p4shot_order;
        /* Custom camera list */
        IntPtr custom_camera_strings;
    }
    ;

    // TODO: June 1 2020 - pick up here 

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_makernotes_t
    {
        libraw_canon_makernotes_t canon;
        libraw_nikon_makernotes_t nikon;
        libraw_hasselblad_makernotes_t hasselblad;
        libraw_fuji_info_t fuji;
        libraw_olympus_makernotes_t olympus;
        libraw_sony_info_t sony;
        libraw_kodak_makernotes_t kodak;
        libraw_panasonic_makernotes_t panasonic;
        libraw_pentax_makernotes_t pentax;
        libraw_p1_makernotes_t phaseone;
        libraw_samsung_makernotes_t samsung;
        libraw_metadata_common_t common;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_canon_makernotes_t
    {
        int CanonColorDataVer;
        int CanonColorDataSubVer;
        int SpecularWhiteLevel;
        int NormalWhiteLevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] int[] ChannelBlackLevel;
        int AverageBlackLevel;
        /* multishot */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] multishot;
        /* metering */
        short MeteringMode;
        short SpotMeteringMode;
        byte FlashMeteringMode;
        short FlashExposureLock;
        short ExposureMode;
        short AESetting;
        byte HighlightTonePriority;
        /* stabilization */
        short ImageStabilization;
        /* focus */
        short FocusMode;
        short AFPoint;
        short FocusContinuous;
        short AFPointsInFocus30D;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] byte[] AFPointsInFocus1D;
        ushort AFPointsInFocus5D; /* bytes in reverse*/
                                  /* AFInfo */
        ushort AFAreaMode;
        ushort NumAFPoints;
        ushort ValidAFPoints;
        ushort AFImageWidth;
        ushort AFImageHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)] short[] AFAreaWidths;     /* cycle to NumAFPoints */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)] short[] AFAreaHeights;    /* --''--               */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)] short[] AFAreaXPositions; /* --''--               */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)] short[] AFAreaYPositions; /* --''--               */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] short[] AFPointsInFocus;   /* cycle to floor((NumAFPoints+15)/16) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] short[] AFPointsSelected;  /* --''--               */
        ushort PrimaryAFPoint;
        /* flash */
        short FlashMode;
        short FlashActivity;
        short FlashBits;
        short ManualFlashOutput;
        short FlashOutput;
        short FlashGuideNumber;
        /* drive */
        short ContinuousDrive;
        /* sensor */
        short SensorWidth;
        short SensorHeight;
        short SensorLeftBorder;
        short SensorTopBorder;
        short SensorRightBorder;
        short SensorBottomBorder;
        short BlackMaskLeftBorder;
        short BlackMaskTopBorder;
        short BlackMaskRightBorder;
        short BlackMaskBottomBorder;
        int AFMicroAdjMode;
        float AFMicroAdjValue;
        short MakernotesFlip;
        short RecordMode;
        short SRAWQuality;
        uint wbi;
        float firmware;
        short RF_lensID;

    }
;

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_hasselblad_makernotes_t
    {
        int BaseISO;
        double Gain;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] char[] Sensor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] SensorUnit; // SU
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] HostBody;   // HB
        int SensorCode;
        int SensorSubCode;
        int CoatingCode;
        int uncropped;

        /* CaptureSequenceInitiator is based on the content of the 'model' tag
          - values like 'Pinhole', 'Flash Sync', '500 Mech.' etc in .3FR 'model' tag
            come from MAIN MENU > SETTINGS > Camera;
          - otherwise 'model' contains:
            1. if CF/CFV/CFH, SU enclosure, can be with SU type if '-' is present
            2. else if '-' is present, HB + SU type;
            3. HB;
        */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] char[] CaptureSequenceInitiator;

        /* SensorUnitConnector, makernotes 0x0015 tag:
         - in .3FR - SU side
         - in .FFF - HB side
        */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] SensorUnitConnector;

        int format; // 3FR, FFF, Imacon (H3D-39 and maybe others), Hasselblad/Phocus DNG, Adobe DNG
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] int[] nIFD_CM; // number of IFD containing CM
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] int[] RecommendedCrop;

        /* mnColorMatrix is in makernotes tag 0x002a;
          not present in .3FR files and Imacon/H3D-39 .FFF files;
          when present in .FFF and Phocus .DNG files, it is a copy of CM1 from .3FR;
          available samples contain all '1's in the first 3 elements
        */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 3)] double[] mnColorMatrix;
    };

[StructLayout(LayoutKind.Sequential)]
    public struct libraw_fuji_info_t
    {
        float ExpoMidPointShift;
        ushort DynamicRange;
        ushort FilmMode;
        ushort DynamicRangeSetting;
        ushort DevelopmentDynamicRange;
        ushort AutoDynamicRange;
        ushort DRangePriority;
        ushort DrangePriorityAuto;
        ushort DRangePriorityFixed;
        float BrightnessCompensation;
        ushort FocusMode;
        ushort AFMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] ushort[] FocusPixel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] ushort[] ImageStabilization;
        ushort FlashMode;
        ushort WB_Preset;
        ushort ShutterType;
        ushort ExrMode;
        ushort Macro;
        uint Rating;
        ushort CropMode;
        ushort FrameRate;
        ushort FrameWidth;
        ushort FrameHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0c + 1)] char[] SerialSignature;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 +1 )] char[] RAFVersion;
        ushort RAFDataVersion;
        int isTSNERDTS;
        short DriveMode;
    }

    public struct libraw_sensor_highspeed_crop_t
    {
        ushort cleft;
        ushort ctop;
        ushort cwidth;
        ushort cheight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_nikon_makernotes_t
    {

        double ExposureBracketValue;
        ushort ActiveDLighting;
        ushort ShootingMode;
        /* stabilization */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)] byte[] ImageStabilization;
        byte VibrationReduction;
        byte VRMode;
        /* focus */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)] string FocusMode;
        byte AFPoint;
        ushort AFPointsInFocus;
        byte ContrastDetectAF;
        byte AFAreaMode;
        byte PhaseDetectAF;
        byte PrimaryAFPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 29)] byte[] AFPointsUsed;
        ushort AFImageWidth;
        ushort AFImageHeight;
        ushort AFAreaXPposition;
        ushort AFAreaYPosition;
        ushort AFAreaWidth;
        ushort AFAreaHeight;
        byte ContrastDetectAFInFocus;
        /* flash */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)] string FlashSetting;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)] string FlashType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] FlashExposureCompensation;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] ExternalFlashExposureComp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] FlashExposureBracketValue;
        byte FlashMode;
        sbyte FlashExposureCompensation2;
        sbyte FlashExposureCompensation3;
        sbyte FlashExposureCompensation4;
        byte FlashSource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] byte[] FlashFirmware;
        byte ExternalFlashFlags;
        byte FlashControlCommanderMode;
        byte FlashOutputAndCompensation;
        byte FlashFocalLength;
        byte FlashGNDistance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] FlashGroupControlMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] FlashGroupOutputAndCompensation;
        byte FlashColorFilter;
        ushort NEFCompression;
        int ExposureMode;
        int ExposureProgram;
        int nMEshots;
        int MEgainOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] double[] ME_WB;
        byte AFFineTune;
        byte AFFineTuneIndex;
        byte AFFineTuneAdj;
        uint LensDataVersion;
        uint FlashInfoVersion;
        uint ColorBalanceVersion;
        byte key;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] ushort[] NEFBitDepth;
        ushort HighSpeedCropFormat; /* 1 -> 1.3x; 2 -> DX; 3 -> 5:4; 4 -> 3:2; 6 ->
                                   16:9; 11 -> FX uncropped; 12 -> DX uncropped;
                                   17 -> 1:1 */
        libraw_sensor_highspeed_crop_t SensorHighSpeedCrop;
        ushort SensorWidth;
        ushort SensorHeight;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_olympus_makernotes_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] int[] OlympusSensorCalibration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] ushort[] FocusMode;
        ushort AutoFocus;
        ushort AFPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] uint[] AFAreas;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] double[] AFPointSelected;
        ushort AFResult;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] ushort[] DriveMode;
        ushort ColorSpace;
        byte AFFineTune;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] short[] AFFineTuneAdj;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] char[] CameraType2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_panasonic_makernotes_t
    {
        /* Compression:
         34826 (Panasonic RAW 2): LEICA DIGILUX 2;
         34828 (Panasonic RAW 3): LEICA D-LUX 3; LEICA V-LUX 1; Panasonic DMC-LX1; Panasonic DMC-LX2; Panasonic DMC-FZ30; Panasonic DMC-FZ50;
         34830 (not in exiftool): LEICA DIGILUX 3; Panasonic DMC-L1;
         34316 (Panasonic RAW 1): others (LEICA, Panasonic, YUNEEC);
        */
        ushort Compression;
        ushort BlackLevelDim;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] float[] BlackLevel;
        uint Multishot;
        float gamma;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] int[] HighISOMultiplier;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_pentax_makernotes_t
    {
        ushort FocusMode;
        ushort AFPointSelected;
        uint AFPointsInFocus;
        ushort FocusPosition;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] byte[] DriveMode;
        short AFAdjustment;
        byte MultiExposure;
        ushort Quality;
        /*    byte AFPointMode;     */
        /*    byte SRResult;        */
        /*    byte ShakeReduction;  */
    }

    [StructLayout(LayoutKind.Sequential)]
    struct libraw_samsung_makernotes_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] ImageSizeFull;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] ImageSizeCrop;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] int[] ColorSpace;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)] uint[] key;
        double DigitalGain; /* PostAEGain, digital stretch */
        int DeviceType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] char[] LensFirmware;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_kodak_makernotes_t
    {
        ushort BlackLevelTop;
        ushort BlackLevelBottom;
        short offset_left, offset_top; /* KDC files, negative values or zeros */
        ushort clipBlack, clipWhite;   /* valid for P712, P850, P880 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camDaylight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camTungsten;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camFluorescent;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camFlash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camCustom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 3)] float[] romm_camAuto;
        ushort val018percent, val100percent, val170percent;
        short MakerNoteKodak8a;
        float ISOCalibrationGain;
        float AnalogISO;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_p1_makernotes_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] Software;        // tag 0x0203
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] SystemType;      // tag 0x0204
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] char[] FirmwareString; // tag 0x0301
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] char[] SystemModel;
    }


    [StructLayout(LayoutKind.Sequential)]

    public struct libraw_sony_info_t
    {
        ushort CameraType;
        byte Sony0x9400_version; /* 0 if not found/deciphered, 0xa, 0xb, 0xc following exiftool convention */
        byte Sony0x9400_ReleaseMode2;
        uint Sony0x9400_SequenceImageNumber;
        byte Sony0x9400_SequenceLength1;
        uint Sony0x9400_SequenceFileNumber;
        byte Sony0x9400_SequenceLength2;
        byte AFAreaModeSetting;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] ushort[] FlexibleSpotPosition;
        byte AFPointSelected;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] byte[] AFPointsUsed;
        byte AFTracking;
        byte AFType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] ushort[] FocusLocation;
        byte AFMicroAdjValue;
        byte AFMicroAdjOn;
        byte AFMicroAdjRegisteredLenses;
        ushort group2010;
        ushort real_iso_offset;
        float firmware;
        ushort ImageCount3_offset;
        uint ImageCount3;
        uint ElectronicFrontCurtainShutter;
        ushort MeteringMode2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)] string SonyDateTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] byte[] TimeStamp;
        uint ShotNumberSincePowerUp;
        ushort PixelShiftGroupPrefix;
        uint PixelShiftGroupID;
        char nShotsInPixelShiftGroup;
        char numInPixelShiftGroup; /* '0' if ARQ, first shot in the group has '1'
                                  here */
        ushort prd_ImageHeight, prd_ImageWidth;
        ushort prd_RawBitDepth;
        ushort prd_StorageMethod; /* 82 -> Padded; 89 -> Linear */
        ushort prd_BayerPattern;  /* 0 -> not valid; 1 -> RGGB; 4 -> GBRG */

        ushort SonyRawFileType; /* takes precedence over RAWFileType and Quality:
                               0  for uncompressed 14-bit raw
                               1  for uncompressed 12-bit raw
                               2  for compressed raw
                               3  for lossless compressed raw
                            */
        ushort RAWFileType;     /* takes precedence over Quality
                               0 for compressed raw, 1 for uncompressed;
                            */
        uint Quality;       /* 0 or 6 for raw, 7 or 8 for compressed raw */
        ushort FileFormat;      /*  1000 SR2
                                2000 ARW 1.0
                                3000 ARW 2.0
                                3100 ARW 2.1
                                3200 ARW 2.2
                                3300 ARW 2.3
                                3310 ARW 2.3.1
                                3320 ARW 2.3.2
                                3330 ARW 2.3.3
                                3350 ARW 2.3.5
                             */
    };

    // got to here

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_raw_inset_crop_t
    {
        ushort cleft, ctop, cwidth, cheight, aspect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_thumbnail_t
    {
        int /* enum LibRaw_thumbnail_formats*/ tformat;
        ushort twidth, theight;
        uint tlength;
        int tcolors;
        IntPtr thumb;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_lensinfo_t
    {
        float MinFocal, MaxFocal, MaxAp4MinFocal, MaxAp4MaxFocal, EXIF_MaxAp;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string LensMake;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string Lens;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string LensSerial;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string InternalLensSerial;
        ushort FocalLengthIn35mmFormat;
        libraw_nikonlens_t nikon;
        libraw_dnglens_t dng;
        libraw_makernotes_lens_t makernotes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_nikonlens_t
    {
        float NikonEffectiveMaxAp;
        byte NikonLensIDNumber, NikonLensFStops, NikonMCUVersion, NikonLensType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_makernotes_lens_t
    {
        ulong LensID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string Lens;
        ushort LensFormat; /* to characterize the image circle the lens covers */
        ushort LensMount; /* 'male', lens itself */
        ulong CamID;
        ushort CameraFormat; /* some of the sensor formats */
        ushort CameraMount; /* 'female', body throat */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        string body;
        short FocalType; /* -1/0 is unknown; 1 is fixed focal; 2 is zoom */

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        string LensFeatures_pre;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        string LensFeatures_suf;
        float MinFocal, MaxFocal;
        float MaxAp4MinFocal, MaxAp4MaxFocal, MinAp4MinFocal, MinAp4MaxFocal;
        float MaxAp, MinAp;
        float CurFocal, CurAp;
        float MaxAp4CurFocal, MinAp4CurFocal;
        float MinFocusDistance;
        float FocusRangeIndex;
        float LensFStops;
        ulong TeleconverterID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string Teleconverter;
        ulong AdapterID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string Adapter;
        ulong AttachmentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string Attachment;
        ushort CanonFocalUnits;
        float FocalLengthIn35mmFormat;
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_dnglens_t
    {
        float MinFocal, MaxFocal, MaxAp4MinFocal, MaxAp4MaxFocal;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_iparams_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string guard;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string make;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string model;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string software;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string normalized_make;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string normalized_model;

        public uint maker_index;

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


        uint xmplen;
        IntPtr xmpdata;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_image_sizes_t
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
        libraw_raw_inset_crop_t raw_inset_crop;
    }
}
