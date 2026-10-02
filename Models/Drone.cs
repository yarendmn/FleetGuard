using FleetGuard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace FleetGuard.Models
{
    public class Drone : Vehicle, IInspectable, IReportable
{
    public int BatteryCycle { get; set; } // Drone'a özel özellik

    public Drone(int id, string brand, string model) : base(id, brand, model)
    {
        
    }

    // Override ile Drone'a özel hesap 
    public override double CalculateServiceCost()
    {
        return BatteryCycle * 10.5; 
    }

    public void Inspect() => Console.WriteLine($"{Brand} {Model} sensör testi başarılı.");
    public void GenerateReport() => Console.WriteLine($"{Brand} {Model} uçuş logları raporlandı.");
}
}
