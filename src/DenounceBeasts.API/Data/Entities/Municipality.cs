using DenounceBeasts.API.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Models
{
     [Table("Municipality")]
    public class Municipality
    {
        [Key]
        //[Column("MUNICIPALITY_ID")]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
       
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public List<Sector> Sectors { get; set; }
    }
}
