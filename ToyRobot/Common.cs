using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public enum Facing
    {
        North,
        South,
        West,
        East
    }

    public enum Commands
    {
        Place,
        Move,
        Right,
        Left,
        Report
    }

    public static class Common
    {
        //list of valid command with regex pattern
        public static List<RegExPattern> RegExPatterns = new List<RegExPattern>()
        {
            new RegExPattern() { Command = "Place", Pattern = @"^PLACE\b \d{1},\d{1},(NORTH|SOUTH|EAST|WEST)\b$"},
            new RegExPattern() { Command = "Move", Pattern = @"^MOVE\b"},
            new RegExPattern() { Command = "Left", Pattern = @"^LEFT\b"},
            new RegExPattern() { Command = "Right", Pattern = @"^RIGHT\b"},
            new RegExPattern() { Command = "Report", Pattern = @"^REPORT\b"}
        };

        public static void DisplayIntroText()
        {
            Console.WriteLine("Toy Robot Console Program");
            Console.WriteLine("");
            Console.WriteLine("AVAILABLE COMMANDS");
            Console.WriteLine("________________________________");
            Console.WriteLine("PLACE X,Y,F : where X=any number from 0 to 4, Y=any number from 0 to 4, F=NORTH or SOUTH or EAST or WEST");
            Console.WriteLine("MOVE");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("REPORT");
            Console.WriteLine("Type EXIT to terminate program");
            Console.WriteLine("");
        }
    }
}
