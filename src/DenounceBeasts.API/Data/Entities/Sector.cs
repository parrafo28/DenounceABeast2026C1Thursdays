using DenounceBeasts.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Data.Entities
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        //[Range(1,100)]
        public int MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }
    }
}
