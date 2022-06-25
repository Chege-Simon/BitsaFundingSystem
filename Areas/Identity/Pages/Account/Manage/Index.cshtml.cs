using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BitsaFundingSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BitsaFundingSystem.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<BitsaFundingSystemUser> _userManager;
        private readonly SignInManager<BitsaFundingSystemUser> _signInManager;

        public IndexModel(
            UserManager<BitsaFundingSystemUser> userManager,
            SignInManager<BitsaFundingSystemUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string WalletId { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "First Name")]
            public string First_Name { get; set; }
            [Display(Name = "Middle Name")]
            public string Middle_Name { get; set; }
            [Display(Name = "Last Name")]
            public string Last_Name { get; set; }
            [Display(Name = "WalletId")]
            public string WalletId { get; set; }
        }

        private async Task LoadAsync(BitsaFundingSystemUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var theUser = await _userManager.GetUserAsync(User);

            Username = userName;

            Input = new InputModel
            {
                First_Name = theUser.First_Name,
                Middle_Name = theUser.Middle_Name,
                Last_Name = theUser.Last_Name,
                WalletId = theUser.WalletId,
                PhoneNumber = phoneNumber
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

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            if (Input.First_Name != user.First_Name)
            {
                user.First_Name = Input.First_Name;
            }
            if (Input.Middle_Name != user.Middle_Name)
            {
                user.Middle_Name = Input.Middle_Name;
            }
            if (Input.Last_Name != user.Last_Name)
            {
                user.Last_Name = Input.Last_Name;
            }
            if (Input.WalletId != user.WalletId)
            {
                user.WalletId = Input.WalletId;
            }


            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
