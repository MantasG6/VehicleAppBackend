using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Cors;

namespace Backend.Controllers
{
    [EnableCors("AllowOriginsPolicy")]
    [Route("VehicleData")]
    [ApiController]
    public class VehicleDatasController : ControllerBase
    {
        private readonly VehicleDataContext _context;

        public VehicleDatasController(VehicleDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: new VehicleData from system
        /// </summary>
        /// <param name="id">id of the vehicle</param>
        /// <returns></returns>
        [HttpGet("new/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleData>>> GetNewVehicleDatas(int id)
        {
            VehicleData newVehicleData = GenerateVehicleData(id);
            _context.Add(newVehicleData);
            _context.SaveChanges();
            return await GetVehicleDatas(id);
        }

        /// <summary>
        /// GET: all VehicleData of a specific vehicle from database
        /// </summary>
        /// <param name="id">id of the vehicle</param>
        /// <returns></returns>
        [HttpGet("Vehicle/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleData>>> GetVehicleDatas(int id)
        {
            var filteredData = _context.VehicleDatas.Where(x => x.VehicleNumber == id);
            return await filteredData.ToListAsync();
        }

        // GET: VehicleData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleData>> GetVehicleData(int id)
        {
            var vehicleData = await _context.VehicleDatas.FindAsync(id);

            if (vehicleData == null)
            {
                return NotFound();
            }

            return vehicleData;
        }

        private bool VehicleDataExists(int id)
        {
            return _context.VehicleDatas.Any(e => e.Id == id);
        }
        /// <summary>
        /// generates random vehicleData (imitation of data push from devices)
        /// </summary>
        /// <param name="VehicleNumber">id of the vehicle</param>
        /// <returns></returns>
        private VehicleData GenerateVehicleData(int VehicleNumber)
        {
            VehicleData newVehicleData;
            Random random = new Random();

            double newLatitude = random.NextDouble() * 100;
            double newLongitude = random.NextDouble() * 100;
            int newSpeed = random.Next(0, 200);
            int newVehicleNumber = VehicleNumber;
            newLatitude = Math.Round(newLatitude, 6);
            newLongitude = Math.Round(newLongitude, 6);
            newVehicleData = new VehicleData(newLatitude, newLongitude, newSpeed, newVehicleNumber);
            return newVehicleData;
        }
    }
}
