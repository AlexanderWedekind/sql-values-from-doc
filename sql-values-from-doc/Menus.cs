namespace menus;

using System.Text.RegularExpressions;
using file_browse;
using messages;
public class Menus
{
    public static void Speak(string message)
    {
        Console.WriteLine(message);
    }

    // public static string ValidateUserInput(string input)
    // {
    //     return Regex.Replace(input.Trim(), )
    // }
    public static string NonNullUserInput()
    {
        bool notNull = true;
        string input = "";
        do
        {
            if(notNull == true)
            {
                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception e)
                {
                    notNull = false;
                }
            }
            else
            {
                Speak(Messages.rejectNull);
                try
                {
                    input = Console.ReadLine();
                }
                catch(Exception e)
                {
                    notNull = false;
                }
            }
        }while(notNull == false);
        return input;
    }

    public static int GetMenuInput(int menuLength)
    {
        bool validChoiceMade = false;
        int choice = -1;
        while(validChoiceMade == false)
        {
            string input = NonNullUserInput();
            string cleanedInput = "";
            if(String.IsNullOrEmpty(input) == false)
            {
                cleanedInput = Regex.Replace(input.Trim(), @"[^0-9]", "");
                if(String.IsNullOrEmpty(cleanedInput) == false)
                {
                    choice = Int32.Parse(cleanedInput);
                    if(choice > -1 && choice < menuLength)
                    {
                        validChoiceMade = true;    
                    }
                }
            }
            if(validChoiceMade == false)
            {
                Speak(Messages.invalidMenuChoice);
            }    
        }
        return choice;
    }
    public static int Menu(string message, string[] options)
    {
        Speak(message);
        for(int i = 0; i < options.Length; i++)
        {
            Speak($"- [{i}]: {options[i]}");
        }
        return GetMenuInput(options.Length);
    }

    public static void FolderMenu()
    {
        bool exit = false;
        while(exit == false)
        {
            int choice = Menu(Messages.FolderMenuMessage(), FileBrowse.DirMenuOptions());
            switch (choice)
            {
                case 0:
                    exit = true;
                    FileBrowse.currentUri = Directory.GetCurrentDirectory();
                    break;
                case 1:
                    FileBrowse.UpOneLevel();
                    break;
                case 2:
                    break;
                default:
                    FileBrowse.DownOneLevel(FileBrowse.SubDirNames()[choice - 3]);
                    break;
            }    
        }
    }
}