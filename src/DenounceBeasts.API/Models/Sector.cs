namespace DenounceBeasts.API.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
