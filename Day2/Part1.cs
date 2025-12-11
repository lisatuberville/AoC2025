namespace Day2
{
    public class Part1
    {
        //all invalid ids have an even number of characters
        //there are no leading zeros
        //ranges are separated by commas
        //each range gives first and last id separated by a dash

        //for each number in a range, split number into an even number of digits and compare each half to see if it is a repeating number
        
        public static void GetAndAddInvalidIDs()
        {
            string line = System.IO.File.ReadAllText("input.txt");
            List<string> ranges = [.. line.Split(',')];
            List<string> invalidIDs = [];
            long sumOfInvalidIDs = 0;
            
            foreach (string range in ranges)
            {
                string start = range.Split('-')[0];
                string end = range.Split('-')[1];
                for (long i = long.Parse(start); i <= long.Parse(end); i++)
                {
                    string id = i.ToString();
                    int length = id.Length;
                    if (length % 2 != 0)
                    {
                        continue; //only numbers with an even number of digits can be invalid IDs
                    }
                    string firstHalf = id[..(length / 2)];
                    string secondHalf = id.Substring(length / 2, length / 2);
                    if (firstHalf == secondHalf)
                    {
                        invalidIDs.Add(id);
                    }
                }
            }
            foreach (string invalidID in invalidIDs)
            {
                    sumOfInvalidIDs += long.Parse(invalidID);
            }
            Console.WriteLine($"Sum of invalid IDs: {sumOfInvalidIDs}");
        }
    }
}