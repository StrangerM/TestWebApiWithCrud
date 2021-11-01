using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.Interfaces;
using System.IO;

namespace TestWebApi.BLL
{
    public class IoTDataBaseProvider : InterfaceIoTDataBaseProvidercs
    {
        static ManualResetEvent manualReset = new ManualResetEvent(true);

        readonly ConcurrentBag<IoT> ioTs = new ConcurrentBag<IoT>();

        private static object _locker = new object();

        public void  AddToList(IoT io)
        {
            if (io is null)
            {
                return;
            }

            ioTs.Add(io);

            manualReset.WaitOne();
        }

        public void PushToDb()
        {
            Thread.Sleep(5000);

            manualReset.Set();

            lock (_locker)
            {
                List<string> temp = new List<string>();
                foreach (var item in ioTs)
                {
                    temp.Add($"Got signal from sensor {item.Name} with Id:{item.Id} and temp:{item.Temp}");
                }

                File.AppendAllLines("data.txt", temp);
                ioTs.Clear();
            }

           manualReset.Reset();
        }
    }
}
