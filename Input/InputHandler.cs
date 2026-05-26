namespace Tetris_CLI.Input;

public class InputHandler
{
    public bool Left;
    public bool Right;
    public bool Rotate;
    public bool Down;

    public void Update()
    {
        Left = false;
        Right = false;
        Rotate = false;
        Down = false;

        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            Left = key == ConsoleKey.LeftArrow;
            Right = key == ConsoleKey.RightArrow;
            Rotate = key == ConsoleKey.UpArrow;
        }
    }
}