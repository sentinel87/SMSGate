using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SMSGate
{
    public class Gate
    {
        public bool sendMessage(string Number, string Msg)
        {
            string MsgInfo = "";
            WebClient Client = new WebClient();
            try
            {
                string baseUrl = Config.GateUrl;
                Client.QueryString.Add("login",Config.GateLogin);
                Client.QueryString.Add("pass",Config.GatePass);
                Client.QueryString.Add("to",Number);
                Client.QueryString.Add("message",Msg);
                Client.QueryString.Add("unicode", "1");
                Client.Headers.Add("user-agent", Config.UserAgent);
                Stream receivedStream = Client.OpenRead(baseUrl);
                StreamReader Reader = new StreamReader(receivedStream);
                MsgInfo = Reader.ReadToEnd();
                receivedStream.Close();
                Reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sending error: " + ex.Message,"BŁĄD",MessageBoxButtons.OK);
                return false;
            }
            MessageBox.Show(MsgInfo, "INFO", MessageBoxButtons.OK);
            return true;
        }
    }
}
