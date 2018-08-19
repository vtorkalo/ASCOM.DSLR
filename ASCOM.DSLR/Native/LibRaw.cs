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
        public static extern IntPtr libraw_set_exifparser_handler(IntPtr data, exif_parser_callback cb, IntPtr datap);


        public delegate IntPtr exif_parser_callback(IntPtr context, int tag, int type, int len, uint ord, IntPtr ifp);

        [DllImport("libraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libraw_COLOR(IntPtr data, int row, int col);
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
        //libraw_imgother_t other;
        //libraw_thumbnail_t thumbnail;
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
        IntPtr profile;
        uint profile_length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] uint[] black_stat;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] libraw_dng_color_t[] dng_color;
        libraw_dng_levels_t dng_levels;
        float baseline_exposure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256 * 4)] int[] WB_Coeffs;    /* R, G1, B, G2 coeffs */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 5)] float[] WBCT_Coeffs; /* CCT, than R, G1, B, G2 coeffs */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] libraw_P1_color_t[] P1_color;
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] dng_whitelevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] uint[] default_crop; /* Origin and size */
        uint preview_colorspace;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] float[] analogbalance;
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
        int sony_arw2_posterization_thr;
        /* Nikon Coolscan */
        float coolscan_nef_gamma;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] char[] p4shot_order;
        /* Custom camera list */
        IntPtr custom_camera_strings;
    }
    ;

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

    }
;

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_hasselblad_makernotes_t
    {
        int BaseISO;
        double Gain;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_fuji_info_t
    {
        float FujiExpoMidPointShift;
        ushort FujiDynamicRange;
        ushort FujiFilmMode;
        ushort FujiDynamicRangeSetting;
        ushort FujiDevelopmentDynamicRange;
        ushort FujiAutoDynamicRange;
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
        ushort FrameRate;
        ushort FrameWidth;
        ushort FrameHeight;
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
        int nMEshots;
        int MEgainOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] double[] ME_WB;
        byte AFFineTune;
        byte AFFineTuneIndex;
        byte AFFineTuneAdj;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_olympus_makernotes_t
    {
        int OlympusCropID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] ushort[] OlympusFrame; /* upper left XY, lower right XY */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] int[] OlympusSensorCalibration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] ushort[] FocusMode;
        ushort AutoFocus;
        ushort AFPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] uint[] AFAreas;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] double[] AFPointSelected;
        ushort AFResult;
        uint ImageStabilization;
        ushort ColorSpace;
        byte AFFineTune;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] short[] AFFineTuneAdj;
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
        /*    byte AFPointMode;     */
        /*    byte SRResult;        */
        /*    byte ShakeReduction;  */
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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_sony_info_t
    {
        ushort SonyCameraType;
        byte Sony0x9400_version; /* 0 if not found/deciphered, 0xa, 0xb, 0xc following exiftool convention */
        byte Sony0x9400_ReleaseMode2;
        uint Sony0x9400_SequenceImageNumber;
        byte Sony0x9400_SequenceLength1;
        uint Sony0x9400_SequenceFileNumber;
        byte Sony0x9400_SequenceLength2;
        libraw_raw_crop_t raw_crop;
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
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_raw_crop_t
    {
        ushort cleft, ctop, cwidth, cheight;
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
        libraw_raw_crop_t raw_crop;
    }
}
