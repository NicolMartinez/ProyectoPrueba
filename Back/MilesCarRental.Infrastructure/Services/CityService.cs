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
    public class CityService
    {
        private static Repository<City> _repository;

        public CityService(IDbConnection connection)
        {
            _repository = new Repository<City>(connection);
        }

        public bool Add(City product)
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

        public List<City> GetAll()
        {
            List<City> Citys = new();
            try
            {
                Citys = _repository.GetAll().ToList();
            }
            catch 
            {
            }

            return Citys;
        }

        public City Get(long Id)
        {
            City product = new();
            try
            {
                product = _repository.GetById(Id);
            }
            catch
            {
            }

            return product;
        }

        public bool Update(City product)
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

        public bool Delete(City product)
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
