//To disable all the compiler warnings about the missing documentation of enum members
#pragma warning disable 1591

namespace EOSDigital.SDK
{
    /// <summary>
    /// Error Codes
    /// </summary>
    public enum ErrorCode : int
    {
        /// <summary>
        /// ED-SDK Function Success Code
        /// </summary>
        OK = 0x00000000,

        #region EDSDK Error Code Masks

        ISSPECIFIC_MASK = unchecked((int)0x80000000),
        COMPONENTID_MASK = 0x7F000000,
        RESERVED_MASK = 0x00FF0000,
        ERRORID_MASK = 0x0000FFFF,

        #endregion

        #region EDSDK Base Component IDs

        CMP_ID_CLIENT_COMPONENTID = 0x01000000,
        CMP_ID_LLSDK_COMPONENTID = 0x02000000,
        CMP_ID_HLSDK_COMPONENTID = 0x03000000,

        #endregion

        #region EDSDK Generic Error IDs

        #region Miscellaneous errors

        UNIMPLEMENTED = 0x00000001,
        INTERNAL_ERROR = 0x00000002,
        MEM_ALLOC_FAILED = 0x00000003,
        MEM_FREE_FAILED = 0x00000004,
        OPERATION_CANCELLED = 0x00000005,
        INCOMPATIBLE_VERSION = 0x00000006,
        NOT_SUPPORTED = 0x00000007,
        UNEXPECTED_EXCEPTION = 0x00000008,
        PROTECTION_VIOLATION = 0x00000009,
        MISSING_SUBCOMPONENT = 0x0000000A,
        SELECTION_UNAVAILABLE = 0x0000000B,

        #endregion

        #region File errors

        FILE_IO_ERROR = 0x00000020,
        FILE_TOO_MANY_OPEN = 0x00000021,
        FILE_NOT_FOUND = 0x00000022,
        FILE_OPEN_ERROR = 0x00000023,
        FILE_CLOSE_ERROR = 0x00000024,
        FILE_SEEK_ERROR = 0x00000025,
        FILE_TELL_ERROR = 0x00000026,
        FILE_READ_ERROR = 0x00000027,
        FILE_WRITE_ERROR = 0x00000028,
        FILE_PERMISSION_ERROR = 0x00000029,
        FILE_DISK_FULL_ERROR = 0x0000002A,
        FILE_ALREADY_EXISTS = 0x0000002B,
        FILE_FORMAT_UNRECOGNIZED = 0x0000002C,
        FILE_DATA_CORRUPT = 0x0000002D,
        FILE_NAMING_NA = 0x0000002E,

        #endregion

        #region Directory errors

        DIR_NOT_FOUND = 0x00000040,
        DIR_IO_ERROR = 0x00000041,
        DIR_ENTRY_NOT_FOUND = 0x00000042,
        DIR_ENTRY_EXISTS = 0x00000043,
        DIR_NOT_EMPTY = 0x00000044,

        #endregion

        #region Property errors

        PROPERTIES_UNAVAILABLE = 0x00000050,
        PROPERTIES_MISMATCH = 0x00000051,
        PROPERTIES_NOT_LOADED = 0x00000053,

        #endregion

        #region Function Parameter errors

        INVALID_PARAMETER = 0x00000060,
        INVALID_HANDLE = 0x00000061,
        INVALID_POINTER = 0x00000062,
        INVALID_INDEX = 0x00000063,
        INVALID_LENGTH = 0x00000064,
        INVALID_FN_POINTER = 0x00000065,
        INVALID_SORT_FN = 0x00000066,

        #endregion

        #region Device errors

        DEVICE_NOT_FOUND = 0x00000080,
        DEVICE_BUSY = 0x00000081,
        DEVICE_INVALID = 0x00000082,
        DEVICE_EMERGENCY = 0x00000083,
        DEVICE_MEMORY_FULL = 0x00000084,
        DEVICE_INTERNAL_ERROR = 0x00000085,
        DEVICE_INVALID_PARAMETER = 0x00000086,
        DEVICE_NO_DISK = 0x00000087,
        DEVICE_DISK_ERROR = 0x00000088,
        DEVICE_CF_GATE_CHANGED = 0x00000089,
        DEVICE_DIAL_CHANGED = 0x0000008A,
        DEVICE_NOT_INSTALLED = 0x0000008B,
        DEVICE_STAY_AWAKE = 0x0000008C,
        DEVICE_NOT_RELEASED = 0x0000008D,

        #endregion

        #region Stream errors

        STREAM_IO_ERROR = 0x000000A0,
        STREAM_NOT_OPEN = 0x000000A1,
        STREAM_ALREADY_OPEN = 0x000000A2,
        STREAM_OPEN_ERROR = 0x000000A3,
        STREAM_CLOSE_ERROR = 0x000000A4,
        STREAM_SEEK_ERROR = 0x000000A5,
        STREAM_TELL_ERROR = 0x000000A6,
        STREAM_READ_ERROR = 0x000000A7,
        STREAM_WRITE_ERROR = 0x000000A8,
        STREAM_PERMISSION_ERROR = 0x000000A9,
        STREAM_COULDNT_BEGIN_THREAD = 0x000000AA,
        STREAM_BAD_OPTIONS = 0x000000AB,
        STREAM_END_OF_STREAM = 0x000000AC,

        #endregion

        #region Communications errors

        COMM_PORT_IS_IN_USE = 0x000000C0,
        COMM_DISCONNECTED = 0x000000C1,
        COMM_DEVICE_INCOMPATIBLE = 0x000000C2,
        COMM_BUFFER_FULL = 0x000000C3,
        COMM_USB_BUS_ERR = 0x000000C4,

        #endregion

        #region Lock/Unlock

        USB_DEVICE_LOCK_ERROR = 0x000000D0,
        USB_DEVICE_UNLOCK_ERROR = 0x000000D1,

        #endregion

        #region STI/WIA

        STI_UNKNOWN_ERROR = 0x000000E0,
        STI_INTERNAL_ERROR = 0x000000E1,
        STI_DEVICE_CREATE_ERROR = 0x000000E2,
        STI_DEVICE_RELEASE_ERROR = 0x000000E3,
        DEVICE_NOT_LAUNCHED = 0x000000E4,

        ENUM_NA = 0x000000F0,
        INVALID_FN_CALL = 0x000000F1,
        HANDLE_NOT_FOUND = 0x000000F2,
        INVALID_ID = 0x000000F3,
        WAIT_TIMEOUT_ERROR = 0x000000F4,

        #endregion

        #region PTP

        SESSION_NOT_OPEN = 0x00002003,
        INVALID_TRANSACTIONID = 0x00002004,
        INCOMPLETE_TRANSFER = 0x00002007,
        INVALID_STRAGEID = 0x00002008,
        DEVICEPROP_NOT_SUPPORTED = 0x0000200A,
        INVALID_OBJECTFORMATCODE = 0x0000200B,
        SELF_TEST_FAILED = 0x00002011,
        PARTIAL_DELETION = 0x00002012,
        SPECIFICATION_BY_FORMAT_UNSUPPORTED = 0x00002014,
        NO_VALID_OBJECTINFO = 0x00002015,
        INVALID_CODE_FORMAT = 0x00002016,
        UNKNOWN_VENDOR_CODE = 0x00002017,
        CAPTURE_ALREADY_TERMINATED = 0x00002018,
        INVALID_PARENTOBJECT = 0x0000201A,
        INVALID_DEVICEPROP_FORMAT = 0x0000201B,
        INVALID_DEVICEPROP_VALUE = 0x0000201C,
        SESSION_ALREADY_OPEN = 0x0000201E,
        TRANSACTION_CANCELLED = 0x0000201F,
        SPECIFICATION_OF_DESTINATION_UNSUPPORTED = 0x00002020,
        NOT_CAMERA_SUPPORT_SDK_VERSION = 0x00002021,
        #endregion

        #region PTP Vendor

        UNKNOWN_COMMAND = 0x0000A001,
        OPERATION_REFUSED = 0x0000A005,
        LENS_COVER_CLOSE = 0x0000A006,
        LOW_BATTERY = 0x0000A101,
        OBJECT_NOTREADY = 0x0000A102,
        CANNOT_MAKE_OBJECT = 0x0000A104,
        MEMORYSTATUS_NOTREADY = 0x0000A106,

        #endregion

        #region Take Picture errors

        TAKE_PICTURE_AF_NG = 0x00008D01,
        TAKE_PICTURE_RESERVED = 0x00008D02,
        TAKE_PICTURE_MIRROR_UP_NG = 0x00008D03,
        TAKE_PICTURE_SENSOR_CLEANING_NG = 0x00008D04,
        TAKE_PICTURE_SILENCE_NG = 0x00008D05,
        TAKE_PICTURE_NO_CARD_NG = 0x00008D06,
        TAKE_PICTURE_CARD_NG = 0x00008D07,
        TAKE_PICTURE_CARD_PROTECT_NG = 0x00008D08,
        TAKE_PICTURE_MOVIE_CROP_NG = 0x00008D09,
        TAKE_PICTURE_STROBO_CHARGE_NG = 0x00008D0A,
        TAKE_PICTURE_NO_LENS_NG = 0x00008D0B,
        TAKE_PICTURE_SPECIAL_MOVIE_MODE_NG = 0x00008D0C,
        TAKE_PICTURE_LV_REL_PROHIBIT_MODE_NG = 0x00008D0D,

        #endregion

        LAST_GENERIC_ERROR_PLUS_ONE = 0x000000F5,

        #endregion
    }

    /// <summary>
    /// SDK Data Types
    /// </summary>
    public enum DataType : int
    {
        Unknown = 0,
        Bool = 1,
        String = 2,
        Int8 = 3,
        UInt8 = 6,
        Int16 = 4,
        UInt16 = 7,
        Int32 = 8,
        UInt32 = 9,
        Int64 = 10,
        UInt64 = 11,
        Float = 12,
        Double = 13,
        ByteBlock = 14,
        Rational = 20,
        Point = 21,
        Rect = 22,
        Time = 23,

        Bool_Array = 30,
        Int8_Array = 31,
        Int16_Array = 32,
        Int32_Array = 33,
        UInt8_Array = 34,
        UInt16_Array = 35,
        UInt32_Array = 36,
        Rational_Array = 37,

        FocusInfo = 101,
        PictureStyleDesc = 102,
    }

    /// <summary>
    /// Property IDs
    /// </summary>
    public enum PropertyID : int
    {
        Unknown = 0x0000FFFF,

        ProductName = 0x00000002,
        OwnerName = 0x00000004,
        MakerName = 0x00000005,
        DateTime = 0x00000006,
        FirmwareVersion = 0x00000007,
        BatteryLevel = 0x00000008,
        CFn = 0x00000009,
        SaveTo = 0x0000000b,
        CurrentStorage = 0x0000000c,
        CurrentFolder = 0x0000000d,
        MyMenu = 0x0000000e,
        BatteryQuality = 0x00000010,
        BodyIDEx = 0x00000015,
        HDDirectoryStructure = 0x00000020,

        //Image Properties
        ImageQuality = 0x00000100,
        JpegQuality = 0x00000101,
        Orientation = 0x00000102,
        ICCProfile = 0x00000103,
        FocusInfo = 0x00000104,
        DigitalExposure = 0x00000105,
        WhiteBalance = 0x00000106,
        ColorTemperature = 0x00000107,
        WhiteBalanceShift = 0x00000108,
        Contrast = 0x00000109,
        ColorSaturation = 0x0000010a,
        ColorTone = 0x0000010b,
        Sharpness = 0x0000010c,
        ColorSpace = 0x0000010d,
        ToneCurve = 0x0000010e,
        PhotoEffect = 0x0000010f,
        FilterEffect = 0x00000110,
        ToningEffect = 0x00000111,
        ParameterSet = 0x00000112,
        ColorMatrix = 0x00000113,
        PictureStyle = 0x00000114,
        PictureStyleDesc = 0x00000115,
        PictureStyleCaption = 0x00000200,

        //Image Processing Properties
        Linear = 0x00000300,
        ClickWBPoint = 0x00000301,
        WBCoeffs = 0x00000302,

        //Image GPS Properties
        GPSVersionID = 0x00000800,
        GPSLatitudeRef = 0x00000801,
        GPSLatitude = 0x00000802,
        GPSLongitudeRef = 0x00000803,
        GPSLongitude = 0x00000804,
        GPSAltitudeRef = 0x00000805,
        GPSAltitude = 0x00000806,
        GPSTimeStamp = 0x00000807,
        GPSSatellites = 0x00000808,
        GPSStatus = 0x00000809,
        GPSMapDatum = 0x00000812,
        GPSDateStamp = 0x0000081D,

        //Property Mask
        AtCapture_Flag = unchecked((int)0x80000000),

        //Capture Properties
        AEMode = 0x00000400,
        DriveMode = 0x00000401,
        ISO = 0x00000402,
        MeteringMode = 0x00000403,
        AFMode = 0x00000404,
        Av = 0x00000405,
        Tv = 0x00000406,
        ExposureCompensation = 0x00000407,
        FlashCompensation = 0x00000408,
        FocalLength = 0x00000409,
        AvailableShots = 0x0000040a,
        Bracket = 0x0000040b,
        WhiteBalanceBracket = 0x0000040c,
        LensName = 0x0000040d,
        AEBracket = 0x0000040e,
        FEBracket = 0x0000040f,
        ISOBracket = 0x00000410,
        NoiseReduction = 0x00000411,
        FlashOn = 0x00000412,
        RedEye = 0x00000413,
        FlashMode = 0x00000414,
        LensStatus = 0x00000416,
        Artist = 0x00000418,
        Copyright = 0x00000419,
        DepthOfField = 0x0000041b,
        EFCompensation = 0x0000041e,
        AEModeSelect = 0x00000436,

        //EVF Properties
        Evf_OutputDevice = 0x00000500,
        Evf_Mode = 0x00000501,
        Evf_WhiteBalance = 0x00000502,
        Evf_ColorTemperature = 0x00000503,
        Evf_DepthOfFieldPreview = 0x00000504,

        //EVF IMAGE DATA Properties
        Evf_Zoom = 0x00000507,
        Evf_ZoomPosition = 0x00000508,
        Evf_FocusAid = 0x00000509,
        Evf_ImagePosition = 0x0000050B,
        Evf_HistogramStatus = 0x0000050C,
        Evf_AFMode = 0x0000050E,

        Record = 0x00000510,

        Evf_HistogramY = 0x00000515,
        Evf_HistogramR = 0x00000516,
        Evf_HistogramG = 0x00000517,
        Evf_HistogramB = 0x00000518,

        Evf_CoordinateSystem = 0x00000540,
        Evf_ZoomRect = 0x00000541,
        Evf_ImageClipRect = 0x00000545,
    }

    /// <summary>
    /// MyMenu IDs
    /// </summary>
    public enum MyMenuID : int
    {
        Quality = 11,
        RedEye = 12,
        Beep = 8,
        Shoot_WO_Card = 9,
        ReviewTime = 7,
        AEB = 13,
        Whitebalance = 0,
        CustomWB = 15,
        WBShift_BKT = 2,
        Colorspace = 3,
        PictureStyle = 4,
        DustDeleteData = 10,
        ProtectImages = 65536,
        Rotate = 65537,
        EraseImages = 65538,
        PrintOrder = 65539,
        TransferOrder = 65540,
        HighlightAlert = 65543,
        AFPointDisplay = 65544,
        Histogram = 65545,
        AutoPlay = 65548,
        AutoPowerOff = 131072,
        FileNumbering = 131074,
        AutoRotate = 131076,
        InfoButton = 131091,
        Format = 131093,
        LCDBrigthness = 131078,
        DateTime = 131079,
        Language = 131080,
        Videosystem = 131081,
        SensorCleaning = 131088,
        LiveViewFunctionSettings = 131083,
        FlashControl = 131094,
        CameraUserSettings = 131095,
        ClearAllCameraSettings = 131087,
        FirmwareVersion = 131089,
        CFnI_Exposure = 196608,
        CFnII_Image = 196614,
        CFn_III_AutoFocus_Drive = 196610,
        CFnIV_Operation_Others196611,
        ClearAllCFn = 196612,
        ExposureLevelIncrements = 262144,
        ISOSpeedSettingsIncrements = 262145,
        ISOExpansion = 262159,
        BracketingAutoCancel = 262147,
        BracketingSequence = 262148,
        SafetyShift = 262151,
        FlashSyncSpeenInAvMode = 262158,
        LongExpNoiseReduction = 327680,
        HighISOSpeedNoiseReduction = 327681,
        HighlightTonePriority = 327682,
        LensDriveWhenAFImpossible = 393220,
        LensAFStopButtonFunction = 393221,
        AFPointSelectionMethod = 393235,
        SuperimposedDisplay393236,
        AFAssistBeamFiring = 393229,
        AFDuringLiveViewShooting = 393233,
        MirrorLockup = 393230,
        ShutterButton_AFONButton = 458752,
        AFON_AELockButtonSwitch = 458753,
        SetButtonWhenShooting = 458755,
        DialDirectionDuringTv_Av = 458757,
        FocusingScreen = 458762,
        AddOriginalDecisionData = 458766,
        LiveViewExposureSimulation = 458767,
        NotSet = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Camera Commands
    /// </summary>
    public enum CameraCommand : int
    {
        TakePicture = 0x00000000,
        ExtendShutDownTimer = 0x00000001,
        BulbStart = 0x00000002,
        BulbEnd = 0x00000003,
        PressShutterButton = 0x00000004,
        DoEvfAf = 0x00000102,
        DriveLensEvf = 0x00000103,
        DoClickWBEvf = 0x00000104,
    }

    /// <summary>
    /// Shutter Button State
    /// </summary>
    public enum ShutterButton : int
    {
        OFF = 0x00000000,
        Halfway = 0x00000001,
        Completely = 0x00000003,
        Halfway_NonAF = 0x00010001,
        Completely_NonAF = 0x00010003,
    }

    /// <summary>
    /// Camera Status
    /// </summary>
    public enum CameraStatusCommand : int
    {
        UILock = 0x00000000,
        UIUnLock = 0x00000001,
        EnterDirectTransfer = 0x00000002,
        ExitDirectTransfer = 0x00000003,
    }

    /// <summary>
    /// Property Event IDs
    /// </summary>
    public enum PropertyEventID : int
    {
        /// <summary>
        /// Notifies all property events.
        /// </summary>
        All = 0x00000100,
        /// <summary>
        /// Notifies that a camera property value has been changed. 
        /// The changed property can be retrieved from event data. 
        /// The changed value can be retrieved by means of EdsGetPropertyData. 
        /// In the case of type 1 protocol standard cameras, 
        /// notification of changed properties can only be issued for custom functions (CFn). 
        /// If the property type is 0x0000FFFF, the changed property cannot be identified. 
        /// Thus, retrieve all required properties repeatedly.
        /// </summary>
        PropertyChanged = 0x00000101,
        /// <summary>
        /// Notifies of changes in the list of camera properties with configurable values. 
        /// The list of configurable values for property IDs indicated in event data 
        /// can be retrieved by means of EdsGetPropertyDesc. 
        /// For type 1 protocol standard cameras, the property ID is identified as "Unknown"
        /// during notification. 
        /// Thus, you must retrieve a list of configurable values for all properties and
        /// retrieve the property values repeatedly. 
        /// (For details on properties for which you can retrieve a list of configurable
        /// properties, see the description of EdsGetPropertyDesc). 
        /// </summary>
        PropertyDescChanged = 0x00000102,
    }

    /// <summary>
    /// Object Event IDs
    /// </summary>
    public enum ObjectEventID : int
    {
        /// <summary>
        /// Notifies all object events.
        /// </summary>
        All = 0x00000200,
        /// <summary>
        /// Notifies that the volume object (memory card) state (VolumeInfo)
        /// has been changed. 
        /// Changed objects are indicated by event data. 
        /// The changed value can be retrieved by means of EdsGetVolumeInfo. 
        /// Notification of this event is not issued for type 1 protocol standard cameras.
        /// </summary>
        VolumeInfoChanged = 0x00000201,
        /// <summary>
        /// Notifies if the designated volume on a camera has been formatted.
        /// If notification of this event is received, get sub-items of the designated
        /// volume again as needed. 
        /// Changed volume objects can be retrieved from event data. 
        /// Objects cannot be identified on cameras earlier than the D30
        /// if files are added or deleted. 
        /// Thus, these events are subject to notification.
        /// </summary>
        VolumeUpdateItems = 0x00000202,
        /// <summary>
        /// Notifies if many images are deleted in a designated folder on a camera.
        /// If notification of this event is received, get sub-items of the designated
        /// folder again as needed. 
        /// Changed folders (specifically, directory item objects) can be retrieved
        /// from event data.
        /// </summary>
        FolderUpdateItems = 0x00000203,
        /// <summary>
        /// Notifies of the creation of objects such as new folders or files
        /// on a camera compact flash card or the like. 
        /// This event is generated if the camera has been set to store captured
        /// images simultaneously on the camera and a computer,
        /// for example, but not if the camera is set to store images
        /// on the computer alone. 
        /// Newly created objects are indicated by event data. 
        /// Because objects are not indicated for type 1 protocol standard cameras,
        /// (that is, objects are indicated as NULL),
        /// you must again retrieve child objects under the camera object to 
        /// identify the new objects.
        /// </summary>
        DirItemCreated = 0x00000204,
        /// <summary>
        /// Notifies of the deletion of objects such as folders or files on a camera
        /// compact flash card or the like. 
        /// Deleted objects are indicated in event data. 
        /// Because objects are not indicated for type 1 protocol standard cameras, 
        /// you must again retrieve child objects under the camera object to
        /// identify deleted objects.
        /// </summary>
        DirItemRemoved = 0x00000205,
        /// <summary>
        /// Notifies that information of DirItem objects has been changed. 
        /// Changed objects are indicated by event data. 
        /// The changed value can be retrieved by means of EdsGetDirectoryItemInfo. 
        /// Notification of this event is not issued for type 1 protocol standard cameras.
        /// </summary>
        DirItemInfoChanged = 0x00000206,
        /// <summary>
        /// Notifies that header information has been updated, as for rotation information
        /// of image files on the camera. 
        /// If this event is received, get the file header information again, as needed. 
        /// This function is for type 2 protocol standard cameras only.
        /// </summary>
        DirItemContentChanged = 0x00000207,
        /// <summary>
        /// Notifies that there are objects on a camera to be transferred to a computer. 
        /// This event is generated after remote release from a computer or local release
        /// from a camera. 
        /// If this event is received, objects indicated in the event data must be downloaded.
        /// Furthermore, if the application does not require the objects, instead
        /// of downloading them,
        /// execute EdsDownloadCancel and release resources held by the camera. 
        /// The order of downloading from type 1 protocol standard cameras must be the order
        /// in which the events are received.
        /// </summary>
        DirItemRequestTransfer = 0x00000208,
        /// <summary>
        /// Notifies if the camera's direct transfer button is pressed. 
        /// If this event is received, objects indicated in the event data must be downloaded. 
        /// Furthermore, if the application does not require the objects, instead of
        /// downloading them, 
        /// execute EdsDownloadCancel and release resources held by the camera. 
        /// Notification of this event is not issued for type 1 protocol standard cameras.
        /// </summary>
        DirItemRequestTransferDT = 0x00000209,
        /// <summary>
        /// Notifies of requests from a camera to cancel object transfer 
        /// if the button to cancel direct transfer is pressed on the camera. 
        /// If the parameter is 0, it means that cancellation of transfer is requested for
        /// objects still not downloaded,
        /// with these objects indicated by kEdsObjectEvent_DirItemRequestTransferDT. 
        /// Notification of this event is not issued for type 1 protocol standard cameras.
        /// </summary>
        DirItemCancelTransferDT = 0x0000020A,
        VolumeAdded = 0x0000020C,
        VolumeRemoved = 0x0000020D,
    }

    /// <summary>
    /// State Event IDs
    /// </summary>
    public enum StateEventID : int
    {
        /// <summary>
        /// Notifies all state events.
        /// </summary>
        All = 0x00000300,
        /// <summary>
        /// Indicates that a camera is no longer connected to a computer, 
        /// whether it was disconnected by unplugging a cord, opening
        /// the compact flash compartment, 
        /// turning the camera off, auto shut-off, or by other means.
        /// </summary>
        Shutdown = 0x00000301,
        /// <summary>
        /// Notifies of whether or not there are objects waiting to
        /// be transferred to a host computer. 
        /// This is useful when ensuring all shot images have been transferred 
        /// when the application is closed. 
        /// Notification of this event is not issued for type 1 protocol 
        /// standard cameras.
        /// </summary>
        JobStatusChanged = 0x00000302,
        /// <summary>
        /// Notifies that the camera will shut down after a specific period. 
        /// Generated only if auto shut-off is set. 
        /// Exactly when notification is issued (that is, the number of
        /// seconds until shutdown) varies depending on the camera model. 
        /// To continue operation without having the camera shut down,
        /// use EdsSendCommand to extend the auto shut-off timer.
        /// The time in seconds until the camera shuts down is returned
        /// as the initial value.
        /// </summary>
        WillSoonShutDown = 0x00000303,
        /// <summary>
        /// As the counterpart event to kEdsStateEvent_WillSoonShutDown,
        /// this event notifies of updates to the number of seconds until
        /// a camera shuts down. 
        /// After the update, the period until shutdown is model-dependent.
        /// </summary>
        ShutDownTimerUpdate = 0x00000304,
        /// <summary>
        /// Notifies that a requested release has failed, due to focus
        /// failure or similar factors.
        /// </summary>
        CaptureError = 0x00000305,
        /// <summary>
        /// Notifies of internal SDK errors. 
        /// If this error event is received, the issuing device will probably
        /// not be able to continue working properly,
        /// so cancel the remote connection.
        /// </summary>
        InternalError = 0x00000306,
        /// <summary>
        /// The autofocus is done working.
        /// </summary>
        AfResult = 0x00000309,
        /// <summary>
        /// The bulb exposure time has changed.
        /// </summary>
        BulbExposureTime = 0x00000310,
    }

    /// <summary>
    /// Drive Lens
    /// </summary>
    public enum DriveLens : int
    {
        Near1 = 0x00000001,
        Near2 = 0x00000002,
        Near3 = 0x00000003,
        Far1 = 0x00008001,
        Far2 = 0x00008002,
        Far3 = 0x00008003,
    }

    /// <summary>
    /// Seek Origin
    /// </summary>
    public enum SeekOrigin : int
    {
        Current = 0,
        Begin = 1,
        End = 2,
    }

    /// <summary>
    /// File Access
    /// </summary>
    public enum FileAccess : int
    {
        Read = 0,
        Write = 1,
        ReadWrite = 2,
        Error = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// File-creation Disposition
    /// </summary>
    public enum FileCreateDisposition : int
    {
        /// <summary>
        /// Creates a new file. An error occurs if the designated file already exists
        /// </summary>
        CreateNew = 0,
        /// <summary>
        /// Creates a new file. If the designated file already
        /// exists, that file is overwritten and existing attributes
        /// </summary>
        CreateAlways = 1,
        /// <summary>
        /// Opens a file. An error occurs if the designated file does not exist.
        /// </summary>
        OpenExisting = 2,
        /// <summary>
        /// If the file exists, it is opened. If the designated file
        /// does not exist, a new file is created.
        /// </summary>
        OpenAlways = 3,
        /// <summary>
        /// Opens a file and sets the file size to 0 bytes.
        /// </summary>
        TruncateExisting = 4,
    }

    /// <summary>
    /// Image Type
    /// </summary>
    public enum ImageType : int
    {
        Unknown = 0x00000000,
        Jpeg = 0x00000001,
        CRW = 0x00000002,
        RAW = 0x00000004,
        CR2 = 0x00000006,
    }

    /// <summary>
    /// Image Size
    /// </summary>
    public enum ImageSize : int
    {
        Large = 0,
        Middle = 1,
        Small = 2,
        Middle1 = 5,
        Middle2 = 6,
        Small1 = 14,
        Small2 = 15,
        Small3 = 16,
        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Compression Quality
    /// </summary>
    public enum CompressQuality : int
    {
        Normal = 2,
        Fine = 3,
        Lossless = 4,
        SuperFine = 5,
        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Image Quality
    /// </summary>
    public enum ImageQuality : int
    {
        /// <summary>
        /// Jpeg Large
        /// </summary>
        LargeJpeg = 0x0010FF0F,
        /// <summary>
        /// Jpeg Middle1
        /// </summary>
        Middle1Jpeg = 0x0510FF0F,
        /// <summary>
        /// Jpeg Middle2
        /// </summary>
        Middle2Jpeg = 0x0610FF0F,
        /// <summary>
        /// Jpeg Small
        /// </summary>
        SmallJpeg = 0x0210FF0F,
        /// <summary>
        /// Jpeg Small2
        /// </summary>
        Small2Jpeg = 0x0F13FF0F,
        /// <summary>
        /// Jpeg Small3
        /// </summary>
        Small3Jpeg = 0x1013FF0F,
        /// <summary>
        /// Jpeg Large Fine
        /// </summary>
        LargeJpegFine = 0x0013FF0F,
        /// <summary>
        /// Jpeg Large Normal
        /// </summary>
        LargeJpegNormal = 0x0012FF0F,
        /// <summary>
        /// Jpeg Middle Fine
        /// </summary>
        MiddleJpegFine = 0x0113FF0F,
        /// <summary>
        /// Jpeg Middle Normal
        /// </summary>
        MiddleJpegNormal = 0x0112FF0F,
        /// <summary>
        /// Jpeg Small Fine
        /// </summary>
        SmallJpegFine = 0x0213FF0F,
        /// <summary>
        /// Jpeg Small Normal
        /// </summary>
        SmallJpegNormal = 0x0212FF0F,
        /// <summary>
        /// Jpeg Small1 Fine
        /// </summary>
        Small1JpegFine = 0x0E13FF0F,
        /// <summary>
        /// Jpeg Small1 Normal
        /// </summary>
        Small1JpegNormal = 0x0E12FF0F,

        /// <summary>
        /// RAW
        /// </summary>
        RAW = 0x0064FF0F,
        /// <summary>
        /// RAW + Jpeg Large Fine
        /// </summary>
        RAW_LargeJpegFine = 0x00640013,
        /// <summary>
        /// RAW + Jpeg Large Normal
        /// </summary>
        RAW_LargeJpegNormal = 0x00640012,
        /// <summary>
        /// RAW + Jpeg Middle Fine
        /// </summary>
        RAW_MiddleJpegFine = 0x00640113,
        /// <summary>
        /// RAW + Jpeg Middle Normal
        /// </summary>
        RAW_MiddleJpegNormal = 0x00640112,
        /// <summary>
        /// RAW + Jpeg Small Fine
        /// </summary>
        RAW_SmallJpegFine = 0x00640213,
        /// <summary>
        /// RAW + Jpeg Small Normal
        /// </summary>
        RAW_SmallJpegNormal = 0x00640212,
        /// <summary>
        /// RAW + Jpeg Small1 Fine
        /// </summary>
        RAW_Small1JpegFine = 0x00640E13,
        /// <summary>
        /// RAW + Jpeg Small1 Normal
        /// </summary>
        RAW_Small1JpegNormal = 0x00640E12,
        /// <summary>
        /// RAW + Jpeg Small2
        /// </summary>
        RAW_Small2Jpeg = 0x00640F13,
        /// <summary>
        /// RAW + Jpeg Small3
        /// </summary>
        RAW_Small3Jpeg = 0x00641013,
        /// <summary>
        /// RAW + Jpeg Large
        /// </summary>
        RAW_LargeJpeg = 0x00640010,
        /// <summary>
        /// RAW + Jpeg Middle1
        /// </summary>
        RAW_Middle1Jpeg = 0x00640510,
        /// <summary>
        /// RAW + Jpeg Middle2
        /// </summary>
        RAW_Middle2Jpeg = 0x00640610,
        /// <summary>
        /// RAW + Jpeg Small
        /// </summary>
        RAW_SmallJpeg = 0x00640210,

        /// <summary>
        /// MRAW(SRAW1)
        /// </summary>
        MRAW = 0x0164FF0F,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large Fine
        /// </summary>
        MRAW_LargeJpegFine = 0x01640013,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large Normal
        /// </summary>
        MRAW_LargeJpegNormal = 0x01640012,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle Fine
        /// </summary>
        MRAW_MiddleJpegFine = 0x01640113,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle Normal
        /// </summary>
        MRAW_MiddleJpegNormal = 0x01640112,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small Fine
        /// </summary>
        MRAW_SmallJpegFine = 0x01640213,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small Normal
        /// </summary>
        MRAW_SmallJpegNormal = 0x01640212,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small1 Fine
        /// </summary>
        MRAW_Small1JpegFine = 0x01640E13,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small1 Normal
        /// </summary>
        MRAW_Small1JpegNormal = 0x01640E12,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small2
        /// </summary>
        MRAW_Small2Jpeg = 0x01640F13,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small3
        /// </summary>
        MRAW_Small3Jpeg = 0x01641013,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large
        /// </summary>
        MRAW_LargeJpeg = 0x01640010,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle1
        /// </summary>
        MRAW_Middle1Jpeg = 0x01640510,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle2
        /// </summary>
        MRAW_Middle2Jpeg = 0x01640610,
        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small
        /// </summary>
        MRAW_SmallJpeg = 0x01640210,

        /// <summary>
        /// SRAW(SRAW2)
        /// </summary>
        SRAW = 0x0264FF0F,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large Fine
        /// </summary>
        SRAW_LargeJpegFine = 0x02640013,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large Normal
        /// </summary>
        SRAW_LargeJpegNormal = 0x02640012,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle Fine
        /// </summary>
        SRAW_MiddleJpegFine = 0x02640113,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle Normal
        /// </summary>
        SRAW_MiddleJpegNormal = 0x02640112,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small Fine
        /// </summary>
        SRAW_SmallJpegFine = 0x02640213,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small Normal
        /// </summary>
        SRAW_SmallJpegNormal = 0x02640212,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small1 Fine
        /// </summary>
        SRAW_Small1JpegFine = 0x02640E13,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small1 Normal
        /// </summary>
        SRAW_Small1JpegNormal = 0x02640E12,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small2
        /// </summary>
        SRAW_Small2Jpeg = 0x02640F13,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small3
        /// </summary>
        SRAW_Small3Jpeg = 0x02641013,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large
        /// </summary>
        SRAW_LargeJpeg = 0x02640010,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle1
        /// </summary>
        SRAW_Middle1Jpeg = 0x02640510,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle2
        /// </summary>
        SRAW_Middle2Jpeg = 0x02640610,
        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small
        /// </summary>
        SRAW_SmallJpeg = 0x02640210,

        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Image Quality for Legacy Cameras
    /// </summary>
    public enum ImageQualityLegacy : int
    {
        /// <summary>
        /// Jpeg Large
        /// </summary>
        LJ = 0x001F000F,
        /// <summary>
        /// Jpeg Middle1
        /// </summary>
        M1J = 0x051F000F,
        /// <summary>
        /// Jpeg Middle2
        /// </summary>
        M2J = 0x061F000F,
        /// <summary>
        /// Jpeg Small
        /// </summary>
        SJ = 0x021F000F,
        /// <summary>
        /// Jpeg Large Fine
        /// </summary>
        LJF = 0x00130000,
        /// <summary>
        /// Jpeg Large Normal
        /// </summary>
        LJN = 0x00120000,
        /// <summary>
        /// Jpeg Middle Fine
        /// </summary>
        MJF = 0x01130000,
        /// <summary>
        /// Jpeg Middle Normal
        /// </summary>
        MJN = 0x01120000,
        /// <summary>
        /// Jpeg Small Fine
        /// </summary>
        SJF = 0x02130000,
        /// <summary>
        /// Jpeg Small Normal
        /// </summary>
        SJN = 0x02120000,

        /// <summary>
        ///  RAW
        /// </summary>
        LR = 0x00240000,
        /// <summary>
        /// RAW + Jpeg Large Fine
        /// </summary>
        LRLJF = 0x00240013,
        /// <summary>
        /// RAW + Jpeg Large Normal
        /// </summary>
        LRLJN = 0x00240012,
        /// <summary>
        /// RAW + Jpeg Middle Fine
        /// </summary>
        LRMJF = 0x00240113,
        /// <summary>
        /// RAW + Jpeg Middle Normal
        /// </summary>
        LRMJN = 0x00240112,
        /// <summary>
        /// RAW + Jpeg Small Fine
        /// </summary>
        LRSJF = 0x00240213,
        /// <summary>
        /// RAW + Jpeg Small Normal
        /// </summary>
        LRSJN = 0x00240212,

        /// <summary>
        /// RAW
        /// </summary>
        LR2 = 0x002F000F,
        /// <summary>
        /// RAW + Jpeg Large
        /// </summary>
        LR2LJ = 0x002F001F,
        /// <summary>
        /// RAW + Jpeg Middle1
        /// </summary>
        LR2M1J = 0x002F051F,
        /// <summary>
        /// RAW + Jpeg Middle2
        /// </summary>
        LR2M2J = 0x002F061F,
        /// <summary>
        /// RAW + Jpeg Small
        /// </summary>
        LR2SJ = 0x002F021F,

        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Image Source
    /// </summary>
    public enum ImageSource : int
    {
        FullView = 0,
        Thumbnail = 1,
        Preview = 2,
        RAWThumbnail = 3,
        RAWFullView = 4,
    }

    /// <summary>
    /// Target Image Type
    /// </summary>
    public enum TargetImageType : int
    {
        Unknown = 0x00000000,
        Jpeg = 0x00000001,
        TIFF = 0x00000007,
        TIFF16 = 0x00000008,
        RGB = 0x00000009,
        RGB16 = 0x0000000A,
        DIB = 0x0000000B,
    }

    /// <summary>
    /// Progress Option
    /// </summary>
    public enum ProgressOption : int
    {
        NoReport = 0,
        Done = 1,
        Periodically = 2,
    }

    /// <summary>
    /// File Attribute
    /// </summary>
    public enum FileAttribute : int
    {
        Normal = 0x00000000,
        ReadOnly = 0x00000001,
        Hidden = 0x00000002,
        System = 0x00000004,
        Archive = 0x00000020,
    }

    /// <summary>
    /// Battery Level
    /// </summary>
    public enum BatteryQuality : int
    {
        Empty = 0,
        Low = 9,
        Half = 49,
        Normal = 80,
        High = 69,
        Quarter = 19,
        //Error = 0,
        //BCLevel = 0,
        AC = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Save to Device
    /// </summary>
    public enum SaveTo : int
    {
        Camera = 1,
        Host = 2,
        Both = 3,
    }

    /// <summary>
    /// Storage Type
    /// </summary>
    public enum StorageType : int
    {
        None = 0,
        CF = 1,
        SD = 2,
        HD = 4,
        CFast = 5,
    }

    /// <summary>
    /// Whitebalance
    /// </summary>
    public enum WhiteBalance : int
    {
        Pasted = -2,
        Click = -1,
        Auto = 0,
        Daylight = 1,
        Cloudy = 2,
        Tangsten = 3,
        Fluorescent = 4,
        Strobe = 5,
        WhitePaper = 6,
        Shade = 8,
        ColorTemperature = 9,
        PCSet1 = 10,
        PCSet2 = 11,
        PCSet3 = 12,
        WhitePaper2 = 15,
        WhitePaper3 = 16,
        WhitePaper4 = 18,
        WhitePaper5 = 19,
        PCSet4 = 20,
        PCSet5 = 21,
    }

    /// <summary>
    /// Photo Effect
    /// </summary>
    public enum PhotoEffect : int
    {
        Off = 0,
        Monochrome = 5,
    }

    /// <summary>
    /// Color Matrix
    /// </summary>
    public enum ColorMatrix : int
    {
        Custom = 0,
        ColorMatrix1 = 1,
        ColorMatrix2 = 2,
        ColorMatrix3 = 3,
        ColorMatrix4 = 4,
        ColorMatrix5 = 5,
        ColorMatrix6 = 6,
        ColorMatrix7 = 7,
    }

    /// <summary>
    /// Filter Effect
    /// </summary>
    public enum FilterEffect : int
    {
        None = 0,
        Yellow = 1,
        Orange = 2,
        Red = 3,
        Green = 4,
    }

    /// <summary>
    /// Toning Effect
    /// </summary>
    public enum ToningEffect : int
    {
        None = 0,
        Sepia = 1,
        Blue = 2,
        Purple = 3,
        Green = 4,
    }

    /// <summary>
    /// Color Space
    /// </summary>
    public enum ColorSpace : int
    {
        sRGB = 1,
        AdobeRGB = 2,
        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Picture Style
    /// </summary>
    public enum PictureStyle : int
    {
        Standard = 0x0081,
        Portrait = 0x0082,
        Landscape = 0x0083,
        Neutral = 0x0084,
        Faithful = 0x0085,
        Monochrome = 0x0086,
        Auto = 0x0087,
        User1 = 0x0021,
        User2 = 0x0022,
        User3 = 0x0023,
        PC1 = 0x0041,
        PC2 = 0x0042,
        PC3 = 0x0043,
    }

    /// <summary>
    /// Transfer Option
    /// </summary>
    public enum TransferOption : int
    {
        ByDirectTransfer = 1,
        ByRelease = 2,
        ToDesktop = 0x00000100,
    }

    /// <summary>
    /// Bracketing Mode
    /// </summary>
    public enum BracketMode : int
    {
        Exposure = 0x01,
        ISO = 0x02,
        Whitebalance = 0x04,
        FlashExposure = 0x08,
        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Liveview Output Device
    /// </summary>
    public enum EvfOutputDevice : int
    {
        Off = 0,
        Camera = 1,
        PC = 2,
        Filming = 3,
        Mobile = 4,
        Mobile2 = 8,
    }

    /// <summary>
    /// Liveview Zoom Level
    /// </summary>
    public enum EvfZoom : int
    {
        Fit = 1,
        x5 = 5,
        x10 = 10,
    }

    /// <summary>
    /// Liveview Autofocus Mode
    /// </summary>
    public enum EvfAFMode : int
    {
        Quick = 0,
        Live = 1,
        LiveFace = 2,
        LiveMulti = 3,
    }

    /// <summary>
    /// Flash Type
    /// </summary>
    public enum FlashType : int
    {
        None = 0,
        Internal = 1,
        ExternalETTL = 2,
        ExternalATTL = 3,
        Invalid = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Flash ETTL 2 Mode
    /// </summary>
    public enum ETTL2Mode : int
    {
        Evaluative = 0,
        Average = 1,
    }

    /// <summary>
    /// Processing parameter of a camera
    /// </summary>
    public enum ProcessingParameter : int
    {
        Standard = 0,
        ProcessingParameter1 = 1,
        ProcessingParameter2 = 2,
        ProcessingParameter3 = 3,
    }

    /// <summary>
    /// The orientation of an image
    /// </summary>
    public enum ImageOrientation : int
    {
        /// <summary>
        /// The 0th row is at the visual top of the image, and the 0th column is on the visual left-hand side
        /// </summary>
        ULRD = 1,
        /// <summary>
        /// The 0th row is at the visual bottom of the image, and the 0th column is on the visual right-hand side
        /// </summary>
        DRLU = 3,
        /// <summary>
        /// The 0th row is on the visual right-hand side of the image, and the 0th column is at the visual top
        /// </summary>
        LDUR = 6,
        /// <summary>
        /// The 0th row is on the visual left-hand side of the image, and the 0th column is at the visual bottom
        /// </summary>
        RUDL = 8,

        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Tone curve
    /// </summary>
    public enum ToneCurve : int
    {
        Standard = 0x00000000,
        UserSetting = 0x00000011,
        CustomSetting = 0x00000080,
        TCD1 = 0x00000001,
        TCD2 = 0x00000002,
        TCD3 = 0x00000003,
    }

    /// <summary>
    /// Drive mode of a camera
    /// </summary>
    public enum DriveMode : int
    {
        SingleFrame = 0x00000000,
        Continuous = 0x00000001,
        Video = 0x00000002,
        HighSpeedContinuous = 0x00000004,
        LowSpeedContinuous = 0x00000005,
        SilentSingleFrame = 0x00000006,
        SelfTimer10sContinuous = 0x00000007,
        SelfTimer10s = 0x00000010,
        SelfTimer2s = 0x00000011,
    }

    /// <summary>
    /// Autofocus mode of a camera
    /// </summary>
    public enum AFMode : int
    {
        OneShot = 0,
        AIServo = 1,
        AIFocus = 2,
        Manual = 3,
        Unknown = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Noise reduction method
    /// </summary>
    public enum NoiseReduction : int
    {
        Off = 0,
        On1 = 1,
        On2 = 2,
        On = 3,
        Auto = 4,
    }

    /// <summary>
    /// State of red eye reduction
    /// </summary>
    public enum RedEye : int
    {
        Off = 0,
        On = 1,
        Invalid = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Flash synchronization of curtain
    /// </summary>
    public enum SynchroTiming : int
    {
        Curtain1 = 0,
        Curtain2 = 1,
        Invalid = unchecked((int)0xFFFFFFFF),
    }

    /// <summary>
    /// Mode of histogram
    /// </summary>
    public enum HistogramStatus : int
    {
        Hide = 0,
        Normal = 1,
        Grayout = 2,
    }

    /// <summary>
    /// Video recording methods
    /// </summary>
    public enum Recording : int
    {
        Off = 0,
        Ready = 3,
        On = 4,
    }

    /// <summary>
    /// Image type to save after RAW processing
    /// </summary>
    public enum SaveImageType : int
    {
        Jpeg = 0x00000001,
        TIFF = 0x00000007,
        TIFF16 = 0x00000008,
    }

    /// <summary>
    /// Camera sub-type
    /// </summary>
    public enum DeviceSubType : int
    {
        CanonPTPCameras = 1,
        CanonPTP_IPCameras = 2,
    }
}
