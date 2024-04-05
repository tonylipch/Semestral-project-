namespace Semestralka;

public class FileOperation
{
   public Dictionary<string, int> GetWordFrequency(string filePath)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        HashSet<string> excludedWords = new HashSet<string>
                {"a","i","tak", "aby", 
                    "nebo", "aby","jen",
                    "u", "po", "nad",
                    "pod", "ve", "v", "za",
                    "do", "na", "ze", "o",
                    "však","čímž","iž","s",
                    "se","si"
                    
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
            Console.WriteLine($"Stala se nejaka chyba pri nacteni souboru: {e.Message}");
       
        }

        return wordFrequency;
    }
   
   
   
}