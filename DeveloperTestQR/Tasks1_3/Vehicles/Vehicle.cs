using System.Text.Json.Serialization;

namespace Tasks1_3.Vehicles;

[JsonDerivedType(typeof(Bicycle), typeDiscriminator: "Bicycle")]
[JsonDerivedType(typeof(Car), typeDiscriminator: "Car")]
[JsonDerivedType(typeof(Plane), typeDiscriminator: "Plane")]
[JsonDerivedType(typeof(Train), typeDiscriminator: "Train")]
public abstract class Vehicle
{
    public int PassengerAmount { get; protected set; }
    public int MaxSpeed { get; protected set; }
}