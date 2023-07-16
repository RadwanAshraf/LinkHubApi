using LinkHubApi.CodeFirstMigration.Data;
using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Entities.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LinkHubApi.Services
{
    public class SocialLinkService : ISocialLinkService
    {
        private readonly AppDbContext _context;
        public SocialLinkService(AppDbContext appContext) {

            _context = appContext;
        }
        public async Task<List<SocialLink>?> GetLinksAsync()
        {   
            List<SocialLink> socialLinks = await _context.SocialLinks.ToListAsync();
            if (socialLinks == null)
                return null;

            return socialLinks;
        }
        public async Task<List<SocialLink>?> GetSocialLinksByUserId(int id)
        {

            var socialLinks = await _context.SocialLinks.ToListAsync();
            var userLinks = socialLinks.FindAll(x => x.UserId == id);
            
            if (userLinks != null)
            {
                return userLinks;
            }

            return null;
        }
        public async Task<SocialLink?> GetSocialLink(int id)
        {

            var socialLinks = await _context.SocialLinks.FindAsync(id);
            
            if (socialLinks == null)
            {
                return null;
            }

             return socialLinks;
        }
        public async Task<SocialLink>? AddSocialLinkAsync(SocialLink socialLink)
        {
            if (SocialLinkExists(socialLink.Id))
            {
                return null;
            }
            else
            {
                _context.SocialLinks.Add(socialLink);
                Console.WriteLine(socialLink.ToString());
                await _context.SaveChangesAsync();
            }
            return socialLink;

        }
        public async Task<SocialLink>? UpdateSocialLinkAsync(int id, SocialLink socialLink)
        {
            var linkExist = SocialLinkExists(id);
            if (!linkExist)
            {
                Console.WriteLine("ERROR : the you try to Update is not Exist");
                return null;
            }
            _context.SocialLinks.Update(socialLink);
            await _context.SaveChangesAsync();
            return socialLink;
        }
        public SocialLink? DeleteSocialLink(int id)
        {
            var socialLink = _context.SocialLinks.Find(id);
            if (socialLink is null)
            {
                return null;
            }
            _context.SocialLinks.Remove(socialLink);
            _context.SaveChanges();
            return socialLink;
        }
        public bool SocialLinkExists(int id)
        {
            return (_context.SocialLinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    } 
}
