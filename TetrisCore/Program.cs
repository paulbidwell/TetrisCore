using System;
using System.Diagnostics;

namespace TetrisCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0,0);

            var dropSpeed = 700;
            var currentColPosition = 0;
            var previousColPosition = 0;
            var currentRowPosition = 0;
            var previousRowPosition = 0;

            const int gridWidth = 10;
            const int gridHeight = 10;
            var tetrisGrid = new bool[gridHeight, gridWidth];

            for (var r = 0; r < gridHeight; r++)
            {
                for (var c = 0; c < gridWidth; c++)
                {
                    tetrisGrid[r, c] = false;
                }
            }

            var dropTimer = new Stopwatch();
            dropTimer.Start();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        currentColPosition++;
                    }

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        currentColPosition--;
                    }

                    Console.SetCursorPosition(previousColPosition, previousRowPosition);
                    Console.Write(" ");

                    Console.SetCursorPosition(currentColPosition, currentRowPosition);
                    Console.Write("o");

                    previousColPosition = currentColPosition;
                    previousRowPosition = currentRowPosition;
                }

                var dropTime = (int)dropTimer.ElapsedMilliseconds;

                if (dropTime > dropSpeed)
                {
                    dropTimer.Restart();

                    if (currentRowPosition + 1 <= gridHeight && !tetrisGrid[currentRowPosition +1, currentColPosition])
                    {
                        if (tetrisGrid[currentRowPosition, currentColPosition])
                        {
                            currentRowPosition--;

                            Console.SetCursorPosition(previousColPosition, previousRowPosition);
                            Console.Write(" ");

                            Console.SetCursorPosition(currentColPosition, currentRowPosition);
                            Console.Write("o");

                            previousColPosition = currentColPosition;
                            previousRowPosition = currentRowPosition;
                        }
                        else
                        {
                            Console.SetCursorPosition(previousColPosition, previousRowPosition);
                            Console.Write(" ");

                            Console.SetCursorPosition(currentColPosition, currentRowPosition);
                            Console.Write("o");

                            previousColPosition = currentColPosition;
                            previousRowPosition = currentRowPosition;

                            currentRowPosition++;
                        }
                    }
                    else
                    {
                        tetrisGrid[currentRowPosition -1, currentColPosition] = true;

                        currentColPosition = 0;
                        previousColPosition = 0;
                        currentRowPosition = 0;
                        previousRowPosition = 0;
                        Console.SetCursorPosition(0, 0);
                    }
                }
            }
        }
    }
}