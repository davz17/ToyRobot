using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ToyRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var table = new Table(5, 5);        //initialize table with 5x5 dimension. default based index is zero

            Common.DisplayIntroText();
            Console.Write("Enter command:");
            string input = Console.ReadLine();

            while(input.ToUpper() != "EXIT")
            {
                //interpret input whether Place, Move, Right, Left, or Report
                var commandPattern = InterpretInput(input);

                if (commandPattern == null) Console.WriteLine("Invalid command.");
                else
                {
                    if (commandPattern.Command == Commands.Place.ToString())
                    {
                        //extract the X and Y from the input
                        var command = input.Split(",").ToArray();
                        var xPos = Int32.Parse(command[0].ToUpper().Replace("PLACE ", ""));
                        var yPos = Int32.Parse(command[1]);
                        var facing = command[2].Trim().ToUpper();

                        var selectedFacing = Facing.North;
                        if (facing == Facing.North.ToString().ToUpper()) selectedFacing = Facing.North;
                        if (facing == Facing.West.ToString().ToUpper()) selectedFacing = Facing.West;
                        if (facing == Facing.East.ToString().ToUpper()) selectedFacing = Facing.East;
                        if (facing == Facing.South.ToString().ToUpper()) selectedFacing = Facing.South;

                        robot.Place(table, xPos, yPos, selectedFacing);
                    }

                    if (commandPattern.Command == Commands.Move.ToString()) robot.Move();
                    if (commandPattern.Command == Commands.Left.ToString()) robot.TurnLeft();
                    if (commandPattern.Command == Commands.Right.ToString()) robot.TurnRight();
                    if (commandPattern.Command == Commands.Report.ToString()) robot.Report();
                }

                Console.Write("Enter command:");
                input = Console.ReadLine();
            }
        }

        private static RegExPattern InterpretInput(string input)
        {
            //match initial word from input
            var matchedPattern = Common.RegExPatterns.Where(x => input.ToUpper().StartsWith(x.Command.ToUpper())).FirstOrDefault();
            if (matchedPattern == null) return null;

            //if initial word from input was found as valid command pattern, test the whole input if valid thrue regex
            Regex regex = new Regex(matchedPattern.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);

            if (matches.Count == 1) return matchedPattern;
            return null;
        }
    }
}
