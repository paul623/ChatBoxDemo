using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Experiment2_TcpChatServer
{
    class Client
    {
        public String userName;
        public TcpClient tcpClient;
        public BinaryReader br;
        public BinaryWriter bw;
        public ReceiveMessageListener listener;
        public bool flag = false;

        public Client(String userName,TcpClient client,ReceiveMessageListener receiveMessageListener)
        {
            this.userName = userName;
            this.tcpClient = client;
            this.listener = receiveMessageListener;
            NetworkStream networkStream = tcpClient.GetStream();
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
            Thread thread = new Thread(receiveMessage);
            thread.Start();
            flag = true;
            thread.IsBackground = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   userName == client.userName;
        }
        public bool sendMessage(String ecodeMessage)
        {
            try
            {
                bw.Write(ecodeMessage);
                bw.Flush();
                return true;
            }catch {
                return false;
            }

            
        }

        public void receiveMessage()
        {
            while (true)
            {
                try
                {
                    String temp = br.ReadString();
                    listener.getMessage(userName, temp,br,bw);
                }
                catch
                {
                    return;
                }
            }
            
        }
        public void stop()
        {
            flag = false;
            if (bw != null)
            {
                bw.Close();
            }
            if (br != null)
            {
                br.Close();
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        public interface ReceiveMessageListener
        {
            void getMessage(String accountName,String message, BinaryReader br, BinaryWriter bw);
        }
    }
   
}
