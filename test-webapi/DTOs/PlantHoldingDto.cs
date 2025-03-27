namespace test_webapi.DTOs
{
    public class PlantHoldingDto
    {
        public int HoldingID { get; set; }
        public int? CustID { get; set; }
        public int? PlantNameID { get; set; }
        public string? SerialNumber { get; set; }
        public int? StatusID { get; set; }
        public string? SWL { get; set; }
        public string? PlantDescription { get; set; }
        public string? StatusDescription { get; set; }
    }
}