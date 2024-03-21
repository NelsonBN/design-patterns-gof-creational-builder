Console.WriteLine("Fluent Builder");

var car = new CarBuilder()
    .Type("Coupe")
    .WithEngine("V8")
    .WithColor("Blue")
    .WithDesignInterior("Leather")
    .AddFeatures("Air Conditioning", "Power Windows")
    .AddFeatures("Sunroof")
    .Build();

Console.WriteLine(car);



/// <summary>
/// Product
/// </summary>
class Car
{
    public string Type { get; set; }
    public string Engine { get; set; }
    public int CC { get; set; }
    public int HP { get; set; }
    public int Doors { get; set; }
    public int Seats { get; set; }
    public string Color { get; set; }
    public string Interior { get; set; }
    public int Year { get; set; }
    public List<string> Features { get; private set; } = [];

    public override string ToString()
        => $"[{Type}] {Engine}, {CC}cc, {HP}hp, {Color}, {Doors} doors, {Seats} seats, {Year} Year, with ({string.Join(", ", Features)})";
}

/// <summary>
/// Concrete Builder
/// </summary>
class CarBuilder
{
    private readonly Car _car = new Car();

    public CarBuilder Type(string type) {
        _car.Type = type;
        return this;
    }

    public CarBuilder WithEngine(string engineType) {
        _car.Engine = engineType;
        return this;
    }

    public CarBuilder WithColor(string color) {
        _car.Color = color;
        return this;
    }

    public CarBuilder WithDesignInterior(string interiorType) {
        _car.Interior = interiorType;
        return this;
    }

    public CarBuilder AddFeatures(params string[] features) {
        _car.Features.AddRange(features);
        return this;
    }

    public Car Build()
    {
        if(string.IsNullOrEmpty(_car.Interior)) _car.Interior = "Cloth";
        if(string.IsNullOrEmpty(_car.Color)) _car.Color = "White";

        _validate();

        (_car.CC, _car.HP) = _car.Engine switch
        {
            "V4" => (1600, 120),
            "V6" => (2000, 180),
            "V8" => (2500, 250),
        };

        (_car.Doors, _car.Seats) = _car.Type switch
        {
            "Sedan" => (5, 5),
            "Coupe" => (3, 2),
        };

        _car.Year = DateTime.UtcNow.Year;

        return _car;
    }

    private void _validate()
    {
        if(_car.Engine is not ("V4" or "V6" or "V8")) throw new ArgumentException("Invalid engine");
        if(_car.Type is not ("Sedan" or "Coupe")) throw new ArgumentException("Invalid type");
        if(_car.Interior is not ("Leather" or "Cloth")) throw new ArgumentException("Invalid Interior");
    }
}
