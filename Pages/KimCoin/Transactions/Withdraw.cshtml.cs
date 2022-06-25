
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BitsaFundingSystem.Areas.Identity.Data;
using BitsaFundingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MpesaLib;
using Newtonsoft.Json;
using BitsaFundingSystem.Models;
using BitsaFundingSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSocketSharp;

namespace BitsaFundingSystem.Pages.KimCoin.Transactions
{
    public class WithdrawModel : PageModel
    {
        private readonly IMpesaClient _mpesaClient;
        public P2PConnectionService _connectionService;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        private readonly SignInManager<BitsaFundingSystemUser> _signInManager;
        private readonly BitsaFundingSystemContext _context;
        public string AccessToken { get; set; }
        public string PaymentRequest { get; set; }
        public string QueryRequest { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string CheckoutRequestID { get; set; }
        public string MerchantRequestID { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public Transaction Transaction { get; set; }
        private string WalletId;
        public List<Project> Projects { get; set; }


        public WithdrawModel(
           UserManager<BitsaFundingSystemUser> userManager,
           SignInManager<BitsaFundingSystemUser> signInManager,
           IMpesaClient mpesaClient,
            P2PConnectionService ConnectionService, 
            BitsaFundingSystemContext context)
        {
            _mpesaClient = mpesaClient;
            _connectionService = ConnectionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public class InputModel
        {
            [Required]
            public decimal Amount { get; set; }
            public string Phone_Number { get; set; }
            public string PersonalWalletId { get; set; }
            public string ProjectWalletId { get; set; }

        }
        public class PaymentResponse
        {
            public string MerchantRequestID { get; set; }
            public string CheckoutRequestID { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseDescription { get; set; }
            public string CustomerMessage { get; set; }
        }
        public class QueryResponse
        {
            public string ResponseCode { get; set; }
            public string ResponseDescription { get; set; }
            public string MerchantRequestID { get; set; }
            public string CheckoutRequestID { get; set; }
            public string ResultCode { get; set; }
            public string ResultDesc { get; set; }
        }

        private async Task LoadAsync(BitsaFundingSystemUser user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var theUser = await _userManager.GetUserAsync(User);
            Projects = _context.Projects.Where(a => a.OwnerId == user.Id).ToList();
            ViewData["ProjectWallets"] = Projects.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.WalletId.ToString(),
                                     Text = a.Title + " -- " + a.WalletId
                                 }).ToList();
            double cash = 0.0;

            Input = new InputModel
            {
                PersonalWalletId = theUser.WalletId,
                ProjectWalletId = "",
                Phone_Number = phoneNumber,
                Amount = (decimal)cash,
            };

        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            return Page();
        }
        public Project ThisProject { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            if (Input.PersonalWalletId.IsNullOrEmpty() && Input.ProjectWalletId.IsNullOrEmpty())
            {
                await LoadAsync(user);
                StatusMessage = "Withdraw Failed. Please Select a Wallet.";
                return Page();
            }
            else if (!Input.PersonalWalletId.IsNullOrEmpty() && !Input.ProjectWalletId.IsNullOrEmpty())
            {
                await LoadAsync(user);
                StatusMessage = "Withdraw Failed. Please Select either a Personal Wallet or Project Wallet.";
                return Page();
            }
            //ConsumerKey = "zvRyh2hw4Klz7Fif3hkQI2mqtVWHwAYc";
            //ConsumerSecret = "MieqYohdXRQ3V81u";
            //AccessToken = await _mpesaClient.GetAuthTokenAsync(ConsumerKey, ConsumerSecret, RequestEndPoint.AuthToken);
            //var BusinessToCustomerObject = new BusinessToCustomerDto
            //(
            //    "withdraw from app",//Remarks
            //    "1", //Amount
            //    "BusinessPayment", //CommandID
            //    "BitsaFundingSystem", //InitiatorName
            //    "test", //Occasion
            //    "603047", //PartyA
            //    "254" + Input.Phone_Number[1..], //PartyB
            //    "https://blablabla/timeoutendpoint", //QueueTimeOutURL
            //    "https://blablabla/resultendpoint", //ResultURL
            //    "security credential" //SecurityCredential
            //);
            //var b2crequest = await _mpesaClient.MakeB2CPaymentAsync(BusinessToCustomerObject, AccessToken, RequestEndPoint.BusinessToCustomer);
            //var walletId;
            if (!Input.ProjectWalletId.IsNullOrEmpty())
            {
                WalletId = Input.ProjectWalletId;

                Projects = _context.Projects.Where(a => a.OwnerId == user.Id).ToList();
                foreach (var Project in Projects)
                {
                    if (Project.WalletId == Input.ProjectWalletId)
                    {
                        ThisProject = Project;
                    }
                }
                if (ThisProject.Balance < Input.Amount || ThisProject.Balance <= 0)
                {
                    StatusMessage = "Withdraw Request Failed. Balance less Withdraw Amount";
                    return RedirectToPage();

                }
                else if (ThisProject.WalletId == Input.ProjectWalletId && ThisProject.Balance > Input.Amount)
                {
                    ThisProject.Balance -= Input.Amount;
                    _context.Attach(ThisProject).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProjectExists(ThisProject.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

            }
            else if(!Input.PersonalWalletId.IsNullOrEmpty())
            {
                if (user.Balance < Input.Amount || user.Balance <= 0)
                {
                    StatusMessage = "Withdraw Request Failed. Balance less Withdraw Amount";
                    return RedirectToPage();
                }
                WalletId = Input.PersonalWalletId;
                user.Balance -= Input.Amount;
                await _userManager.UpdateAsync(user);
            }
            Transaction = new Transaction();
            Transaction.ToAddress = "Mpesa:" + Input.Phone_Number;
            Transaction.Amount = Input.Amount;
            Transaction.FromAddress = WalletId;
            _connectionService.AssignTransaction(Transaction);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            return RedirectToPage("./Blockchain");
        }
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
