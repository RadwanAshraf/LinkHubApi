

using LinkHubApi.CodeFirstMigration.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkHubApi.CodeFirstMigration.Entities
{
    public class ProfileSettings
    {
        public int Id { get; set; }
        public byte[]? ProfilePic { get; set; }
        public string Font { get; set; }
        public int Style { get; set; }
        public string Mode { get; set; }
        public string FontColor { get; set; }
        public byte[] Background { get; set; }
        public int? AvatarID { get; set; }

        User User { get; set; } 

    }
}
