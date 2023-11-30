namespace Tasks1_3.Vehicles;

[Serializable]
public class Train : Vehicle
{
    public bool HasRestaurant { get; protected set; } = false;
    public bool HasBioToilet { get; protected set; } = true;

    public Train()
    {
        PassengerAmount = 143;
        MaxSpeed = 190;
    }
}