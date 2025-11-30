namespace messages;

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
            "Exit this menu",
            "Go one level up",
            "See files here"
        };
        return options;
    }
    public static string[] preFileMenuOptions()
    {
        return [
            "Back to folders"
        ];
    }
}