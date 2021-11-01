using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.BLL;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/iot")]
    [ApiController]
    public class IoTHandlerController : ControllerBase
    {
        private readonly InterfaceIoTDataBaseProvidercs _data;

        public IoTHandlerController(InterfaceIoTDataBaseProvidercs data)
        {
            _data = data;
        }

        [HttpPost]
        public JsonResult IoTAdd(IoT io)
        {
            if (io is null)
            {
                return new JsonResult(StatusCodes.Status400BadRequest);
            }

            Task task = Task.Factory.StartNew(() =>
            {
                    _data.AddToList(io);
            });

            Task task1 = Task.Factory.StartNew(() =>
            {
                _data.PushToDb();
            });

            return new JsonResult(io)
            {
                StatusCode = 200
            };
        }
    }
}
