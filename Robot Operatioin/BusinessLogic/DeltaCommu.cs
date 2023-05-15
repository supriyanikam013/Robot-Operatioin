using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Operatioin.BusinessLogic
{
    class DeltaCommu
    {
        private const int READ_BUFFER_SIZE = 2048; // 2KB.

        private const int WRITE_BUFFER_SIZE = 2048; // 2KB.

        private byte[] bufferReceiver = null;
        private byte[] bufferSender = null;

        private Socket mSocket = null;

        private string IP = "";
        private int Port = 502;

        /// Connect to device   
        public string Connect(string ip)
        {
            string comm = "";

            try
            {
                this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.bufferReceiver = new byte[READ_BUFFER_SIZE];
                this.bufferSender = new byte[WRITE_BUFFER_SIZE];
                this.mSocket.SendBufferSize = READ_BUFFER_SIZE;  /// Send buffer size 2048
                this.mSocket.ReceiveBufferSize = WRITE_BUFFER_SIZE;  /// Receive buffer size 2048
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(ip), this.Port);
                this.mSocket.SendTimeout = 100;          //***hp
                this.mSocket.ReceiveTimeout = 100;      //***hp               
                this.mSocket.Connect(server);

                comm = "OK";
                return comm;
            }
            catch (Exception)
            {
                comm = "NOK";
                return comm;
            }

        }

        /// Disconnect with device  
        public void Disconnect()
        {
            if (this.mSocket == null) return;
            if (this.mSocket.Connected)
            {
                this.mSocket.Close();
            }
        }

        /// <summary>
        /// Function 03 (03hex) Read Holding Registers
        /// Read the binary contents of holding registers in the slave.
        /// </summary>
        /// <param name="id">Slave id</param>
        /// <param name="slaveAddress">Slave Address</param>
        /// <param name="startAddress">Starting Address</param>
        /// <param name="function">Function</param>
        /// <param name="numberOfPoints">Quantity of Registers</param>
        /// <returns>Byte Array</returns>
        /// 

        public byte[] ReadHoldingRegistersMsg(ushort id, byte slaveAddress, ushort startAddress, byte function, uint numberOfPoints)
        {
            byte[] frame = new byte[12];
            frame[0] = (byte)(id >> 8);	// Transaction Identifier High
            frame[1] = (byte)id; // Transaction Identifier Low
            frame[2] = 0; // Protocol Identifier High
            frame[3] = 0; // Protocol Identifier Low
            frame[4] = 0; // Message Length High
            frame[5] = 6; // Message Length Low(6 bytes to follow)
            frame[6] = slaveAddress; // Slave address(Unit Identifier)
            frame[7] = function; // Function             
            frame[8] = (byte)(startAddress >> 8); // Starting Address High
            frame[9] = (byte)startAddress; // Starting Address Low           
            frame[10] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            frame[11] = (byte)numberOfPoints; // Quantity of Registers Low
            return frame;
        }

        public byte[] WriteHoldingRegistersMsg(ushort id, byte slaveAddress, ushort startAddress, byte function, uint numberOfPoints, ushort[] data)
        {
            byte[] frame = new byte[13];
            frame[0] = (byte)(id >> 8);	// Transaction Identifier High
            frame[1] = (byte)id; // Transaction Identifier Low
            frame[2] = 0; // Protocol Identifier High
            frame[3] = 0; // Protocol Identifier Low
            frame[4] = 0; // Message Length High

            //frame[5] =  frame[6] to frame[12]  7 + data * 2 
            byte msg_len = Convert.ToByte(7 + data.Length * 2);  //frame[5] =  frame[6] to frame[12]  7 + data * 2 
            frame[5] = msg_len; // Message Length Low(6 bytes to follow) 
            frame[6] = slaveAddress; // Slave address(Unit Identifier)
            frame[7] = function; // Function             
            frame[8] = (byte)(startAddress >> 8); // Starting Address High
            frame[9] = (byte)startAddress; // Starting Address Low           
            frame[10] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            frame[11] = (byte)numberOfPoints; // Quantity of Registers Low

            //frame[12] =  data * 2 \\ length of data
            byte data_length = Convert.ToByte(data.Length * 2);
            frame[12] = data_length; // length of data*2

            // create array of size data * 2
            byte[] data_byte = new byte[data_length];
            int j = 0;   // create j for assign data

            for (int i = 0; i < data.Length; i++)
            {
                data_byte[j] = (byte)(data[i] >> 8); // Quantity of Registers High
                data_byte[j + 1] = (byte)data[i]; // Quantity of Registers Low
                j = j + 2; // increment j by 2
            }

            frame = frame.Concat(data_byte).ToArray(); // concat two array frame + data_array 

            return frame;

            //byte[] frame = new byte[17];
            //frame[0] = (byte)(id >> 8);	// Transaction Identifier High
            //frame[1] = (byte)id; // Transaction Identifier Low
            //frame[2] = 0; // Protocol Identifier High
            //frame[3] = 0; // Protocol Identifier Low
            //frame[4] = 0; // Message Length High
            //frame[5] = 11; // Message Length Low(6 bytes to follow)
            //frame[6] = slaveAddress; // Slave address(Unit Identifier)
            //frame[7] = function; // Function             
            //frame[8] = (byte)(startAddress >> 8); // Starting Address High
            //frame[9] = (byte)startAddress; // Starting Address Low           
            //frame[10] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            //frame[11] = (byte)numberOfPoints; // Quantity of Registers Low
            //frame[12] = 4;
            //frame[13] = 0;
            //frame[14] = 5;
            //frame[15] = 0;
            //frame[16] = 6;

            //return frame;
        }

        public ushort[] ReadHoldingRegisters(ref string plc_data_read_status, ushort id, byte slaveAddress, ushort startAddress, byte function, uint numberOfPoints)
        {
            byte[] frame = new byte[12];
            frame[0] = (byte)(id >> 8);	// Transaction Identifier High
            frame[1] = (byte)id; // Transaction Identifier Low
            frame[2] = 0; // Protocol Identifier High
            frame[3] = 0; // Protocol Identifier Low
            frame[4] = 0; // Message Length High
            frame[5] = 6; // Message Length Low(6 bytes to follow)
            frame[6] = slaveAddress; // Slave address(Unit Identifier)
            frame[7] = function; // Function             
            frame[8] = (byte)(startAddress >> 8); // Starting Address High
            frame[9] = (byte)startAddress; // Starting Address Low           
            frame[10] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            frame[11] = (byte)numberOfPoints; // Quantity of Registers Low

            ushort[] temp = null;

            try
            {
                int a = Write(frame); // Send message
                                      //Thread.Sleep(100); // Delay 100ms

                byte[] buffReceiver = Read(); // Receive messages                         

                // Process data.
                int SizeByte = buffReceiver[8]; // The data bytes received.


                if (function != buffReceiver[7])
                {
                    byte[] byteMsg = new byte[9];
                    Array.Copy(buffReceiver, 0, byteMsg, 0, byteMsg.Length);
                    byte[] data = new byte[SizeByte];
                    //txtReceiMsg.Text = commuAuto.Display(byteMsg);
                    //string ReceiMsg = commuAuto.Display(byteMsg);

                    byte[] errorbytes = new byte[3];
                    Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                    CheckValidate(errorbytes); // Check validate
                }
                else
                {
                    byte[] byteMsg = new byte[9 + SizeByte];
                    Array.Copy(buffReceiver, 0, byteMsg, 0, byteMsg.Length);
                    byte[] data = new byte[SizeByte];
                    // txtReceiMsg.Text = Display(byteMsg); // Show received messages                    
                    Array.Copy(buffReceiver, 9, data, 0, data.Length);
                    //temp = Word.ConvertByteArrayToWordArray(data);
                }

                plc_data_read_status = "OK"; //ref plc_data_read_status return "OK" if no error
                return temp;

            }
            catch (Exception ex)
            {
                plc_data_read_status = ex.Message; //ref plc_data_read_status return ex.meaasge if  error occure
                return temp;
            }


        }

        public ushort[] WriteHoldingRegisters(ref string plc_data_write_status, ushort id, byte slaveAddress, ushort startAddress, byte function, uint numberOfPoints, ushort[] data_write)
        {
            byte[] frame = new byte[13];
            frame[0] = (byte)(id >> 8);	// Transaction Identifier High
            frame[1] = (byte)id; // Transaction Identifier Low
            frame[2] = 0; // Protocol Identifier High
            frame[3] = 0; // Protocol Identifier Low
            frame[4] = 0; // Message Length High

            //frame[5] =  frame[6] to frame[12]  7 + data * 2 
            byte msg_len = Convert.ToByte(7 + data_write.Length * 2);  //frame[5] =  frame[6] to frame[12]  7 + data * 2 
            frame[5] = msg_len; // Message Length Low(6 bytes to follow) 
            frame[6] = slaveAddress; // Slave address(Unit Identifier)
            frame[7] = function; // Function             
            frame[8] = (byte)(startAddress >> 8); // Starting Address High
            frame[9] = (byte)startAddress; // Starting Address Low           
            frame[10] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            frame[11] = (byte)numberOfPoints; // Quantity of Registers Low

            //frame[12] =  data * 2 \\ length of data
            byte data_length = Convert.ToByte(data_write.Length * 2);
            frame[12] = data_length; // length of data*2

            // create array of size data * 2
            byte[] data_byte = new byte[data_length];
            int j = 0;   // create j for assign data

            for (int i = 0; i < data_write.Length; i++)
            {
                data_byte[j] = (byte)(data_write[i] >> 8); // Quantity of Registers High
                data_byte[j + 1] = (byte)data_write[i]; // Quantity of Registers Low
                j = j + 2; // increment j by 2
            }

            frame = frame.Concat(data_byte).ToArray(); // concat two array frame + data_array 


            ushort[] temp = null;
            try
            {
                int a = Write(frame); // Send message
                //Thread.Sleep(100); // Delay 100ms
                byte[] buffReceiver = Read(); // Receive messages                         

                // Process data.
                int SizeByte = buffReceiver[8]; // The data bytes received.


                if (function != buffReceiver[7])
                {
                    byte[] byteMsg = new byte[9];
                    Array.Copy(buffReceiver, 0, byteMsg, 0, byteMsg.Length);
                    byte[] data = new byte[SizeByte];
                    //txtReceiMsg.Text = commuAuto.Display(byteMsg);
                    //string ReceiMsg = commuAuto.Display(byteMsg);

                    byte[] errorbytes = new byte[3];
                    Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                    CheckValidate(errorbytes); // Check validate
                }
                else
                {
                    byte[] byteMsg = new byte[9 + SizeByte];
                    Array.Copy(buffReceiver, 0, byteMsg, 0, byteMsg.Length);
                    byte[] data = new byte[SizeByte];
                    //txtReceiMsg.Text = Display(byteMsg); // Show received messages
                    //string ReceiMsg = commuAuto.Display(byteMsg);// Show received messages
                    Array.Copy(buffReceiver, 9, data, 0, data.Length);
                    //temp = Word.ConvertByteArrayToWordArray(data);
                }

                plc_data_write_status = "OK"; //ref plc_data_write_status return "OK" if no error
                return temp;

            }
            catch (Exception ex)
            {
                plc_data_write_status = ex.Message; //ref plc_data_write_status return ex.meaasge if  error occure
                return temp;
            }


        }

        /// <summary>
        /// Write data
        /// </summary>
        /// <param name="frame">Frame communication</param>
        /// <returns>int</returns>
        /// 

        public int Write(byte[] frame)
        {
            return this.mSocket.Send(frame, frame.Length, SocketFlags.None);
        }

        /// <summary>
        /// Read Data
        /// </summary>
        /// <returns>byte array</returns>
        /// 

        public byte[] Read()
        {
            NetworkStream ns = new NetworkStream(this.mSocket);
            if (ns.CanRead)
            {
                int rs = this.mSocket.Receive(this.bufferReceiver, this.bufferReceiver.Length, SocketFlags.None);
            }
            return this.bufferReceiver;



            // Check to see if this NetworkStream is readable. 



            //NetworkStream myNetworkStream = new NetworkStream(this.mSocket);
            //byte[] myReadBuffer = new byte[1024];
            //if (myNetworkStream.CanRead)
            //{

            //    StringBuilder myCompleteMessage = new StringBuilder();
            //    int numberOfBytesRead = 0;

            //    // Incoming message may be larger than the buffer size. 
            //    do
            //    {
            //        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

            //        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

            //    }
            //    while (myNetworkStream.DataAvailable);

            //    // Print out the received message to the console.
            //    Console.WriteLine("You received the following message : " +
            //                                 myCompleteMessage);
            //}
            //else
            //{
            //    Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            //}
            //return myReadBuffer;



            //NetworkStream myNetworkStream = new NetworkStream(this.mSocket);
            //byte[] myReadBuffer = new byte[1024];
            //// Check to see if this NetworkStream is readable.
            //if (myNetworkStream.CanRead)
            //{

            //    StringBuilder myCompleteMessage = new StringBuilder();
            //    int numberOfBytesRead = 0;

            //    // Incoming message may be larger than the buffer size.
            //    do
            //    {
            //        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

            //        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
            //    }
            //    while (myNetworkStream.DataAvailable);

            //    // Print out the received message to the console.
            //    Console.WriteLine("You received the following message : " +
            //                                 myCompleteMessage);
            //}
            //else
            //{
            //    Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            //}

            //return myReadBuffer;

        }

        /// <summary>
        /// Check validate
        /// </summary>
        /// <param name="messageReceived">frame</param>
        /// 

        public string CheckValidate(byte[] messageReceived)
        {
            string erroMsg = "";

            try
            {
                switch (messageReceived[1])
                {

                    case 129: // Hex: 81                     
                    case 130: // Hex: 82 
                    case 131: // Hex: 83 
                    case 132: // Hex: 83 
                    case 133: // Hex: 84 
                    case 134: // Hex: 86 
                    case 143: // Hex: 8F 
                    case 144: // Hex: 90
                        break;
                }
                switch (messageReceived[2])
                {
                    case 1:
                        erroMsg = "01/0x01: Illegal Function.";
                        break;
                    case 2:
                        erroMsg = "02/0x02: Illegal Data Address.";
                        break;
                    case 3:
                        erroMsg = "03/0x03: Illegal Data Value.";
                        break;
                    case 4:
                        erroMsg = "04/0x04: Failure In Associated Device.";
                        break;
                    case 5:
                        erroMsg = "05/0x05: Acknowledge.";
                        break;
                    case 6:
                        erroMsg = "06/0x06: Slave Device Busy.";
                        break;
                    case 7:
                        erroMsg = "07/0x07: NAK – Negative Acknowledgements.";
                        break;
                    case 8:
                        erroMsg = "08/0x08: Memory Parity Error.";
                        break;
                    case 10:
                        erroMsg = "10/0x0A: Gateway Path Unavailable.";
                        break;
                    case 11:
                        erroMsg = "11/0x0B: Gateway Target Device Failed to respond.";
                        //default:
                        break;
                }

                return erroMsg;




            }
            catch (Exception ex)
            {
                return erroMsg = ex.Message;
            }
        }

        /// <summary>
        /// Display Data
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Message</returns>
        /// 

        public string Display(byte[] data)
        {
            string result = string.Empty;
            foreach (var item in data)
            {
                result += string.Format("{0:X2}", item);
            }
            return result;
        }

    }
}
