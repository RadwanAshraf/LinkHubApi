using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Entities.ViewModel;

namespace LinkHubApi.Services
{
    public interface ISocialLinkService
    {
        Task<List<SocialLink>?> GetLinksAsync();
        Task<List<SocialLink>?> GetSocialLinksByUserId(int id);
        Task<SocialLink?> GetSocialLink(int id);
        Task<SocialLink>? AddSocialLinkAsync(SocialLink socialLink);
        Task<SocialLink>? UpdateSocialLinkAsync(int id, SocialLink socialLink);
        SocialLink? DeleteSocialLink(int id);
        bool SocialLinkExists(int id);

    }
}
