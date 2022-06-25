using BitsaFundingSystem.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsaFundingSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GitHubLink { get; set; }
        public string Purpose { get; set; }
        public string OwnerId { get; set; }
        public string WalletId { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
