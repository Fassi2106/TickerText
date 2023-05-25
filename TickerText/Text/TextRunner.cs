namespace TickerText.Text;

public class TextRunner
{
    private readonly string[] _lines;
    private readonly int _speed;
    private readonly int _windowWidth;
    private readonly int _windowHeight;
    private int _currentPosition;
    private ConsoleColor _textColor;
    private bool _isBlinking;

    public TextRunner(string[] lines, int speed, ConsoleColor textColor, bool isBlinking)
    {
        _lines = lines;
        _speed = speed;
        _windowWidth = Console.WindowWidth;
        _windowHeight = Console.WindowHeight;
        _currentPosition = _windowWidth;
        _textColor = textColor;
        _isBlinking = isBlinking;
    }

    public void Start()
    {
        int linesToDisplay = Math.Min(_lines.Length, _windowHeight);

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < linesToDisplay; i++)
            {
                int displayColumn = _currentPosition;

                if (displayColumn < 0)
                {
                    displayColumn = _windowWidth + displayColumn;
                }

                if (displayColumn < _windowWidth)
                {
                    Console.SetCursorPosition(displayColumn, i);
                    Console.ForegroundColor = _textColor;
                    Console.Write(_lines[i]);
                }
                else
                {
                    int overflow = displayColumn - _windowWidth;
                    Console.SetCursorPosition(0, i);
                    Console.ForegroundColor = _textColor;
                    Console.Write(_lines[i].Substring(overflow) + _lines[i].Substring(0, overflow));
                }
            
                Console.SetCursorPosition(0, i);
            }

            if (_isBlinking)
            {
                Thread.Sleep(_speed);
                Console.Clear();
                Thread.Sleep(_speed);
            }
            else
            {
                Thread.Sleep(_speed);
            }

            _currentPosition--;

            if (_currentPosition < -_windowWidth)
            {
                _currentPosition = _windowWidth;
            }
        }
    }
}