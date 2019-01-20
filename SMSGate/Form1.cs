using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Configuration;

namespace SMSGate
{
    public partial class Form1 : Form
    {
        Gate MsgSend = new Gate();
        public Form1()
        {
            InitializeComponent();
            bool ConfigurationStatus=setConfiguration();
            if(!ConfigurationStatus)
            {
                this.Close();
            }
        }

        private bool setConfiguration()
        {
            try
            {
                Config.GateLogin = ConfigurationManager.AppSettings["GateLogin"];
                Config.GatePass = ConfigurationManager.AppSettings["GatePass"];
                Config.GateUrl = ConfigurationManager.AppSettings["GateUrl"];
                Config.UserAgent = ConfigurationManager.AppSettings["UserAgent"];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Configuration error: " + ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string Number = tbNumber.Text;
            string Message = tbMessage.Text;
            MsgSend.sendMessage(Number, Message);
        }
    }
}
