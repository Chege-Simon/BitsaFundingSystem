using BitsaFundingSystem.Models;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitsaFundingSystem.Pages
{
    public class BlockchainModel : PageModel
    {
        public P2PConnectionService _connectionService;
        public IList<string> Servers { get; set; }
        public Blockchain Chain { get; set; }

        public BlockchainModel( P2PConnectionService ConnectionService)
        {
            _connectionService = ConnectionService;
        }

        public void OnGet()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Chain = _connectionService.AskForBlockChain();
            Servers = _connectionService.GetServes();
        }
    }
}
