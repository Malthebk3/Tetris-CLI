namespace Tetris_CLI.Input;

public class InputHandler
{
    public bool Left;
    public bool Right;
    public bool Rotate;
    public bool SoftDrop; //down arrow
    public bool HardDrop; //spacebar

    public void Update()
    {
        Left = Right = Rotate = SoftDrop = HardDrop = false;

        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow)    Left = true;
            if (key == ConsoleKey.RightArrow)   Right = true;
            if (key == ConsoleKey.UpArrow)      Rotate = true;
            if (key == ConsoleKey.DownArrow)    SoftDrop = true;
            if (key == ConsoleKey.Spacebar)     HardDrop = true;
        }
    }
}