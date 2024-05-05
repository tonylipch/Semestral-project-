namespace Semestralka;
using System;
using System.IO;

//Main inteface
public class Interface
{
    //Dictionary which count our words
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
            Console.Write("Choose operation: ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                
                    switch (choice)
                    {
                        //[1] Print statistic of words
                        case 1 :
                         
                            Console.WriteLine("\nThe most popular words are :");
                            foreach (var pair in wordFrequency.OrderByDescending(pair => pair.Value).Take(10)) // Выводим 10 наиболее часто встречающихся слов
                            {
                                Console.WriteLine($"{pair.Key}: {pair.Value} x");
                            } 
                            GoBackAction();
                            break;
                        //[2]  Find specific word
                        case 2:
                        
                            GetWordStatistic();
                            GoBackAction();
                            break;
                        
                        //[3] Open new file
                        case 3:
                            AnalyzeFile();
                            break;
                        
                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong choice. Please try again");
                            break;
                    }
                  
                    
            }
            catch (FormatException)
            {
               Console.Clear();
               ReadFile(menu);
            }

           
            
        }
    }

    //Using for reading files with some text
    public static void AnalyzeFile(){ 
      
        Console.WriteLine("Enter path to file: ");
        string filePath = Console.ReadLine();
        while (!File.Exists(filePath))
        {
           
            Console.WriteLine("File doesn't exist, preass any key");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enter path to file again: ");
           filePath = Console.ReadLine();
          
        
        }
        if(File.Exists(filePath))
        {
            FileOperation fo = new FileOperation();
            wordFrequency = fo.GetWordFrequency(filePath);
        }
        
    }


//Find some word and cout frequency of them
public static void GetWordStatistic()
{
    Console.WriteLine("Enter the word: ");
    string word = Console.ReadLine().ToLower();

    if (!wordFrequency.ContainsKey(word))
    {
        Console.WriteLine("Word not found");
        return;
    }

    Console.WriteLine($"{word}: {wordFrequency.GetValueOrDefault(word,0)} x");
    
}


// Read some interface files
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

  
        Console.WriteLine("press [B/b] to step back");
        string turnback = Console.ReadLine().ToLower();
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
                    Console.WriteLine("Wrong choice! press [B/b] to step back");
                    turnback = Console.ReadLine().ToLower();
                }
                Console.Clear();
                ReadFile(menu);
                break;
                        
        }
        
    }





}