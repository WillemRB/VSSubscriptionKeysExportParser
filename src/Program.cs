using System.Xml;
using System.Xml.Serialization;

namespace VSSubscriptionKeysExportParser;

internal class Program
{
    private static string _subscriptionFilePath = @".\KeysExport.xml";

    public static void Main(string[] args)
    {
        SubscritionProductKeys productKeys;

        var serializer = new XmlSerializer(typeof(SubscritionProductKeys));

        using (var reader = XmlReader.Create(_subscriptionFilePath))
        {
            var deserialized = serializer.Deserialize(reader);

            if (deserialized != null)
                productKeys = (SubscritionProductKeys)deserialized;
        }

        return;
    }
}