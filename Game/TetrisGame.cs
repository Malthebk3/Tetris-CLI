namespace Tetris_CLI.Game;

public class TetrisGame
{
    public Board Board = new();
    public Tetromino CurrentPiece;
    public TetrisGame()
    {
        CurrentPiece = new Tetromino
        {
            X = 4,
            Y = 0
        };
    }
    public void Update()
    {
        if (CurrentPiece.Y < Board.Height - 2)
        CurrentPiece.Y++;
    }
}