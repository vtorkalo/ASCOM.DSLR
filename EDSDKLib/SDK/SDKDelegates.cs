using System;

namespace EOSDigital.SDK
{
    /// <summary>
    /// A delegate for progress.
    /// </summary>
    /// <param name="inPercent">The progress. A value between 0 and 100</param>
    /// <param name="inContext">Reference to the object the progress is about</param>
    /// <param name="outCancel">Pass true to cancel the underlying process</param>
    /// <returns></returns>
    public delegate ErrorCode SDKProgressCallback(int inPercent, IntPtr inContext, ref bool outCancel);
    /// <summary>
    /// A delegate for property events.
    /// </summary>
    /// <param name="inEvent">The property event ID</param>
    /// <param name="inPropertyID">The property ID</param>
    /// <param name="inParameter">A parameter for additional information</param>
    /// <param name="inContext">A reference to the object that has sent the event</param>
    /// <returns>Any of the SDK errors</returns>
    public delegate ErrorCode SDKPropertyEventHandler(PropertyEventID inEvent, PropertyID inPropertyID, int inParameter, IntPtr inContext);
    /// <summary>
    /// A delegate for object events.
    /// </summary>
    /// <param name="inEvent">The object event ID</param>
    /// <param name="inRef">A pointer to the object that has changed</param>
    /// <param name="inContext">A reference to the object that has sent the event</param>
    /// <returns>Any of the SDK errors</returns>
    public delegate ErrorCode SDKObjectEventHandler(ObjectEventID inEvent, IntPtr inRef, IntPtr inContext);
    /// <summary>
    /// A delegate for state events.
    /// </summary>
    /// <param name="inEvent">The state event ID</param>
    /// <param name="inParameter">A parameter for additional information</param>
    /// <param name="inContext">A reference to the object that has sent the event</param>
    /// <returns>Any of the SDK errors</returns>
    public delegate ErrorCode SDKStateEventHandler(StateEventID inEvent, int inParameter, IntPtr inContext);
    /// <summary>
    /// A delegate to inform of an added camera.
    /// </summary>
    /// <param name="inContext">A reference to the added camera</param>
    /// <returns>Any of the SDK errors</returns>
    public delegate ErrorCode SDKCameraAddedHandler(IntPtr inContext);
}
