using Tetris_CLI.Rendering;
using Tetris_CLI.Input;
using Tetris_CLI.Game;

namespace Tetris_CLI;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new TetrisGame();
        var inputHandler = new InputHandler();
        var renderer = new ConsoleRenderer();

        while (true)
        {
            game.Update();

            renderer.Draw(game.Board, game.CurrentPiece);

            Thread.Sleep(500);
        }
    }
}