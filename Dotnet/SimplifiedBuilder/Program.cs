Console.WriteLine("Simplified Builder");

// Create builder
var builder = new CarBuilder();

builder.Type("Sedan");
builder.Engine("V6");
builder.AddFeatures("Air Conditioning");
builder.AddFeatures("Power Windows");
builder.AddFeatures("Sunroof");

// Get the product from the builder.
var sedanCar = builder.Build();
Console.WriteLine(sedanCar);

builder = new CarBuilder();
builder.Type("Coupe");
builder.Engine("V8");
builder.PaintCar("Blue");
builder.DesignInterior("Leather");
builder.AddFeatures("Air Conditioning", "Power Windows");

var coupeCar = builder.Build();
Console.WriteLine(coupeCar);



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
    public List<string> Features { get; private set; } = [];

    public override string ToString()
        => $"[{Type}] {Engine}, {CC}cc, {HP}hp, {Color}, {Doors} doors, {Seats} seats, with ({string.Join(", ", Features)})";
}

/// <summary>
/// Concrete Builder
/// </summary>
class CarBuilder
{
    private readonly Car _car = new();

    public void Type(string type)
        => _car.Type = type;

    public void Engine(string engineType)
        => _car.Engine = engineType;

    public void PaintCar(string color)
        => _car.Color = color;

    public void DesignInterior(string interiorType)
        => _car.Interior = interiorType;

    public void AddFeatures(params string[] features)
        => _car.Features.AddRange(features);

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

        return _car;
    }

    private void _validate()
    {
        if(_car.Engine is not ("V4" or "V6" or "V8")) throw new ArgumentException("Invalid engine");
        if(_car.Type is not ("Sedan" or "Coupe")) throw new ArgumentException("Invalid type");
        if(_car.Interior is not ("Leather" or "Cloth")) throw new ArgumentException("Invalid Interior");
    }
}
