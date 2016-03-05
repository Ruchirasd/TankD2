using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TankD2.Controllers
{
    class Connection
    {
       // public const string SERVER_IP = "127.0.0.1";
        public const string SERVER_IP = "192.168.1.2";
        public const int SERVER_PORT = 7000;
        private   BinaryWriter writer;
        private const string CLIENT_IP = "localhost";
        private const int CLIENT_PORT = 6000;
        private  TcpClient client;
        private TcpListener listner;
        private NetworkStream serverStream;


        private BackgroundWorker listenerThread = new BackgroundWorker();
        public void ReceiveData(object sender)
        {
            //listner = new TcpListener(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            listner = new TcpListener(IPAddress.Any, SERVER_PORT);
            listner.Start();
                Console.Write("Server started.....");
               
                Socket connection;
               
                while (true)
                {
                    //connection is connected socket
                    connection = listner.AcceptSocket();
                    if (connection.Connected)
                    {

                        this.serverStream = new NetworkStream(connection);

                        SocketAddress sockAdd = connection.RemoteEndPoint.Serialize();
                        string s = connection.RemoteEndPoint.ToString();
                        List<Byte> inputStr = new List<byte>();

                        int asw = 0;
                        while (asw != -1)
                        {
                            asw = this.serverStream.ReadByte();
                            inputStr.Add((Byte)asw);
                        }

                        String reply = Encoding.UTF8.GetString(inputStr.ToArray());

                    Console.Write(reply);
                      
                        ThreadPool.QueueUserWorkItem(new WaitCallback(GameEngine.Resolve), reply);
                        this.serverStream.Close();
                  
                    }
                }

                
               

            }


        public  void ConnectToServer(String msg)
        {

            try
            {
                
                    
                client = new TcpClient();
                client.Connect(CLIENT_IP, CLIENT_PORT);
                writer = new BinaryWriter(client.GetStream());
                Byte[] tempStr = Encoding.ASCII.GetBytes(msg);
                writer.Write(tempStr);
               
                if (client.Connected)
                {
                    Console.WriteLine("connected......");
                }
                else {
                    Console.WriteLine("not connected");
                }
                client.Close();
            }catch(SocketException e){
                Console.WriteLine("unable to connect server");
            
            }
            
        }

      public void InitializeBackGroundThreads()
        {
           
            listenerThread.DoWork += new DoWorkEventHandler(listenerThread_DoWork);
            Console.WriteLine("St");
            
        }

        public void listenerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("St2");
            ReceiveData(null);
        }

     }
}

