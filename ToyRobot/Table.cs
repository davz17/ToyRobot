namespace ToyRobot
{
    public class Table
    {
        public int ColumnCount { get; private set; }
        public int RowCount { get; private set; }   

        public Table(int columnCount, int rowCount)
        {
            this.ColumnCount = columnCount;
            this.RowCount = rowCount;
        }
    }
}

