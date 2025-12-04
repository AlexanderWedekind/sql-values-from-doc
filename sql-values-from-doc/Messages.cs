namespace messages;

using System.ComponentModel.DataAnnotations;
using file_browse;
public class Messages
{
    public static string newLine = "\n";
    public static string plsSelectDocUri = "type the uri of the document you want to work with";
    public static string invalidMenuChoice = "That was not a valid menu choice!\nPlease choose one of the above options, by entering only the number that corresponds to your choice.";
    public static string rejectNull = "You can't leave this black. Use keyboard to enter choice, then press [Enter]";
    public static string AnnounceCurrentDir()
    {
        return $"You are in:\n{FileBrowse.currentUri}";
    }
    public static string FolderMenuMessage()
    {
        return $"{AnnounceCurrentDir()}\n\nChoose an option:\n";
    }
    public static string[] preDirMenuOptions()
    {
        string[] options =
        {
            "Exit this app",
            "Go one level up",
            "See files here"
        };
        return options;
    }
    public static string FileMenuMessage = "Choose a file to parse, or go back to folders\n";
    public static string[] preFileMenuOptions()
    {
        return [
            "Back to folders"
        ];
    }
    public static string wrongFileType = "We can only work with '.docx' files, at this point.\nChoose a file of the correct format.";
    public static string[] PreParseFileMenuOptions()
    {
        string[] options =
        {
            "Exit this file",
            "Next paragraph",
            "Previous paragraph",
            "Extract this element's text as is",
            "Edit this paragraph text before extracting",
            "Finish with this file, and create the final output"
        };
        return options;
    }
    public static string ParseFileMenuMessage()
    {
        return $"You're looking at file: {FileBrowse.GetFileOrDirName(FileBrowse.currentUri)},\nin: {FileBrowse.GetFileContainingDirName()}\n\n" + 
        "Displaying text one paragraph at a time. Choose from the options for each:";
    }
    public static string lastParagraphMessage = "This is the last paragragraph in this word document; choose a different option:\n";
    public static string firstParagraphMessage = "This is the first paragraph, there are no paragraphs in front of this one; choose a different options:\n";
    public static string pressKeyToContinue = "(press any key to continue)";
}