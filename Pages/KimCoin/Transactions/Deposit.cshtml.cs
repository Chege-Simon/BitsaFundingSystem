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
using MpesaLib.Helpers.Exceptions;

namespace BitsaFundingSystem.Pages.KimCoin.Transactions
{
    public class DepositeModel : PageModel
    {
        private readonly IMpesaClient _mpesaClient;
        public P2PConnectionService _connectionService;
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        private readonly SignInManager<BitsaFundingSystemUser> _signInManager;
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
        public string ErrorMessage { get; set; }


        public DepositeModel(
           UserManager<BitsaFundingSystemUser> userManager,
           SignInManager<BitsaFundingSystemUser> signInManager,
           IMpesaClient mpesaClient, 
            P2PConnectionService ConnectionService)
        {
            _mpesaClient = mpesaClient;
            _connectionService = ConnectionService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public class InputModel
        {
            [Required]
            public decimal Amount{ get; set; }
            public string Phone_Number { get; set; }
            public string WalletId { get; set; }

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


            Input = new InputModel
            {
                WalletId = theUser.WalletId,
                Phone_Number = phoneNumber
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
        private string CalculatePassword(string shortCode, string passkey, string timestamp)
        {
            return Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(shortCode + passkey + timestamp));
        }
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
            ConsumerKey = "zvRyh2hw4Klz7Fif3hkQI2mqtVWHwAYc";
            ConsumerSecret = "MieqYohdXRQ3V81u";
            //AccessToken = await _mpesaClient.GetAuthTokenAsync(ConsumerKey, ConsumerSecret, RequestEndPoint.AuthToken);

            // initialize object with data
            var MpesaExpressObject = new LipaNaMpesaOnlineDto
            (
                    "174379",// businessShortCode
                    DateTime.Now, //Timestamp
                    "CustomerPayBillOnline",  //transactionType
                    "1", // amount
                    "254"+Input.Phone_Number[1..],// partyA
                    "174379",// partyB
                    "254" + Input.Phone_Number[1..], // phoneNumber
                    "https://mydomain.com/path", // callBackUrl
                    "BitsaFundingSystem",//accountReference
                    "Deposit To Wallet",//transactionDescription
                    "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919" //passkey
            );

            //Make payment request 
            //try
            //{
            //    PaymentRequest = await _mpesaClient.MakeLipaNaMpesaOnlinePaymentAsync(MpesaExpressObject, AccessToken, RequestEndPoint.LipaNaMpesaOnline);
            //}
            //catch (MpesaApiException e)
            //{
            //    Console.WriteLine($"An Error Occured, Status Code {e.StatusCode}: {e.Content}");
            //    ErrorMessage = $"An Error Occured, Status Code {e.StatusCode}: {e.Content}";
            //    return RedirectToPage();

            //}
            //var paymentresponse = JsonConvert.DeserializeObject<PaymentResponse>(PaymentRequest);
            //CheckoutRequestID = paymentresponse.CheckoutRequestID;

            //Thread.Sleep(TimeSpan.FromSeconds(5));
            var QueryLipaNaMpesaTransactionObject = new LipaNaMpesaQueryDto
            (
                "174379", //BusinessShortCode
                "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919", //passkey
                DateTime.Now, //Timestamp
                "CheckoutRequestID" //CheckoutRequestID

            );

            //QueryRequest = await _mpesaClient.QueryLipaNaMpesaTransactionAsync(QueryLipaNaMpesaTransactionObject, AccessToken, RequestEndPoint.QueryLipaNaMpesaOnlieTransaction);
            //var queryresponse = JsonConvert.DeserializeObject<PaymentResponse>(QueryRequest);
            //if (queryresponse.ResponseCode != "0")
            //{
            //    StatusMessage = "Mpesa Request Failed.";
            //    return RedirectToPage();
            //}
            //else
            //{
            //}
            Transaction = new Transaction();
            Transaction.FromAddress = "Mpesa:" + Input.Phone_Number;
            Transaction.Amount = Input.Amount;
            Transaction.ToAddress = user.WalletId;
            _connectionService.AssignTransaction(Transaction);

            user.Balance += Input.Amount;
            await _userManager.UpdateAsync(user);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return RedirectToPage("./Blockchain");
        }
    }
}
