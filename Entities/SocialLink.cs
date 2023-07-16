using LinkHubApi.CodeFirstMigration.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkHubApi.CodeFirstMigration.Entities
{
    public class SocialLink
    {
        [JsonIgnore]
        public int Id { get; set; } 
        public SocialLinksEnum Title { get; set; }
        public string? LinkUrl { get; set; }
        public string? IconUrl { get; set; }
        public bool ? IsActive { get; set; }

        public int UserId { get; set; }

    }
}
