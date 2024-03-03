namespace HomeWorkDevices.Models
{
    public class Socket
    {
        public bool IsSwitchedOn { get; set; }
        public Device? ConnectedDevice { get;  set; }

        public Socket()
        {
        }

        public event Action<Device> DeviceConnected;

        public event Action<Device> DeviceDisconnected;

        public void ConnectDevice(Device device)
        {
            if (IsSwitchedOn)
            {
                ConnectedDevice = device;
                DeviceConnected?.Invoke(device);
            }
            else
            {
                Console.WriteLine("Cannot connect device. The socket is switched off.");
            }
        }

        public void DisconnectDevice()
        {
            var disconnectedDevice = ConnectedDevice;
            ConnectedDevice = null;
            DeviceDisconnected?.Invoke(disconnectedDevice);
        }
    }

}

