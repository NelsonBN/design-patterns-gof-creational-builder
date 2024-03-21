Console.WriteLine("Classic Builder Example");

// Define which concrete builder will be used to build the product.
ICarBuilder sedanBuilder = new SedanBuilder();

// Create the director and pass the concrete builder to it.
var dealership = new Dealership(sedanBuilder);

// Construct the product using the director.
dealership.Construct();

// Get the product from the builder.
var sedanCar = sedanBuilder.Build();
Console.WriteLine(sedanCar);


ICarBuilder coupeBuilder = new CoupeBuilder();

dealership = new Dealership(coupeBuilder);
dealership.Construct();

var coupeCar = coupeBuilder.Build();
Console.WriteLine(coupeCar);



/// <summary>
/// Director
/// </summary>
class Dealership
{
    private ICarBuilder _builder;

    public Dealership(ICarBuilder builder)
        => _builder = builder;

    public void Construct()
    {
        _builder.Engine("V6");
        _builder.PaintCar("Red");
        _builder.DesignInterior("Leather");
        _builder.AddFeature("Air Conditioning");
        _builder.AddFeature("Power Windows");
        _builder.AddFeature("Sunroof");
    }
}

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
/// Builder Interface
/// </summary>
interface ICarBuilder
{
    void Engine(string engineType);
    void PaintCar(string color);
    void DesignInterior(string interiorType);
    void AddFeature(string feature);
    Car Build();
}


/// <summary>
/// Concrete Builder
/// </summary>
class SedanBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void Engine(string engineType)
    {
        switch (engineType)
        {
            case "V4":
                _car.Engine = engineType;
                _car.CC = 1600;
                _car.HP = 120;
                break;

            case "V6":
                _car.Engine = engineType;
                _car.CC = 2000;
                _car.HP = 180;
                break;

            case "V8":
                _car.Engine = engineType;
                _car.CC = 2500;
                _car.HP = 250;
                break;
        }
    }

    public void PaintCar(string color)
        => _car.Color = color;

    public void DesignInterior(string interiorType)
        => _car.Interior = interiorType;

    public void AddFeature(string feature)
        => _car.Features.Add(feature);

    public Car Build()
    {
        if (string.IsNullOrEmpty(_car.Engine)) throw new ArgumentException("Engine is required");
        if (string.IsNullOrEmpty(_car.Color)) throw new ArgumentException("Color is required");
        if (string.IsNullOrEmpty(_car.Interior)) throw new ArgumentException("Interior is required");

        _car.Type = "Sedan";
        _car.Doors = 5;
        _car.Seats = 5;

        return _car;
    }
}

class CoupeBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void Engine(string engineType)
    {
        switch (engineType)
        {
            case "V4":
                _car.Engine = engineType;
                _car.CC = 1800;
                _car.HP = 150;
                break;

            case "V6":
                _car.Engine = engineType;
                _car.CC = 2200;
                _car.HP = 200;
                break;

            case "V8":
                _car.Engine = engineType;
                _car.CC = 2700;
                _car.HP = 270;
                break;
        }
    }

    public void PaintCar(string color)
        => _car.Color = color;

    public void DesignInterior(string interiorType)
        => _car.Interior = interiorType;

    public void AddFeature(string feature)
        => _car.Features.Add(feature);

    public Car Build()
    {
        if (string.IsNullOrEmpty(_car.Engine)) throw new ArgumentException("Engine is required");
        if (string.IsNullOrEmpty(_car.Color)) throw new ArgumentException("Color is required");
        if (string.IsNullOrEmpty(_car.Interior)) throw new ArgumentException("Interior is required");

        _car.Type = "Coupe";
        _car.Doors = 3;
        _car.Seats = 2;

        return _car;
    }
}
