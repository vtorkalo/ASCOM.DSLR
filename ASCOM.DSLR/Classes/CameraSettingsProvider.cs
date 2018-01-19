using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ASCOM.DSLR.Classes
{
    public class CameraSettingsProvider
    {
        public CameraSettings ReadSettings(string serialized)
        {
            var type = typeof(CameraSettings);
            var serializer = new XmlSerializer(type);
            CameraSettings result = null;

            using (TextReader reader = new StringReader(serialized))
            {
                result = (CameraSettings)serializer.Deserialize(reader);
            }
            return result;
        }

        public string SaveSettings(CameraSettings settings)
        {
            XmlSerializer xsSubmit = new XmlSerializer(settings.GetType());
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, settings);
                    xml = sww.ToString();
                }
            }

            return xml;
        }
    }
}
