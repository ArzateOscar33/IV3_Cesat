using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keyence.IV3.Sdk;
using System.Net;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;


namespace IV3_CESAT
{
    public partial class Form1 : Form
    {
        //declaramos las variables necesarias 
        Size IMAGE_SIZE = new Size(1280, 960);//1280, 960
        VisionSensorStore store = new VisionSensorStore();
        IVisionSensor camara;

        //
        // byte[]  ipAddressCamara= { 169, 254, 109, 199 };

        private bool _enableIpAddress;
        private bool _enablePortNo;

        public IPAddress IpAddress { private set; get; }
        public ushort PortNo { private set; get; }

        public string RawIpAddress
        {
            set { _maskedTextBoxIpAddress.Text = value; }
            get { return _maskedTextBoxIpAddress.Text; }
        }

        public string RawPortNo
        {
            set { _textBoxPortNo.Text = value; }
            get { return _textBoxPortNo.Text; }
        }

        private bool EnableAddress
        {
            get { return _enableIpAddress && _enablePortNo; }
        }


        public Form1()
        {
            InitializeComponent();
            Conexion();

            //
            string ipAddressLocal = GetEthernetIPAddress();
            ShowIPAddressInTextBox(ipAddressLocal);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IpAddressValidating();
           // PortNoValidating();
        }
        private void Conexion()
        {
            try
            {
                byte[] ipAddressLocal = GetEthernetIPAddressByte() ;
                IPAddress ipLocal = new IPAddress(ipAddressLocal);
                VisionSensorStore.StartPoint = ipLocal;

                byte[] ipAddressCamara = { 169, 254, 206, 36 };
                IPAddress ipCamara = new IPAddress(ipAddressCamara);
                camara = store.Create(ipCamara, 63000);

              
            }
            catch { }


        }//metodoConexion
        private void IniciarCamara()
        {
            camara.EventEnable = true;
            camara.ResultUpdated += EventoResultadoCamara;
            camara.ImageAcquired += EventoImagenCamara;

            timer_camara.Start();
        }

        private void EventoImagenCamara(object sender, ImageAcquiredEventArgs e)
        {
            var image = new Bitmap(IMAGE_SIZE.Width, IMAGE_SIZE.Height, PixelFormat.Format24bppRgb);
            BitmapData lockData = image.LockBits(new Rectangle(Point.Empty, IMAGE_SIZE), ImageLockMode.WriteOnly,
                                                 PixelFormat.Format24bppRgb);
            Marshal.Copy(e.LiveImage.ByteData, 0, lockData.Scan0, e.LiveImage.ByteData.Length);
            image.UnlockBits(lockData);
            if (_pictureBox.Image != null)
            {
                _pictureBox.Image.Dispose();
            }
            using (Graphics marcador = Graphics.FromImage(image))
            {
                marcador.SmoothingMode = SmoothingMode.AntiAlias;
                for (byte i = 0; i < 64; i++)
                {
                    camara.DrawWindow(marcador, Color.Green, Color.Red, i);
                }
            }



            _pictureBox.Image = image;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IniciarCamara();
           
        }

        private void timer_camara_Tick(object sender, EventArgs e)
        {
            //
            camara.TickTack();
            // label_programa.Text = camara.ActiveProgram.ProgramName;

            /* if (camara.Errors.Length > 0)
             {
                 label_error.Text = camara.Errors[0].Description;
                 label_error.ForeColor = Color.Red;
                 label_error.Visible = true;

                 //limpiar errores
                 camara.ClearError(camara.Errors[0]);

             }
             else
             {
                 if (label_error.Visible)
                 {
                     label_error.Text = "";
                     label_error.Visible = false;
                 }
             }*/
        }

        private void EventoResultadoCamara(object sender, ToolResultUpdatedEventArgs e)
        {
            if (e.TotalStatusResult)
            {
                label_ok.Text = "OK";
                label_ok.ForeColor = Color.Lime;
            }
            else
            {
                label_ok.Text = "NOK";
                label_ok.ForeColor = Color.Red;
            }
        }

        static string GetEthernetIPAddress()
        {
            // Buscar todas las interfaces de red
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Filtrar por interfaces Ethernet
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // Obtener la primera dirección IPv4 asociada a la interfaz Ethernet
                    UnicastIPAddressInformationCollection ipAddresses = networkInterface.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipAddressInfo in ipAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ipAddressInfo.Address.ToString();
                        }
                    }
                }
            }

            // Si no se encuentra una interfaz Ethernet con dirección IPv4, puedes devolver un valor predeterminado o manejarlo de otra manera
            return "No se encontró la dirección IP";
        }
        static byte[] GetEthernetIPAddressByte()
        {
            // Buscar todas las interfaces de red
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Filtrar por interfaces Ethernet
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // Obtener la primera dirección IPv4 asociada a la interfaz Ethernet
                    UnicastIPAddressInformationCollection ipAddresses = networkInterface.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipAddressInfo in ipAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            // Convertir la dirección IP a un array de bytes y retornarlo
                            return ipAddressInfo.Address.GetAddressBytes();
                        }
                    }
                }
            }

            // Si no se encuentra una interfaz Ethernet con dirección IPv4, puedes devolver un valor predeterminado o manejarlo de otra manera
            return new byte[0]; // Retorna un array vacío como valor predeterminado
        }

        public void ShowIPAddressInTextBox(string ipAddress)
        {
            // Acceder al TextBox (asegúrate de tener un TextBox llamado txbIpMaestro en tu formulario)
            //  TextBox txbIpMaestro = new TextBox(); // Este es un ejemplo, asegúrate de que sea el TextBox correcto en tu aplicación
            _maskedTextBoxIpAddress.Text = ipAddress;
            // Puedes asignar la propiedad Text del TextBox directamente al valor de la dirección IP
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void IpAddressValidating()
        {
            const int ipAddressPartsCount = 4;
            MatchCollection match = Regex.Matches(_maskedTextBoxIpAddress.Text, "[0-9]+");
            if (match.Count != ipAddressPartsCount)
            {
                SetIpAddressDisable();
                return;
            }
            var ipParts = new byte[ipAddressPartsCount];
            for (int i = 0; i < ipAddressPartsCount; i++)
            {
                bool successParse = byte.TryParse(match[i].ToString(), out ipParts[i]);
                if (successParse) continue;
                SetIpAddressDisable();
                return;
            }
            errorProvider.Clear();
            IpAddress = new IPAddress(ipParts);
            _enableIpAddress = true;
        }
        private void SetIpAddressDisable()
        {
            errorProvider.SetError(_maskedTextBoxIpAddress, "Error");
            _enableIpAddress = false;
        }
    }

  
}
