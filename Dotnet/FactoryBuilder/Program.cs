using Demo;

Console.WriteLine("Factory Builder");

var car = Car.Create()
    .Type("Coupe")
    .WithEngine("V8")
    .WithColor("Blue")
    .WithDesignInterior("Leather")
    .AddFeatures("Air Conditioning", "Power Windows")
    .AddFeatures("Sunroof")
    .Build();

Console.WriteLine(car);
