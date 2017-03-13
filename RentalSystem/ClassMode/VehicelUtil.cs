using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSystem
{
    public class VehicelUtil
    {
        public static Vehicle CreateVehicle(string licenseNO, string name, string color, int yearsOfService, double dailyRent, int load, string type)
        {
            Vehicle vehicle = null;
            switch (type)
            {
                case "car":
                    vehicle = new Car(color, dailyRent, licenseNO, name, 0, "", yearsOfService);
                    break;
                case "truck":
                    vehicle = new Truck(color, dailyRent, licenseNO, name, 0, "", yearsOfService, load);
                    break;
                default:
                    break;
            }
            return vehicle;
        }
    }
}
