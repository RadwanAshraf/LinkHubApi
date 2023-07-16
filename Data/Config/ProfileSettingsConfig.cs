using LinkHubApi.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkHubApi.CodeFirstMigration.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkHub.CodeFirstMigration.Data.Config
{
    public class ProfileSettingsConfig : IEntityTypeConfiguration<ProfileSettings>
    {
        public void Configure(EntityTypeBuilder<ProfileSettings> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FontColor)
                .HasColumnType("VARCHAR(7)")
                .HasMaxLength(7)
                .IsRequired(false);

            builder.Property(x => x.Style)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.AvatarID)
                   .HasColumnType("int")
                   .IsRequired(false);

            builder.Property(x => x.Mode)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(150).IsRequired();

            builder.Property(x => x.Background)
                 .HasColumnType("VARBINARY(MAX)")
                .IsRequired(false);

            builder.Property(x => x.Font)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(150).IsRequired();

            builder.Property(x => x.ProfilePic)
                 .HasColumnType("VARBINARY(MAX)")
                .IsRequired(false);


            builder.ToTable("ProfileSettings");
            builder.HasData(LoadProfileSettings());



        }

        private static ProfileSettings[] LoadProfileSettings() { 

            return new ProfileSettings[] {

                new ProfileSettings{ Id = 1,Font="Arial",FontColor="#521486",AvatarID=1,Mode ="Dark",},
                new ProfileSettings{ Id = 2,Font="Arial",FontColor="#521486",AvatarID=2,Mode ="Blue", },
                new ProfileSettings{ Id = 3,Font="Arial",FontColor="#521486",AvatarID=3,Mode ="White", },
                new ProfileSettings{ Id = 4,Font="Arial",FontColor="#521486",AvatarID=4,Mode ="Purple ",  },
                new ProfileSettings{ Id = 5,Font="Arial",FontColor="#521486",AvatarID=5,Mode ="Red",},
                                                                      
            };


        }
    }
}
