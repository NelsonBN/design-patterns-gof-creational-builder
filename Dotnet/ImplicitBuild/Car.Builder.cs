namespace Demo;

/// <summary>
/// Concrete Builder
/// </summary>
public partial class Car
{
    public static Builder Create() => new();
    public static implicit operator Car(Builder builder) => builder.Build();

    public class Builder
    {
        private readonly Car _car = new();

        public Builder Type(string type) {
            _car.Type = type;
            return this;
        }

        public Builder WithEngine(string engineType) {
            _car.Engine = engineType;
            return this;
        }

        public Builder WithColor(string color) {
            _car.Color = color;
            return this;
        }

        public Builder WithDesignInterior(string interiorType) {
            _car.Interior = interiorType;
            return this;
        }

        public Builder AddFeatures(params string[] features) {
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
}
