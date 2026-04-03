
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        int breite = 30;
        int hoehe = 15;

        List<(int x, int y)> schlange = new List<(int, int)>();
        schlange.Add((10, 5));

        ConsoleKey richtung = ConsoleKey.RightArrow;
        Random rand = new Random();
        (int x, int y) essen = (rand.Next(0, breite), rand.Next(0, hoehe));

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var taste = Console.ReadKey(true).Key;
                richtung = taste;
            }

            var kopf = schlange[0];

            if (richtung == ConsoleKey.RightArrow) kopf.x++;
            if (richtung == ConsoleKey.LeftArrow) kopf.x--;
            if (richtung == ConsoleKey.UpArrow) kopf.y--;
            if (richtung == ConsoleKey.DownArrow) kopf.y++;

            schlange.Insert(0, kopf);
            schlange.RemoveAt(schlange.Count - 1);

            if (kopf.x == essen.x && kopf.y == essen.y)
            {
                schlange.Add(schlange[schlange.Count - 1]);
                essen = (rand.Next(0, breite), rand.Next(0, hoehe));
            }

            Console.Clear();

            Console.SetCursorPosition(essen.x, essen.y);
            Console.Write("X");

            foreach (var teil in schlange)
            {
                Console.SetCursorPosition(teil.x, teil.y);
                Console.Write("O");
            }

            Thread.Sleep(150);
        }
    }
}






















