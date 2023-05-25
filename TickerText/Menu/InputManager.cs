namespace TickerText.Menu;

public class InputManager<T>
{
    private readonly string _message;

    private const string ErrorMessageEmptyInput = "Empty input. Try again.";

    private const string ErrorMessageInvalidInput = "Invalid input. Try again.";

    private readonly bool _allowEmpty;
    
    public InputManager(string message, bool allowEmpty = false)
    {
        _message = message;

        _allowEmpty = allowEmpty;
    }

    public T ReceiveInput()
    {
        Console.Write(_message);
        
        var input = Console.ReadLine();

        if (_allowEmpty)
        {
            return default;
        }
        
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine(ErrorMessageEmptyInput);

            return ReceiveInput();
        }

        if (!TryConvertStringToGenericType(input, out T? result) || result == null)
        {
            Console.WriteLine(ErrorMessageInvalidInput);

            return ReceiveInput();
        }

        return result;
    }
    
    private static bool TryConvertStringToGenericType<T>(string value, out T? result)
    {
        var success = false;
        result = default(T);
        
        if (typeof(IConvertible).IsAssignableFrom(typeof(T)))
        {
            try
            {
                result = (T)Convert.ChangeType(value, typeof(T));
                success = true;
            }
            catch (Exception)
            { }
        }
    
        return success;
    }
}