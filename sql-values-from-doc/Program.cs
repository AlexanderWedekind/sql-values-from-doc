namespace sqlFromDoc;

using System.Reflection.Metadata;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using messages;
using menus;
using file_browse;

public class Program
{
    public static Messages messages = new Messages();
    
    
    public static void Main(string[] args)
    {
        FileBrowse.ResetCurrentUri();
        Console.WriteLine($"'Directory.GetCurrentDirectory()' at startup: {FileBrowse.currentUri}");
        Menus.FolderMenu();
    }
}
