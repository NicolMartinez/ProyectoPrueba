using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Application.Interfaces;
using MilesCarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure
{
    public class InfrastructureDI
    {
        public static ServiceCollection ConfigureServices()
        {
            ServiceCollection service = new();

            service.AddScoped<IConfiguration, IConfiguration>();

            return service;
        }
    }
}
