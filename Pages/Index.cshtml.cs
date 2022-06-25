using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsaFundingSystem.Pages
{
    public class IndexModel : PageModel
    {
        public P2PConnectionService _connectionService;
        private readonly BitsaFundingSystemContext _context;
        public string StartServer { get; set; }
        public string ConnectServer { get; set; }
        public Blockchain Chain { get; set; }

        public IndexModel(P2PConnectionService ConnectionService, BitsaFundingSystemContext context)
        {
            _context = context;
            _connectionService = ConnectionService;
        }
        public IList<Project> TopProjects { get; set; }
        public IList<Project> RecentProject { get; set; }

        public async Task OnGetAsync()
        {
            TopProjects = await _context.Projects.OrderByDescending(a => a.Balance).Take(3).ToListAsync();
            RecentProject = await _context.Projects.OrderByDescending(a => a.Created_At).Take(3).ToListAsync();
            try
            {
                StartServer = _connectionService.StartServer();
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
