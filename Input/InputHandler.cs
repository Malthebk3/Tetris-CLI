namespace Tetris_CLI.Input;

public class InputHandler
{
    public bool Left;
    public bool Right;

    public void Update()
    {
        Left = false;
        Right = false;

        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            Left = key == ConsoleKey.LeftArrow;
            Right = key == ConsoleKey.RightArrow;
        }
    }
}