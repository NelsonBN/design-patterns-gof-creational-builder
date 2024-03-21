namespace Demo;

/// <summary>
/// Concrete Builder
/// </summary>
public partial class Car
{
    public class CoupeBuilder : ICarBuilder
    {
        private readonly Car _car = new();

        public ICarBuilder WithEngine(string engineType) {
            _car.Engine = engineType;
            return this;
        }

        public ICarBuilder WithColor(string color) {
            _car.Color = color;
            return this;
        }

        public ICarBuilder WithDesignInterior(string interiorType) {
            _car.Interior = interiorType;
            return this;
        }

        public ICarBuilder AddFeatures(params string[] features) {
            _car.Features.AddRange(features);
            return this;
        }

        public Car Build()
        {
            _car.Type = "Coupe";
            if(string.IsNullOrEmpty(_car.Interior)) _car.Interior = "Cloth";
            if(string.IsNullOrEmpty(_car.Color)) _car.Color = "White";

            _validate();

            (_car.CC, _car.HP) = _car.Engine switch
            {
                "V4" => (1600, 120),
                "V6" => (2000, 180),
                "V8" => (2500, 250),
            };

            _car.Doors = 3;
            _car.Seats = 2;

            _car.Year = DateTime.UtcNow.Year;

            return _car;
        }

        private void _validate()
        {
            if(_car.Engine is not ("V4" or "V6" or "V8")) throw new ArgumentException("Invalid engine");
            if(_car.Interior is not ("Leather" or "Cloth")) throw new ArgumentException("Invalid Interior");
        }
    }
}
