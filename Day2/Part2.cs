namespace Day2
{
    public class Part2
    {
        //there are no leading zeros
        //ranges are separated by commas
        //each range gives first and last id separated by a dash

        //for each number in a range, split number into equal parts and compare to find numbers with repeating sequences
        
        public static void GetAndAddInvalidIDs()
        {
            string line = File.ReadAllText("input.txt");
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
                    
                    for (int partSize = 1; partSize <= length / 2; partSize++)
                    {
                        if (length % partSize != 0)
                        {
                            continue; //only consider part sizes that evenly divide the length
                        }
                        bool isRepeating = true;
                        string firstPart = id[..partSize];
                        for (int j = partSize; j < length; j += partSize)
                        {
                            string nextPart = id.Substring(j, partSize);
                            if (nextPart != firstPart)
                            {
                                isRepeating = false;
                                break;
                            }
                        }
                        if (isRepeating)
                        {
                            invalidIDs.Add(id);
                            break; //no need to check larger part sizes
                        }
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