using System.Net.Sockets;
using System.Text;

namespace TestTCPIP.Models
{
    public class TCPIPModel
    {
        public TCPIPModel() { }
        public bool SendMessage(string ipremote, int port, string message)
        {
            TcpClient m_client = new TcpClient();
            m_client.SendTimeout = 3000;
            m_client.ReceiveTimeout = 3000;
            m_client.Connect(ipremote, port);
            System.Threading.Thread.Sleep(200);
            if (!m_client.Connected)
            {
                return false;
            }
            else
            {
                byte[] buff = System.Text.Encoding.Default.GetBytes(message.ToCharArray());
                m_client.GetStream().Write(buff, 0, buff.Length);
                return true;
            }    
        }
    }
}
