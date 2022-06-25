using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BitsaFundingSystem.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BitsaFundingSystemUser class
    public class BitsaFundingSystemUser : IdentityUser
    {
        [PersonalData]
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Role { get; set; }
        public decimal Balance { get; set; }
        public string WalletId { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
