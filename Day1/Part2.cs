namespace Day1
{
    public class Part2
    {
      public static void CalculatePassword()
        {
            int MaxValue = 100;
            int MinValue = 0;
            int CurrentPosition = 50;
            int ZerosCount = 0;

            string[] lines = System.IO.File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                int WholeRotations = 0;
                int Clicks = 0;
                int Direction = 0;

                Clicks = int.Parse(line[1..]);
                Direction = line[..1] == "R" ? 1 : -1;
                Console.WriteLine($"Processing line: {line}, Clicks: {Clicks}, Direction: {Direction}, CurrentPosition: {CurrentPosition}");

                int NewPosition = CurrentPosition + Clicks * Direction;

                if(Math.Sign(NewPosition) != Math.Sign(CurrentPosition) && CurrentPosition != 0)
                {
                    Console.WriteLine("Partial rotation detected. Incrementing ZerosCount by 1.");
                    ZerosCount ++;
                }

                WholeRotations = Math.Abs(NewPosition) / MaxValue;
                Console.WriteLine($"Whole rotations: {WholeRotations}");
                ZerosCount += WholeRotations;

                NewPosition %= MaxValue;

                if (NewPosition < MinValue)
                {
                    NewPosition += MaxValue;
                }

                CurrentPosition = NewPosition;
                Console.WriteLine($"ZerosCount so far: {ZerosCount}");
                Console.WriteLine($"Updated CurrentPosition to: {CurrentPosition}");
                Console.WriteLine("-----");
            }

            Console.WriteLine($"Number of times at zero: {ZerosCount}");
    
        }  
    }
}