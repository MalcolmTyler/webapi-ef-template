namespace test_webapi.DTOs
{
    public class CustomerDto
    {
        public int CustID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactTitle { get; set; }
        public string? ContactFirstNames { get; set; }
        public string? ContactSurname { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? Line4 { get; set; }
        public string? Postcode { get; set; }
        public string? Telephone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public bool? Mailshot { get; set; }
    }
}