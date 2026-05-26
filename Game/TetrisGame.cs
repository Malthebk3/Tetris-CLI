using System.Runtime.CompilerServices;
using Tetris_CLI.Input;

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
    public void Update(InputHandler input)
    {
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

        int[,] newShape =
        {
            { 1, 1,},
            { 1, 1,},
        };

        CurrentPiece.Shape = newShape;
    }
}