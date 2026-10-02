using FleetGuard.Interfaces;
using FleetGuard.Models;

public class Truck : Vehicle, IMaintainable, IInspectable, IReportable
{
          public Truck(int id, string brand, string model, double mileage, bool isActive) : base(id, brand, model, mileage, isActive) {  }

          // Override ile Truck'a özel hesap
          public override double CalculateServiceCost()
          {
             return 2500 + (Mileage * 0.10); 
          }

         public void PerformMaintenance() => Console.WriteLine($"{Brand} {Model} ağır vasıta bakımı yapıldı.");
         public void CalculateNextMaintenance() => Console.WriteLine($"{Brand} {Model} sonraki bakım: {Mileage + 30000} km.");
         public void Inspect() => Console.WriteLine($"{Brand} {Model} yük/fren muayenesi tamam.");
         public void GenerateReport() => Console.WriteLine($"{Brand} {Model} detaylı sefer raporu oluşturuldu.");
}