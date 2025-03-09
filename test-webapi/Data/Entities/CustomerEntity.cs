using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_webapi.Entities
{
    public class CustomerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustID { get; set; }

        [MaxLength(50)]
        public string? CompanyName { get; set; }

        [MaxLength(50)]
        public string? ContactTitle { get; set; }

        [MaxLength(50)]
        public string? ContactFirstNames { get; set; }

        [MaxLength(50)]
        public string? ContactSurname { get; set; }

        [MaxLength(50)]
        public string? Line1 { get; set; }

        [MaxLength(50)]
        public string? Line2 { get; set; }

        [MaxLength(50)]
        public string? Line3 { get; set; }

        [MaxLength(50)]
        public string? Line4 { get; set; }

        [MaxLength(50)]
        public string? Postcode { get; set; }

        [MaxLength(50)]
        public string? Telephone { get; set; }

        [MaxLength(50)]
        public string? Fax { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        public bool? Mailshot { get; set; }
    }
}