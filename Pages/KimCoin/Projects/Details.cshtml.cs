using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using Octokit;
using System.Net;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Authorization;

namespace BitsaFundingSystem.Pages.KimCoin.Projects
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly BitsaFundingSystem.Data.BitsaFundingSystemContext _context;
        public P2PConnectionService _connectionService;

        public DetailsModel(BitsaFundingSystem.Data.BitsaFundingSystemContext context, P2PConnectionService ConnectionService)
        {
            _connectionService = ConnectionService;
            _context = context;
        }

        public Models.Project Project { get; set; }
        public Blockchain TheBlockChain { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            TheBlockChain = _connectionService.AskForBlockChain();
            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
