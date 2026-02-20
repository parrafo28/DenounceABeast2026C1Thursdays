
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Models.Dtos
{
    public class MunicipalityCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
