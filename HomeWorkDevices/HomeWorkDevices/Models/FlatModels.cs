using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
    public class FlatModels
    {
        public List<Devices> Devices{ get; set; }
        public Socket Socket { get; set; }

        public FlatModels(Socket socket)
        {
            Socket = socket;
            Devices = new List<Devices>();
        }
    }
   
}

