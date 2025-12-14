namespace Day3
{
    public class Part2
    {
        public static void GetJoltage()
        {
            long TotalJoltage = 0;
            int CurrentDigit = 0;
            List<string> BankValues = new List<string>();
            string[] Banks = System.IO.File.ReadAllLines("input.txt");
            
            foreach (string Bank in Banks)
            {
                int BatteryCount = 12;
                int MinIndex = 0;
                string BankValue = "";
            
                 while(BankValue.Length < BatteryCount)
                 {
                    int MaxDigit = 0;
                    int IndexOfMaxDigit = -1;
                    int MaxIndex = Bank.Length - (BatteryCount - BankValue.Length);
                    for(int i = MinIndex; i <= MaxIndex; i++)
                    {
                        CurrentDigit = int.Parse(Bank[i].ToString());
                         if (CurrentDigit > MaxDigit)
                         {
                            MaxDigit = CurrentDigit;
                            IndexOfMaxDigit = i;
                             if(MaxDigit == 9)
                             {
                                 break;
                             }
                         }           
                    }
                    BankValue += MaxDigit.ToString();
                    MinIndex = IndexOfMaxDigit+1;
                    CurrentDigit = 0;
                    MaxIndex = Bank.Length - (BatteryCount - BankValue.Length);
                 }
                  BankValues.Add(BankValue);
                  MinIndex = 0;
                  BankValue = "";
             }
             foreach(string i in BankValues)
            {
                TotalJoltage+= long.Parse(i);
            }
            Console.WriteLine($"Part 2 Final Joltage: {TotalJoltage}");
        }
    }
}