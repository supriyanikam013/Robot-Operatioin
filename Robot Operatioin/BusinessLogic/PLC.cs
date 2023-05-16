using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using static CYGNII_Operations_management.BusinessLogic.ApplicationLogic;

namespace Robot_Operatioin.BusinessLogic
{
    class PLC
    {
        public string IP
        { get; set; }
        public CPU_Type CPU_type
        { get; set; }
        public Int16 Rack
        { get; set; }

        public Int16 Slot
        { get; set; }

        public string Name
        { get; set; }

        public object Tag
        { get; set; }
        public bool IsAvailable
        {
            get
            {
                Ping ping = new Ping();
                PingReply result = ping.Send(IP);
                if (result.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
        }

        public ExceptionCode lastErrorCode = 0;
        public string lastErrorString;

        public bool IsConnected = false;
        public int LastReadTime = 0;
        public int LastWriteTime = 0;

        // Privates
        private Socket mSocket;


        public PLC()
        {
            IP = "localhost";
            CPU_type = CPU_Type.S7400;
        
            Rack = 0;
            Slot = 3;
        }
        public PLC(CPU_Type cpu, string ip, Int16 rack, Int16 slot)
        {
            this.IP = ip;
            this.CPU_type = cpu;
            this.Rack = rack;
            this.Slot = slot;
        }

        public PLC(CPU_Type cpu, string ip, Int16 rack, Int16 slot, string name, object tag)
        {
            IP = ip;
            CPU_type = cpu;
            Rack = rack;
            Slot = slot;
            Name = name;
            Tag = tag;
        }

        #region Connection (Open, Close)
        public ExceptionCode Open()
        {
            byte[] bReceive = new byte[256];

            try
            {
                // check if available
                Ping p = new Ping();
                PingReply pingReplay = p.Send(IP);
                if (pingReplay.Status != IPStatus.Success)
                    throw new Exception();
            }
            catch
            {
                lastErrorCode = ExceptionCode.IPAdressNotAvailable;
                //lastErrorString = "Destination IP-Address '" + IP + "' is not available!";
                lastErrorString = "Địa chỉ IP '" + IP + "' không tồn tại!";
                return lastErrorCode;
            }

            try
            {
                // open the channel
                mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
                mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 3000);

                IPEndPoint _server = new IPEndPoint(new IPAddress(IPToByteArray(IP)), 102);
                //Dns.GetHostEntry(mIP).AddressList(0), 102)
                IPEndPoint _local = new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 102);
                mSocket.Connect(_server);
            }
            catch (Exception ex)
            {
                lastErrorCode = ExceptionCode.ConnectionError;
                lastErrorString = ex.Message;
                return ExceptionCode.ConnectionError;
            }

            #region cputype method
            //try
            //{
            //    byte[] bSend1 = { 3, 0, 0, 22, 17, 224, 0, 0, 0, 46,
            //        0, 193, 2, 1, 0, 194, 2, 3, 0, 192,
            //        1, 9 };
            //    switch (CPU_type)
            //    {
            //        case CPU_Type.S7200:
            //            //S7200: Chr(193) & Chr(2) & Chr(16) & Chr(0) 'Eigener Tsap
            //            bSend1[11] = 193;
            //            bSend1[12] = 2;
            //            bSend1[13] = 16;
            //            bSend1[14] = 0;
            //            //S7200: Chr(194) & Chr(2) & Chr(16) & Chr(0) 'Fremder Tsap
            //            bSend1[15] = 194;
            //            bSend1[16] = 2;
            //            bSend1[17] = 16;
            //            bSend1[18] = 0;
            //            break;
            //        //case CPU_Type.S71200:
            //        case CPU_Type.S7300:
            //            //S7300: Chr(193) & Chr(2) & Chr(1) & Chr(0)  'Eigener Tsap
            //            bSend1[11] = 193;
            //            bSend1[12] = 2;
            //            bSend1[13] = 1;
            //            bSend1[14] = 0;
            //            //S7300: Chr(194) & Chr(2) & Chr(3) & Chr(2)  'Fremder Tsap
            //            bSend1[15] = 194;
            //            bSend1[16] = 2;
            //            bSend1[17] = 3;
            //            bSend1[18] = (byte)(Rack * 2 * 16 + Slot);
            //            break;
            //        case CPU_Type.S7400:
            //            //S7400: Chr(193) & Chr(2) & Chr(1) & Chr(0)  'Eigener Tsap
            //            bSend1[11] = 193;
            //            bSend1[12] = 2;
            //            bSend1[13] = 1;
            //            bSend1[14] = 0;
            //            //S7400: Chr(194) & Chr(2) & Chr(3) & Chr(3)  'Fremder Tsap
            //            bSend1[15] = 194;
            //            bSend1[16] = 2;
            //            bSend1[17] = 3;
            //            bSend1[18] = (byte)(Rack * 2 * 16 + Slot);
            //            break;
            //        default:
            //            return ExceptionCode.WrongCPU_Type;
            //    }
            //    mSocket.Send(bSend1, 22, SocketFlags.None);

            //    if (mSocket.Receive(bReceive, 22, SocketFlags.None) != 22) throw new Exception(ExceptionCode.WrongNumberReceivedBytes.ToString());

            //    byte[] bsend2 = { 3, 0, 0, 25, 2, 240, 128, 50, 1, 0,
            //        0, 255, 255, 0, 8, 0, 0, 240, 0, 0,
            //        3, 0, 3, 1, 0 };
            //    mSocket.Send(bsend2, 25, SocketFlags.None);

            //    if (mSocket.Receive(bReceive, 27, SocketFlags.None) != 27) throw new Exception(ExceptionCode.WrongNumberReceivedBytes.ToString());
            //    IsConnected = true;
            //}
            //catch
            //{
            //    lastErrorCode = ExceptionCode.ConnectionError;
            //    //lastErrorString = "Couldn't establish the connection!";
            //    lastErrorString = "Không thể thành lập được kết nối tới PLC!";
            //    IsConnected = false;
            //    return ExceptionCode.ConnectionError;
            //}
            #endregion

            return ExceptionCode.ExceptionNo;
            // ok
        }

        public void Close()
        {
            if (mSocket.Connected)
            {
                mSocket.Close();
                IsConnected = false;
            }
        }

        private byte[] IPToByteArray(string ip)
        {
            byte[] v = new byte[4];
            string txt = ip;
            string txt2 = null;
            try
            {
                txt2 = txt.Substring(0, txt.IndexOf("."));
                v[0] = byte.Parse(txt2);
                txt = txt.Substring(txt2.Length + 1);

                txt2 = txt.Substring(0, txt.IndexOf("."));
                v[1] = byte.Parse(txt2);
                txt = txt.Substring(txt2.Length + 1);

                txt2 = txt.Substring(0, txt.IndexOf("."));
                v[2] = byte.Parse(txt2);
                txt = txt.Substring(txt2.Length + 1);

                v[3] = byte.Parse(txt);
                return v;
            }
            catch
            {
                v[0] = 0;
                v[1] = 0;
                v[2] = 0;
                v[3] = 0;
                return v;
            }
        }
        #endregion


        #region Read(string variable)
     public object Read(string var)
        {
            return var;
        }
        #endregion

    }


}
