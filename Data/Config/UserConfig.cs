using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.CodeFirstMigration.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkHub.CodeFirstMigration.Data.Config
{
     public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasAnnotation("RegularExpression", @"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .HasAnnotation("Description", "Email address of the user");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasAnnotation("Description", "Password of the user");

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.JobTitle)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Location)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Birthday)
                .HasColumnType("date");

            builder.Property(u => u.Gender)
                .HasDefaultValue(false)
                .HasAnnotation("Description", 
                "Gender of the user: true for male, false for female");


            builder.ToTable("User");
            builder.HasData(LoadUser());
        }
              
  
        private static User[] LoadUser()
        {
            return new User[] {

                new User
        {

             Id=1,
            FName = "John",
            LName = "Doe",
            UserName = "jdoe",
            Email = "jdoe@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Software Engineer",
            Location = "New York City",
            Birthday = new DateTime(1990, 1, 1),
            Gender = true,
        },
                new User
        {

                    Id=2,
            FName = "Jane",
            LName = "Doe",
            UserName = "jane.doe",
            Email = "jane.doe@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Product Manager",
            Location = "San Francisco",
            Birthday = new DateTime(1985, 5, 1),
            Gender = false,
            SocialLinks = new List<SocialLink>
            {
                
            }
        },
                new User
        {

                    Id=3,
            FName = "John",
            LName = "Doe",
            UserName = "jdoe",
            Email = "jdoe@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Software Engineer",
            Location = "New York City",
            Birthday = new DateTime(1990, 1, 1),
            Gender = true,
         
        },
                new User
        {

                    Id=4,
            FName = "Jane",
            LName = "Doe",
            UserName = "janedoe",
            Email = "janedoe@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Product Manager",
            Location = "San Francisco",
            Birthday = new DateTime(1985, 5, 1),
            Gender = false,
           
        },
                new User
        {

                    Id=5,
            FName = "Mark",
            LName = "Johnson",
            UserName = "markjohnson",
            Email = "markjohnson@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Marketing Manager",
            Location = "Chicago",
            Birthday = new DateTime(1983, 10, 15),
            Gender = true,
           
        },
                new User
        {

                    Id=6,
            FName = "Emily",
            LName = "Chen",
            UserName = "emilychen",
            Email = "emilychen@example.com",
            Password = "P@ssw0rd",
            Phone = "555-555-5555",
            JobTitle = "Sales Representative",
            Location = "Los Angeles",
            Birthday = new DateTime(1992, 2, 28),
            Gender = false,
          
        },

          };

        }
    }
}
