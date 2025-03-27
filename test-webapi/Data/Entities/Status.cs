using System.ComponentModel.DataAnnotations;

namespace test_webapi.Data.Entities
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusDescription { get; set; } = string.Empty;

        // Navigation property
        public virtual ICollection<PlantHolding> PlantHoldings { get; set; } = new List<PlantHolding>();
    }
}