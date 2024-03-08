using Microsoft.Extensions.Configuration;
using MilesCarRental.Application.Interfaces;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Repository.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure.Services
{
    public class VehicleService
    {
        private static Repository<Vehicle> _repository;

        public VehicleService(IDbConnection connection)
        {
            _repository = new Repository<Vehicle>(connection);
        }

        public bool Add(Vehicle product)
        {
            bool isAdded = false;
            try
            {;
                isAdded = _repository.Add(product);
            }
            catch
            {
            }
            return isAdded;
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new();
            try
            {
                vehicles = _repository.GetAll().ToList();
            }
            catch 
            {
            }

            return vehicles;
        }

        public List<Vehicle> GetAllByCity(long idCity)
        {
            List<Vehicle> vehicles = new();
            try
            {
                vehicles = _repository.GetAllByCity(idCity).ToList();
            }
            catch
            {
            }

            return vehicles;
        }

        public Vehicle Get(long Id)
        {
            Vehicle product = new();
            try
            {
                product = _repository.GetById(Id);
            }
            catch
            {
            }

            return product;
        }

        public bool Update(Vehicle product)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = _repository.Update(product);
            }
            catch
            {
            }

            return isUpdated;
        }

        public bool Delete(Vehicle product)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = _repository.Delete(product);
            }
            catch
            {
            }
            return isDeleted;
        }
    }
}
