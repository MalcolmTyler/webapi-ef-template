using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_webapi.Data.Entities
{
    [Table("AllPlant")]
    public class AllPlantEntity
    {
        [Key]
        public int PlantNameID { get; set; }

        public int? PlantCategory { get; set; }

        [MaxLength(50)]
        public string? PlantDescription { get; set; }

        [MaxLength(50)]
        public string? NormalPrice { get; set; }

        // Navigation property
        [ForeignKey("PlantCategory")]
        public virtual PlantCategoryEntity? Category { get; set; }
    }
}