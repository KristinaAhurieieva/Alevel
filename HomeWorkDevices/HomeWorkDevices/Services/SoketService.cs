using HomeWorkDevices.Models;

namespace HomeWorkDevices.Services
{
    public class SocketService
    {
        public Socket _socket;

        public SocketService()
        {
            _socket = new Socket();
        }

        public void ConnectDevice(Device device)
        {
            if (_socket.IsSwitchedOn)
            {
                _socket.ConnectedDevice = device;
                Console.WriteLine($"Device {device.Name} is connected to the socket.");
            }
            else
            {
                Console.WriteLine("Cannot connect device. The socket is switched off.");
            }
        }

        public void DisconnectDevice()
        {
            if (_socket.ConnectedDevice != null)
            {
                Console.WriteLine($"Device {_socket.ConnectedDevice.Name} is disconnected from the socket.");
                _socket.ConnectedDevice = null;
            }
            else
            {
                Console.WriteLine("No device is connected to the socket.");
            }
        }

        public void SwitchOn()
        {
            _socket.IsSwitchedOn = true;
            Console.WriteLine("The socket is switched on.");
        }

        public void SwitchOff()
        {
            DisconnectDevice();
            _socket.IsSwitchedOn = false;
            Console.WriteLine("The socket is switched off.");
        }
    }
}


