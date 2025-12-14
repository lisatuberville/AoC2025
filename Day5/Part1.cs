namespace Day5
{
    public class Part1
    {
        public static void CountFreshIngredients()
        {
            var Ranges = new List<(long Start, long End)>();
            var Ingredients = new List<long>();
            int FreshIngredients = 0;
            string[] Data = System.IO.File.ReadAllLines("input.txt");
            foreach(string Row in Data)
            {
                if(Row.Contains('-'))
                {
                    var RangeHalves = Row.Split('-');
                    Ranges.Add((long.Parse(RangeHalves[0]), long.Parse(RangeHalves[1])));
                }
                else
                {
                    if(Row.Length > 0)
                    {
                        Ingredients.Add(long.Parse(Row));
                    }
                }
            }
            for(int i = 0; i<Ingredients.Count; i++)
            {
                for(int r = 0; r<Ranges.Count; r++)
                {
                    if(Ingredients[i] >= Ranges[r].Start && Ingredients[i] <= Ranges[r].End)
                    {
                        FreshIngredients++;
                        break;
                    }
                }
            }
            Console.WriteLine($"FreshIngredients: {FreshIngredients}");
        }
    }
}