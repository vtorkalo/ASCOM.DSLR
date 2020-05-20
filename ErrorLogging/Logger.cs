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
        
        public Logger()
        {
            try
            {
                lock (lgparams)
                {
                    if (lgparams.filePath.Equals(""))
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

        public void WriteMessage(string message)
        {
            LogParams.nlog.Error(message);
        }

    }
}
