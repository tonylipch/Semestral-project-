namespace Semestralka;

public class Interface
{

    private string menu = "D:\\Projects\\Semestral-project-\\obj\\menu.txt";

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


    public  void MenuOperations()
    {
        
      
        
        bool validChoice = false;

        //Processing user selection
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
                            Console.WriteLine("Enter path to file: ");
                           

                                string filePath = Console.ReadLine();
                                    
                                  if (!File.Exists(filePath))
                                  {
                                    Console.WriteLine("File doesn't exist, preass any key");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                  }else
                                  {
                                      FileOperation fo = new FileOperation();
                                      Dictionary<string, int> wordFrequency = fo.GetWordFrequency(filePath);
                                        
                                        
                                        
                                      Console.WriteLine("\nNejčastější slova jsou :");
                                      foreach (var pair in wordFrequency.OrderByDescending(pair => pair.Value).Take(10)) // Выводим 10 наиболее часто встречающихся слов
                                      {
                                            Console.WriteLine($"{pair.Key}: {pair.Value} krat");
                                      }
                                        
                                      GoBackAction();
                                      break;
                                  }
                        default:
                            Console.WriteLine("Zadan spatny vyber. Zkuste jeste jednou");
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




}