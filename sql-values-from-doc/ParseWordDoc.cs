namespace parse_word_doc;

using System.Reflection.Metadata;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using file_browse;
using messages;
using DocumentFormat.OpenXml.Office.CustomUI;
using menus;

public class ParseWordDoc
{
    public static WordprocessingDocument doc;
    public static void OpenDoc()
    {
        doc = WordprocessingDocument.Open(FileBrowse.currentUri, false);
    }

    public static void CloseDoc()
    {
        doc.Dispose();
    }
    
    public static bool ValidFileType()
    {
        bool valid = false;
        if(FileBrowse.currentUri.Substring(FileBrowse.currentUri.LastIndexOf('.') + 1) == "docx")
        {
            valid = true;
        }
        return valid;
    }

    public static DocumentFormat.OpenXml.Wordprocessing.Paragraph[] openDocParagraphs = [];

    public static string[] ParseFileMenuOptions()
    {
        string[] options = [];
        options = Messages.PreParseFileMenuOptions();
        return options;
    }

    public static void GetOpenDocParagraphs()
    {
        openDocParagraphs = doc.MainDocumentPart.Document.Body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToArray();
        
    }

    public static void ClearDocParagraphs()
    {
        openDocParagraphs = [];
    }

    public static string GetTargetParagraphText(int index)
    {
        return openDocParagraphs[index].InnerText;
    }

    public static void GetSqlValuesLines()
    {
        DocumentFormat.OpenXml.Wordprocessing.Paragraph[] paragraphs = doc.MainDocumentPart.Document.Body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToArray();
        foreach(DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph in paragraphs)
        {
            Console.WriteLine($"\nParagraph inner text:\n{paragraph.InnerText}");
        }
    }
}