namespace Day1
{
    public class Part1
    {
        public static void CalculatePassword()
        {
            int MaxValue = 100;
            int MinValue = 0;
            int Clicks = 0;
            int CurrentValue = 50;
            int ZerosCount = 0;

            string[] lines = System.IO.File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                Clicks = line[..1] == "R" ? int.Parse(line[1..]) : -int.Parse(line[1..]);
                CurrentValue = (CurrentValue + Clicks) % MaxValue;
                if (CurrentValue < MinValue)
                {
                    CurrentValue += MaxValue;
                }
                if (CurrentValue == 0)
                {
                    ZerosCount++;
                }
            }

            Console.WriteLine($"Number of times at zero: {ZerosCount}");

        }
    }
}