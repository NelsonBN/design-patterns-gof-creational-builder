namespace Demo;

/// <summary>
/// Builder Interface
/// </summary>
public interface ICarBuilder
{
    ICarBuilder WithEngine(string engineType);
    ICarBuilder WithColor(string color);
    ICarBuilder WithDesignInterior(string interiorType);
    ICarBuilder AddFeatures(params string[] features);
    Car Build();
}
