using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using Microsoft.AspNetCore.Identity;
using BitsaFundingSystem.Areas.Identity.Data;

namespace BitsaFundingSystem.Pages.KimCoin.Users
{
    public class IndexModel : PageModel
    {
        private readonly BitsaFundingSystem.Data.BitsaFundingSystemContext _context;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;

        public IndexModel(
            UserManager<BitsaFundingSystemUser> userManager, BitsaFundingSystem.Data.BitsaFundingSystemContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<BitsaFundingSystemUser> BitsaFundingSystemUsers { get;set; }

        public async Task OnGetAsync()
        {
            BitsaFundingSystemUsers = await _userManager.Users.ToListAsync();
        }
    }
}
