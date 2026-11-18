using System;
using System.Collections.Generic;
using System.Threading;

namespace Pac_Man
{
    internal class Program
    {
        // Map: 1 = Wall (#), 2 = Pellet (.), 3 = Power-up (O), 0 = Empty
        static int[,] map = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,3,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,3,1},
            {1,2,1,1,2,1,1,1,2,1,2,1,1,1,2,1,1,2,1},
            {1,2,1,1,2,1,1,1,2,1,2,1,1,1,2,1,1,2,1},
            {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
            {1,2,1,1,2,1,2,1,1,1,1,1,2,1,2,1,1,2,1},
            {1,2,2,2,2,1,2,2,2,1,2,2,2,1,2,2,2,2,1},
            {1,1,1,1,2,1,1,1,0,1,0,1,1,1,2,1,1,1,1},
            {0,0,0,1,2,1,0,0,0,0,0,0,0,1,2,1,0,0,0},
            {1,1,1,1,2,1,0,1,1,0,1,1,0,1,2,1,1,1,1},
            {0,0,0,0,2,0,0,1,0,0,0,1,0,0,2,0,0,0,0},
            {1,1,1,1,2,1,0,1,1,1,1,1,0,1,2,1,1,1,1},
            {0,0,0,1,2,1,0,0,0,0,0,0,0,1,2,1,0,0,0},
            {1,1,1,1,2,1,2,1,1,1,1,1,2,1,2,1,1,1,1},
            {1,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,1},
            {1,2,1,1,2,1,1,1,2,1,2,1,1,1,2,1,1,2,1},
            {1,3,2,1,2,2,2,2,2,0,2,2,2,2,2,1,2,3,1},
            {1,1,2,1,2,1,2,1,1,1,1,1,2,1,2,1,2,1,1},
            {1,2,2,2,2,1,2,2,2,1,2,2,2,1,2,2,2,2,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        static int score = 0;
        static int lives = 3;
        static int pacX = 9, pacY = 11;
        static int pacDirX = 0, pacDirY = 0;
        static bool isPoweredUp = false;
        static int powerTimer = 0;

        class Ghost
        {
            public int X, Y;
            public ConsoleColor Color;
            public Ghost(int x, int y, ConsoleColor color)
            {
                X = x; Y = y; Color = color;
            }
        }

        static List<Ghost> ghosts = new List<Ghost> {
            new Ghost(9, 8, ConsoleColor.Red),
            new Ghost(8, 9, ConsoleColor.Magenta),
            new Ghost(9, 9, ConsoleColor.Cyan),
            new Ghost(10, 9, ConsoleColor.DarkYellow)
        };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rand = new Random();

            while (true)
            {
                // Handle Keyboard Input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) { pacDirX = 0; pacDirY = -1; }
                    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) { pacDirX = 0; pacDirY = 1; }
                    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) { pacDirX = -1; pacDirY = 0; }
                    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) { pacDirX = 1; pacDirY = 0; }
                }

                // Move Pac-Man
                int nextX = pacX + pacDirX;
                int nextY = pacY + pacDirY;

                // Wrap-around tunnel
                if (nextX < 0) nextX = map.GetLength(1) - 1;
                else if (nextX >= map.GetLength(1)) nextX = 0;

                if (nextY >= 0 && nextY < map.GetLength(0) && map[nextY, nextX] != 1)
                {
                    pacX = nextX;
                    pacY = nextY;
                }

                // Eat pellets or power-ups
                if (map[pacY, pacX] == 2)
                {
                    map[pacY, pacX] = 0;
                    score += 10;
                }
                else if (map[pacY, pacX] == 3)
                {
                    map[pacY, pacX] = 0;
                    score += 50;
                    isPoweredUp = true;
                    powerTimer = 35; // Power-up duration length
                }

                if (isPoweredUp)
                {
                    powerTimer--;
                    if (powerTimer <= 0) isPoweredUp = false;
                }

                // Move Ghosts
                foreach (var g in ghosts)
                {
                    List<int[]> validMoves = new List<int[]>();
                    int[] dx = { 0, 0, -1, 1 };
                    int[] dy = { -1, 1, 0, 0 };

                    for (int i = 0; i < 4; i++)
                    {
                        int gx = g.X + dx[i];
                        int gy = g.Y + dy[i];
                        if (gx >= 0 && gx < map.GetLength(1) && gy >= 0 && gy < map.GetLength(0))
                        {
                            if (map[gy, gx] != 1) validMoves.Add(new int[] { gx, gy });
                        }
                    }

                    if (validMoves.Count > 0)
                    {
                        int moveIndex = rand.Next(validMoves.Count);
                        g.X = validMoves[moveIndex][0];
                        g.Y = validMoves[moveIndex][1];
                    }

                    // Check collisions with ghosts
                    if (g.X == pacX && g.Y == pacY)
                    {
                        if (isPoweredUp)
                        {
                            g.X = 9; g.Y = 9; // Respawn ghost
                            score += 200;
                        }
                        else
                        {
                            lives--;
                            pacX = 9; pacY = 11;
                            pacDirX = 0; pacDirY = 0;
                            if (lives <= 0)
                            {
                                Console.SetCursorPosition(0, map.GetLength(0) + 2);
                                Console.ResetColor();
                                Console.WriteLine($"Game Over! Final Score: {score}");
                                return;
                            }
                        }
                    }
                }

                // Render screen frame efficiently
                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        bool drawn = false;
                        if (x == pacX && y == pacY)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("C");
                            drawn = true;
                        }
                        else
                        {
                            foreach (var g in ghosts)
                            {
                                if (g.X == x && g.Y == y)
                                {
                                    Console.ForegroundColor = isPoweredUp ? ConsoleColor.Blue : g.Color;
                                    Console.Write("M");
                                    drawn = true;
                                    break;
                                }
                            }
                        }

                        if (!drawn)
                        {
                            if (map[y, x] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("#");
                            }
                            else if (map[y, x] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (map[y, x] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("O");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    Console.WriteLine();
                }

                Console.ResetColor();
                Console.WriteLine($"Score: {score}  Lives: {lives}  {(isPoweredUp ? "[POWER-UP ACTIVE]" : "               ")}");

                Thread.Sleep(180); // Game speed control loop
            }
        }
    }
}