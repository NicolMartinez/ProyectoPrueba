using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Infrastructure.Services;
using System.Data;

namespace MilesCarRental.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly IDbConnection _dbConnection;

        public CityController(ILogger<CityController> logger, IDbConnection connection)
        {
            _logger = logger;
            _dbConnection = connection;
        }

        [HttpGet()]
        public List<City> Get()
        {
            CityService service = new CityService(_dbConnection);
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public City Get(long id)
        {
            CityService service = new CityService(_dbConnection);
            return service.Get(id);
        }

        [HttpPost()]
        public bool Post(City City)
        {
            CityService service = new CityService(_dbConnection);
            return service.Add(City);
        }

        [HttpPut()]
        public bool Put(City City)
        {
            CityService service = new CityService(_dbConnection);
            return service.Update(City);
        }

        [HttpDelete()]
        public bool Delete(City City)
        {
            CityService service = new CityService(_dbConnection);
            return service.Delete(City);
        }
    }
}
