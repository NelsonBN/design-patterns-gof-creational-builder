namespace Demo;

public class BulletedListBuilder
{
    private readonly List<string> _items = [];

    public BulletedListBuilder Item(string item)
    {
        _items.Add(item);
        return this;
    }

    public Section.BulletedList Build()
        => new(_items);
}
