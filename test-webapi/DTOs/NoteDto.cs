namespace test_webapi.DTOs
{
    public class NoteDto
    {
        public int NoteID { get; set; }
        public int? CustID { get; set; }
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }
    }
}