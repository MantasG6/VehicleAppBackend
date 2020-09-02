using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class VehicleData
    {
        public VehicleData(double latitude, double longitude, int speed, int vehicleNumber)
        {
            Latitude = latitude;
            Longitude = longitude;
            Speed = speed;
            VehicleNumber = vehicleNumber;
        }
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get;set; }
        [ForeignKey("VehicleFK")]
        public int VehicleNumber { get; set; }
    }
}
