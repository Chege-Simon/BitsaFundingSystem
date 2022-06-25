using BitsaFundingSystem.Models;
using EllipticCurve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitsaFundingSystem.Services
{
    public class P2PConnectionService
    {
        private static P2PServer _server;
        public static readonly P2PClient Client = new P2PClient();
        public IList<String> Servers { get; set; }
        public string Server { get; set; }
        public List<string> ConnectResponses { get; set; }
        public List<string> ConnnectToServer()
        {
            for (int i = 2; i < 5; i++)
            {
                string serverUrl = "ws://127.0.0.1:600";
                serverUrl += i;
                ConnectResponses = new List<string>
                {
                    Client.Connect($"{serverUrl}/Blockchain")
                };
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            return ConnectResponses;
        }
        public Blockchain AskForBlockChain()
        {
            return Program.Kim;
        }
        public string StartServer()
        {
            _server = new P2PServer();
            return _server.Start();
        }
        public string StopServer()
        {
            return _server.Stop();
        } 
        public IList<string> GetServes()
        {
            return Client.GetServers();
        }
        public void AssignTransaction(Transaction Transaction)
        {
            var rand = new Random();
            Servers = GetServes();
            int rnd = rand.Next(Servers.Count);
            Server = Servers[rnd];
            Account newAccount = new Account();
            PrivateKey prvkey = newAccount.PrivKey;
            PublicKey pubkey = prvkey.publicKey();
            // Generate Signature
            var trxHash = Utils.GetTransactionHash(Transaction, DateTime.Now);
            Signature signature = Ecdsa.sign(trxHash, prvkey);
            //Console.WriteLine("This is the trxHash: " + trxHash);
            Client.SendToSpecificNode(Server, trxHash, Transaction, signature, pubkey);
        }
    }
}
