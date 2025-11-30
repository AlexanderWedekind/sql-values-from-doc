namespace file_browse;

using System.Diagnostics;
using sqlFromDoc;
using menus;
using messages;

public class FileBrowse
{
    public static string currentUri = "";

    public static void ResetCurrentUri()
    {
        currentUri = Directory.GetCurrentDirectory();
    }
    
    public static string[] getSubDirs()
    {
        string[] subDirs = [];
        subDirs = Directory.GetDirectories(currentUri);
        return subDirs;
    }

    public static string[] getFiles()
    {
        string[] files = [];
        files = Directory.GetFiles(currentUri);
        return files;
    }

    public static string GetFileOrDirName(string fullPath)
    {
        string name = "";
        int lastSlash = fullPath.LastIndexOf('\\');
        if(lastSlash > -1 && lastSlash < fullPath.Length - 1)
        {
            name = fullPath.Substring(lastSlash + 1);    
        }
        return name;
    }

    public static string[] SubDirNames()
    {
        List<string> names = new List<string>();
        foreach(string subDir in getSubDirs())
        {
            names.Add(GetFileOrDirName(subDir));
        }
        return names.ToArray();
    }

    public static string[] FileNames()
    {
        List<string> names = new List<string>();
        foreach(string filePath in getFiles())
        {
            names.Add(GetFileOrDirName(filePath));
        }
        return names.ToArray();
    }

    public static string[] DirMenuOptions()
    {
        string[] dirNames = SubDirNames();
        for(int i = 0; i < dirNames.Length; i++)
        {
            dirNames[i] = $"Go into -> {dirNames[i]}";
        }
        string[] options = Messages.preDirMenuOptions().Concat(dirNames).ToArray();
        return options;
    }

    public static string[] FileMenuOptions()
    {
        string[] fileNames = FileNames();
        for(int i = 0; i < fileNames.Length; i++)
        {
            fileNames[i] = $"Open -> {fileNames[i]}";
        }
        string[] options = Messages.preFileMenuOptions().Concat(fileNames).ToArray();
        return options;
    }

    public static void DownOneLevel(string name)
    {
        currentUri = $"{currentUri}\\{name}";
    }

    public static void UpOneLevel()
    {
        int lastSlash = currentUri.LastIndexOf('\\');
        if(lastSlash > -1)
        {
            currentUri = currentUri.Substring(0, currentUri.Length - (currentUri.Length - lastSlash));
        }
    }
}
