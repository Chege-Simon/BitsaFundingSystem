using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using BitsaFundingSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BitsaFundingSystem.Pages.KimCoin.Projects
{
    public class IndexModel : PageModel
    {
        private readonly BitsaFundingSystem.Data.BitsaFundingSystemContext _context;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        public BitsaFundingSystemUser TheUser { get; set; }

        public IndexModel(
            UserManager<BitsaFundingSystemUser> userManager, BitsaFundingSystem.Data.BitsaFundingSystemContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Project> Project { get;set; }
        public async Task<ActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Project = await _context.Projects.ToListAsync();
            TheUser = user;
            return Page();
        }
    }
}
