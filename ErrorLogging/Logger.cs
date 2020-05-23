using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace Logging
{
    class LogParams
    {
        public string filePath = @"";
        public NLog.Config.LoggingConfiguration nlogConfig;
        public NLog.Targets.Target target;
        public static NLog.Logger nlog;
    }
    public class Logger
    {
        static LogParams lgparams = new LogParams();

        static private void checkAndInitLogger()
        {
            if (lgparams.filePath.Equals(""))
            {
                try
                {
                    lock (lgparams)
                    {
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

                            lgparams.target = new NLog.Targets.FileTarget("logfile") { FileName = lgparams.filePath };

                            lgparams.nlogConfig = new NLog.Config.LoggingConfiguration();

                            lgparams.nlogConfig.AddRule(LogLevel.Info, LogLevel.Fatal, lgparams.target);

                            NLog.LogManager.Configuration = lgparams.nlogConfig;

                            LogParams.nlog = NLog.LogManager.GetCurrentClassLogger();
                        }
                    }
                }
                catch (Exception e)
                {
                    string s = e.Message;
                }
            }
        }

        static public void WriteErrorMessage(string message)
        {
            checkAndInitLogger();

            LogParams.nlog.Error(message);
        }

        static public void WriteDebugMessage(string message)
        {
            checkAndInitLogger();

            LogParams.nlog.Debug(message);
        }

        static public void WriteInfoMessage(string message)
        {
            checkAndInitLogger();

            LogParams.nlog.Info(message);
        }

        static public void WriteTraceMessage(string message)
        {
            checkAndInitLogger();

            LogParams.nlog.Trace(message);
        }
        static public void WriteMessage(string message)
        {
            WriteErrorMessage(message);
        }

    }
}
