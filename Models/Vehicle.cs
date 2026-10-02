using System;
using System.Collections.Generic;
using System.Text;

namespace FleetGuard.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        
        public string Model { get; set; }
     
        public bool IsActive { get; set; }

        private double mileage;

        // Encapsulation: Negatif kilometre atanamaz
        public double Mileage
        {
            get { return mileage; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Mileage (Kilometre) negatif olamaz!"); 
            mileage = value;
            }
        }

        public string VehicleStatus
        {
            get
            {
                if (Mileage > 100000) return "Yüksek kilometre";
            if (Mileage > 50000) return "Bakım kontrolü önerilir"; 
            return "Normal"; 
        }
        }

        public Vehicle(int id, string brand, string model)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Mileage = 0;
            IsActive = true;
        }
        public Vehicle(int id, string brand, string model, double mileage, bool isActive)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Mileage = mileage; 
            IsActive = isActive;

        }

        public virtual double CalculateServiceCost()
        {
            return 0; // Temel sınıfta varsayılan maliyet sıfır
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Brand} {Model} (ID: {Id}) - Kilometre: {Mileage} - Aktif: {IsActive}");
        }

    }
}
