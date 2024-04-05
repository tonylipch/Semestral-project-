namespace Semestralka;
using System;
using System.IO;


public class Interface
{
    private static Dictionary<string, int> wordFrequency;
    private const string menu = "menu.txt";
    
    public  void MenuOperations()
    {
        bool validChoice = false;

        //Processing user selection
        
        AnalyzeFile();
        while (!validChoice)
        {
            //Load menu
            ReadFile(menu);
            Console.Write("Zvolte prosim cislo: ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                
                
                
                    switch (choice)
                    {
                        case 1 :
                         
                           Console.WriteLine("\nNejčastější slova jsou :");
                           foreach (var pair in wordFrequency.OrderByDescending(pair => pair.Value).Take(10)) // Выводим 10 наиболее часто встречающихся слов
                           {
                               Console.WriteLine($"{pair.Key}: {pair.Value} krat");
                           }

                        
                            break;
                        case 2:
                        
                            GetWordStatistic();
                           
                            break;
                        
                        case 3:
                            AnalyzeFile();
                            break;
                        
                        default:
                            Console.Clear();
                            Console.WriteLine("Zadan spatny vyber. Zkuste jeste jednou");
                            break;
                    }
                    GoBackAction();
                    
            }
            catch (FormatException)
            {
               Console.Clear();
               ReadFile(menu);
            }

           
            
        }
    }


public static void AnalyzeFile(){ 
    Console.WriteLine("Enter path to file: ");
                           

    string filePath = Console.ReadLine();
                                    
    if (!File.Exists(filePath))
    {
        Console.WriteLine("File doesn't exist, preass any key");
        Console.ReadKey();
        Console.Clear();
        
    }else
    {
        FileOperation fo = new FileOperation();
        wordFrequency = fo.GetWordFrequency(filePath);
                                      
     
    }
        
}

public static void GetWordStatistic()
{
    Console.WriteLine("Enter the word: ");
    string word = Console.ReadLine().ToLower();

    if (!wordFrequency.ContainsKey(word))
    {
        Console.WriteLine("Word not found");
        return;
    }

    Console.WriteLine($"{word}: {wordFrequency.GetValueOrDefault(word,0)} krat");
    
}

public static void ReadFile(string filename)
    {
        // If it exist
        if (!File.Exists(filename))
        {
            Console.WriteLine("File doesn't exist");
            
            return;
        }

        string[] lines = File.ReadAllLines(filename);


        // Output file
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }

    }

    private void GoBackAction( )
    {
        Console.WriteLine("stlacite [B/b] aby se vratit zpet");
        string  turnback = Console.ReadLine().ToLower();
        Console.Clear();

        switch (turnback)
        {
            case "b": 
                Console.Clear();
                ReadFile(menu);
                break;
            
            default: 
                while (turnback != "b")
                {
                    Console.WriteLine("Zadan spatny vyber");
                    turnback = Console.ReadLine().ToLower();
                }
                Console.Clear();
                ReadFile(menu);
                break;
                        
        }
        
    }





}