using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedSensors
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var r = new Random();
            var iothubDC = DeviceClient.CreateFromConnectionString("{UseYourDeviceConnectionStringHere}");

            while (true)
            { 
                var messageString = "{\"time\":\""+DateTime.Now+"\",\"temperature\":" + r.Next(10).ToString() + ",\"flow\":" + r.Next(10).ToString() + "}";
                Console.WriteLine("Sending message:" + messageString);
                Message iotHubMessage = new Message(Encoding.UTF8.GetBytes(messageString));
                await iothubDC.SendEventAsync(iotHubMessage);
                await Task.Delay(5000);
            }
        }
    }
}
