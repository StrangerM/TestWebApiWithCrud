using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Interfaces
{
    public interface InterfaceIoTDataBaseProvidercs
    {
        public void AddToList(IoT io);

        public void PushToDb();

    }
}
