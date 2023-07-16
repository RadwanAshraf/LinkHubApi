using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkHubApi.CodeFirstMigration.Data;
using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Services;
using System.Text.Json;

namespace LinkHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private readonly ISocialLinkService _socialLinkService;

        public SocialLinksController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }

        // GET: api/SocialLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialLink>>> GetSocialLinks()
        {
          var Response = await _socialLinkService.GetLinksAsync();
          if (Response == null)
          {
              return NotFound();
          }
            return Response;
        }

        // GET: api/SocialLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocialLink>> GetSocialLink(int id)
        {
            var socialLink = JsonSerializer.Serialize(
                await _socialLinkService.GetSocialLinksByUserId(id));
            if (socialLink == null)
            {
                return NotFound();
            }

            return Ok(socialLink);
        }

        [HttpGet("user/{UserId}")]
        public async Task<ActionResult<SocialLink>> GetSocialLinkByUserId(int UserId)
        {
            var socialLink = JsonSerializer.Serialize(
                await _socialLinkService.GetSocialLinksByUserId(UserId));
            if (socialLink == null)
            {
                return NotFound();
            }

            return Ok(socialLink);
        }


        // PUT: api/SocialLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialLink(int id, SocialLink socialLink)
        {
            if (id != socialLink.Id)
            {
                return BadRequest();
            }

            //_context.Entry(socialLink).State = EntityState.Modified;

            return NoContent();
        }

        // POST: api/SocialLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SocialLink>> PostSocialLink(SocialLink socialLink)
        {
          if (_socialLinkService.SocialLinkExists(socialLink.Id))
          {
              return Problem("Entity set 'SocialLinks'  is Exits.");
          }
            socialLink = await _socialLinkService.AddSocialLinkAsync(socialLink);
           
            return CreatedAtAction("GetSocialLink", new { id = socialLink.Id }, socialLink);
        }

        // DELETE: api/SocialLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialLink(int id)
        {
            if (!_socialLinkService.SocialLinkExists(id))
            {
                return NotFound("This Social Link is Not Exist...");
            }
            var socialLink = _socialLinkService.DeleteSocialLink(id);

            if (socialLink == null)
            {
                return NotFound("Error While Deleting your Link... ");
            }
           
            return Ok();
        }

        private bool SocialLinkExists(int id)
        {
            return _socialLinkService.SocialLinkExists(id);
        }
    }
}
