using System.ComponentModel;
using Learning.AspNetCore.WebApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.AspNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SetupController : ControllerBase
    {
        private SiteContext _siteContext;

        public SetupController(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token = default)
        {
            await _siteContext.Database.EnsureCreatedAsync();

            var displayNameSetting = await _siteContext.Settings.FindAsync("DisplayName");

            var menu = await _siteContext.Menu
                .Where(a => a.Id != 0)
                .OrderBy(a => a.Order)
                .ToListAsync();

            return this.Ok(new 
            {
                DisplayName = displayNameSetting?.Value ?? "Unspecified",
                Menu = menu,
            });
        }
    }
}
