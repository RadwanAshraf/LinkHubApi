

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LinkHubApi.CodeFirstMigration.Entities
{
    
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        // Loging Info
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; } = null!; 
        public string Phone { get; set; } = null!;

        // Basic Info
        public string? About { get; set; }
        public DateTime? Birthday { get; set; }
        public string JobTitle { get; set; } = null!;
        public bool Gender { get; set; } = false;
        public string Location { get; set; } = null!;


        public int AccountSettingsID { get; set; }
        [JsonIgnore]
        public ProfileSettings? ProfileSettings { get; set; } = null!;
        [JsonIgnore]
        public ICollection<SocialLink>? SocialLinks { get; set; } = new List<SocialLink>();


        public override string ToString()
        {
            return $"ID:{Id}+" + $"\n" +
                $"FName:{FName}" + $"\n" +
                $"LName:{LName}" + $"\n" +
                $"UserName:{UserName}" + $"\n" +
                $"Email:{Email}" + $"\n" + 
                $"Password:{Password}" + $"\n" +
                $"Phone:{Phone}" + $"\n" + 
                $"About:{About}" + $"\n" +
                $"Birthday:{Birthday}" + $"\n" + 
                $"JobTitle:{JobTitle}" + $"\n" +
                $"Gender:{Gender}" + $"\n"+
                $"Location:{Location}" + $"\n" +
                $"AccountSettingsID:{AccountSettingsID}"+$"\n";
        }
    }
}
