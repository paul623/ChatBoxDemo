using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Experiment1_TcpChatClient
{
    public partial class Form1 : Form
    {
        private const int port = 8848;

        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader br;
        private BinaryWriter bw;
        private String log = "";
        private Boolean flag_open = false;
        private String Pic_dir;


        private delegate void ShowLog(String log);
        private ShowLog showLog;

        private delegate void UpdateComboBox(string usernames);
        private UpdateComboBox updateComboBox;

        private delegate void UpdateImgBox(Image image);
        private UpdateImgBox updateImgBox;

        public Form1()
        {
            InitializeComponent();

            showLog = new ShowLog(setLog);
            updateComboBox = new UpdateComboBox(setComboBox);
            updateImgBox = new UpdateImgBox(setImgBox);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textbox_chatbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            //开始连接服务器，同步方式阻塞进行

            IPHostEntry remoteHost = Dns.GetHostEntry(textbox_ip.Text);
            tcpClient = new TcpClient();
            tcpClient.Connect(remoteHost.HostName, port);//阻塞啦！！！
            if (tcpClient != null)
            {
                String username = textBox_name.Text;
                log = DateUtil.getTime() + "以用户名为 "+username+"连接服务器";
                textbox_chatbox.AppendText(log);
                networkStream = tcpClient.GetStream();
                br = new BinaryReader(networkStream);
                bw = new BinaryWriter(networkStream);
                SendMessage(username, 1,"");//向服务器发送信息，告诉服务器自己的用户名
                
                Thread thread = new Thread(ReceiveMessage);
                thread.Start();
                thread.IsBackground = true;
            }
            else
            {
                log = DateUtil.getTime() + "连接服务器失败，请重试";
                textbox_chatbox.AppendText(log);
            }
        }
        private String EncodeMessage(String message, int code,String goalName)
        {
            switch (code)
            {
                case 1://汇报用户名
                    return "1$" + message;
                case 2://发送信息
                    return "2$" + message+"$"+goalName;
                case 3://断开连接
                    return "3$" + message;
                case 4://发送图片(2进制数据)
                    return "4$" + message+"$"+goalName;
                default:
                    return "-1$错误";
            }
        }
        private void DecodeMessage(String message)
        {
            String[] results = message.Split('$');
            int code = int.Parse(results[0]);
            switch (code)
            {
                case 1://更新的是用户
                    comboBox1.Invoke(updateComboBox, message);
                    break;
                case 2://收到信息
                    String rev = message.Substring(message.IndexOf('$')+1);
                    textbox_chatbox.Invoke(showLog,DateUtil.getTime()+rev);
                    break;
            }
           
        }
        public void SendMessage(String message, int code, String goalName)
        {
            String sendmessage = EncodeMessage(message, code, goalName);
            try
            {
                bw.Write(sendmessage);
                bw.Flush();
                log = DateUtil.getTime() + "发送信息：" + message;
                if (code == 1)
                {
                    flag_open = true;
                }
                else 
                {
                    if (code != 4)
                    {
                        textbox_chatbox.AppendText(log);
                    }
                    
                }
               
            }
            catch
            {
                log = DateUtil.getTime() + "发送信息异常，服务器已断开连接";
                return;
            }
        }
        public void ReceiveMessage()
        {
            while (flag_open)
            {
                try
                {
                    string rcvMsgStr = br.ReadString();
                    String[] results = rcvMsgStr.Split('$');
                    int code = int.Parse(results[0]);
                    if (code == 3)//接收图片
                    {
                        pic_show.Invoke(updateImgBox, SetByteToImage(br.ReadBytes(int.Parse(results[1]))));
                    }
                    else
                    {
                        DecodeMessage(rcvMsgStr);
                    }
                    
                }
                catch
                {
                    log = DateUtil.getTime() + "接收发生异常，服务器已断开连接";
                    textbox_chatbox.Invoke(showLog,log);
                    return;
                }
            }
        }
        private void button_stop_Click(object sender, EventArgs e)
        {
            SendMessage(textBox_name.Text, 3,"");
            log = DateUtil.getTime() + "已发起下线请求";
            textbox_chatbox.Invoke(showLog, log);
            flag_open = false;
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

        public void setLog(String log)
        {
            textbox_chatbox.AppendText(log);
        }
        public void setComboBox(string names)
        {
            String results = names.Substring(names.IndexOf('$') + 1);
            String []namelist = results.Split('$');
            comboBox1.Items.Clear();
            for(int i = 0; i < namelist.Length; i++)
            {
                comboBox1.Items.Add(namelist[i]);
            }
            comboBox1.Items.Add("所有人");
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SendMessage(textbox_sendbox.Text, 2, comboBox1.Text);
            textbox_sendbox.Clear();
        }

        private void button_pic_send_Click(object sender, EventArgs e)
        {
            int length = SetImageToByteArray(Pic_dir).Length;
            SendMessage(length+"", 4, comboBox1.Text);
            sendImg();
            pic_show.Image = null;
        }

        private void button_pic_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Pic_dir = fileDialog.FileName;
                pic_show.Image = Image.FromFile(Pic_dir);
                
            }
        }
        private void sendImg()
        {
            byte[] datas =SetImageToByteArray(Pic_dir);
            bw.Write(datas, 0, datas.Length);
            bw.Flush();
        }
        private byte[] SetImageToByteArray(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }
        public Image SetByteToImage(byte[] mybyte)
        {
            MemoryStream ms = new MemoryStream(mybyte);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }
        private void setImgBox(Image i)
        {
            pic_show.Image = i;
        }
    }
   
}
