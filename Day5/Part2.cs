namespace Day5
{
    public class Part2
    {
        public static void CountFreshIngredients()
        {
            var Ranges = new List<(long Start, long End)>();
            var NewRanges = new List<(long Start, long End)>();
            long FreshIngredients = 0;
            string[] Data = System.IO.File.ReadAllLines("input.txt");

            foreach (string Row in Data)
            {
                if (Row.Contains('-'))
                {
                    var RangeHalves = Row.Split('-');
                    Ranges.Add((long.Parse(RangeHalves[0]), long.Parse(RangeHalves[1])));
                }
            }

            Ranges.Sort((t1, t2) => t1.Start.CompareTo(t2.Start));

            NewRanges.Add((Ranges[0].Start, Ranges[0].End));

            for (int r = 1; r < Ranges.Count; r++)
            {
                var (Start, End) = NewRanges[^1];
                if (Ranges[r].Start <= End)
                {
                    NewRanges[^1] = (Start, Math.Max(End, Ranges[r].End));
                }
                else
                {
                    NewRanges.Add((Ranges[r].Start, Ranges[r].End));
                }
            }
            
            for(int i = 0; i < NewRanges.Count; i++)
            {
                FreshIngredients += NewRanges[i].End - NewRanges[i].Start + 1;
            }
             Console.WriteLine($"FreshIngredients: {FreshIngredients}");
        }
    }
}