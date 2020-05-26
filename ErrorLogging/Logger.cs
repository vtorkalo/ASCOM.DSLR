using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace Logging
{
    class LogParams
    {
        public string filePath = @"";
        public NLog.Config.LoggingConfiguration nlogConfig;
        public NLog.Config.LoggingRule logruleLevels = null;
        public NLog.Targets.Target target;
        public static NLog.Logger nlog;
        public NLog.LogLevel logLevel = NLog.LogLevel.Fatal;
    }
    public class Logger
    {
 
        static private LogParams lgparams = new LogParams();

        static public void SetLogLevelTrace()
        {
            lock (lgparams)
            {
                lgparams.logLevel = NLog.LogLevel.Trace;
            }

            CheckAndInitLogger();
        }

        static public void SetLogLevelDebug()
        {
            lock (lgparams)
            {
                lgparams.logLevel = NLog.LogLevel.Debug;
            }

            CheckAndInitLogger();
        }

        static public void SetLogLevelInfo()
        {
            lock (lgparams)
            {
                lgparams.logLevel = NLog.LogLevel.Info;
            }

            CheckAndInitLogger();
        }

        static public void SetLogLevelWarn()
        {
            lock (lgparams)
            {
                lgparams.logLevel = NLog.LogLevel.Warn;
            }

            CheckAndInitLogger();
        }

        static public void SetLogLevelError()
        {
            lock (lgparams)
            {
                lgparams.logLevel = NLog.LogLevel.Error;
            }

            CheckAndInitLogger();
        }

        static public void SetLogLevelFatal()
        {
            lock (lgparams)
            {

                lgparams.logLevel = NLog.LogLevel.Fatal;
            }

            CheckAndInitLogger();
        }


        static private void CheckAndInitLogger()
        {
            try
            {
                lock (lgparams)
                {

                    // TODO: fix this so that it updates the log level when called.  May need to store the rule in lgparams to allow it to be deleted
                    //       before resetting

                    if (lgparams.filePath.Equals(""))  // This is probably a little strange, but there is possibility that lgparams could have been set
                                                        // between when the check above occured and when we locked the containing object
                    {
                        DateTime localdate = DateTime.Now;

                        lgparams.filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        lgparams.filePath += "\\ASCOM";
                        lgparams.filePath += "\\Logs ";
                        lgparams.filePath += localdate.Year.ToString("D4");
                        lgparams.filePath += "-";
                        lgparams.filePath += localdate.Month.ToString("D2");
                        lgparams.filePath += "-";
                        lgparams.filePath += localdate.Day.ToString("D2");
                        lgparams.filePath += "\\ASCOM.DSLR.CameraDebug.";
                        lgparams.filePath += localdate.Hour.ToString("D2");
                        lgparams.filePath += localdate.Minute.ToString("D2");
                        lgparams.filePath += ".";
                        lgparams.filePath += localdate.Second.ToString("D2");
                        lgparams.filePath += localdate.Millisecond.ToString("D4");
                        lgparams.filePath += ".txt";
                    }

                    lgparams.target = new NLog.Targets.FileTarget("logfile") { FileName = lgparams.filePath };

                    lgparams.nlogConfig = new NLog.Config.LoggingConfiguration();

                    if(lgparams.logruleLevels != null)
                    {
                        lgparams.nlogConfig.LoggingRules.Remove(lgparams.logruleLevels);

                        lgparams.logruleLevels = null;
                    }

                    lgparams.logruleLevels = new LoggingRule("*", lgparams.logLevel, LogLevel.Fatal, lgparams.target);

                    lgparams.nlogConfig.LoggingRules.Add(lgparams.logruleLevels);

                    // lgparams.nlogConfig.AddRule(lgparams.logLevel, LogLevel.Fatal, lgparams.target);

                    NLog.LogManager.Configuration = lgparams.nlogConfig;

                    LogParams.nlog = NLog.LogManager.GetCurrentClassLogger();
                }
            }
            catch (Exception e)
            {
                string s = e.Message;
            }
 
            // code for unit testing... uncomment if unit testing

            // LogParams.nlog.Trace("Unit test -> Trace message");
            // LogParams.nlog.Debug("Unit test -> Debug message");
            // LogParams.nlog.Info("Unit test -> Info message");
            // LogParams.nlog.Warn("Unit test -> Warn message");
            // LogParams.nlog.Error("Unit test -> Error message");
            // LogParams.nlog.Fatal("Unit test -> Fatal message");
        }

        static public void WriteErrorMessage(string message)
        {
            CheckAndInitLogger();

            LogParams.nlog.Error(message);
        }

        static public void WriteDebugMessage(string message)
        {
            CheckAndInitLogger();

            LogParams.nlog.Debug(message);
        }

        static public void WriteInfoMessage(string message)
        {
            CheckAndInitLogger();

            LogParams.nlog.Info(message);
        }

        static public void WriteTraceMessage(string message)
        {
            CheckAndInitLogger();

            LogParams.nlog.Trace(message);
        }
        // static public void WriteMessage(string message)
        // {
        //    WriteErrorMessage(message);
        // }

    }
}
