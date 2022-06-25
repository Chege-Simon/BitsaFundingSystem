using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BitsaFundingSystem.Areas.Identity.Data;
using BitsaFundingSystem.Data;
using BitsaFundingSystem.Models;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BitsaFundingSystem.Pages.KimCoin
{
    public class MakeTransactionModel : PageModel
    {
        public P2PConnectionService _connectionService;
        private readonly BitsaFundingSystemContext _context;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        public MakeTransactionModel( P2PConnectionService ConnectionService,
        UserManager<BitsaFundingSystemUser> userManager,
        BitsaFundingSystemContext context
            )
        {
            _connectionService = ConnectionService;
            _userManager = userManager;
            _context = context;
        }
        [BindProperty]
        public Transaction Transaction { get; set; }
        public string PersonalWalletId { get; set; }
        public string ProjectWalletId { get; set; }
        public List<Project> Projects { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public decimal Amount { get; set; }
            public string PersonalWalletId { get; set; }
            public string ProjectWalletId { get; set; }

        }
        public async Task OnGetAsync(string WalletId)
        {
            var theUser = await _userManager.GetUserAsync(User);
            //Projects = _context.Projects.Where(a => a.OwnerId == theUser.Id).ToList();
            ViewData["ProjectWallets"] = _context.Projects.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.WalletId.ToString(),
                                     Text = a.Title + " -- " + a.WalletId
                                 }).ToList();
            double cash = 0.0;

            Input = new InputModel
            {
                PersonalWalletId = theUser.WalletId,
                ProjectWalletId = WalletId,
                Amount = (decimal)cash,
            };

        }
        public Project Project { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Transaction.ToAddress = Input.ProjectWalletId;
            Transaction.FromAddress = Input.PersonalWalletId;
            Transaction.Amount = Input.Amount;
            _connectionService.AssignTransaction(Transaction);

            Thread.Sleep(TimeSpan.FromSeconds(10));
            Project = _context.Projects.Where(a => a.OwnerId == user.Id).Where(a => a.WalletId == Input.ProjectWalletId).FirstOrDefault();
            Project.Balance += Input.Amount;
            _context.Attach(Project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            user.Balance -= Input.Amount;
            await _userManager.UpdateAsync(user);
            return RedirectToPage("./Blockchain");
        }
    }
}
