namespace Semestralka;

public class FileOperation
{
   public Dictionary<string, int> GetWordFrequency(string filePath)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        //Words which program doesn't count
        HashSet<string> excludedWords = new HashSet<string>
                {"and","but","or", "also", 
                    "since", "because","if",
                    "although", "when", "where",
                    "so that", "while", "after", "before",
                    "nevertheless", "therefore", "in", "on",
                    "to","if","a"
                };

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);// Split text by words
                    foreach (string word in words)
                    {
                        string cleanedWord = word.ToLower();

                        if (!excludedWords.Contains(cleanedWord))
                        {
                            if (wordFrequency.ContainsKey(cleanedWord))
                            {
                                wordFrequency[cleanedWord]++;
                            }
                            else
                            {
                                wordFrequency[cleanedWord] = 1;
                            }
                        }
                    }
                }
            }
        }
        
        catch (IOException e)
        {
            Console.WriteLine($"Something wrong with reading file: {e.Message}");
       
        }

        return wordFrequency;
    }
   
   
   
}