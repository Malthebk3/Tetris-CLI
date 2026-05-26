using System.Runtime.CompilerServices;
using Tetris_CLI.Input;

namespace Tetris_CLI.Game;

public class TetrisGame
{
    public Board Board = new();
    public Tetromino CurrentPiece;
    public Random _random = new();
    public bool IsGameOver { get; private set; }
    public TetrisGame()
    {
        CurrentPiece = new Tetromino
        {
            X = 4,
            Y = 0
        };
    }
    public void Update(InputHandler input)
    {
        if (IsGameOver) return; //Stops processing if game ended

        if (input.Left && Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X - 1, CurrentPiece.Y))
            CurrentPiece.X--;
        else if (input.Right && Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X + 1, CurrentPiece.Y))
            CurrentPiece.X++;
        
        if (input.Rotate)
        {
            var rotated = TetrominoShapes.RotateClockwise(CurrentPiece.Shape);

            if (Board.IsValidPosition(rotated, CurrentPiece.X, CurrentPiece.Y))
            {
                CurrentPiece.Shape = rotated;
            }
        }

        bool canMoveDown = Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X, CurrentPiece.Y + 1);
        if (canMoveDown)
        {
            CurrentPiece.Y++;
        }
        else
        {
            LockCurrentPiece();
            Board.ClearFullLines();
            SpawnNewPiece();
        }
    }
    public void LockCurrentPiece()
    {
        Board.LockPiece(CurrentPiece);
    }
    public void SpawnNewPiece()
    {
        CurrentPiece.X = Board.Width / 2;
        CurrentPiece.Y = 0;

        int randomShape = _random.Next(0, 6);
        TetrominoType type = (TetrominoType)randomShape;

        CurrentPiece.Shape = TetrominoShapes.GetShape(type);
        if (!Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X, CurrentPiece.Y))
        {
            IsGameOver = true;
        }
    }
}