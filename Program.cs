using System.Diagnostics;
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

        Console.CursorVisible = false;

        var stopwatch = Stopwatch.StartNew();
        double lastTime = stopwatch.Elapsed.TotalSeconds;

        Console.Clear();
        while (!game.IsGameOver)
        {
            double currentTime = stopwatch.Elapsed.TotalSeconds;
            double deltaTime = currentTime - lastTime;
            lastTime = currentTime;

            deltaTime = Math.Min(deltaTime, 0.1); //Cap deltaTime to prevent big jumps

            input.Update();
            game.Update(input, deltaTime);
            renderer.Draw(game.Board, game.CurrentPiece);

            Thread.Sleep(10);
        }
    }
}