using Demo;

Console.WriteLine("Nested Builder");

var car = new Car.Builder()
    .Type("Coupe")
    .WithEngine("V8")
    .WithColor("Blue")
    .WithDesignInterior("Leather")
    .AddFeatures("Air Conditioning", "Power Windows")
    .AddFeatures("Sunroof")
    .Build();

Console.WriteLine(car);
