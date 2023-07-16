using LinkHubApi.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkHubApi.CodeFirstMigration.Enums;

namespace LinkHub.CodeFirstMigration.Data.Config
{
    public class SocialLinkConfig : IEntityTypeConfiguration<SocialLink>
    {
        public void Configure(EntityTypeBuilder<SocialLink> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(sl => sl.Title)
                .IsRequired();

            builder.Property(sl => sl.LinkUrl)
                .HasMaxLength(256);

            builder.Property(sl => sl.IconUrl)
                .HasMaxLength(256);

            builder.Property(sl => sl.IsActive)
                .HasDefaultValue(true);



            builder.ToTable("SocialLink");
           builder.HasData(LoadLink());
            
        }

        private static SocialLink[] LoadLink()
        {

            return new SocialLink[] {


               new SocialLink
                {
                    Id=1,
                    UserId=1,
                    Title = SocialLinksEnum.Facebook,
                    LinkUrl = "https://www.facebook.com/johndoe",
                    IconUrl = "https://www.facebook.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {
                    Id=2,
                    UserId=1,
                    Title = SocialLinksEnum.Twitter,
                    LinkUrl = "https://twitter.com/johndoe",
                    IconUrl = "https://twitter.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {
                    Id=3,
                    UserId = 1,
                    Title = SocialLinksEnum.LinkedIn,
                    LinkUrl = "https://www.linkedin.com/in/johndoe",
                    IconUrl = "https://www.linkedin.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {
                    Id=4,
                    UserId = 2,
                    Title = SocialLinksEnum.Facebook,
                    LinkUrl = "https://www.facebook.com/janedoe",
                    IconUrl = "https://www.facebook.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {
                    Id=5,
                    UserId=2,
                    Title = SocialLinksEnum.Twitter,
                    LinkUrl = "https://twitter.com/janedoe",
                    IconUrl = "https://twitter.com/favicon.ico",
                    IsActive = false
                },
                new SocialLink
                {   Id = 6,
                    UserId=3,
                    Title = SocialLinksEnum.LinkedIn,
                    LinkUrl = "https://www.linkedin.com/in/janedoe",
                    IconUrl = "https://www.linkedin.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {
                    Id=7,
                    UserId=3,
                    Title = SocialLinksEnum.Facebook,
                    LinkUrl = "https://www.facebook.com/johndoe",
                    IconUrl = "https://www.facebook.com/favicon.ico",
                    IsActive = true
                },
                new SocialLink
                {   Id =8,
                    UserId=3,
                    Title = SocialLinksEnum.Twitter,
                    LinkUrl = "https://twitter.com/johndoe",
                    IconUrl = "https://twitter.com/favicon.ico",
                    IsActive = true
                }, 
            
            
            };

        }
    }
    }
