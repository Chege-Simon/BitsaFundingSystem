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

namespace BitsaFundingSystem.Pages.KimCoin.Users
{
    public class DetailsModel : PageModel
    {
        private readonly BitsaFundingSystem.Data.BitsaFundingSystemContext _context;

        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        public DetailsModel(
            UserManager<BitsaFundingSystemUser> userManager, BitsaFundingSystem.Data.BitsaFundingSystemContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public BitsaFundingSystemUser BitsaFundingSystemUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            { 
                return NotFound();
            }

            //var user = await _userManager.GetUserAsync(id);
            var user = await _userManager.FindByEmailAsync(email);
            BitsaFundingSystemUser = user;
            //Project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);

            if (BitsaFundingSystemUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
