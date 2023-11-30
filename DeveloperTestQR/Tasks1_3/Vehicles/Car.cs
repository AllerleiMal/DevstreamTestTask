namespace Tasks1_3.Vehicles;

[Serializable]
public class Car : Vehicle
{
    public bool HasAirConditioner { get; protected set; } = true;
    public double EngineVolume { get; protected set; } = 3.5;
    public string? Brand { get; protected set; } = "Ford";
    public string? Model { get; protected set; } = "Fiesta";

    public Car()
    {
        PassengerAmount = 5;
        MaxSpeed = 150;
    }
}