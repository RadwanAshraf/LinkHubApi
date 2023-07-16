namespace LinkHubApi.Entities.ViewModel
{
    public class UserDto
    {

        // Loging Info
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // Basic Info
        public string? About { get; set; }
        public DateTime? Birthday { get; set; }
        public string JobTitle { get; set; } = null!;
        public bool Gender { get; set; } = false;
        public string Location { get; set; } = null!;

        public string ProfileLink { get; set; } = null!;

        public int AccountSettingsID { get; set; }

        private string password = null!;

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }
    }
}
