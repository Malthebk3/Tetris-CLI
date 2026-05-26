namespace Tetris_CLI.Game;

public class Board
{
    public int Height = 20;
    public int Width = 10;
    public int[,] Grid => new int[Height, Width];
}