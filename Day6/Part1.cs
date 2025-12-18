using System.Data;

namespace Day6
{
    public partial class Part1
    {
        //i will represent rows, j will represent columns

         [System.Text.RegularExpressions.GeneratedRegex(@"\s+")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();
       public static string[,] CreateMatrixFromFile(string FilePath)
        {
            var Data = File.ReadAllLines(FilePath);
            //remove extra spaces, only want one space between values
            Data = [.. Data.Select(Line => MyRegex().Replace(Line, " "))];
            
            int Rows = Data.Length;
            int Columns = Data.Length > 0 ? Data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length : 0;

            string[,] Matrix = new string[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                var Values = Data[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < Columns; j++)
                {
                    Matrix[i, j] = Values[j];
                }
            }
            return Matrix;
        }

         public static string[,] RotateMatrix90DegreesClockwise(string[,] Matrix)
        {
            int Rows = Matrix.GetLength(0);
            int Columns = Matrix.GetLength(1);
            string[,] RotatedMatrix = new string[Columns, Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    RotatedMatrix[j, Rows - 1 - i] = Matrix[i, j];  //have to subtract 1 because arrays are 0 indexed
                }
            }
            return RotatedMatrix;
        }

        public static void GetHomeworkAnswer()
        {
            string[,] OriginalMatrix = CreateMatrixFromFile("input.txt");
            string[,] RotatedMatrix = RotateMatrix90DegreesClockwise(OriginalMatrix);
            // for (int i = 0; i < RotatedMatrix.GetLength(0); i++)
            // {
            //     for (int j = 0; j < RotatedMatrix.GetLength(1); j++)
            //     {
            //         Console.Write(RotatedMatrix[i, j] + " ");
            //     }
            //     Console.WriteLine();
            // }

            //have to use long because int isn't long enough for the final answer
            List<long> Results = [];
            long HomeworkAnswer = 0;

            for (int i = 0; i < RotatedMatrix.GetLength(0); i++)
            {   
                string Operator = RotatedMatrix[i,0];
                long Result = long.Parse(RotatedMatrix[i,1]);

                for (int j = 2; j < RotatedMatrix.GetLength(1); j++)
                {
                    string Number = RotatedMatrix[i, j];
                
                    if (long.TryParse(Number, out long Num))
                    {
                        if (Operator == "+")
                        {
                            Result += Num;
                        }
                        else if (Operator == "*")
                        {
                            Result *= Num;
                        }
                    }
                }
                Results.Add(Result);
            }
            foreach(long Value in Results)
                {
                    HomeworkAnswer += Value;
                }   
                Console.WriteLine($"HomeWork Answer: {HomeworkAnswer}");
        }
    }
}

