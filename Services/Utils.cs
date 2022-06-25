
using BitsaFundingSystem.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BitsaFundingSystem.Services
{
    public static class Utils
    {

        public static string GenHash(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            byte[] hash = SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }


        public static string ConvertToDateTime(this Int64 timestamp)
        {
            return new DateTime(timestamp).ToString("dd MMM yyyy hh:mm:ss"); ;
        }

        public static string GetTransactionHash(Transaction details, DateTime TimeStamp)
        {
            var TransactionId = GenHash(TimeStamp + details.FromAddress + details.Amount + details.ToAddress);

            return TransactionId;
        }

    }
}