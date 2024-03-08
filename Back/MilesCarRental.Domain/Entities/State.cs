using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesCarRental.Domain.Entities
{
    /// <summary>
    /// Entidad para estado
    /// </summary>
    [Table("State")]
    public class State
    {
        /// <summary>
        /// Id unico del estado
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Descripcion del estado
        /// </summary>
        public string? Description { get; set; }
    }
}
