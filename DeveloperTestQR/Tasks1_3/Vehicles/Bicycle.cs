namespace Tasks1_3.Vehicles;

[Serializable]
public class Bicycle : Vehicle
{
    public bool HasBasket { get; protected set; } = true;
    public bool HasRack { get; protected set; } = false;

    public Bicycle()
    {
        PassengerAmount = 1;
        MaxSpeed = 35;
    }
}