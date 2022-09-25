using Learning.AspNetCore.WebApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.AspNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PagesController : ControllerBase
    {
        private SiteContext _siteContext;

        public PagesController(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        [HttpGet("{pageName}")]
        public async Task<IActionResult> Get([FromRoute] string pageName, CancellationToken token = default)
        {
            var page = await _siteContext.Pages.FindAsync(pageName);
            if (page == null)
            {
                return this.NotFound();
            }
            return this.Ok(page);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token = default)
        {
            throw new ArgumentException("fjdskfjasdkl");
            var pages = await _siteContext.Pages
                .OrderBy(a => a.DisplayName)
                .Select(a => new { a.Name, a.DisplayName })
                .ToListAsync();
            return this.Ok(pages);
        }
    }
}
