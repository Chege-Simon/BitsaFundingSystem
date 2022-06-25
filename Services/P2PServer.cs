using BitsaFundingSystem.Models;
using BitsaFundingSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace BitsaFundingSystem
{
    public class P2PServer : WebSocketBehavior
    {
        public string FileLocation = @"C:\Users\geneva\OneDrive\Desktop\School Work\Final Project\webserver\";
        private bool _chainSynched;
        private WebSocketServer _wss;
        public string data { get; set; }

        public string Start()
        {
            _wss = new WebSocketServer($"ws://127.0.0.1:6001");
            _wss.AddWebSocketService<P2PServer>("/Blockchain");
            _wss.Start();
            return "Started server at ws://127.0.0.1:6001";
        }
        public string Stop()
        {
            _wss.RemoveWebSocketService("/Blockchain");
            _wss.Stop();
            return "Stopped server at ws://127.0.0.1:6001";
        }
        protected override async void OnMessage(MessageEventArgs e)
        {
            if (e.Data == "Hi Server Node")
            {

                Send("Hi Client Node");

                Send(JsonConvert.SerializeObject(Program.Kim));
            }
            else if (e.Data.Contains("ws://127.0.0.1:"))
            {
                P2PConnectionService.Client.Connect($"{e.Data}/Blockchain");
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            else
            {
                Blockchain newChain = JsonConvert.DeserializeObject<Blockchain>(e.Data);

                if (newChain.IsValid() && newChain.Chain.Count > Program.Kim.Chain.Count)
                {
                    List<Transaction> newTransactions = new List<Transaction>();
                    //newTransactions.AddRange(newChain.PendingTransactions);
                    newTransactions = (List<Transaction>)newChain.PendingTransactions;

                    newChain.PendingTransactions = newTransactions;
                    Program.Kim = newChain;
                    await File.WriteAllTextAsync(FileLocation + "KIMBLOCKCHAIN.txt", JsonConvert.SerializeObject(Program.Kim));
                }

                if (!_chainSynched)
                {
                    Send(JsonConvert.SerializeObject(Program.Kim));
                    _chainSynched = true;
                }
                Console.WriteLine(e.Data);
            }
        }
    }
}
