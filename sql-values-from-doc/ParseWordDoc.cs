namespace parse_word_doc;

using System.Reflection.Metadata;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using file_browse;

public class ParseWordDoc
{
    public static string docUri = "";
    public static WordprocessingDocument doc;
    public static void getDocument(string docUri)
    {
        doc = WordprocessingDocument.Open(docUri,false);
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