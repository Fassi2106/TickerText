namespace TickerText.DataStorage;

public interface IStorageProvider
{
    void SaveData(object data);
    
    object? LoadData(object? _default);
}