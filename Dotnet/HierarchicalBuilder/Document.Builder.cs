namespace Demo;

public partial record Document
{
    public static implicit operator Document(Builder builder)
        => builder.Build();

    public static Builder Create(string fileName)
        => new(fileName);

    public class Builder
    {
        private readonly string _fileName;
        private string? _header;
        private string? _footer;
        private readonly List<Section> _sections = [];

        public Builder(string fileName)
            => _fileName = fileName;


        public Builder Header(string header)
        {
            _header = header;
            return this;
        }

        public Builder Footer(string footer)
        {
            _footer = footer;
            return this;
        }

        public Builder Section(Action<Section.Builder> section)
        {
            var sectionBuilder = new Section.Builder();
            section(sectionBuilder);
            _sections.Add(sectionBuilder.Build());
            return this;
        }

        public Document Build()
            => new()
            {
                FileName = _fileName,
                Header = _header,
                Footer = _footer,
                Sections = _sections
            };
    }
}
