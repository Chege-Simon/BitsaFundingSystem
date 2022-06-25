using BitsaFundingSystem.Models;
using EllipticCurve;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WebSocketSharp;

namespace BitsaFundingSystem
{
    public class P2PClient
    {
        IDictionary<string, WebSocket> wsDict = new Dictionary<string, WebSocket>();
        public string FileLocation = @"C:\Users\geneva\OneDrive\Desktop\School Work\Final Project\webserver\";
        public string data { get; set; }
        public string Connect(string url)
        {
            if (!wsDict.ContainsKey(url))
            {
                WebSocket ws = new WebSocket(url);
                ws.OnClose += (sender, e) => {
                    ws.Connect();
                    ws.Send("Hi Server Node");
                    ws.Send($"ws://127.0.0.1:6001");
                    ws.Send(JsonConvert.SerializeObject(Program.Kim));
                };
                ws.OnError += (sender, e) => {
                    ws.Connect();
                    ws.Send("Hi Server Node");
                    ws.Send($"ws://127.0.0.1:6001");
                    ws.Send(JsonConvert.SerializeObject(Program.Kim));
                };
                ws.OnMessage += async (sender, e) => 
                {
                    if (e.Data == "Hi Client Node")
                    {
                        Console.WriteLine(e.Data);
                        data = e.Data;
                    }
                    else
                    {
                        var newChain = JsonConvert.DeserializeObject<Blockchain>(e.Data);

                        if (Program.Kim.Chain.Count == 1)
                        {
                            //var newNewTransactions = new List<Transaction>();
                            //newNewTransactions.AddRange(newChain.PendingTransactions);
                            //newNewTransactions.AddRange(Program.Kim.PendingTransactions);

                            //newChain.PendingTransactions = newNewTransactions;
                            Program.Kim = newChain;
                            await File.WriteAllTextAsync(FileLocation + "KIMBLOCKCHAIN.txt", JsonConvert.SerializeObject(Program.Kim));

                        }
                        if (!newChain.IsValid() || newChain.Chain.Count <= Program.Kim.Chain.Count) return;
                        var newTransactions = new List<Transaction>();
                        newTransactions = (List<Transaction>)newChain.PendingTransactions;

                        newChain.PendingTransactions = newTransactions;
                        Program.Kim = newChain;
                        await File.WriteAllTextAsync(FileLocation + "KIMBLOCKCHAIN.txt", JsonConvert.SerializeObject(Program.Kim));
                    }
                };
                ws.Connect();
                ws.Send("Hi Server Node");
                ws.Send($"ws://127.0.0.1:6001");
                ws.Send(JsonConvert.SerializeObject(Program.Kim));
                wsDict.Add(url, ws); 
                //ws.OnClose += (sender, e) =>
                //{
                //    ws.Send("Hi Server Node");
                //    ws.Send($"ws://127.0.0.1:6001");
                //};
            }
            return data;
        }

        public void Send(string url, string data)
        {
            foreach (var item in wsDict)
            {
                if (item.Key == url)
                {
                    item.Value.Send(data);
                }
            }
        }
        public void SendToSpecificNode(string ServerKey,string trxHash, Transaction Transaction, Signature Signature, PublicKey Pubkey)
        {
            foreach (var item in wsDict)
            {
                if (item.Key == ServerKey)
                {
                    Load data = new Load
                    {
                        Transaction = Transaction,
                        Signature = Signature,
                        Pubkey = Pubkey,
                        trxHash = trxHash
                    };
                    item.Value.Send(JsonConvert.SerializeObject(data));
                    
                }
            }
        }

        public void Broadcast(string data)
        {
            foreach (var item in wsDict)
            {
                item.Value.Send(data);
            }
        }

        public IList<string> GetServers()
        {
            IList<string> servers = new List<string>();
            foreach (var item in wsDict)
            {
                servers.Add(item.Key);
            }
            return servers;
        }

        public void Close()
        {
            foreach (var item in wsDict)
            {
                item.Value.Close();
            }
        }
    }
}
