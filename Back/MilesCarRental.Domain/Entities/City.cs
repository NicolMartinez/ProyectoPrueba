using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesCarRental.Domain.Entities
{
    /// <summary>
    /// Entidad para ciudades
    /// </summary>
    [Table("City")]
    public class City
    {
        /// <summary>
        /// Id de la ciudad
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Coordenadas de la ubicacion
        /// </summary>
        public string? Coordinates { get; set; }

    }
}
