namespace Day4
{
    public class Part2
    {
        public static string[,] CreateMatrixFromFile(string FilePath)
        {
            var Data = File.ReadAllLines(FilePath);
            int Rows = Data.Length;
            int Columns = Data.Max(row => row.Length);
            
            string[,] Matrix = new string[Rows, Columns];
            for (int RowNumber = 0; RowNumber < Rows; RowNumber++)
            {
                var RowData = Data[RowNumber].ToCharArray();
                for (int ColumnNumber = 0; ColumnNumber < RowData.Length; ColumnNumber++)
                {
                    Matrix[RowNumber, ColumnNumber] = RowData[ColumnNumber].ToString();
                }
            }
            return Matrix;
        }

        public static void CountRolls()
        {
            string[,] MyMatrix = CreateMatrixFromFile("input.txt");
            string Roll = "@";
            int RollsRemoved = 0;
            int MaxRolls = 4;
            bool KeepChecking = true;
            while(KeepChecking == true){
                int AccessibleRolls = 0;
                var RollsToRemove = new List<(int Row, int Column)>();
                for (int Row = 0; Row < MyMatrix.GetLength(0); Row++)
                {
                    for (int Column = 0; Column < MyMatrix.GetLength(1); Column++)
                    {
                        if(MyMatrix[Row,Column] == Roll)
                        {
                            int BeginningRow = Row == 0 ? Row : Row - 1;
                            int EndingRow = Row == MyMatrix.GetLength(0) - 1 ? Row : Row + 1;
                            int BeginningColumn = Column == 0 ? Column : Column - 1;
                            int EndingColumn = Column == MyMatrix.GetLength(1) - 1 ? Column : Column + 1;
                            int AdjacentRolls = 0;

                            for(int r = BeginningRow; r <= EndingRow; r++)
                            {
                                for(int c = BeginningColumn; c <= EndingColumn; c++)
                                {
                                    if(r==Row && c == Column)
                                    {
                                        //do nothing
                                    }
                                    else
                                    {
                                        if(MyMatrix[r,c] == Roll)
                                        {
                                            AdjacentRolls++;
                                        }
                                    }
                                }
                            }
                            if(AdjacentRolls < MaxRolls)
                            {
                                AccessibleRolls++;
                                RollsToRemove.Add((Row, Column));
                            }
                        }
                    }
                }
                foreach(var roll in RollsToRemove)
                {
                    MyMatrix[roll.Row, roll.Column] = ".";
                    RollsRemoved++;
                }
                
                if(RollsToRemove.Count == 0)
                {
                    KeepChecking = false;
                }
            }
            Console.WriteLine($"Rolls Removed: {RollsRemoved}");
        }
    }
}