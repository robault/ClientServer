using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

using ClientServer;
using ImageFilters;

using System.Media;

namespace ClientServer
{
    public partial class ClientForm : Form
    {
        System.Timers.Timer listeningTimer = new System.Timers.Timer(4000);
        System.Timers.Timer alarmTimer = new System.Timers.Timer(1000);
        bool alarmIsOn = false;
        bool connectionError = false;
        bool imageError = false;

        TcpChannel tcpChannel = null;
        Type requiredType = null;
        RemoteImage remoteObject = null;
        
        int darken = 2;
        int darkness = 0;
        bool greycale = false;
        bool invert = false;
        int contrast = 2;
        int contrastness = 0;
        int gamma = 2;
        double gammaness = 2.6; //median to .2 and 5
        double standardDev = 0.0;

        int alarmThreshold = 148000;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;

                resetToolStripMenuItem_Click(sender, e);

                tcpChannel = new TcpChannel();
                ChannelServices.RegisterChannel(tcpChannel);

                requiredType = typeof(RemoteImage);
                remoteObject = (RemoteImage)Activator.GetObject(requiredType, "tcp://localhost:20102/RemoteImage");

                brighnessLabel.Text = darkness.ToString();
                gammaLabel.Text = gammaness.ToString();
                contrastLabel.Text = contrastness.ToString();

                alarmTimer.Elapsed += new ElapsedEventHandler(alarmTimer_Elapsed);

                ////set default values
                //darken = 1;
                //darkness = -40;
                //contrast = 1;
                //contrastness = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void alarmTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\ringout.wav");
            simpleSound.Play();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            listeningTimer.Elapsed += new ElapsedEventHandler(listeningTimer_Elapsed);
            listeningTimer.Start();
            Log("Timer started.");

            stopButton.Enabled = true;
            connectButton.Enabled = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            listeningTimer.Stop();
            Log("Timer stopped.");

            stopButton.Enabled = false;
            connectButton.Enabled = true;
        }

        //timer
        protected void listeningTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CaptureImage();
        }

        protected void CaptureImage()
        {
            try
            {
                Image<Bgr, Byte> camImage = null;

                try
                {
                    camImage = remoteObject.GetCamImage();
                    
                    if(camImage == null)
                        connectionError = true;
                }
                catch
                {
                    //Log("Failed:remoteObject.GetCamImage()");
                    connectionError = true;
                }
                try
                {
                    camImage._Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL);
                }
                catch
                {
                    //Log("Failed:FLIP.HORIZONTAL");
                    imageError = true;
                }
                try
                {
                    camImage._Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);
                }
                catch
                {
                    //Log("Failed:FLIP.VERTICAL");
                    imageError = true;
                }
                if (IsBlank(camImage.ToBitmap()) != true && connectionError == false)
                {
                    try
                    {
                        Bitmap image = camImage.ToBitmap(camImagePictureBox.Width, camImagePictureBox.Height);

                        if (darken == 1)
                        {
                            ImageFilters.BitmapFilter.Brightness(image, darkness);
                            //darken = 2;
                        }
                        if (darken == 0)
                        {
                            ImageFilters.BitmapFilter.Brightness(image, darkness);
                            //darken = 2;
                        }

                        if (greycale == true)
                            ImageFilters.BitmapFilter.GrayScale(image);

                        if (invert == true)
                            ImageFilters.BitmapFilter.Invert(image);

                        if (contrast == 1)
                        {
                            ImageFilters.BitmapFilter.Contrast(image, (sbyte)(contrastness));
                            //contrast = 2;
                        }
                        if (contrast == 0)
                        {
                            ImageFilters.BitmapFilter.Contrast(image, (sbyte)(contrastness));
                            //contrast = 2;
                        }

                        if (gamma == 1)
                        {
                            //10% = .48 when range is .2 to 5, median is 2.6
                            ImageFilters.BitmapFilter.Gamma(image, gammaness, gammaness, gammaness);
                        }
                        if (gamma == 0)
                        {
                            ImageFilters.BitmapFilter.Gamma(image, gammaness, gammaness, gammaness);
                        }

                        camImagePictureBox.Image = image;
                        this.Text = "Client - last updated: " + DateTime.Now.ToLongTimeString() + "     " + "H:" + image.Height.ToString() + " W:" + image.Width.ToString();

                        Bitmap resized = ResizeBitmap(image, 40, 30);
                        double currentStdDev = GetStdDev(resized);

                        //Log("Capture:" + DateTime.Now.ToLongTimeString());
                        //Log("Brightness:" + darkness);
                        //Log("Contrast:" + contrastness);
                        //Log("Gamma:" + gammaness);
                        //Log("StdDev:" + currentStdDev.ToString());
                        //Log("ImageDIFF:" + Math.Round(Math.Abs(currentStdDev - standardDev), 0).ToString());
                        //Log(Math.Round(Math.Abs(currentStdDev - standardDev), 0).ToString());

                        if (standardDev != 0)
                        {
                            if (Math.Abs(currentStdDev - standardDev) > alarmThreshold)
                            {
                                //alarm
                                if (alarmIsOn == false)
                                {
                                    alarmIsOn = true;

                                    alarmTimer.Start();
                                    DialogResult dr = MessageBox.Show("Someone is here.", "WebCam Detection!", MessageBoxButtons.OK);

                                    if (dr == DialogResult.OK)
                                    {
                                        alarmTimer.Stop();
                                        alarmIsOn = false;
                                    }
                                }
                            }
                        }

                        standardDev = currentStdDev;

                        SetLabelValues();
                    }
                    catch (Exception ex)
                    {
                        Log("Cannot convert and darken image. " + ex.Message);
                    }
                }
                else
                {
                    Log("Image was blank.");
                }
            }
            catch (SocketException se)
            {
                Log(se.Message);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            finally
            {
                if (connectionError == true)
                {
                    if (imageError == true)
                    {
                        Log("Could not modify image." + DateTime.Now.ToShortTimeString());
                    }
                    else
                    {
                        Log("Connection error at: " + DateTime.Now.ToShortTimeString());
                    }
                }

                connectionError = false;
                imageError = false;
            }
        }

        private void ClientForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();

            int picW = 320;
            int picH = 240;
            int formH = 523;
            int formW = 293;

            int newFormH = this.Height;
            int newFormW = this.Width;

            camImagePictureBox.Height = (newFormH - 53);
            camImagePictureBox.Width = (newFormW - 203);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void darkenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darken = 1;
            darkness = darkness - 10;
        }

        private void lightenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darken = 0;
            darkness = darkness + 10;
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (greycale == false)
                greycale = true;
            else
                greycale = false;
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invert == false)
                invert = true;
            else
                invert = false;
        }

        private void contrastUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contrast = 1;
            contrastness = contrastness + 10;
        }

        private void contrastDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contrast = 0;
            contrastness = contrastness - 10;
        }

        private void gammaUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamma = 1;
            gammaness = gammaness + .48; //10%
        }

        private void gammaDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamma = 0;
            gammaness = gammaness - .48; //10%
        }


        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 523;
            this.Height = 293;

            Rectangle screen = System.Windows.Forms.Screen.GetWorkingArea(new Point(0, 0));
            this.Location = new Point((screen.Width - 523), (screen.Height - 293));

            camImagePictureBox.Width = 320;
            camImagePictureBox.Height = 240;

            notifyIcon1_MouseDoubleClick(sender, null);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void camImagePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void camImagePictureBox_Resize(object sender, EventArgs e)
        {
            //listeningTimer.Stop();
            //listeningTimer.Start();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            remoteObject = null;
            requiredType = null;
            ChannelServices.UnregisterChannel(tcpChannel);
            tcpChannel = null;
        }

        ///Helper Methods

        private void Log(string message)
        {
            logTextBox.Text += Environment.NewLine;
            logTextBox.Text += message;
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        public static bool IsBlank(Bitmap imageFileName)
        {

            double stdDev = GetStdDev(imageFileName);

            return stdDev < 100000;

        }

        /// <summary>

        /// Get the standard deviation of pixel values.

        /// </summary>

        /// <param name="imageFileName">Name of the image file.</param>

        /// <returns>Standard deviation.</returns>
        public static double GetStdDev(Bitmap imageFileName)
        {
            double total = 0, totalVariance = 0;
            int count = 0;
            double stdDev = 0;

            // First get all the bytes
            using (Bitmap b = imageFileName)
            {
                BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, b.PixelFormat);
                int stride = bmData.Stride;
                IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - b.Width * 3;

                    for (int y = 0; y < b.Height; ++y)
                    {
                        for (int x = 0; x < b.Width; ++x)
                        {
                            count++;
                            byte blue = p[0];
                            byte green = p[1];
                            byte red = p[2];
                            int pixelValue = Color.FromArgb(0, red, green, blue).ToArgb();
                            total += pixelValue;
                            double avg = total / count;
                            totalVariance += Math.Pow(pixelValue - avg, 2);
                            stdDev = Math.Sqrt(totalVariance / count);
                            p += 3;
                        }
                        p += nOffset;
                    }
                }
                b.UnlockBits(bmData);
            }
            return stdDev;
        }

        //http://www.codeproject.com/KB/GDI-plus/csharpgraphicfilters11.aspx
        public static bool Darken(Bitmap b, int nBrightness)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB. 

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;
                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        int nVal = (int)(p[0] - (byte)nBrightness);

                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }

        ///Manual image control events
        
        private void lightenButton_Click(object sender, EventArgs e)
        {
            darken = 0;
            darkness = darkness + 10;
            SetLabelValues();
        }

        private void darkenButton_Click(object sender, EventArgs e)
        {
            darken = 1;
            darkness = darkness - 10;
            SetLabelValues();
        }

        private void gammaUpButton_Click(object sender, EventArgs e)
        {
            gamma = 1;
            if(gammaness > .2 && gammaness < 5)
                gammaness = gammaness + .48;
            SetLabelValues();
        }

        private void gammaDownButton_Click(object sender, EventArgs e)
        {
            gamma = 0;
            if (gammaness > .2 && gammaness < 5)
                gammaness = gammaness - .48;
            SetLabelValues();
        }

        private void contrastUpButton_Click(object sender, EventArgs e)
        {
            contrast = 1;
            contrastness = contrastness + 10;
            SetLabelValues();
        }

        private void contrastDownButton_Click(object sender, EventArgs e)
        {
            contrast = 0;
            contrastness = contrastness - 10;
            SetLabelValues();
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            CaptureImage();
            SetLabelValues();
        }

        protected void SetLabelValues()
        {
            brighnessLabel.Text = darkness.ToString();
            gammaLabel.Text = gammaness.ToString();
            contrastLabel.Text = contrastness.ToString();
        }

        
        /// Resize methods
        
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetToolStripMenuItem_Click(sender, e);
        }

        private void x480ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camImagePictureBox.Width = 640;
            camImagePictureBox.Height = 480;

            this.Width = camImagePictureBox.Width + 53;
            this.Height = camImagePictureBox.Height + 203;
        }

        private void x600ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camImagePictureBox.Width = 800;
            camImagePictureBox.Height = 600;

            this.Width = camImagePictureBox.Width + 53;
            this.Height = camImagePictureBox.Height + 203;
        }

        private void x768ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camImagePictureBox.Width = 1024;
            camImagePictureBox.Height = 768;

            this.Width = camImagePictureBox.Width + 53;
            this.Height = camImagePictureBox.Height + 203;
        }

        private void x960ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camImagePictureBox.Width = 1280;
            camImagePictureBox.Height = 960;

            this.Width = camImagePictureBox.Width + 53;
            this.Height = camImagePictureBox.Height + 203;
        }
    }
}
