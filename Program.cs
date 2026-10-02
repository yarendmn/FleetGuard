using FleetGuard.Interfaces;
using FleetGuard.Models;
using System;

class Program
{
    // Maksimum 50 araçlık dizi
    static Vehicle[] fleet = new Vehicle[50]; 
    static int vehicleCount = 0;

    static void Main(string[] args)
    {
        // Test için birkaç araç ekleyelim
        fleet[vehicleCount++] = new Car(1, "Toyota", "Corolla");
        fleet[vehicleCount++] = new Truck(2, "Ford", "Cargo", 60000, true);
        fleet[vehicleCount++] = new Drone(3, "DJI", "Mavic"); 

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- FleetGuard Menü ---");
            Console.WriteLine("1 - Araç ekle"); 
            Console.WriteLine("2 - Araçları göster"); 
            Console.WriteLine("3 - Araç incele"); 
            Console.WriteLine("4 - Bakım gerçekleştir"); 
            Console.WriteLine("5 - Bakım maliyeti hesapla"); 
            Console.WriteLine("6 - Araç raporu oluştur"); 
            Console.WriteLine("7 - Çıkış"); 
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddVehicle();
                    break;
                case "2":
                    ShowVehicles();
                    break;
                case "3":
                    InspectVehicles();
                    break;
                case "4":
                    PerformMaintenance();
                    break;
                case "5":
                    CalculateCosts();
                    break;
                case "6":
                    GenerateReports();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Çıkılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static void AddVehicle()
    {
        if (vehicleCount >= 50) 
        {
            Console.WriteLine("Filo kapasitesi dolu! (Maksimum 50)"); 
            return;
        }

        Console.Write("Tür (1: Car, 2: Truck): ");
        string type = Console.ReadLine();

        Console.Write("Marka: ");
        string brand = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        Console.Write("Kilometre: ");
        if (double.TryParse(Console.ReadLine(), out double mileage))
        {
            if (type == "1") fleet[vehicleCount++] = new Car(vehicleCount, brand, model);
            else if (type == "2") fleet[vehicleCount++] = new Truck(vehicleCount, brand, model, mileage, isActive);
            else if (type == "3") fleet[vehicleCount++] = new Drone(vehicleCount, brand, model);
            else Console.WriteLine("Geçersiz tür.");
        }
        else Console.WriteLine("Hatalı kilometre girişi.");
    }

    static void ShowVehicles()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            fleet[i].ShowInfo();
        }
    }

    static void InspectVehicles()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            if (fleet[i] is IInspectable inspectable)
            {
                inspectable.Inspect();
            }
        }
    }

    static void PerformMaintenance()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            if (fleet[i] is IMaintainable maintainable)
            {
                maintainable.PerformMaintenance();
            }
        }
    }

    static void CalculateCosts()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            // Polymorphism devrede! Her araç kendi maliyetini hesaplar
            double cost = fleet[i].CalculateServiceCost(); 
            Console.WriteLine($"{fleet[i].Brand} {fleet[i].Model} Bakım Maliyeti: {cost} TL");
        }
    }

    static void GenerateReports()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            if (fleet[i] is IReportable reportable)
            {
                reportable.GenerateReport();
            }
        }
    }
}
