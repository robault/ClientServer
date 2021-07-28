using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Sockets;

using System.Timers;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Diagnostics;

using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientServer
{
    public partial class ServerForm : Form
    {
        TcpChannel tcpChannel = new TcpChannel(20102);

        public ServerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        TcpListener server = null;
        int port = 13000;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        System.Timers.Timer listeningTimer = new System.Timers.Timer(1000); //1 second
        byte[] bytes = new byte[1024]; 
        string data = "HeyThere.";

        private void startButton_Click(object sender, EventArgs e)
        {
            //server = new TcpListener(ip, port);
            //server.Start();
            //Log("Server started on:");
            //Log("Server: " + ip.ToString());
            //Log("Port: " + port.ToString());
            listeningTimer.Elapsed += new ElapsedEventHandler(listeningTimer_Elapsed);
            listeningTimer.Start();
            Log("Timer started.");
        }

        void listeningTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //while (true)
                //{
                //    TcpClient client = server.AcceptTcpClient();
                //    NetworkStream stream = client.GetStream();
                //    Log("Accepted client.");
                //    byte[] outgoingBytes = Encoding.ASCII.GetBytes(data);
                //    stream.Write(outgoingBytes, 0, outgoingBytes.Length);
                //    Log("Wrote: " + data);
                //    stream.Close();
                //    client.Close();
                //    Log("Client closed.");
                //}

                RemoteImage myImage = new RemoteImage();
                Image<Bgr, Byte> camImage = myImage.CamImage;
                scamImagePictureBox.Image = camImage.ToBitmap(scamImagePictureBox.Width, scamImagePictureBox.Height);
            }
            catch (SocketException se)
            {
                Log(se.Message);
            }
            finally
            {
                //server.Stop();
                //listeningTimer.Stop();
                //Log("Server stopped.");
                //Log("Timer stopped.");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //server.Stop();
            listeningTimer.Stop();
            //Log("Server stopped.");
            Log("Timer stopped.");

            ChannelServices.UnregisterChannel(tcpChannel);
            tcpChannel = null;
        }

        private void Log(string message)
        {
            logTextBox.Text += Environment.NewLine;
            logTextBox.Text += message;
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            try
            {
                ChannelServices.RegisterChannel(tcpChannel);
                Type customType = typeof(RemoteImage);
                RemotingConfiguration.RegisterWellKnownServiceType(customType, "RemoteImage", WellKnownObjectMode.SingleCall);

                Log("RemoteCamServer listening on port: 20102");
            }
            catch (SocketException se)
            {
                Log(se.Message);
            }
            //catch (Exception ex)
            //{
            //    Log(ex.Message);
            //}
        }
    }

    public class RemoteImage : System.MarshalByRefObject
    {
        Capture camCapture = new Capture();
        EventLog eventLog1 = new EventLog("Application");

        public RemoteImage()
        {
            //Constructor
        }

        private Image<Bgr, Byte> _camImage = null;
        public Image<Bgr, Byte> CamImage
        {
            get
            {
                try
                {
                    _camImage = camCapture.QueryFrame();
                }
                catch (Exception ex)
                {
                    eventLog1.WriteEntry("Error: " + ex.Message);
                }
                return _camImage;
            }
        }

        public Image<Bgr, Byte> GetCamImage()
        {
            camCapture = new Capture();
            Image<Bgr, Byte> camImage = camCapture.QueryFrame();
            return camImage;
        }
    }
}
