using System;
using System.IO;
using EOSDigital.SDK;

namespace EOSDigital.API
{
    /// <summary>
    /// A delegate for progress
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="progress">The progress. A value between 0 and 100</param>
    public delegate void ProgressHandler(object sender, int progress);
    /// <summary>
    /// A delegate to pass a stream
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="img">An image embedded in a stream</param>
    public delegate void LiveViewUpdate(Camera sender, Stream img);
    /// <summary>
    /// A delegate to report an available download
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="Info">The data for the download</param>
    public delegate void DownloadHandler(Camera sender, DownloadInfo Info);
    /// <summary>
    /// A delegate for property changes
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="eventID">The property event ID</param>
    /// <param name="propID">The property ID</param>
    /// <param name="parameter">A parameter for additional information</param>
    public delegate void PropertyChangeHandler(Camera sender, PropertyEventID eventID, PropertyID propID, int parameter);
    /// <summary>
    /// A delegate for camera state changes
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="eventID">The state event ID</param>
    /// <param name="parameter">A parameter for additional information</param>
    public delegate void StateChangeHandler(Camera sender, StateEventID eventID, int parameter);
    /// <summary>
    /// A delegate for property changes
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="eventID">The object event ID</param>
    /// <param name="reference">A pointer to the object that has changed</param>
    public delegate void ObjectChangeHandler(Camera sender, ObjectEventID eventID, IntPtr reference);
    /// <summary>
    /// A delegate to inform of an added camera
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    public delegate void CameraAddedHandler(CanonAPI sender);
    /// <summary>
    /// A delegate to inform of a change of a camera
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    public delegate void CameraUpdateHandler(Camera sender);
    /// <summary>
    /// A delegate to inform of SDK exceptions
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="ex">The SDK exception</param>
    public delegate void SDKExceptionHandler(object sender, ErrorCode ex);
    /// <summary>
    /// A delegate to inform of exceptions
    /// </summary>
    /// <param name="sender">The sender of this event</param>
    /// <param name="ex">The exception</param>
    public delegate void GeneralExceptionHandler(object sender, Exception ex);
}
