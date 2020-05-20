using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class DirectionSimulation
    {
        string directions;

        (int, int) position = (0, 0);

        List<((int, int), (int, int))> steppedRoads = new List<((int, int), (int, int))>();
        ConsoleColor defaultColor = Console.ForegroundColor;

        public DirectionSimulation(string directions)
        {
            this.directions = directions ?? throw new ArgumentNullException(nameof(directions));
        }

        public void ShowPosition()
        {
            for(int row = 5 ; row >= -5 ; row--)
            {
                for(int col = -5 ; col <= 5 ; col++)
                {
                    if((col, row) == position)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("o");
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                        Console.Write("*");

                    if(col < 5)
                    {
                        if(steppedRoads.Contains(((col, row), (col + 1, row))))
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(" -- ");

                        if(steppedRoads.Contains(((col, row), (col + 1, row))))
                            Console.ForegroundColor = defaultColor;

                    }
                }
                Console.WriteLine();

                if(row > -5)
                {
                    for(int col = -5 ; col <= 5 ; col++)
                    {
                        if(steppedRoads.Contains(((col, row), (col, row - 1))))
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write("|");

                        if(steppedRoads.Contains(((col, row), (col, row - 1))))
                            Console.ForegroundColor = defaultColor;

                        if(col < 5)
                        {
                            Console.Write("    ");
                        }
                    }
                    Console.WriteLine();
                }

            }
        }

        public void ShowMap(int step)
        {
            Console.WriteLine(directions.Substring(0, step) + "|" + directions.Substring(step));
            (int, int) previousPosition = position;
            if(step > 0)
            {
                switch(directions[step - 1])
                {
                    case 'U':
                        position.Item2++;
                        break;
                    case 'D':
                        position.Item2--;
                        break;
                    case 'R':
                        position.Item1++;
                        break;
                    case 'L':
                        position.Item1--;
                        break;
                }

                position.Item1 = Math.Min(Math.Max(position.Item1, -5), 5);
                position.Item2 = Math.Min(Math.Max(position.Item2, -5), 5);
            }

            if(previousPosition != position && !steppedRoads.Contains((previousPosition, position))
                && !steppedRoads.Contains((position, previousPosition)))
            {
                if(previousPosition.Item1 < position.Item1 || previousPosition.Item2 > position.Item2)
                    steppedRoads.Add((previousPosition, position));
                else
                    steppedRoads.Add((position, previousPosition));
            }


            ShowPosition();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tiles : " + steppedRoads.Count);
            Console.ForegroundColor = defaultColor;

            Console.WriteLine();
            if(step < directions.Length)
                Console.WriteLine("Press any key to show next step");
        }

        public void Show()
        {
            for(int i = 0 ; i <= directions.Length ; i++)
            {
                Console.Clear();
                ShowMap(i);
                if(i < directions.Length)
                    Console.ReadKey(true);
            }
        }
    }
}

