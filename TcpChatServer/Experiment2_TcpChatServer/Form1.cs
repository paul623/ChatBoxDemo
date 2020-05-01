using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experiment2_TcpChatServer
{
    public partial class Form1 : Form
    {
        private IPAddress localAddress;
        private const int port = 8848;
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader br;
        private BinaryWriter bw;
        private String log = "";
        private int count = 0;

        public delegate void ShowLog(String log);
        public ShowLog showLog;
        public delegate void ShowNumber();
        public ShowNumber showNumber;

        private List<Client> clientList;
        private MyListener listener;
        byte[] temp;

        public Form1()
        {
            InitializeComponent();
            localAddress = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            showLog = new ShowLog(setLog);
            showNumber = new ShowNumber(setNumber);
            clientList = new List<Client>();
            listener = new MyListener(this);
        }

        private void setNumber()
        {
            label_status.Text = "已上线" + count + "人";
        }

       
      
        public static String getTime()
        {
            return "\r\n" + DateTime.Now.ToString() + "\r\n";
        }
        private void StartServer()
        {
            log = getTime() + "开始启动服务器中。。。";
            textBox_log.Invoke(showLog, log);
            tcpListener = new TcpListener(localAddress, port);
            tcpListener.Start();
            log = getTime() + "IP:" + localAddress + " 端口号：" + port + " 已启用监听";
            textBox_log.Invoke(showLog, log);
            while (true)
            {
                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    networkStream = tcpClient.GetStream();
                    br = new BinaryReader(networkStream);
                    bw = new BinaryWriter(networkStream);
                    String accountName =br.ReadString();
                    accountName = decodeUserName(accountName);
                    log = getTime() + "用户:"+accountName+"已上线";
                    count++;
                    label_status.Invoke(showNumber);
                    textBox_log.Invoke(showLog, log);
                    clientList.Add(new Client(accountName,tcpClient,listener));
                    notifyUpdateUserList();
                }
                catch
                {
                    log = getTime() + "已终止监听";
                    textBox_log.Invoke(showLog, log);
                    return;
                }
            }
            
        }





        public String decodeUserName(String words)
        {
            return words.Split('$')[1];
        }

        public void setLog(String log)
        {
            textBox_log.AppendText(log);
        }

        public class MyListener : Client.ReceiveMessageListener
        {
            public Form1 f;
            public MyListener(Form1 form)
            {
                f = form;
            }
            public void getMessage(String accountname,string message, BinaryReader br, BinaryWriter bw)
            {
                //TODO
                string []results = message.Split('$');
                if (int.Parse(results[0]) == 2)
                {
                    String content = results[1];
                    String goalName = results[2];
                    f.SendMessageToClient(content,goalName,accountname,false,false);
                }else if (int.Parse(results[0]) ==3)
                {
                    String content = results[1];
                    f.stopClientByName(content);
                }
                else if(int.Parse(results[0])==4)
                {
                    int length = int.Parse(results[1]);
                    String goalName = results[2];
                    f.temp = br.ReadBytes(length);
                    f.SendMessageToClient("3$" + length, goalName, accountname, false,true);
                    f.SendMessageToClient("我发送了一条广播图片，但是程序员太菜不会实现", goalName, accountname, true,false);
                }
            }
        }
        private void SendMessageToClient(String content,String goalName,String userName,bool byte_flag,bool sys_flag)
        {
            bool flag = false;
            if (goalName.Equals("所有人"))
            {
                flag = true;
            }
            foreach(Client i in clientList)
            {
                if (flag)
                {
                    i.sendMessage("2$广播：" + userName+"说: "+content);
                }
                else
                {
                    if (i.userName.Equals(goalName))
                    {
                        if (byte_flag)
                        {
                            i.bw.Write(temp, 0, temp.Length);
                            i.bw.Flush();
                        }
                        else
                        {
                            if (sys_flag)
                            {
                                i.sendMessage(content);
                            }
                            else
                            {
                                i.sendMessage("2$" + userName + "说: " + content);
                            }
                            
                        }
                        return;
                    }
                }
                
            }

        }

        private void notifyUpdateUserList()
        {
            String message = "1" + getCurUserName();
            foreach (Client i in clientList)
            {
                i.sendMessage(message);
            }
        }
        private String getCurUserName()
        {
            String aa = "";
            foreach(Client i in clientList)
            {
                aa = aa + "$" + i.userName;
            }
            return aa;
        }
        public void stopClientByName(String name)
        {
            foreach(Client i in clientList){
                if (i.userName.Equals(name))
                {
                    i.stop();
                    count--;
                    label_status.Invoke(showNumber);
                    textBox_log.Invoke(showLog, getTime() + name + "已下线");
                    clientList.Remove(i);
                }
            }
        }
        private void button_stop_Click(object sender, EventArgs e)
        {
            CloseAllClients();
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
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
            log = getTime() + "已停止服务器";
            textBox_log.Invoke(showLog, log);
            count = 0;
        }

        public void CloseAllClients()
        {
            foreach(Client i in clientList)
            {
                i.stop();
            }
            clientList.Clear();
        }

        private void label_status_Click(object sender, EventArgs e)
        {

        }

        private void button_open_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(StartServer);
            thread.Start();
            thread.IsBackground = true;
        }
    }
    
}
