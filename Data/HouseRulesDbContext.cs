using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Data;
public class HouseRulesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Chore> Chores { get; set; }
    public DbSet<ChoreAssignment> ChoreAssignments { get; set; }
    public DbSet<ChoreCompletion> ChoreCompletions { get; set; }

    public HouseRulesDbContext(DbContextOptions<HouseRulesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser {Id = "8b84b12a-0727-41dc-82e3-f44f1f038541", UserName = "jdfitz", Email = "jdfitz@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "9cb98efe-c05e-4992-9827-bb3f9f0d68ea", UserName = "jbarton", Email = "jbarton@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "e8fd99fa-a22c-412c-b45c-703c85ab4585", UserName = "greg", Email = "greg@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])}
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 2, IdentityUserId = "8b84b12a-0727-41dc-82e3-f44f1f038541", FirstName = "JD", LastName = "Fitzmartin", Address = "834 Road St"},
            new UserProfile {Id = 3, IdentityUserId = "9cb98efe-c05e-4992-9827-bb3f9f0d68ea", FirstName = "Josh", LastName = "Barton", Address = "421 High Way"},
            new UserProfile {Id = 4, IdentityUserId = "e8fd99fa-a22c-412c-b45c-703c85ab4585", FirstName = "Greg", LastName = "Korte", Address = "5253 Vista St"}
        });

        modelBuilder.Entity<Chore>().HasData(new Chore[]
        {
            new Chore {Id = 1, Name = "Vacuuming", Difficulty = 2, ChoreFrequencyDays = 5},
            new Chore {Id = 2, Name = "Mow the Lawn", Difficulty = 4, ChoreFrequencyDays = 7},
            new Chore {Id = 3, Name = "Clean Litterboxes", Difficulty = 3, ChoreFrequencyDays = 2},
            new Chore {Id = 4, Name = "Dishes", Difficulty = 3, ChoreFrequencyDays = 2},
            new Chore {Id = 5, Name = "Take Out Trash", Difficulty = 3, ChoreFrequencyDays = 4}
        });

        modelBuilder.Entity<ChoreAssignment>().HasData(new ChoreAssignment[]
        {
            new ChoreAssignment {Id = 1, ChoreId = 3, UserProfileId = 1},
            new ChoreAssignment {Id = 2, ChoreId = 5, UserProfileId = 3},
            new ChoreAssignment {Id = 3, ChoreId = 2, UserProfileId = 4},
            new ChoreAssignment {Id = 4, ChoreId = 4, UserProfileId = 2},
            new ChoreAssignment {Id = 5, ChoreId = 1, UserProfileId = 1},
            new ChoreAssignment {Id = 6, ChoreId = 3, UserProfileId = 2},
            new ChoreAssignment {Id = 7, ChoreId = 5, UserProfileId = 1},
            new ChoreAssignment {Id = 8, ChoreId = 4, UserProfileId = 4},
            new ChoreAssignment {Id = 9, ChoreId = 1, UserProfileId = 3}
        });

        modelBuilder.Entity<ChoreCompletion>().HasData(new ChoreCompletion[]
        {
            new ChoreCompletion {Id = 1, ChoreId = 3, UserProfileId = 4, CompletedOn = new DateTime(2023, 9, 10)},
            new ChoreCompletion {Id = 2, ChoreId = 1, UserProfileId = 1, CompletedOn = new DateTime(2023, 9, 11)},
            new ChoreCompletion {Id = 3, ChoreId = 4, UserProfileId = 2, CompletedOn = new DateTime(2023, 9, 14)},
            new ChoreCompletion {Id = 4, ChoreId = 2, UserProfileId = 3, CompletedOn = new DateTime(2023, 9, 15)},
            new ChoreCompletion {Id = 5, ChoreId = 5, UserProfileId = 2, CompletedOn = new DateTime(2023, 9, 16)},
            new ChoreCompletion {Id = 6, ChoreId = 3, UserProfileId = 4, CompletedOn = new DateTime(2023, 9, 16)},
            new ChoreCompletion {Id = 7, ChoreId = 4, UserProfileId = 1, CompletedOn = new DateTime(2023, 9, 17)},
            new ChoreCompletion {Id = 8, ChoreId = 1, UserProfileId = 3, CompletedOn = new DateTime(2023, 9, 20)},
            new ChoreCompletion {Id = 9, ChoreId = 2, UserProfileId = 1, CompletedOn = new DateTime(2023, 9, 21)}
        });
    }
}