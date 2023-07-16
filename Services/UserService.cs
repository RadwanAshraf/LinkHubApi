using LinkHubApi.CodeFirstMigration.Data;
using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Entities.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LinkHubApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext appContext) {

            _context = appContext;
        }
        public async Task<List<UserDto>?> GetUsersAsync()
        {   
            List<User> users = await _context.Users.ToListAsync();
            if (users == null)
                return null;
            List<UserDto> userDto = users.Select(x => new UserDto
            {
                UserName = x.UserName,
                Email = x.Email,
                LName = x.LName,
                FName = x.FName,
                Phone = x.Phone,
                Birthday = x.Birthday,
                About = x.About,
                Gender = x.Gender,
                JobTitle = x.JobTitle,
                Location = x.Location,
                AccountSettingsID = x.AccountSettingsID,

            }).ToList();

            return userDto;
        }
        public async Task<User?> GetUserById(int id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return user;
            }

            return null;
        }
        public async Task<User?> AddUserAsync(User NewUser)
        {
            if (UserExists(NewUser.UserName))
            {
                return null;
            }
            else
            {
                NewUser.ProfileSettings = null;
                NewUser.SocialLinks = null;
                _context.Users.Add(NewUser);
                Console.WriteLine(NewUser.ToString());
                await _context.SaveChangesAsync();
            }
            return NewUser;

        }
        public async Task<User?> UpdateUserAsync(int id, User NewUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                Console.WriteLine("ERROR : Updata User Data FAILED");
                return null;
            }

            NewUser.Id = id;
            NewUser.ProfileSettings = user.ProfileSettings;
            NewUser.Email = user.Email;
            NewUser.Password=user.Password;
            
            _context.Users.Update(NewUser);
            await _context.SaveChangesAsync();
            
            return user;

        }
        public User? DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null)
            {
                return null;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
        public bool UserExists(string userName)
        {
            return (_context.Users?.Any(e => e.UserName == userName)).GetValueOrDefault();
        }

    } 
}
