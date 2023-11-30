namespace Tasks1_3.Vehicles;

[Serializable]
public class Plane : Vehicle
{
    public double State { get; protected set; } = 1;
    public bool IsPrivate { get; protected set; } = false;
    public string? Manufacturer { get; protected set; } = "Boeing";

    public Plane()
    {
        PassengerAmount = 250;
        MaxSpeed = 800;
    }
}