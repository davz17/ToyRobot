using System;

namespace ToyRobot
{
    public class Robot
    {
        private Table _table;
        public int YPos { get; private set; }
        public int XPos { get; private set; }
        public Facing Facing { get; private set; }

        public Robot() {}

        public void Place(Table table, int xPos, int yPos, Facing facing)
        {          
            //check if initial position is within the table's map
            if ((table.RowCount < yPos) || (yPos < 0))
                DisplayError("Error. Invalid Y position.");
            else if ((table.ColumnCount < xPos) || (xPos < 0))
                DisplayError("Error. Invalid Y position.");
            else
            {
                _table = table;
                this.YPos = yPos;
                this.XPos = xPos;
                this.Facing = facing;
            }
        }

        public void Move()
        {
            if (ValidTable())
            {
                //change coordinate based on current coordinate and facing properties
                switch (this.Facing)
                {
                    case Facing.North:
                        if (_table.RowCount < (this.YPos + 1)) DisplayError("Error. The robot will fall.");
                        else this.YPos += 1;
                        break;
                    case Facing.West:
                        if (this.XPos - 1 < 0) DisplayError("Error. The robot will fall.");
                        else this.XPos -= 1;
                        break;
                    case Facing.South:
                        if (this.YPos - 1 < 0) DisplayError("Error. The robot will fall.");
                        else this.YPos -= 1;
                        break;
                    case Facing.East:
                        if (_table.ColumnCount < (this.XPos + 1)) DisplayError("Error. The robot will fall.");
                        else this.XPos += 1;
                        break;
                }
            }
        }

        public void TurnLeft()
        {
            if (ValidTable())
            {
                //change facing properties counter clockwise
                switch (this.Facing)
                {
                    case Facing.North: this.Facing = Facing.West; break;
                    case Facing.West: this.Facing = Facing.South; break;
                    case Facing.South: this.Facing = Facing.East; break;
                    case Facing.East: this.Facing = Facing.North; break;
                }
            }
        }

        public void TurnRight()
        {
            if (ValidTable())
            {
                //change facing properties clockwise
                switch (this.Facing)
                {
                    case Facing.North: this.Facing = Facing.East; break;
                    case Facing.East: this.Facing = Facing.South; break;
                    case Facing.South: this.Facing = Facing.West; break;
                    case Facing.West: this.Facing = Facing.North; break;
                }
            }
        }

        public void Report()
        {
            if (ValidTable())
            {
                Console.WriteLine($"{this.XPos},{this.YPos},{this.Facing}");
            }
        }

        private bool ValidTable()
        {
            if (_table is null)
            {
                Console.WriteLine("Error. The robot has not been placed yet.");
                return false;
            }
            return true;
        }
        private void DisplayError(string error)
        {
            Console.WriteLine(error);
        }
    }
}
