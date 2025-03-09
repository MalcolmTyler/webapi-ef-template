namespace test_webapi.Data
{
    using Microsoft.EntityFrameworkCore;
    using test_webapi.Entities;

    public class AppDbContext : DbContext
    {
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Summary>().HasData(
                new Summary { Id = 1, Description = "Freezing" },
                new Summary { Id = 2, Description = "Bracing" },
                new Summary { Id = 3, Description = "Chilly" },
                new Summary { Id = 4, Description = "Cool" },
                new Summary { Id = 5, Description = "Mild" },
                new Summary { Id = 6, Description = "Warm" },
                new Summary { Id = 7, Description = "Balmy" },
                new Summary { Id = 8, Description = "Hot" },
                new Summary { Id = 9, Description = "Sweltering" },
                new Summary { Id = 10, Description = "Scorching" }
            );

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { CustID = 1, CompanyName = "Company A", ContactTitle = "Mr.", ContactFirstNames = "John", ContactSurname = "Doe", Line1 = "123 Main St", Line2 = "", Line3 = "", Line4 = "", Postcode = "12345", Telephone = "123-456-7890", Fax = "123-456-7891", Email = "john.doe@companya.com", Mailshot = true },
                new CustomerEntity { CustID = 2, CompanyName = "Company B", ContactTitle = "Ms.", ContactFirstNames = "Jane", ContactSurname = "Smith", Line1 = "456 Elm St", Line2 = "", Line3 = "", Line4 = "", Postcode = "67890", Telephone = "987-654-3210", Fax = "987-654-3211", Email = "jane.smith@companyb.com", Mailshot = false },
                new CustomerEntity { CustID = 3, CompanyName = "Company C", ContactTitle = "Dr.", ContactFirstNames = "Alice", ContactSurname = "Johnson", Line1 = "789 Oak St", Line2 = "", Line3 = "", Line4 = "", Postcode = "54321", Telephone = "555-555-5555", Fax = "555-555-5556", Email = "alice.johnson@companyc.com", Mailshot = true }
            );

            modelBuilder.Entity<NoteEntity>().HasData(
                new NoteEntity { NoteID = 1, CustID = 1, Date = new DateTime(2023, 1, 1), Notes = "Dummy note 1 for customer 1" },
                new NoteEntity { NoteID = 2, CustID = 1, Date = new DateTime(2023, 1, 2), Notes = "Dummy note 2 for customer 1" },
                new NoteEntity { NoteID = 3, CustID = 2, Date = new DateTime(2023, 1, 3), Notes = "Dummy note 1 for customer 2" },
                new NoteEntity { NoteID = 4, CustID = 2, Date = new DateTime(2023, 1, 4), Notes = "Dummy note 2 for customer 2" },
                new NoteEntity { NoteID = 5, CustID = 3, Date = new DateTime(2023, 1, 5), Notes = "Dummy note 1 for customer 3" },
                new NoteEntity { NoteID = 6, CustID = 3, Date = new DateTime(2023, 1, 6), Notes = "Dummy note 2 for customer 3" }
            );
        }
    }
}