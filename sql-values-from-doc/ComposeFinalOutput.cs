using file_browse;
using menus;
using parse_word_doc;

namespace compose_final_output;

public class ComposeFinalOutput
{
    public static string finalOutput = "";
    public static string outputFileName = "";
    public static string outputFilePath = "";
    public static string outputFileDir = "";

    public static void GetOutputDir()
    {
        outputFileDir = FileBrowse.currentUri;
    }

    public static void GetOutputFileName()
    {
        outputFileName = $"{FileBrowse.GetFileOrDirName(FileBrowse.currentUri).Substring(0, FileBrowse.GetFileOrDirName(FileBrowse.currentUri).Length - (FileBrowse.GetFileOrDirName(FileBrowse.currentUri).Length - FileBrowse.GetFileOrDirName(FileBrowse.currentUri).LastIndexOf(".")))}_parsed_output";
    }

    public static void GetOutputFilePath()
    {
        outputFilePath = $"{outputFileDir}\\{outputFileName}";
    }

    public static void FinalOutputToConsole()
    {
        Menus.Speak($"Your final output looks as follows; copy paste from console here, or view in file '{outputFileName}', in '{outputFileDir}:\n\n{finalOutput}");
    }

    public static void AddExtractedText(int index)
    {
        finalOutput = $"{finalOutput}\n{ParseWordDoc.GetTargetParagraphText(index)}";
    }

    public static void CreateOutputFile()
    {
        //Directory.CreateDirectory(outputFileDir);
        StreamWriter writeOutputFile = File.CreateText($"{outputFilePath}.txt");
        writeOutputFile.WriteLine(finalOutput);
        writeOutputFile.Close();
    }
}