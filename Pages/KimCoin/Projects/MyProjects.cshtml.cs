using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsaFundingSystem.Areas.Identity.Data;
using BitsaFundingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BitsaFundingSystem.Pages.KimCoin.Projects
{
    public class MyProjectsModel : PageModel
    {
        private readonly BitsaFundingSystem.Data.BitsaFundingSystemContext _context;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        public BitsaFundingSystemUser TheUser { get; set; }
        public MyProjectsModel(
            UserManager<BitsaFundingSystemUser> userManager, 
            BitsaFundingSystem.Data.BitsaFundingSystemContext context
            )
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public List<Project> Project { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            TheUser = user;

            Project = await _context.Projects.Where(p => p.OwnerId == user.Id.ToString()).ToListAsync();

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
