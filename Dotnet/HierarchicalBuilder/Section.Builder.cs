namespace Demo;

public partial record Section
{
    public class Builder
    {
        private readonly List<Element> _elements = [];

        public Builder Header1(string header)
        {
            _elements.Add(new Header1(header));
            return this;
        }

        public Builder Header2(string header)
        {
            _elements.Add(new Header2(header));
            return this;
        }

        public Builder Header3(string header)
        {
            _elements.Add(new Header3(header));
            return this;
        }

        public Builder Paragraph(string paragraph)
        {
            _elements.Add(new Paragraph(paragraph));
            return this;
        }

        public Builder BulletedList(Action<BulletedListBuilder> bulletedList)
        {
            var builder = new BulletedListBuilder();
            bulletedList(builder);
            _elements.Add(builder.Build());
            return this;
        }

        public Section Build()
            => new()
            {
                Elements = _elements
            };
    }
}
