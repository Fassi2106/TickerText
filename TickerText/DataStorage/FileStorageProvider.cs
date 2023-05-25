using System.Xml.Serialization;

namespace TickerText.DataStorage;

public class FileStorageProvider : IStorageProvider
{
    private readonly string _filePath;

    private readonly Type _type;

    public FileStorageProvider(string filePath, Type type)
    {
        _filePath = filePath;
        _type = type;
    }

    public void SaveData(object data)
    {
        var serializer = new XmlSerializer(_type);

        using (var writer = new StreamWriter(_filePath))
        {
            serializer.Serialize(writer, data);
        }
    }

    public object? LoadData()
    {
        var serializer = new XmlSerializer(_type);

        using (var reader = new StreamReader(_filePath))
        {
            return serializer.Deserialize(reader);
        }
    }
}
