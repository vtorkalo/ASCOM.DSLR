using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OTelescope.SampleAPI
{
    public class OTelescopeTcpClient : IDisposable
    {
        private TcpClient TcpClient { get; set; }
        public int Port { get; private set; }

        public void Dispose()
        {
            TerminateTcpClient(false);
        }

        public OTelescopeTcpClient(int port = 1499)
        {
            Port = port;
        }
        /// <summary>
        /// Initialize the TcpClient 
        /// </summary>
        private void InitializeTcpClient(bool verbose = true)
        {
            if (TcpClient != null)
                TerminateTcpClient(verbose);

            try
            {
                TcpClient = new TcpClient("localhost", Port);
            }
            catch (Exception ex)
            {
                TerminateTcpClient(verbose);

                if (verbose)
                {
                    MessageBox.Show(string.Format("InitializeTcpClient: {1}{0}{0}{2}",
                        Environment.NewLine,
                        ex.Message,
                        "Make sure 'Enable TCP Server' is enabled in BackyardEOS/NIKON and that a camera is connected (powered on) to BackyardEOS/NIKON."),
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Close the TcpClient connection is it's open
        /// </summary>
        private void TerminateTcpClient(bool verbose = true)
        {
            if (TcpClient == null)
                return;

            try
            {
                TcpClient.Close();
            }
            catch (Exception ex)
            {
                if (verbose)
                {
                    MessageBox.Show(
                        "TerminateTcpClient: " + ex.Message,
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                TcpClient = null;
            }
        }

        /// <summary>
        /// Sends a command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="keepalive"></param>
        /// <param name="verbose"></param>
        public string SendCommand(string command, bool keepalive = true, bool verbose = false)
        {
            if (TcpClient == null)
                InitializeTcpClient(verbose);

            try
            {
                if (TcpClient?.Client == null)
                    return string.Empty;

                if (!TrySend(command, !keepalive))
                {
                    // This is a nice way to recover gracefully if the connection to the host 
                    // application is lost and available again when keepalive is used.
                    InitializeTcpClient(verbose);
                    TrySend(command);
                }


                if (command.StartsWith("get", StringComparison.InvariantCultureIgnoreCase))
                    return ReceiveData();
            }
            catch (Exception ex)
            {
                if (verbose)
                    MessageBox.Show(ex.Message);

                TerminateTcpClient(verbose);
            }
            finally
            {
                if (!keepalive)
                    TerminateTcpClient(verbose);
            }

            return "";
        }


        private bool TrySend(string command, bool onexceptionthrow = true)
        {
            try
            {
                Thread.Sleep(100);
                TcpClient.Client.Send(Encoding.ASCII.GetBytes(command));
                return true;
            }
            catch (Exception)
            {
                if (onexceptionthrow)
                    throw;
            }

            return false;
        }

        /// <summary>
        /// Process received  data
        /// </summary>
        /// <returns></returns>
        public string ReceiveData()
        {
            if (TcpClient == null)
                return string.Empty;

            var buffer = new byte[1024];
            TcpClient.Client.Receive(buffer);
            return Encoding.ASCII.GetString(buffer.TakeWhile(b => !b.Equals(0)).ToArray());
        }
    }
}
