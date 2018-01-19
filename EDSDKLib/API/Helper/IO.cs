using System;
using System.IO;
using EOSDigital.SDK;
using SeekOrigin = System.IO.SeekOrigin;
using FileAccess = EOSDigital.SDK.FileAccess;

namespace EOSDigital.API
{
    /// <summary>
    /// Stores information to download data from the camera
    /// </summary>
    public class DownloadInfo
    {
        /// <summary>
        /// Pointer to the downloadable object
        /// </summary>
        protected IntPtr inRef;
        /// <summary>
        /// Directory item info of the downloadable object
        /// </summary>
        protected DirectoryItemInfo dirInfo;

        /// <summary>
        /// Pointer to the downloadable object
        /// </summary>
        public IntPtr Reference { get { return inRef; } }
        /// <summary>
        /// The name of the file. You can change it before you pass it to the
        /// <see cref="Camera.DownloadFile(DownloadInfo)"/> or
        /// <see cref="Camera.DownloadFile(DownloadInfo, string)"/> method.
        /// </summary>
        public string FileName
        {
            get { return dirInfo.FileName; }
            set { dirInfo.FileName = value; }
        }
        /// <summary>
        /// The files size in bytes
        /// </summary>
        public int Size { get { return dirInfo.Size; } }
        /// <summary>
        /// The files size in bytes (as ulong)
        /// </summary>
        public long Size64 { get { return dirInfo.Size64; } }
        /// <summary>
        /// States if the file is a RAW file or not
        /// </summary>
        public bool IsRAW { get; protected set; }

        /// <summary>
        /// Creates a new instance of the <see cref="DownloadInfo"/> class
        /// </summary>
        /// <param name="inRef">Pointer to the downloadable object</param>
        internal protected DownloadInfo(IntPtr inRef)
        {
            if (inRef == IntPtr.Zero) throw new ArgumentNullException(nameof(inRef));

            this.inRef = inRef;
            ErrorHandler.CheckError(this, CanonSDK.GetDirectoryItemInfo(inRef, out dirInfo));
            string ext = Path.GetExtension(FileName).ToLower();
            if (ext == ".crw" || ext == ".cr2") IsRAW = true;
            else IsRAW = false;
        }
    }

    /// <summary>
    /// Stores information about a file or folder in a camera
    /// </summary>
    public partial class CameraFileEntry : IDisposable
    {
        /// <summary>
        /// Pointer to the file entry
        /// </summary>
        public IntPtr Reference { get { return Ref; } }
        /// <summary>
        /// The name of the entry. (volume name, folder name or file name)
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// States if the entry is a folder or not
        /// </summary>
        public bool IsFolder { get; protected set; }
        /// <summary>
        /// States if the entry is a volume or not
        /// </summary>
        public bool IsVolume { get; protected set; }
        /// <summary>
        /// If the entry is a volume or folder, these are the subentries it contains. It's null if no subentries are present.
        /// </summary>
        public CameraFileEntry[] Entries { get; internal protected set; }

        /// <summary>
        /// Pointer to the file entry
        /// </summary>
        protected IntPtr Ref;
        /// <summary>
        /// States if the entry is disposed or not
        /// </summary>
        internal protected bool IsDisposed;

        /// <summary>
        /// Creates a new instance of the <see cref="CameraFileEntry"/> class
        /// </summary>
        /// <param name="Ref"></param>
        /// <param name="Name"></param>
        /// <param name="IsFolder"></param>
        /// <param name="IsVolume"></param>
        internal protected CameraFileEntry(IntPtr Ref, string Name, bool IsFolder, bool IsVolume)
        {
            this.Ref = Ref;
            this.Name = Name;
            this.IsFolder = IsFolder;
            this.IsVolume = IsVolume;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~CameraFileEntry()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases this entry but not the subentries
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases this entry and all the subentries
        /// </summary>
        public void DisposeAll()
        {
            Dispose();
            if (Entries != null) for (int i = 0; i < Entries.Length; i++) Entries[i].DisposeAll();
        }

        /// <summary>
        /// Releases this entry but not the subentries
        /// </summary>
        /// <param name="managed">True if called from Dispose, false if called from the finalizer/destructor</param>
        protected virtual void Dispose(bool managed)
        {
            if (!IsDisposed)
            {
                if (managed) DisposeThumb();
                if (Reference != IntPtr.Zero) CanonSDK.EdsRelease(Reference);
                IsDisposed = true;
            }
        }

        /// <summary>
        /// Dispose the thumbnail in an extension
        /// </summary>
        partial void DisposeThumb();

        /// <summary>
        /// Set the thumbnail from a stream. The thumbnail depends on the image class you want to use.
        /// </summary>
        /// <param name="stream">The image stream</param>
        internal protected virtual void SetThumb(IntPtr stream)
        {
            SetThumbSub(stream);
        }

        /// <summary>
        /// Sets the thumbnail
        /// </summary>
        /// <param name="stream">The image stream</param>
        partial void SetThumbSub(IntPtr stream);


        /// <summary>
        /// Determines whether the specified <see cref="CameraFileEntry"/>s are equal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="CameraFileEntry"/></param>
        /// <param name="y">The second <see cref="CameraFileEntry"/></param>
        /// <returns>True if the <see cref="CameraFileEntry"/>s are equal; otherwise, false</returns>
        public static bool operator ==(CameraFileEntry x, CameraFileEntry y)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(x, y)) return true;

            // If one is null, but not both, return false.
            if ((object)x == null || (object)y == null) return false;

            return x.Reference == y.Reference;
        }
        /// <summary>
        /// Determines whether the specified <see cref="CameraFileEntry"/>s are unequal to each other.
        /// </summary>
        /// <param name="x">The first <see cref="CameraFileEntry"/></param>
        /// <param name="y">The second <see cref="CameraFileEntry"/></param>
        /// <returns>True if the <see cref="CameraFileEntry"/>s are unequal; otherwise, false</returns>
        public static bool operator !=(CameraFileEntry x, CameraFileEntry y)
        {
            return !(x == y);
        }
        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="CameraFileEntry"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="CameraFileEntry"/></param>
        /// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="CameraFileEntry"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            // If objects have different types, return false.
            if (obj.GetType() != GetType()) return false;

            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(this, obj)) return true;

            CameraFileEntry cv = obj as CameraFileEntry;
            if (cv == null) return false;

            return Reference == cv.Reference;
        }
        /// <summary>
        /// Serves as a hash function for a <see cref="CameraFileEntry"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="CameraFileEntry"/></returns>
        public override int GetHashCode()
        {
            return Reference.ToInt64().GetHashCode();
        }
    }

    /// <summary>
    /// A Stream encapsulating an unmanaged SDK Stream.
    /// This class can be used to overcome the differences between SDK versions
    /// </summary>
    public class SDKStream : Stream
    {
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }
        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get { return true; }
        }
        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }
        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get
            {
                if (CanonSDK.IsVerGE34)
                {
                    long length;
                    CanonSDK.EdsGetLength(Reference, out length);
                    return length;
                }
                else
                {
                    int length;
                    CanonSDK.EdsGetLength(Reference, out length);
                    return length;
                }
            }
        }
        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get
            {
                if (CanonSDK.IsVerGE34)
                {
                    long position;
                    CanonSDK.EdsGetPosition(Reference, out position);
                    return position;
                }
                else
                {
                    int position;
                    CanonSDK.EdsGetPosition(Reference, out position);
                    return position;
                }
            }
            set { Seek(value, SeekOrigin.Begin); }
        }
        /// <summary>
        /// Pointer to the underlying SDK stream
        /// </summary>
        public IntPtr Reference
        {
            get { return _Reference; }
            protected set { _Reference = value; }
        }
        private IntPtr _Reference;


        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class from an existing SDK stream
        /// </summary>
        /// <param name="sdkStream">Pointer to the SDK stream</param>
        public SDKStream(IntPtr sdkStream)
        {
            if (sdkStream == IntPtr.Zero) throw new ArgumentNullException(nameof(sdkStream));
            Reference = sdkStream;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class with an underlying SDK file stream
        /// </summary>
        /// <param name="filepath">Path to the file</param>
        /// <param name="createDisposition">State how to create the stream</param>
        /// <param name="access">File access type</param>
        public SDKStream(string filepath, FileCreateDisposition createDisposition, FileAccess access)
        {
            if (filepath == null) throw new ArgumentNullException(nameof(filepath));
            ErrorHandler.CheckError(CanonSDK.EdsCreateFileStreamEx(filepath, createDisposition, access, out _Reference));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class with an underlying SDK memory stream.
        /// This stream will resize itself if the current length is exceeded
        /// </summary>
        /// <param name="length">Initial buffer size of the stream in bytes</param>
        public SDKStream(long length)
        {
            ErrorCode err;
            if (CanonSDK.IsVerGE34) err = CanonSDK.EdsCreateMemoryStream(length, out _Reference);
            else err = CanonSDK.EdsCreateMemoryStream((int)length, out _Reference);
            ErrorHandler.CheckError(err);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class with an underlying SDK memory stream.
        /// Note that this stream will not resize itself
        /// </summary>
        /// <param name="buffer">The memory buffer to use for the stream</param>
        public SDKStream(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            ErrorCode err;
            if (CanonSDK.IsVerGE34) err = CanonSDK.EdsCreateMemoryStreamFromPointer(buffer, buffer.LongLength, out _Reference);
            else err = CanonSDK.EdsCreateMemoryStreamFromPointer(buffer, (int)buffer.LongLength, out _Reference);
            ErrorHandler.CheckError(err);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class with an underlying SDK memory stream.
        /// Note that this stream will not resize itself
        /// </summary>
        /// <param name="buffer">Pointer to the memory buffer to use for the stream</param>
        /// <param name="length">The size of the memory buffer in bytes</param>
        public SDKStream(IntPtr buffer, long length)
        {
            if (buffer == IntPtr.Zero) throw new ArgumentNullException(nameof(buffer));

            ErrorCode err;
            if (CanonSDK.IsVerGE34) err = CanonSDK.EdsCreateMemoryStreamFromPointer(buffer, length, out _Reference);
            else err = CanonSDK.EdsCreateMemoryStreamFromPointer(buffer, (int)length, out _Reference);
            ErrorHandler.CheckError(err);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SDKStream"/> class from an existing SDK stream.
        /// Note that this calls <see cref="SDKStream(IntPtr)"/> internally and ignores all parameters but <paramref name="sdkStream"/>
        /// </summary>
        /// <param name="buffer">Pointer to the underlying SDK buffer. Ignored parameter</param>
        /// <param name="sdkStream">Pointer to the SDK stream</param>
        /// <param name="length">The size of the underlying SDK buffer in bytes. Ignored parameter</param>
        [Obsolete("Not necessary anymore. Buffer and length is not used.")]
        public SDKStream(IntPtr buffer, IntPtr sdkStream, long length)
            : this(sdkStream)
        { }


        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be
        /// written to the underlying device.
        /// This is not applicable to the SDK and therefore does nothing.
        /// </summary>
        public override void Flush()
        {
            //Nothing to do here
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position
        /// within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified
        /// byte array with the values between offset and (offset + count - 1) replaced by
        /// the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read
        /// from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number
        /// of bytes requested if that many bytes are not currently available, or zero (0)
        /// if the end of the stream has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return (int)Read(buffer, offset, count);
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position
        /// within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified
        /// byte array with the values between offset and (offset + count - 1) replaced by
        /// the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read
        /// from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number
        /// of bytes requested if that many bytes are not currently available, or zero (0)
        /// if the end of the stream has been reached.</returns>
        public unsafe long Read(byte[] buffer, long offset, long count)
        {
            if (buffer.LongLength < offset + count) throw new ArgumentOutOfRangeException();

            fixed (byte* bufferPtr = buffer)
            {
                byte* offsetBufferPtr = bufferPtr + offset;

                if (CanonSDK.IsVerGE34)
                {
                    long read;
                    ErrorHandler.CheckError(CanonSDK.EdsRead(_Reference, count, (IntPtr)offsetBufferPtr, out read));
                    return read;
                }
                else
                {
                    int read;
                    ErrorHandler.CheckError(CanonSDK.EdsRead(_Reference, (int)count, (IntPtr)offsetBufferPtr, out read));
                    return read;
                }
            }
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the
        /// reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            SDK.SeekOrigin sdkOrigin;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    sdkOrigin = SDK.SeekOrigin.Begin;
                    break;
                case SeekOrigin.Current:
                    sdkOrigin = SDK.SeekOrigin.Current;
                    break;
                case SeekOrigin.End:
                    sdkOrigin = SDK.SeekOrigin.End;
                    break;

                default:
                    throw new ArgumentException("Not a valid enum value", nameof(origin));
            }

            if (CanonSDK.IsVerGE34) ErrorHandler.CheckError(CanonSDK.EdsSeek(_Reference, offset, sdkOrigin));
            else ErrorHandler.CheckError(CanonSDK.EdsSeek(_Reference, (int)offset, sdkOrigin));

            return Position;
        }

        /// <summary>
        /// Always throws a <see cref="NotSupportedException"/>
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances
        /// the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            Write(buffer, (long)offset, count);
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances
        /// the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public unsafe void Write(byte[] buffer, long offset, long count)
        {
            if (buffer.LongLength < offset + count) throw new ArgumentOutOfRangeException();

            fixed (byte* bufferPtr = buffer)
            {
                byte* offsetBufferPtr = bufferPtr + offset;

                if (CanonSDK.IsVerGE34)
                {
                    long written;
                    ErrorHandler.CheckError(CanonSDK.EdsWrite(_Reference, count, (IntPtr)offsetBufferPtr, out written));
                }
                else
                {
                    int written;
                    ErrorHandler.CheckError(CanonSDK.EdsWrite(_Reference, (int)count, (IntPtr)offsetBufferPtr, out written));
                }
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="SDKStream"/> and optionally
        /// releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_Reference != IntPtr.Zero)
            {
                int err = CanonSDK.EdsRelease(_Reference);
                Reference = IntPtr.Zero;
                if (disposing) ErrorHandler.CheckError(err);
            }
        }
    }
}
