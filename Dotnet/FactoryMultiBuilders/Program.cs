using Demo;

Console.WriteLine("Factory to create multiple builders");


var sedanCar = Car.Create<Car.SedanBuilder>()
    .WithEngine("V4")
    .WithColor("Red")
    .AddFeatures("Air Conditioning")
    .Build();

Console.WriteLine(sedanCar);

var coupeCar = Car.Create<Car.CoupeBuilder>()
    .WithEngine("V8")
    .WithColor("Blue")
    .WithDesignInterior("Leather")
    .AddFeatures("Power Windows")
    .AddFeatures("Air Conditioning")
    .AddFeatures("Sunroof")
    .Build();

Console.WriteLine(coupeCar);
