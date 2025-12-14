namespace Day4
{
    public class Part1
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
            int AccessibleRolls = 0;
            int MaxRolls = 4;
            for (int Row = 0; Row < MyMatrix.GetLength(0); Row++)
            {
                for (int Column = 0; Column < MyMatrix.GetLength(1); Column++)
                {
                    if(MyMatrix[Row,Column] == Roll)
                    {
                        //top left = [Row-1,Column-1]
                        //left = [Row,Column-1]
                        //bottom left = [Row+1,Column-1]
                        //top = [Row-1,Column]
                        //bottom = [Row+1,Column]
                        //top right = [Row-1,Column+1]
                        //right = [Row,Column+1]
                        //bottom right = [Row+1,Column+1]
                        //if position is not in the first row, then beginning row = rownumber-1, otherwise begin at row
                        //if position is not in the last row, then last row = rownumber+1, otherwise end at row
                        //if position is not in the first column, then beginning column = ColumnNumber-1, otherwise begin at column
                        //if position is not in the last column, then last column = columnNumber+1, otherwise end at column
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
                        }
                    }
                }
            }
            Console.WriteLine($"Accessible Rolls: {AccessibleRolls}");
        }
    }
}