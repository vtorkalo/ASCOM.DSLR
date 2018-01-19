using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EOSDigital.SDK;

namespace EOSDigital.API
{
    /// <summary>
    /// An Exception that happened while handling the Canon SDK
    /// </summary>
    [Serializable]
    public sealed class SDKException : Exception
    {
        /// <summary>
        /// The specific SDK error code that happened
        /// </summary>
        public ErrorCode Error { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class
        /// </summary>
        public SDKException()
        {
            Error = ErrorCode.INTERNAL_ERROR;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with a specified error code
        /// </summary>
        /// <param name="Error">The SDK error code of the error that happened</param>
        public SDKException(ErrorCode Error)
            : base(Error.ToString())
        {
            this.Error = Error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public SDKException(string message)
            : base(message)
        {
            Error = ErrorCode.INTERNAL_ERROR;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of
        /// this exception
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified</param>
        public SDKException(string message, Exception innerException)
            : base(message, innerException)
        {
            Error = ErrorCode.INTERNAL_ERROR;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with a specified error message and error code
        /// </summary>
        /// <param name="Error">The SDK error code of the error that happened</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public SDKException(string message, ErrorCode Error)
            : base(message)
        {
            this.Error = Error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with a specified
        /// error message, error code and a reference to the inner exception that is the cause of
        /// this exception
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="Error">The SDK error code of the error that happened</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public SDKException(string message, ErrorCode Error, Exception innerException)
            : base(message, innerException)
        {
            this.Error = Error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized 
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/>  that contains contextual
        /// information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private SDKException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Error = (ErrorCode)info.GetUInt32("Error");
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/>
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"/>
        /// that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is a null reference</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            info.AddValue("Error", Error);

            base.GetObjectData(info, context);
        }
    }

    /// <summary>
    /// An Exception that states a problem with the session state of the camera
    /// </summary>
    [Serializable]
    public sealed class CameraSessionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraSessionException"/> class
        /// </summary>
        public CameraSessionException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraSessionException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public CameraSessionException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraSessionException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of
        /// this exception
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified</param>
        public CameraSessionException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraSessionException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized 
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/>  that contains contextual
        /// information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private CameraSessionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/>
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"/>
        /// that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is a null reference</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            base.GetObjectData(info, context);
        }
    }

    /// <summary>
    /// An Exception that states a problem with the state of the Canon SDK
    /// </summary>
    [Serializable]
    public sealed class SDKStateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SDKStateException"/> class
        /// </summary>
        public SDKStateException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKStateException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public SDKStateException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKStateException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of
        /// this exception
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified</param>
        public SDKStateException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDKStateException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized 
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/>  that contains contextual
        /// information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private SDKStateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/>
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"/>
        /// that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is a null reference</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            base.GetObjectData(info, context);
        }
    }

    /// <summary>
    /// An Exception that happened while executing on an STA thread
    /// </summary>
    [Serializable]
    public sealed class ExecutionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ExecutionException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionException"/> class with a reference to
        /// the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified</param>
        public ExecutionException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized 
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/>  that contains contextual
        /// information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private ExecutionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/>
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"/>
        /// that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is a null reference</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            base.GetObjectData(info, context);
        }
    }

    /// <summary>
    /// Handles errors and provides events for errors (e.g. focus problems or general exceptions)
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// If an error happened, that does not break the program, this event is fired (e.g. a focus error)
        /// </summary>
        public static event SDKExceptionHandler NonSevereErrorHappened;
        /// <summary>
        /// If an error happened on a thread that does not fall into the non-severe category, this event is fired
        /// </summary>
        public static event GeneralExceptionHandler SevereErrorHappened;
        /// <summary>
        /// List of all non-severe errors. Items can be added or removed.
        /// </summary>
        public static List<ErrorCode> NonSevereErrors { get; private set; }

        static ErrorHandler()
        {
            NonSevereErrors = new List<ErrorCode>()
            {
                ErrorCode.TAKE_PICTURE_AF_NG,
                ErrorCode.TAKE_PICTURE_CARD_NG,
                ErrorCode.TAKE_PICTURE_CARD_PROTECT_NG,
                ErrorCode.TAKE_PICTURE_LV_REL_PROHIBIT_MODE_NG,
                ErrorCode.TAKE_PICTURE_MIRROR_UP_NG,
                ErrorCode.TAKE_PICTURE_MOVIE_CROP_NG,
                ErrorCode.TAKE_PICTURE_NO_CARD_NG,
                ErrorCode.TAKE_PICTURE_NO_LENS_NG,
                ErrorCode.TAKE_PICTURE_SENSOR_CLEANING_NG,
                ErrorCode.TAKE_PICTURE_SILENCE_NG,
                ErrorCode.TAKE_PICTURE_SPECIAL_MOVIE_MODE_NG,
                ErrorCode.TAKE_PICTURE_STROBO_CHARGE_NG,
                ErrorCode.LENS_COVER_CLOSE,
                ErrorCode.DEVICE_BUSY,
            };
        }

        /// <summary>
        /// Checks for an error in SDK calls and checks how to treat it
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="errorCode">The return code of the SDK call</param>
        /// <exception cref="SDKException">If a severe error is recognized or the <see cref="NonSevereErrorHappened"/>
        /// event is null with a non-severe error, it will be thrown as an exception</exception>
        public static void CheckError(object sender, ErrorCode errorCode)
        {
            if (errorCode == ErrorCode.OK) return;
            else
            {
                bool Severe = !NonSevereErrors.Any(t => t == errorCode);

                var NonSevereErrorHappenedEvent = NonSevereErrorHappened;
                if (!Severe) Severe = NonSevereErrorHappenedEvent == null;

                if (Severe) throw new SDKException(errorCode);
                else NonSevereErrorHappenedEvent.BeginInvoke(sender, errorCode, (a) =>
                {
                    var ar = a as AsyncResult;
                    var invokedMethod = ar.AsyncDelegate as SDKExceptionHandler;
                    invokedMethod.EndInvoke(a);
                }, null);
            }
        }

        /// <summary>
        /// Checks for an error in SDK calls and throws an exception if it's not <see cref="ErrorCode.OK"/>
        /// </summary>
        /// <param name="errorCode">The return code of the SDK call</param>
        /// <exception cref="SDKException">If <paramref name="errorCode"/> is something other than <see cref="ErrorCode.OK"/></exception>
        public static void CheckError(ErrorCode errorCode)
        {
            if (errorCode != ErrorCode.OK) throw new SDKException(errorCode);
        }

        /// <summary>
        /// Checks for an error in <see cref="CanonSDK.EdsRetain"/> and <see cref="CanonSDK.EdsRelease"/> calls
        /// and throws an exception if it's not valid
        /// </summary>
        /// <param name="countOrError">The return code of the SDK call</param>
        /// <returns>The number of references for the pointer that was used for the SDK call</returns>
        public static int CheckError(int countOrError)
        {
            if (countOrError == unchecked((int)0xFFFFFFFF)) throw new SDKException(ErrorCode.INVALID_HANDLE);
            else return countOrError;
        }

        /// <summary>
        /// Checks for an error in <see cref="CanonSDK.EdsRetain"/> and <see cref="CanonSDK.EdsRelease"/> calls
        /// and throws an exception if it's not valid
        /// </summary>
        /// <param name="sender">The calling object instance. This is currently not used and is ignored.</param>
        /// <param name="countOrError">The return code of the SDK call</param>
        /// <returns>The number of references for the pointer that was used for the SDK call</returns>
        public static int CheckError(object sender, int countOrError)
        {
            return CheckError(countOrError);
        }

        /// <summary>
        /// Reports an error that happened in a threading environment
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="ex">The exception that happened</param>
        /// <returns>True if the error could be passed on; false otherwise</returns>
        public static bool ReportError(object sender, Exception ex)
        {
            var SevereErrorHappenedEvent = SevereErrorHappened;
            if (SevereErrorHappenedEvent == null) return false;
            else
            {
                SevereErrorHappenedEvent.BeginInvoke(sender, ex, (a) =>
                {
                    var ar = a as AsyncResult;
                    var invokedMethod = ar.AsyncDelegate as GeneralExceptionHandler;
                    invokedMethod.EndInvoke(a);
                }, null);
                return true;
            }
        }
    }
}
