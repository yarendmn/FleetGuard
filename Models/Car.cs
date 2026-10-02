using FleetGuard.Interfaces;
using FleetGuard.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace FleetGuard.Models
{
    public class Car : Vehicle, IMaintainable, IInspectable
    {
        public Car(int id, string brand, string model): base(id, brand, model) { }

        // Override ile Car'a özel hesap
        public override double CalculateServiceCost()
        {
            return 1000 + (Mileage * 0.05);
        }

        public void PerformMaintenance() => Console.WriteLine($"{Brand} {Model} motor bakımı yapıldı.");
        public void CalculateNextMaintenance() => Console.WriteLine($"{Brand} {Model} sonraki bakım: {Mileage + 15000} km.");
        public void Inspect() => Console.WriteLine($"{Brand} {Model} muayeneden geçti.");
        
    
}

}