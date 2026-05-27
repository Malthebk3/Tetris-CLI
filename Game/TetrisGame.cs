using System.Runtime.CompilerServices;
using Tetris_CLI.Input;

namespace Tetris_CLI.Game;

public class TetrisGame
{
    public Board Board = new();
    public Tetromino CurrentPiece;
    public Random _random = new();
    public bool IsGameOver { get; private set; }
    private double _gravityAccumulator = 0;
    private readonly double _baseDropInterval = 1; //Seconds per drop at level 1
    public TetrisGame()
    {
        CurrentPiece = new Tetromino
        {
            X = 4,
            Y = 0
        };
    }
    public void Update(InputHandler input, double deltaTime)
    {
        if (IsGameOver) return; //Stops processing if game ended

        if (input.HardDrop)
        {
            while (Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X, CurrentPiece.Y + 1))
            {
                CurrentPiece.Y++;
            }
            LockCurrentPiece();
            Board.ClearFullLines();
            SpawnNewPiece();

            _gravityAccumulator = 0; //Reset gravity to prevent instant drop after hard drop
            return; //Early return since we already handled the drop and spawn logic
        }

        //Left and right movement
        if (input.Left && Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X - 1, CurrentPiece.Y))
            CurrentPiece.X--;
        if (input.Right && Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X + 1, CurrentPiece.Y))
            CurrentPiece.X++;
        
        //Rotation
        if (input.Rotate)
        {
            var rotated = TetrominoShapes.RotateClockwise(CurrentPiece.Shape);

            if (Board.IsValidPosition(rotated, CurrentPiece.X, CurrentPiece.Y))
            {
                CurrentPiece.Shape = rotated;
            }
        }
        
        //Gravity and soft drop
        _gravityAccumulator += deltaTime;
        double effectiveInterval = input.SoftDrop ? 0.05 : _baseDropInterval;
        if (_gravityAccumulator >= effectiveInterval)
        {
            if (Board.IsValidPosition(CurrentPiece.Shape, CurrentPiece.X, CurrentPiece.Y + 1))
            {
                CurrentPiece.Y++;
            }
            else
            {
                LockCurrentPiece();
                Board.ClearFullLines();
                SpawnNewPiece();
            }
            _gravityAccumulator -= effectiveInterval; //Reset accumulator but keep overflow for consistent timing
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