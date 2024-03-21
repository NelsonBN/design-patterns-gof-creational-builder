using System.Text;

namespace Demo;

public static class DocumentExtensions
{
    public static string Print(this Document document)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"FileName: {document.FileName}");
        sb.AppendLine($"\tHeader: {document.Header}");
        foreach (var section in document.Sections)
        {
            foreach (var element in section.Elements)
            {
                if (element is Section.Header1 header1)
                {
                    sb.AppendLine($"\t# {header1}");
                }

                else if (element is Section.Header2 header2)
                {
                    sb.AppendLine($"\t\t## {header2}");
                }

                else if (element is Section.Header3 header3)
                {
                    sb.AppendLine($"\t\t\t### {header3}");
                }

                else if(element is Section.BulletedList bulletedList)
                {
                    foreach (var item in bulletedList.Items)
                    {
                        sb.AppendLine($"\t\t* {item}");
                    }
                }

                else if (element is Section.Paragraph paragraph)
                {
                    sb.AppendLine($"\t\t{paragraph}");
                }
            }
        }
        sb.AppendLine($"\tFooter: {document.Footer}");
        return sb.ToString();
    }
}
