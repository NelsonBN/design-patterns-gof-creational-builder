using System.Text;

namespace Demo;

public partial record Document
{
    public string FileName { get; private init; }
    public string? Header { get; private init; }
    public string? Footer { get; private init; }
    public IEnumerable<Section> Sections { get; private init; }

    private Document() { }
}
