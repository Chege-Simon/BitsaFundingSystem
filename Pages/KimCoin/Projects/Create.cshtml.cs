using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using Microsoft.AspNetCore.Identity;
using BitsaFundingSystem.Areas.Identity.Data;
using System.Text;
using System.Security.Cryptography;

namespace BitsaFundingSystem.Pages.KimCoin.Projects
{
    public class CreateModel : PageModel
    {
        private readonly BitsaFundingSystemContext _context;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;

        public CreateModel(
            UserManager<BitsaFundingSystemUser> userManager, BitsaFundingSystemContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            Project.OwnerId = user.Id.ToString();
            Project.Created_At = DateTime.Now;
            Project.Updated_At = DateTime.Now;

            var sha256 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes($"{Project.OwnerId}-{Project.Created_At}");
            var outputBytes = sha256.ComputeHash(inputBytes);
            string result = Convert.ToBase64String(outputBytes);
            Project.WalletId = result;
            Project.Balance = 0;
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./MyProjects");
        }
    }
}
