
namespace DenounceBeasts.API.Models.Dtos
{
    public class MunicipalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        //public List<SectorDto> Sectors { get; internal set; }
    }
}
