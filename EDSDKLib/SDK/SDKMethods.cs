using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EOSDigital.SDK
{
    /// <summary>
    /// This class contains all of the native Canon SDK calls and some wrapper methods
    /// </summary>
    public static class CanonSDK
    {
        /// <summary>
        /// Maximum length of string
        /// </summary>
        public const int MAX_NAME = 256;
        /// <summary>
        /// Block size of a data transfer
        /// </summary>
        public const int TRANSFER_BLOCK_SIZE = 512;

        /// <summary>
        /// The path to the Canon SDK DLL
        /// </summary>
        public const string DllPath = "EDSDK";

        #region Version Check

        /// <summary>
        /// Version of the currently used Canon SDK DLL
        /// </summary>
        public static Version SDKVersion
        {
            get;
            private set;
        }

        /// <summary>
        /// States if the used SDK version is >=3.4
        /// Call <see cref="InitializeVersion"/> to initialize this property.
        /// </summary>
        public static bool IsVerGE34
        {
            get;
            private set;
        }

        /// <summary>
        /// Checks which SDK version is currently used and sets IsVer* properties
        /// </summary>
        /// <exception cref="InvalidOperationException">Could not extract version information</exception>
        public static void InitializeVersion()
        {
            try
            {
                SDKVersion = GetSDKVersion();
                if (SDKVersion == null) throw new InvalidOperationException("Could not find SDK version");

                IsVerGE34 = SDKVersion.Major >= 3 && SDKVersion.Minor >= 4;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not find SDK version", ex);
            }
        }

        /// <summary>
        /// Get SDK version on Windows
        /// </summary>
        /// <returns>The SDK version or null if not found</returns>
        private static Version GetSDKVersion()
        {
            var modules = Process.GetCurrentProcess().Modules;
            foreach (var module in modules)
            {
                var pm = module as ProcessModule;
                string name = pm?.ModuleName?.ToLower();
                if (name == "edsdk.dll")
                {
                    FileVersionInfo vi = pm.FileVersionInfo;
                    return new Version(vi.ProductMajorPart, vi.ProductMinorPart, vi.ProductBuildPart, vi.ProductPrivatePart);
                }
            }
            return null;
        }

        #endregion

        #region Init/Close

        /// <summary>
        /// Initializes the libraries.
        /// This must be called before using the EDSDK API
        /// </summary>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsInitializeSDK();

        /// <summary>
        /// Terminates the use of the libraries.
        /// This must be called when ending the SDK, it releases all resources used by the libraries.
        /// </summary>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsTerminateSDK();

        /// <summary>
        /// Establishes a logical connection with a remote camera. Use this method after getting the camera object.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsOpenSession(IntPtr inCameraRef);

        /// <summary>
        /// Closes a logical connection with a remote camera.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCloseSession(IntPtr inCameraRef);

        #endregion

        #region Properties

        /// <summary>
        /// Gets the byte size and data type of a designated property from a camera object or image object.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outDataType">Pointer to the buffer that is to receive the property type data.</param>
        /// <param name="outSize">Pointer to the buffer that is to receive the property size.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPropertySize(IntPtr inRef, PropertyID inPropertyID, int inParam, out DataType outDataType, out int outSize);

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="inPropertySize">The number of bytes of the prepared buffer for receive property-value.</param>
        /// <param name="outPropertyData">The buffer pointer to receive property-value.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, int inPropertySize, IntPtr outPropertyData);

        /// <summary>
        /// Sets property data for the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID</param>
        /// <param name="inParam">Additional information of property.</param>
        /// <param name="inPropertySize">The number of bytes of the prepared buffer for set property-value.</param>
        /// <param name="inPropertyData">The buffer pointer to set property-value.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, int inPropertySize, [MarshalAs(UnmanagedType.AsAny), In] object inPropertyData);

        /// <summary>
        /// Gets a list of property data that can be set for the object designated in inRef,
        /// as well as maximum and minimum values. This method is only intended for some shooting-related properties
        /// </summary>
        /// <param name="inRef">The reference of the camera.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="outPropertyDesc">Array of the values which can be set up.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPropertyDesc(IntPtr inRef, PropertyID inPropertyID, out PropertyDesc outPropertyDesc);

        #endregion

        #region Commands

        /// <summary>
        /// Sends a command such as "Shoot" to a remote camera.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera which will receive the command.</param>
        /// <param name="inCommand">Specifies the command to be sent</param>
        /// <param name="inParam">Specifies additional command-specific information.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSendCommand(IntPtr inCameraRef, CameraCommand inCommand, int inParam);

        /// <summary>
        /// Sets the remote camera state or mode.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera which will receive the command.</param>
        /// <param name="inCameraState">Specifies the command to be sent.</param>
        /// <param name="inParam">Specifies additional command-specific information.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSendStatusCommand(IntPtr inCameraRef, CameraStatusCommand inCameraState, int inParam);

        #endregion

        #region Camera File System

        /// <summary>
        /// Sets the remaining HDD capacity on the host computer (excluding the portion from image transfer), as calculated by subtracting the portion from the previous time. 
        /// Set a reset flag initially and designate the cluster length and number of free clusters.
        /// Some type 2 protocol standard cameras can display the number of shots left on the camera based on the available disk capacity of the host computer. 
        /// For these cameras, after the storage destination is set to the computer, use this method to notify the camera of the available disk capacity of the host computer.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera which will receive the command.</param>
        /// <param name="inCapacity">The remaining capacity of a transmission place.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetCapacity(IntPtr inCameraRef, Capacity inCapacity);

        /// <summary>
        /// Gets volume information for a memory card in the camera
        /// </summary>
        /// <param name="inCameraRef">Information of the volume</param>
        /// <param name="outVolumeInfo"></param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetVolumeInfo(IntPtr inCameraRef, out VolumeInfo outVolumeInfo);

        /// <summary>
        /// Formats a volume.
        /// </summary>
        /// <param name="inVolumeRef">The reference of the volume.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsFormatVolume(IntPtr inVolumeRef);

        /// <summary>
        /// Gets information about the directory or file object on the memory card (volume) in a remote camera.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outDirItemInfo">Information of the directory item.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetDirectoryItemInfo(IntPtr inDirItemRef, out DirectoryItemInfo outDirItemInfo);

        /// <summary>
        /// Deletes a camera folder or file.
        /// If folders with subdirectories are designated, all files are deleted except protected files.
        /// DirectoryItem objects deleted by means of this method are implicitly released.
        /// Thus, there is no need to release them by means of Release.
        /// </summary>
        /// <param name="inDirItemRef"></param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDeleteDirectoryItem(IntPtr inDirItemRef);

        /// <summary>
        /// Gets attributes of files of a camera.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outFileAttribute">
        /// Indicates the file attributes.
        /// As for the file attributes, OR values of the value defined by enum FileAttributes can be retrieved.
        /// Thus, when determining the file attributes, it must be checked if an attribute flag is set for target attributes.
        /// </param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetAttribute(IntPtr inDirItemRef, out FileAttribute outFileAttribute);

        /// <summary>
        /// Changes attributes of files on a camera.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="inFileAttribute">
        /// Indicates the file attributes.
        /// As for the file attributes, OR values of the value defined by enum FileAttributes can be retrieved.
        /// </param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetAttribute(IntPtr inDirItemRef, FileAttribute inFileAttribute);

        #endregion

        #region Download

        /// <summary>
        /// Downloads a file on a remote camera (in the camera memory or on a memory card) to the host computer.
        /// The downloaded file is sent directly to a file stream created in advance.
        /// When dividing the file being retrieved, call this method repeatedly.
        /// Also in this case, make the data block size a multiple of 512 (bytes), excluding the final block.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="inReadSize">-</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownload(IntPtr inDirItemRef, int inReadSize, IntPtr outStream);

        /// <summary>
        /// Downloads a file on a remote camera (in the camera memory or on a memory card) to the host computer.
        /// The downloaded file is sent directly to a file stream created in advance.
        /// When dividing the file being retrieved, call this method repeatedly.
        /// Also in this case, make the data block size a multiple of 512 (bytes), excluding the final block.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="inReadSize">-</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownload(IntPtr inDirItemRef, long inReadSize, IntPtr outStream);

        /// <summary>
        /// Must be executed when downloading of a directory item is canceled.
        /// Calling this method makes the camera cancel file transmission.
        /// It also releases resources.
        /// This operation need not be executed when using DownloadThumbnail.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownloadCancel(IntPtr inDirItemRef);

        /// <summary>
        /// Must be called when downloading of directory items is complete.
        /// Executing this method makes the camera recognize that file transmission is complete.
        /// This operation need not be executed when using DownloadThumbnail.
        /// </summary>
        /// <param name="inDirItemRef"></param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownloadComplete(IntPtr inDirItemRef);

        /// <summary>
        /// Extracts and downloads thumbnail information from image files in a camera.
        /// Thumbnail information in the camera's image files is downloaded to the host computer.
        /// Downloaded thumbnails are sent directly to a file stream created in advance.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownloadThumbnail(IntPtr inDirItemRef, IntPtr outStream);

        #endregion

        #region Streams

        /// <summary>
        /// Creates a new file on a host computer (or opens an existing file) and creates a file stream for access to the file. 
        /// If a new file is designated before executing this method, the file is actually created following the timing of writing by means of Write or the like with respect to an open stream.
        /// </summary>
        /// <param name="inFileName">Pointer to a null-terminated string that specifies the file name.</param>
        /// <param name="inCreateDisposition">Action to take on files that exist, and which action to take hen files do not exist.</param>
        /// <param name="inDesiredAccess">Access to the stream (reading, writing, or both).</param>
        /// <param name="outStream">The reference of the stream</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateFileStream(string inFileName, FileCreateDisposition inCreateDisposition, FileAccess inDesiredAccess, out IntPtr outStream);

        /// <summary>
        /// Creates a stream in the memory of a host computer.
        /// In the case if writing in excess of the allocated buffer size, the memory is automatically extended.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStream(int inBufferSize, out IntPtr outStream);

        /// <summary>
        /// Creates a stream in the memory of a host computer.
        /// In the case if writing in excess of the allocated buffer size, the memory is automatically extended.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStream(long inBufferSize, out IntPtr outStream);

        /// <summary>
        /// An extended version of CreateStreamFromFile.
        /// Use this method when working with Unicode file names.
        /// </summary>
        /// <param name="inFileName">Designate the file name.</param>
        /// <param name="inCreateDisposition">Action to take on files take when files do not exist.</param>
        /// <param name="inDesiredAccess">Access to the stream (reading, writing, or both)</param>
        /// <param name="outStream">The reference of the stream</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath, CharSet = CharSet.Unicode)]
        public extern static ErrorCode EdsCreateFileStreamEx(string inFileName, FileCreateDisposition inCreateDisposition, FileAccess inDesiredAccess, out IntPtr outStream);

        /// <summary>
        /// Creates a stream from the memory buffer you prepared.
        /// Unlike the buffer size of streams created by means of CreateMemoryStream, the buffer size you prepare
        /// for streams created this way does not expand.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inUserBuffer">-</param>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStreamFromPointer(IntPtr inUserBuffer, int inBufferSize, out IntPtr outStream);

        /// <summary>
        /// Creates a stream from the memory buffer you prepared.
        /// Unlike the buffer size of streams created by means of CreateMemoryStream, the buffer size you prepare
        /// for streams created this way does not expand.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inUserBuffer">-</param>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStreamFromPointer(IntPtr inUserBuffer, long inBufferSize, out IntPtr outStream);

        /// <summary>
        /// Creates a stream from the memory buffer you prepared.
        /// Unlike the buffer size of streams created by means of CreateMemoryStream, the buffer size you prepare for streams created this way does not expand.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inUserBuffer">-</param>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStreamFromPointer(byte[] inUserBuffer, int inBufferSize, out IntPtr outStream);

        /// <summary>
        /// Creates a stream from the memory buffer you prepared.
        /// Unlike the buffer size of streams created by means of CreateMemoryStream, the buffer size you prepare for streams created this way does not expand.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inUserBuffer">-</param>
        /// <param name="inBufferSize">The number of bytes of the memory to allocate.</param>
        /// <param name="outStream">The reference of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateMemoryStreamFromPointer(byte[] inUserBuffer, long inBufferSize, out IntPtr outStream);

        /// <summary>
        /// Creates a stream from an existing stream.
        /// </summary>
        /// <param name="inStream">The reference of the input stream.</param>
        /// <param name="outStreamRef">The reference of the output stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateStream(IntPtr inStream, IntPtr outStreamRef);

        /// <summary>
        /// Gets the pointer to the start address of memory managed by the memory stream. 
        /// As the EDSDK automatically resizes the buffer, the memory stream provides you with the same access methods as for the file stream. 
        /// If access is attempted that is excessive with regard to the buffer size for the stream, data before the required buffer size is allocated is copied internally, and new writing occurs. 
        /// Thus, the buffer pointer might be switched on an unknown timing. Caution in use is therefore advised.
        /// </summary>
        /// <param name="inStreamRef">Designate the memory stream for the pointer to retrieve.</param>
        /// <param name="outPointer">If successful, returns the pointer to the buffer written in the memory stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPointer(IntPtr inStreamRef, out IntPtr outPointer);

        /// <summary>
        /// Reads data the size of inReadSize into the outBuffer buffer, starting at the current read or write position of the stream.
        /// The size if data actually read can be designated in outReadSize.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inReadSize">The number of bytes to read.</param>
        /// <param name="outBuffer">Pointer to the user-supplied buffer that is to receive the data read from the stream.</param>
        /// <param name="outReadSize">The actually read number of bytes.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsRead(IntPtr inStreamRef, int inReadSize, IntPtr outBuffer, out int outReadSize);

        /// <summary>
        /// Reads data the size of inReadSize into the outBuffer buffer, starting at the current read or write position of the stream.
        /// The size if data actually read can be designated in outReadSize.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inReadSize">The number of bytes to read.</param>
        /// <param name="outBuffer">Pointer to the user-supplied buffer that is to receive the data read from the stream.</param>
        /// <param name="outReadSize">The actually read number of bytes.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsRead(IntPtr inStreamRef, long inReadSize, IntPtr outBuffer, out long outReadSize);

        /// <summary>
        /// Writes data of a designated buffer to the current read or write position of the stream.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inWriteSize">The number of bytes to write.</param>
        /// <param name="inBuffer">A pointer to the user-supplied buffer that contains the data to be written (in number of bytes)</param>
        /// <param name="outWrittenSize"></param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsWrite(IntPtr inStreamRef, int inWriteSize, IntPtr inBuffer, out int outWrittenSize);

        /// <summary>
        /// Writes data of a designated buffer to the current read or write position of the stream.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inWriteSize">The number of bytes to write.</param>
        /// <param name="inBuffer">A pointer to the user-supplied buffer that contains the data to be written (in number of bytes)</param>
        /// <param name="outWrittenSize"></param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsWrite(IntPtr inStreamRef, long inWriteSize, IntPtr inBuffer, out long outWrittenSize);

        /// <summary>
        /// Moves the read or write position of the stream (that is, the file position indicator)
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inSeekOffset">Number of bytes to move the pointer.</param>
        /// <param name="inSeekOrigin">Pointer movement mode.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSeek(IntPtr inStreamRef, int inSeekOffset, SeekOrigin inSeekOrigin);

        /// <summary>
        /// Moves the read or write position of the stream (that is, the file position indicator)
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inSeekOffset">Number of bytes to move the pointer.</param>
        /// <param name="inSeekOrigin">Pointer movement mode.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSeek(IntPtr inStreamRef, long inSeekOffset, SeekOrigin inSeekOrigin);

        /// <summary>
        /// Gets the current read or write position of the stream (that is, the file position indicator)
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="outPosition">The current stream pointer.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPosition(IntPtr inStreamRef, out int outPosition);

        /// <summary>
        /// Gets the current read or write position of the stream (that is, the file position indicator)
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="outPosition">The current stream pointer.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetPosition(IntPtr inStreamRef, out long outPosition);

        /// <summary>
        /// Gets the stream size.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="outLength">The length of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetLength(IntPtr inStreamRef, out int outLength);

        /// <summary>
        /// Gets the stream size.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="outLength">The length of the stream.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetLength(IntPtr inStreamRef, out long outLength);

        /// <summary>
        /// Copies data from the copy source stream to the copy destination stream.
        /// The read or write position of the data to copy is determined from the current file read or write position of the respective stream.
        /// After this method is executed, the read or write position of the copy source and copy destination streams are moved
        /// an amount corresponding to inWriteSize in the positive direction.
        /// <para>USE ONLY WITH SDK VERSION &lt;3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inWriteSize">The number of bytes to copy.</param>
        /// <param name="outStreamRef">The reference of the stream or image.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCopyData(IntPtr inStreamRef, int inWriteSize, IntPtr outStreamRef);

        /// <summary>
        /// Copies data from the copy source stream to the copy destination stream.
        /// The read or write position of the data to copy is determined from the current file read or write position of the respective stream.
        /// After this method is executed, the read or write position of the copy source and copy destination streams are moved
        /// an amount corresponding to inWriteSize in the positive direction.
        /// <para>USE ONLY WITH SDK VERSION &gt;=3.4</para>
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream or image.</param>
        /// <param name="inWriteSize">The number of bytes to copy.</param>
        /// <param name="outStreamRef">The reference of the stream or image.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCopyData(IntPtr inStreamRef, long inWriteSize, IntPtr outStreamRef);

        #endregion

        #region Image Handling

        /// <summary>
        /// Creates an image object from an image file.
        /// Without modification, stream objects cannot be worked with as images.
        /// Thus, when extracting images from image files, this method must be used to create image objects.
        /// The image object created this way can be used to get image information
        /// (such as height and width, number of components, and resolution), thumbnail image data, and the image data itself.
        /// </summary>
        /// <param name="inStreamRef">The reference of the stream.</param>
        /// <param name="outImageRef">The reference of the image.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateImageRef(IntPtr inStreamRef, out IntPtr outImageRef);

        /// <summary>
        /// Gets image information from a designated image object.
        /// Here, image information means the image width and height, number of color components, resolution, and effective image area.
        /// </summary>
        /// <param name="inImageRef">Designate the object which to get image information.</param>
        /// <param name="inImageSource">
        /// Of the various image data items in the image file, designate the type of image data representing the information you want to get.
        /// Designate the image as defined in the enum ImageSource.
        /// </param>
        /// <param name="outImageInfo">Stores the image information designated in inImageSource</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetImageInfo(IntPtr inImageRef, ImageSource inImageSource, out ImageInfo outImageInfo);

        /// <summary>
        /// Gets designated image data from an image file, in the form of a designated rectangle. 
        /// Returns uncompressed results for JPEGs and processed results in the designated pixel order (RGB, Top-down BGR, and so on) for RAW images. 
        /// Additionally, by designating the input/output rectangle, it is possible to get reduced, enlarged, or partial images. 
        /// However, because images corresponding to the designated output rectangle are always returned by the SDK, the SDK does not take the aspect ratio into account. 
        /// To maintain the aspect ratio, you must keep the aspect ratio in mind when designating the rectangle.
        /// </summary>
        /// <param name="inImageRef">Designate the image object for which to get the image data.</param>
        /// <param name="inImageSource">Designate the type of image data to get from the image file (thumbnail, preview, and so on). Designate values as defined in Enum ImageSource.</param>
        /// <param name="inImageType">
        /// Designate the output image type.
        /// Because the output format of EdGetImage may only be RGB, only kTargetImageType_RGB or kTargetImageType_RGB16 can be designated. 
        /// However, image types exceeding the resolution of inImageSource cannot be designated.
        /// </param>
        /// <param name="inSrcRect">Designate the coordinates and size of the rectangle to be retrieved (processed) from the source image. </param>
        /// <param name="inDstSize">Designate the rectangle size for output.</param>
        /// <param name="outStreamRef">Designate the memory or file stream for output of the image.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetImage(IntPtr inImageRef, ImageSource inImageSource, TargetImageType inImageType, Rectangle inSrcRect, Size inDstSize, IntPtr outStreamRef);

        /// <summary>
        /// Saves as a designated image type after RAW processing.
        /// When saving with JPEG compression, the JPEG quality setting applies with respect to OptionRef.
        /// </summary>
        /// <param name="inImageRef">Designate the image object for which to produce the file.</param>
        /// <param name="inImageType">Designate the image type to produce. Designate the following image types.</param>
        /// <param name="inSaveSetting">Designate saving options, such as JPEG image quality.</param>
        /// <param name="outStreamRef">Specifies the output file stream. The memory stream cannot be specified here.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSaveImage(IntPtr inImageRef, SaveImageType inImageType, SaveImageSetting inSaveSetting, IntPtr outStreamRef);

        /// <summary>
        /// Switches a setting on and off for creation of an image cache in the SDK for a designated image object during extraction (processing) of the image data.
        /// </summary>
        /// <param name="inImageRef">The reference of the image.</param>
        /// <param name="inUseCache">If cache image data or not. If set to false, the cached image data will be released.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCacheImage(IntPtr inImageRef, bool inUseCache);

        /// <summary>
        /// Incorporates image object property changes (effected by means of SetPropertyData) in the stream.
        /// </summary>
        /// <param name="inImageRef">The reference of the image.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsReflectImageProperty(IntPtr inImageRef);

        #endregion

        #region Events

        /// <summary>
        /// Registers a callback function for when a camera is detected.
        /// </summary>
        /// <param name="inCameraAddedHandler">Pointer to a callback function called when a camera is connected physically.</param>
        /// <param name="inContext">Specifies an application-defined value to be sent to the callback function pointed to by CallBack parameter.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetCameraAddedHandler(SDKCameraAddedHandler inCameraAddedHandler, IntPtr inContext);

        /// <summary>
        /// Registers a callback function for receiving status change notification events for property-related camera evens.
        /// </summary>
        /// <param name="inCameraRef">Designate the camera object.</param>
        /// <param name="inEvent">Designate one or all events to be supplemented.</param>
        /// <param name="inPropertyEventHandler">Designate the pointer to the callback function for receiving property-related camera events.</param>
        /// <param name="inContext">Designate application information to be passed by mens of the callback funcion.Any data needed for your application can be passed.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetPropertyEventHandler(IntPtr inCameraRef, PropertyEventID inEvent, SDKPropertyEventHandler inPropertyEventHandler, IntPtr inContext);

        /// <summary>
        /// Registers a callback function for receiving status change notification events for objects on a remote camera.
        /// Here, object means columns representation memory cards, files and directories, and shot images stored in memory, in particular.
        /// </summary>
        /// <param name="inCameraRef">Designate the camera object.</param>
        /// <param name="inEvent">Designate one or all events to be supplemented.</param>
        /// <param name="inObjectEventHandler">Designate the pointer to the callback function for receiving object-related camera events.</param>
        /// <param name="inContext">Passes inContext without modification, as designated as an SetObjectEventHandler argument.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetObjectEventHandler(IntPtr inCameraRef, ObjectEventID inEvent, SDKObjectEventHandler inObjectEventHandler, IntPtr inContext);

        /// <summary>
        /// Registers a callback function for receiving status change notification events for property states on a camera.
        /// </summary>
        /// <param name="inCameraRef">Designate the camera object.</param>
        /// <param name="inEvent">Designate one or all events to be supplemented.</param>
        /// <param name="inStateEventHandler">Designate the pointer to the callback function for receiving events related to camera object states.</param>
        /// <param name="inContext">Designate application information to be passed by means of the callback function. Any data needed for the application can be passed.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetCameraStateEventHandler(IntPtr inCameraRef, StateEventID inEvent, SDKStateEventHandler inStateEventHandler, IntPtr inContext);

        /// <summary>
        /// Register a progress callback function. 
        /// An event is received as notification of progress during processing that takes a relatively long time, such as downloading files from a remote camera. 
        /// If you register the callback function, the EDSDK calls the callback function during execution or on completion of the following APIs. 
        /// This timing can be used in updating on-screen progress bars, for example.
        /// </summary>
        /// <param name="inRef">The reference of the stream or image.</param>
        /// <param name="inProgressFunc">Pointer to the progress callback function.</param>
        /// <param name="inProgressOption">The option about progress is specified.</param>
        /// <param name="inContext">
        /// Application information, passed in the argument when the callback function is called.
        /// Any information required for the program may be added.
        /// </param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsSetProgressCallback(IntPtr inRef, SDKProgressCallback inProgressFunc, ProgressOption inProgressOption, IntPtr inContext);

        /// <summary>
        /// This function acquires an event. 
        /// In console application, please call this function regularly to acquire
        /// the event from a camera.
        /// </summary>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetEvent();

        #endregion

        #region Evf Image

        /// <summary>
        /// Creates an object used to get the live view image data set.
        /// </summary>
        /// <param name="inStreamRef">The stream reference which opened to get EVF JPEG image.</param>
        /// <param name="outEvfImageRef">The EVFData reference.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsCreateEvfImageRef(IntPtr inStreamRef, out IntPtr outEvfImageRef);

        /// <summary>
        /// Downloads the live view image data set for a camera currently in live view mode.
        /// Live view can be started by using the property ID: PropertyID_Evf_OutputDevice and
        ///	data:OutputDevice_PC to call SetPropertyData.
        ///	In addition to image data, information such as zoom, focus position, and histogram data
        ///	is included in the image data set. Image data is saved in a stream maintained by EvfImageRef.
        ///	GetPropertyData can be used to get information such as the zoom, focus position, etc.
        ///	Although the information of the zoom and focus position can be obtained from EvfImageRef,
        ///	settings are applied to CameraRef.
        /// </summary>
        /// <param name="inCameraRef">The camera reference.</param>
        /// <param name="outEvfImageRef">The EVFData reference.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsDownloadEvfImage(IntPtr inCameraRef, IntPtr outEvfImageRef);

        #endregion

        #region Misc

        /// <summary>
        /// Gets camera list objects.
        /// </summary>
        /// <param name="outCameraListRef">Pointer to the camera-list.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetCameraList(out IntPtr outCameraListRef);

        /// <summary>
        /// Gets device information, such as the device name.
        /// Because device information of remote cameras is stored on the host computer, this method can be called before the session with the camera is opened.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera.</param>
        /// <param name="outDeviceInfo">Information as device of camera.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetDeviceInfo(IntPtr inCameraRef, out DeviceInfo outDeviceInfo);

        /// <summary>
        /// Increments the reference counter of existing objects.
        /// </summary>
        /// <param name="inRef">The reference for the item</param>
        /// <returns>The number of references for this pointer or 0xFFFFFFFF for an error</returns>
        [DllImport(DllPath)]
        public extern static int EdsRetain(IntPtr inRef);

        /// <summary>
        /// Decrements the reference counter of an object.
        /// When the reference counter reaches 0, the object is release.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <returns>The number of references for this pointer or 0xFFFFFFFF for an error</returns>
        [DllImport(DllPath)]
        public extern static int EdsRelease(IntPtr inRef);

        /// <summary>
        /// Gets the number of child objects of the designated object.
        /// Example: Number of files in a directory
        /// </summary>
        /// <param name="inRef">The reference of the list</param>
        /// <param name="outCount">Number of elements in this list.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetChildCount(IntPtr inRef, out int outCount);

        /// <summary>
        /// Gets an indexed child object of the designated object.
        /// </summary>
        /// <param name="inRef">The reference of the item</param>
        /// <param name="inIndex">The index that is passes in (zero based)</param>
        /// <param name="outRef">The pointer which receives reference of the specific index.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetChildAtIndex(IntPtr inRef, int inIndex, out IntPtr outRef);

        /// <summary>
        /// Gets the parent object of the designated object.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="outParentRef">The pointer which receives reference.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        public extern static ErrorCode EdsGetParent(IntPtr inRef, out IntPtr outParentRef);

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets information about the directory or file object on the memory card (volume) in a remote camera.
        /// This method works regardless of the used SDK version.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outDirItemInfo">Information of the directory item.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetDirectoryItemInfo(IntPtr inDirItemRef, out DirectoryItemInfo outDirItemInfo)
        {
            if (IsVerGE34) { return EdsGetDirectoryItemInfo(inDirItemRef, out outDirItemInfo); }
            else
            {
                DirectoryItemInfo_3_4 tmpValue;
                ErrorCode err = EdsGetDirectoryItemInfo(inDirItemRef, out tmpValue);
                if (err == ErrorCode.OK)
                {
                    outDirItemInfo = tmpValue.ToCurrent();
                    return err;
                }

                outDirItemInfo = default(DirectoryItemInfo);
                return err;
            }
        }

        /// <summary>
        /// Gets information about the directory or file object on the memory card (volume) in a remote camera.
        /// <para></para>
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outDirItemInfo">Information of the directory item.</param>
        /// <returns>Any of the SDK errors</returns>
        [DllImport(DllPath)]
        private extern static ErrorCode EdsGetDirectoryItemInfo(IntPtr inDirItemRef, out DirectoryItemInfo_3_4 outDirItemInfo);

        #endregion

        #region GetPropertyData Wrapper

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// This method takes care of differences between SDK versions.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <typeparam name="T">The type of a struct. Must be on of the types described in the <see cref="DataType"/> enum</typeparam>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData<T>(IntPtr inRef, PropertyID inPropertyID, int inParam, out T outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            outPropertyData = default(T);

            if (outPropertyData is PictureStyleDesc)
            {
                PictureStyleDesc tmpValue;
                err = GetPropertyData(inRef, inPropertyID, inParam, out tmpValue);
                if (err == ErrorCode.OK) outPropertyData = (T)(object)tmpValue;
            }
            else { err = GetPropertyDataSub(inRef, inPropertyID, inParam, out outPropertyData); }

            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <typeparam name="T">The type of a struct. Must be on of the types described in the <see cref="DataType"/> enum</typeparam>
        /// <returns>Any of the SDK errors</returns>
        private static ErrorCode GetPropertyDataSub<T>(IntPtr inRef, PropertyID inPropertyID, int inParam, out T outPropertyData)
        {
            IntPtr ptr = IntPtr.Zero;
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            outPropertyData = default(T);

            try
            {
                DataType dt;
                int size;
                err = EdsGetPropertySize(inRef, inPropertyID, inParam, out dt, out size);

                if (err == ErrorCode.OK)
                {
                    ptr = Marshal.AllocHGlobal(size);
                    err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, ptr);

                    if (err == ErrorCode.OK) outPropertyData = (T)Marshal.PtrToStructure(ptr, typeof(T));
                }
            }
            finally { if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr); }

            return err;
        }

        #region Primitive Types

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out bool outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(bool));
            bool val;
            unsafe
            {
                bool* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out byte outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(byte));
            byte val;
            unsafe
            {
                byte* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out short outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(short));
            short val;
            unsafe
            {
                short* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        [CLSCompliant(false)]
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out ushort outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(ushort));
            ushort val;
            unsafe
            {
                ushort* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        [CLSCompliant(false)]
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out uint outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(uint));
            uint val;
            unsafe
            {
                uint* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out int outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(int));
            int val;
            unsafe
            {
                int* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out string outPropertyData)
        {
            IntPtr ptr = IntPtr.Zero;
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            outPropertyData = string.Empty;
            try
            {
                DataType dt;
                int size;
                err = EdsGetPropertySize(inRef, inPropertyID, inParam, out dt, out size);

                if (err == ErrorCode.OK)
                {
                    ptr = Marshal.AllocHGlobal(size);
                    err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, ptr);

                    if (err == ErrorCode.OK) outPropertyData = Marshal.PtrToStringAnsi(ptr);
                }
            }
            finally { if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr); }
            return err;
        }

        #endregion

        #region Arrays

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out bool[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(bool));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new bool[propsize / tpsize];
                unsafe
                {
                    fixed (bool* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new bool[0];
            }
            else outPropertyData = new bool[0];
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out short[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(short));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new short[propsize / tpsize];
                unsafe
                {
                    fixed (short* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new short[0];
            }
            else outPropertyData = new short[0];
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out int[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(int));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new int[propsize / tpsize];
                unsafe
                {
                    fixed (int* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new int[0];
            }
            else outPropertyData = new int[0];
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out byte[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(byte));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new byte[propsize / tpsize];
                unsafe
                {
                    fixed (byte* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new byte[0];
            }
            else outPropertyData = new byte[0];
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        [CLSCompliant(false)]
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out uint[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(uint));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new uint[propsize / tpsize];
                unsafe
                {
                    fixed (uint* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new uint[0];
            }
            else outPropertyData = new uint[0];
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out Rational[] outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int tpsize = Marshal.SizeOf(typeof(Rational));
            int propsize;
            DataType proptype;
            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out proptype, out propsize);
            if (err == ErrorCode.OK)
            {
                var data = new Rational[propsize / tpsize];
                unsafe
                {
                    fixed (Rational* dataP = data)
                    {
                        err = EdsGetPropertyData(inRef, inPropertyID, inParam, propsize, (IntPtr)dataP);
                    }
                }
                if (err == ErrorCode.OK) outPropertyData = data;
                else outPropertyData = new Rational[0];
            }
            else outPropertyData = new Rational[0];
            return err;
        }

        #endregion

        #region Structs

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out Time outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(Time));
            Time val;
            unsafe
            {
                Time* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out FocusInfo outPropertyData)
        {
            IntPtr ptr = IntPtr.Zero;
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            try
            {
                int size = Marshal.SizeOf(typeof(FocusInfo));
                ptr = Marshal.AllocHGlobal(size);
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, ptr);

                outPropertyData = (FocusInfo)Marshal.PtrToStructure(ptr, typeof(FocusInfo));
            }
            finally { if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr); }
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out FocusPoint outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(FocusPoint));
            FocusPoint val;
            unsafe
            {
                FocusPoint* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out Size outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(Size));
            Size val;
            unsafe
            {
                Size* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out Rectangle outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(Rectangle));
            Rectangle val;
            unsafe
            {
                Rectangle* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out Point outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(Point));
            Point val;
            unsafe
            {
                Point* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out MyMenuItems outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            int size = Marshal.SizeOf(typeof(MyMenuItems));
            MyMenuItems val;
            unsafe
            {
                MyMenuItems* ptr = &val;
                err = EdsGetPropertyData(inRef, inPropertyID, inParam, size, (IntPtr)ptr);
            }
            outPropertyData = val;
            return err;
        }

        /// <summary>
        /// Gets property information from the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="inPropertyID">The property ID.</param>
        /// <param name="inParam">Additional information of property. Used in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The value of the property.</param>
        /// <returns>Any of the SDK errors</returns>
        public static ErrorCode GetPropertyData(IntPtr inRef, PropertyID inPropertyID, int inParam, out PictureStyleDesc outPropertyData)
        {
            ErrorCode err = ErrorCode.INTERNAL_ERROR;
            DataType dt;
            int size;
            outPropertyData = default(PictureStyleDesc);

            err = EdsGetPropertySize(inRef, inPropertyID, inParam, out dt, out size);

            if (err == ErrorCode.OK)
            {
                if (size == Marshal.SizeOf(typeof(PictureStyleDesc)))
                {
                    return GetPropertyDataSub(inRef, inPropertyID, inParam, out outPropertyData);
                }
                else if (size == Marshal.SizeOf(typeof(PictureStyleDesc_3_2)))
                {
                    PictureStyleDesc_3_2 tmpValue;
                    err = GetPropertyDataSub(inRef, inPropertyID, inParam, out tmpValue);
                    if (err == ErrorCode.OK)
                    {
                        outPropertyData = tmpValue.ToCurrent();
                        return err;
                    }
                }
                else throw new InvalidOperationException("Cannot find correct struct size");
            }

            return err;
        }

        #endregion

        #endregion
    }
}
