using System.Runtime.CompilerServices;
using Tetris_CLI.Game;

namespace Tetris_CLI.Rendering;

public class ConsoleRenderer
{
    public void Draw(Board board, Tetromino piece)
    {
        Console.SetCursorPosition(0, 0);
        
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                bool isPiece = false;
                for (int py = 0; py < piece.Shape.GetLength(0); py++)
                {
                    for (int px = 0; px < piece.Shape.GetLength(1); px++)
                    {
                        if (piece.Shape[py, px] == 0)
                            continue;
                        
                        int worldX = piece.X + px;
                        int worldY = piece.Y + py;

                        if (worldX == x && worldY == y)
                        {
                            isPiece = true;
                        }
                    }
                }

                bool isBlock = board.Grid[y, x] == 1;

                Console.Write(isPiece || isBlock ? " 1 " : " 0 ");
            }
            Console.WriteLine();
        }
    }
}