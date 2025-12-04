namespace menus;

using System.Text.RegularExpressions;
using compose_final_output;
using file_browse;
using messages;
using parse_word_doc;
public class Menus
{
    public static void Speak(string message)
    {
        Console.WriteLine(message);
    }

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
        Speak($"{Messages.newLine}{message}");
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
                    FileMenu();
                    break;
                default:
                    FileBrowse.DownOneLevel(FileBrowse.SubDirNames()[choice - 3]);
                    break;
            }    
        }
    }

    public static void FileMenu()
    {
        ComposeFinalOutput.GetOutputDir();
        bool exit = false;
        while(exit == false)
        {
            int choice = Menu(Messages.FileMenuMessage, FileBrowse.FileMenuOptions());
            switch (choice)
            {
                case 0:
                    exit = true;
                    //FileBrowse.UpOneLevel();
                    break;
                default:
                    FileBrowse.DownOneLevel(FileBrowse.FileNames()[choice - 1]);
                    if(ParseWordDoc.ValidFileType() == true)
                    {
                        ParseWordDoc.OpenDoc();
                        ParseWordDoc.GetOpenDocParagraphs();
                        ParseFileMenu();
                    }
                    else
                    {
                        Speak(Messages.wrongFileType);
                        FileBrowse.UpOneLevel();
                    }
                    break;
            }            
        }
    }

    public static void ParseFileMenu()
    {
        // "Exit this file",
        // "Next paragraph",
        // "Previous paragraph",
        // "Extract this element's text as is",
        // "Edit this text before extracting",
        // "Finish with this file, and create the final output"

        ComposeFinalOutput.GetOutputFileName();
        ComposeFinalOutput.GetOutputFilePath();
        Speak($"{Messages.newLine}{Messages.ParseFileMenuMessage()}");
        int targetParagraphNr = 0;
        bool exit = false;
        while(exit == false)
        {
            int choice = Menu($"{ParseWordDoc.GetTargetParagraphText(targetParagraphNr)}{Messages.newLine}", ParseWordDoc.ParseFileMenuOptions());
            switch (choice)
            {
                case 0:
                    exit = true;
                    ParseWordDoc.CloseDoc();
                    ParseWordDoc.ClearDocParagraphs();
                    FileBrowse.UpOneLevel();
                    break;
                case 1:
                    targetParagraphNr++;
                    if(targetParagraphNr >= ParseWordDoc.openDocParagraphs.Length)
                    {
                        Menus.Speak($"{Messages.newLine}{Messages.lastParagraphMessage}");
                        targetParagraphNr--;
                    }
                    break;
                case 2:
                    targetParagraphNr--;
                    if(targetParagraphNr < 0)
                    {
                        Menus.Speak($"{Messages.newLine}{Messages.firstParagraphMessage}");
                        targetParagraphNr++;
                    }
                    break;
                case 3:
                    ComposeFinalOutput.AddExtractedText(targetParagraphNr);
                    Menus.Speak($"{Messages.newLine}-- Done --");
                    break;
                case 4:
                    break;
                case 5:
                    ComposeFinalOutput.FinalOutputToConsole();
                    ComposeFinalOutput.CreateOutputFile();
                    exit = true;
                    ParseWordDoc.CloseDoc();
                    ParseWordDoc.ClearDocParagraphs();
                    FileBrowse.UpOneLevel();
                    break;
                default:
                    exit = true;
                    FileBrowse.UpOneLevel();
                    break;
            }
        }
    }
}