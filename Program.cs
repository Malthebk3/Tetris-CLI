using Tetris_CLI.Rendering;
using Tetris_CLI.Input;
using Tetris_CLI.Game;

namespace Tetris_CLI;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new TetrisGame();
        var input = new InputHandler();
        var renderer = new ConsoleRenderer();

        while (true)
        {
            input.Update();

            game.Update(input);

            renderer.Draw(game.Board, game.CurrentPiece);

            Thread.Sleep(500);
        }
    }
}