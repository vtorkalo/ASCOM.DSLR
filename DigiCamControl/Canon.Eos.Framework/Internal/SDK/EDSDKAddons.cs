using System;
using System.Runtime.InteropServices;

namespace Canon.Eos.Framework.Internal.SDK
{
    public partial class Edsdk
    {

        [DllImport(DllPath32, EntryPoint = "EdsSetPropertyData")]
        public extern static uint EdsSetPropertyData_32(IntPtr inRef, uint inPropertyID, int inParam, int inPropertySize, byte[] inPropertyData);

        [DllImport(DllPath64, EntryPoint = "EdsSetPropertyData")]
        public extern static uint EdsSetPropertyData_64(IntPtr inRef, uint inPropertyID, int inParam, int inPropertySize, byte[] inPropertyData);

        public static uint EdsSetPropertyData(IntPtr inRef, uint inPropertyID, int inParam, int inPropertySize, byte[] inPropertyData)
        {
            return IntPtr.Size == 4 /* 64bit */ ? EdsSetPropertyData_32(inRef, inPropertyID, inParam, inPropertySize, inPropertyData) : EdsSetPropertyData_64(inRef, inPropertyID, inParam, inPropertySize, inPropertyData);
        }

        [DllImport(DllPath32, EntryPoint = "EdsCreateEvfImageRef")]
        public extern static uint EdsCreateEvfImageRefCdecl_32(IntPtr inStreamRef, out IntPtr outEvfImageRef);
        [DllImport(DllPath64, EntryPoint = "EdsCreateEvfImageRef")]
        public extern static uint EdsCreateEvfImageRefCdecl_64(IntPtr inStreamRef, out IntPtr outEvfImageRef);

        public static uint EdsCreateEvfImageRefCdecl(IntPtr inStreamRef, out IntPtr outEvfImageRef)
        {
            return IntPtr.Size == 4 /* 64bit */ ? EdsCreateEvfImageRef_32(inStreamRef, out outEvfImageRef) : EdsCreateEvfImageRef_64(inStreamRef, out outEvfImageRef);
        }

        [DllImport(DllPath32, EntryPoint = "EdsDownloadEvfImage")]
        public extern static uint EdsDownloadEvfImageCdecl_32(IntPtr inCameraRef, IntPtr outEvfImageRef);
        [DllImport(DllPath64, EntryPoint = "EdsDownloadEvfImage")]
        public extern static uint EdsDownloadEvfImageCdecl_64(IntPtr inCameraRef, IntPtr outEvfImageRef);

        public static uint EdsDownloadEvfImageCdecl(IntPtr inCameraRef, IntPtr outEvfImageRef)
        {
            return IntPtr.Size == 4 /* 64bit */ ? EdsDownloadEvfImage_32(inCameraRef, outEvfImageRef) : EdsDownloadEvfImage_64(inCameraRef, outEvfImageRef);
        }

    }
}
