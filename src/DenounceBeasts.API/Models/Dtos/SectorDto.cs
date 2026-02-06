namespace DenounceBeasts.API.Models.Dtos
{
    public class SectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true; 
        public int MunicipalityId { get; set; }
    }
}
