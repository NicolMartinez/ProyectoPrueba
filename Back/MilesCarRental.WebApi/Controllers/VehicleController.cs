using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Infrastructure.Services;
using System.Data;

namespace MilesCarRental.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IDbConnection _dbConnection;

        public VehicleController(ILogger<VehicleController> logger, IDbConnection connection)
        {
            _logger = logger;
            _dbConnection = connection;
        }

        [HttpGet()]
        public List<Vehicle> Get()
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Vehicle Get(long id)
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.Get(id);
        }

        [HttpGet("GetByCity/{idCity}")]
        public List<Vehicle> GetByCity(long idCity)
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.GetAllByCity(idCity);
        }

        [HttpPost()]
        public bool Post(Vehicle vehicle)
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.Add(vehicle);
        }

        [HttpPut()]
        public bool Put(Vehicle vehicle)
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.Update(vehicle);
        }

        [HttpDelete()]
        public bool Delete(Vehicle vehicle)
        {
            VehicleService service = new VehicleService(_dbConnection);
            return service.Delete(vehicle);
        }
    }
}
