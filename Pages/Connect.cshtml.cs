using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsaFundingSystem.Models;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BitsaFundingSystem.Pages.KimCoin
{
    public class ConnectModel : PageModel
    {
        public P2PConnectionService _connectionService;
        public List<string> ConnectedServers { get; set; }
        public Blockchain Chain { get; set; }

        public ConnectModel(P2PConnectionService ConnectionService)
        {
            _connectionService = ConnectionService;
        }
        public RedirectResult OnGet()
        {
            ConnectedServers = _connectionService.ConnnectToServer();
            Chain = _connectionService.AskForBlockChain();
            return Redirect("/KimCoin/Transactions/Blockchain");
        }
    }
}
