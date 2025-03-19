namespace test_webapi.Data
{
    using System.Globalization;
    using System.Security.Cryptography;
    using Microsoft.EntityFrameworkCore;
    using test_webapi.Entities;

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Seed data for Summaries
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

    // Seed data for Customers and Notes with static values
    var customers = new List<CustomerEntity>();
    var notes = new List<NoteEntity>();

    for (int i = 1; i <= 100; i++)
    {
        char letter = (char)((i % 26) + 65); // Generate a static letter based on the index
        customers.Add(new CustomerEntity
        {
            CustID = i,
            CompanyName = $"Company {letter}",
            ContactTitle = "Mr.",
            ContactFirstNames = "John",
            ContactSurname = "Doe",
            Line1 = "123 Main St",
            Line2 = "",
            Line3 = "",
            Line4 = "",
            Postcode = "12345",
            Telephone = "123-456-7890",
            Fax = "123-456-7891",
            Email = "john.doe@companya.com",
            Mailshot = true
        });

        notes.Add(new NoteEntity
        {
            NoteID = i,
            CustID = i,
            Date = new DateTime(2023, 1, 1),
            Notes = $"Dummy note 1 for customer {i}"
        });
        notes.Add(new NoteEntity
        {
            NoteID = i + 100,
            CustID = i,
            Date = new DateTime(2023, 1, 2),
            Notes = $"Dummy note 2 for customer {i}"
        });
    }

    modelBuilder.Entity<CustomerEntity>().HasData(customers);
    modelBuilder.Entity<NoteEntity>().HasData(notes);
}
    
    
    
    }
}