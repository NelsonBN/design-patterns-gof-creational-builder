namespace Demo;

public partial record Section
{
    public IEnumerable<Element> Elements { get; private init; }

    private Section() { }


    public abstract record Element { }

    public record Header1(string Value) : Element
    {
        public static implicit operator Header1(string value) => new(value);
        public override string ToString() => Value;
    }

    public record Header2(string Value) : Element
    {
        public static implicit operator Header2(string value) => new(value);
        public override string ToString() => Value;
    }

    public record Header3(string Value) : Element
    {
        public static implicit operator Header3(string value) => new(value);
        public override string ToString() => Value;
    }

    public record Paragraph(string Value) : Element
    {
        public static implicit operator Paragraph(string value) => new(value);
        public override string ToString() => Value;
    }

    public record BulletedList(IEnumerable<string> Items) : Element
    {
        public static implicit operator BulletedList(string items) => new(items);
    }
}
