using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsaFundingSystem.Pages
{
    public class StopModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public P2PConnectionService _connectionService;
        public string StopServer { get; set; }

        public StopModel(ILogger<IndexModel> logger, P2PConnectionService ConnectionService)
        {
            _logger = logger;
            _connectionService = ConnectionService;
        }

        public void OnGet()
        {
            StopServer = _connectionService.StopServer();
        }
    }
}
