using System.Text.Json;
using Tasks1_3.Vehicles;

namespace Tasks1_3;

public static class Program
{
    public static void Main()
    {
        const string menuOptions = "Options:" +
                                   "\n(1) Print inheritor types of type Vehicle sorted alphabetically" +
                                   "\n(2) Find inheritor types of type Vehicle by name part" +
                                   "\n(3) Save inheritors instances in file" +
                                   "\n(4) Quit";
        IEnumerable<Vehicle> vehicles = InstanceService.GetInstances<Vehicle>();

        while (true)
        {
            Console.WriteLine(menuOptions);

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                ProcessMenuChoice(choice, vehicles.ToList(), out bool isFinished);

                if (isFinished)
                {
                    break;
                }
            }
            else
            {
                Console.Error.WriteLine("Proper option number must be positive integer");
            }
        }
        
        Console.WriteLine("See ya later!");
    }
    
    private static void ProcessMenuChoice(int choice, IEnumerable<Vehicle> vehicles, out bool isFinished)
    {
        isFinished = false;
        switch (choice)
        {
            case 1:
            {
                PrintVehicleTypes(vehicles);
                break;
            }
            case 2:
            {
                PrintFoundTypesByNamePart(vehicles);
                break;
            }
            case 3:
            {
                WriteVehiclesToFile(vehicles);
                break;
            }
            case 4:
            {
                isFinished = true;
                return;
            }
            default:
            {
                Console.Error.WriteLine("Invalid option number");
                break;
            }
        }
    }

    private static IEnumerable<string> GetSortedVehicleTypeNames(IEnumerable<Vehicle> vehicles)
    {
        return vehicles.Select(vehicle => vehicle.GetType().Name).Order();
    }

    private static void PrintVehicleTypes(IEnumerable<Vehicle> vehicles)
    {
        var result = GetSortedVehicleTypeNames(vehicles);
                
        Console.WriteLine("Available vehicles' type names:");
        foreach (var vehicleTypeName in result)
        {
            Console.WriteLine(vehicleTypeName);
        }
    }

    private static void WriteVehiclesToFile(IEnumerable<Vehicle> vehicles)
    {
        Console.WriteLine("Enter target file name without extension (default file name is 'vehicles.txt')");
        var filename = Console.ReadLine();
        filename = string.IsNullOrWhiteSpace(filename) ? "vehicles.txt" : filename + ".txt";
        
        if (!TryWriteInstancesToFile(vehicles, filename))
        {
            Console.WriteLine("File creation is unavailable in this directory");
            return;
        }
        Console.WriteLine($"Vehicles successfully written to the file {filename}");
    }

    private static bool TryWriteInstancesToFile(IEnumerable<Vehicle> vehicles, string filename)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(filename);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            writer.WriteLine(JsonSerializer.Serialize(vehicles, options));
        }
        catch (Exception)
        {
            return false;
        }
        
        return true;
    }

    private static void PrintFoundTypesByNamePart(IEnumerable<Vehicle> vehicles)
    {
        Console.WriteLine("Enter the part of type name");
        var typeNamePart = Console.ReadLine();

        IEnumerable<Vehicle> targetInstances = new List<Vehicle>();
        if (!string.IsNullOrWhiteSpace(typeNamePart))
        {
            targetInstances = GetTypesWithSpecifiedNamePart(vehicles, typeNamePart);
        }

        if (!targetInstances.Any())
        {
            Console.WriteLine("No type with such type name part");
            return;
        }
        
        Console.WriteLine("Names of matching types:");
        foreach (var vehicle in targetInstances)
        {
            Console.WriteLine(vehicle.GetType().Name);
        }
    }

    private static IEnumerable<T> GetTypesWithSpecifiedNamePart<T>(IEnumerable<T> instances, string typeNamePart)
    {
        return instances.Where(instance =>
            instance.GetType().Name.Contains(typeNamePart, StringComparison.InvariantCultureIgnoreCase));
    }
}