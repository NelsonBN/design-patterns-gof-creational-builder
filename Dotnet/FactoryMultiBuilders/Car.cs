namespace Demo;

/// <summary>
/// Product
/// </summary>
public partial class Car
{
    public string Type { get; private set; }
    public string Engine { get; private set; }
    public int CC { get; private set; }
    public int HP { get; private set; }
    public int Doors { get; private set; }
    public int Seats { get; private set; }
    public string Color { get; private set; }
    public string Interior { get; private set; }
    public int Year { get; private set; }
    public List<string> Features { get; private set; } = [];

    private Car() { }

    public override string ToString()
        => $"[{Type}] {Engine}, {CC}cc, {HP}hp, {Color}, {Doors} doors, {Seats} seats, {Year} Year, with ({string.Join(", ", Features)})";


    public static ICarBuilder Create<TBuilder>()
        where TBuilder : ICarBuilder, new()
        => new TBuilder();
}
