using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace read_usb
{
    class Program
    {
        // Create the serial port with basic settings
        private static SerialPort port = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

        [STAThread]
        static void Main(string[] args)
        {
            SerialPortProgram();
            //SerialPort.GetPortNames()
        }

        private static void SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications 
            port.Open();
            // Enter an application loop to keep this thread alive 
            
        writeGT:
            string writeData = Console.ReadLine();

            port.WriteLine(writeData);

            goto writeGT;

        }

        private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine(port.ReadExisting());
        }
    }
}
