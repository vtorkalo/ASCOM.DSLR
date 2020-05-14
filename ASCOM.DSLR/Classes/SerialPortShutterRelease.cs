using System.IO.Ports;


namespace CameraControl.Plugins.ExternalDevices
{
    public class SerialPortShutterRelease 
    {
        SerialPort serialPort;
        public SerialPortShutterRelease(string portName)
        {
            serialPort = new SerialPort(portName);
        }

        public string Name { get; set; }

    
        public void OpenShutter()
        {
            serialPort.Open();
            serialPort.RtsEnable = true;
        }

        public void CloseShutter()
        {
            serialPort.RtsEnable = false;
            serialPort.Close();
        }
    }
}