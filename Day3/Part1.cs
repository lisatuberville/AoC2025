namespace Day3
{
    public class Part1
    {
        public static void GetJoltage()
        {
            int CurrentJoltage = 0;
            int CurrentDigit = 0;
            int FirstDigit = 0;
            int SecondDigit = 0;
            string[] Banks = System.IO.File.ReadAllLines("input.txt");
            foreach (string Bank in Banks)
            {
                int MaxDigit = 0;
                int IndexOfMax = -1;

                for(int i = 0; i < Bank.Length-1; i++)
                {
                    CurrentDigit = int.Parse(Bank[i].ToString());
                    if (CurrentDigit > MaxDigit)
                    {
                        MaxDigit = CurrentDigit;
                        IndexOfMax = i;
                    }           
                }

                FirstDigit = MaxDigit;
                MaxDigit = 0;
                for(int i = IndexOfMax + 1; i < Bank.Length; i++)
                {
                    CurrentDigit = int.Parse(Bank[i].ToString());

                    if (CurrentDigit > MaxDigit)
                    {
                        MaxDigit = CurrentDigit;
                        if(MaxDigit == 9)
                        {
                            break;
                        }
                    }
                }

                SecondDigit = MaxDigit;
                CurrentJoltage += int.Parse(FirstDigit.ToString() + SecondDigit.ToString());
            }
            Console.WriteLine($"Part 1 Final Joltage: {CurrentJoltage}");
        }
    }
}