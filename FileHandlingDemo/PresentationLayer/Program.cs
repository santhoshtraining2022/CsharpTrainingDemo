using System;
using DataProvider;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = new car();

            VehicleDataProvide vehicleData = new VehicleDataProvide(vehicle);
             vehicle = new Bus();

             vehicleData = new VehicleDataProvide(vehicle);

        }
    }

    class VehicleDataProvide

    {

       public VehicleDataProvide(IVehicle vehicle)
        {

            Console.WriteLine("Dataprovider of the class"+ vehicle.GetType());
        }

    }

}
