
using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using EllipticCurve;


namespace BitsaFundingSystem.Models
{
    public class Account
    {
        public PrivateKey PrivKey { set; get; }
        public PublicKey PubKey { set; get; }

        public Account()
        {
            PrivKey = new PrivateKey();
            PubKey = PrivKey.publicKey();
        }

        //public string GetPubKeyHex()
        //{
        //    return Convert.ToHexString(PubKey.toString());
        //}


        //change later to use the senders names and creation date.
        public string GetAddress(string name)
        {

            var sha256 = SHA256.Create();

            var inputBytes = Encoding.ASCII.GetBytes($"{name}");
            var outputBytes = sha256.ComputeHash(inputBytes);

            return "UKC_" + Convert.ToBase64String(outputBytes);
        }

        public Signature CreateSignature(Transaction Trx)
        {
            Signature signature = Ecdsa.sign(Trx.ToString(), PrivKey);
            //return signature.toBase64();
            return signature;
        }


    }
}