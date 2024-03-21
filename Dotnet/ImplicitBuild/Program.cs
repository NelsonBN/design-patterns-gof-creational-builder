using Demo;

Console.WriteLine("Implicit Build");

Car car = Car.Create()
    .Type("Coupe")
    .WithEngine("V8")
    .WithColor("Blue")
    .WithDesignInterior("Leather")
    .AddFeatures("Air Conditioning", "Power Windows")
    .AddFeatures("Sunroof");

Console.WriteLine(car);
