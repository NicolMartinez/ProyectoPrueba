using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MilesCarRental.Domain.Entities
{
    /// <summary>
    /// Entidad para vehiculos
    /// </summary>
    [Table("Vehicle")]
    public class Vehicle
    {
        /// <summary>
        /// Id del vehiculo
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Placa del vehiculo
        /// </summary>
        public string? Plate { get; set; }

        /// <summary>
        /// Numero unico de registro del vehiculo
        /// </summary>
        public string? VIN { get; set; }

        /// <summary>
        /// Marca del vehiculo
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Modelo del vehiculo
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Precio de renta
        /// </summary>
        public double RentalPrice { get; set; }

        /// <summary>
        /// Id de la ciudad de ubicacion
        /// </summary>
        public double IdCity { get; set; }

        /// <summary>
        /// Id de la ciudad de ubicacion
        /// </summary>
        public double IdState { get; set; }
    }
}
