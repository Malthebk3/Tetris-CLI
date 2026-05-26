namespace Tetris_CLI.Input;

public class InputHandler
{
    public bool Left;
    public bool Right;

    public void Update()
    {
        Left = Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.LeftArrow;
        Right = Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.RightArrow;
    }
}