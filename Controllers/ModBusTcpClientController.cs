using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Sockets;
using System.Text;

namespace kayahome_backend.Controllers
{
    public class ModBusTcpClientController : BaseController
    {
        [Route("TcpConnection")]
        [HttpGet]
        public IActionResult TcpConnection()
        {
            Byte[] data =
            {
                0x00,0x01,
                0x00,0x00,
                0x00,0x06,
                0x00,
                0x01,
                0x00,0x00,
                0x00,0x01
            };

            Byte[] rData = new byte[11];

            TcpClient tcpClient = new TcpClient();

            UdpClient udpClient = new UdpClient();

            udpClient.Connect("127.0.0.1", 80);
            udpClient.Send(data, data.Length);
            udpClient.Close();

            try
            {
                tcpClient.Connect("192.168.0.3", 502);
                if(tcpClient != null)
                {
                    if(tcpClient.Connected)
                    {
                        NetworkStream networkStream = tcpClient.GetStream();
                        networkStream.Write(data, 0, data.Length);
                        while(true)
                        {
                            int bytes = networkStream.Read(rData, 0, rData.Length);
                            if(bytes > 0)
                            {
                                var sb = new StringBuilder(rData.Length*2);
                                var i = 0;
                                foreach (var b in rData)
                                {
                                    i++;
                                    if (!(i == rData.Length))
                                    {
                                        sb.AppendFormat("0x{0:x2}-", b);
                                    }
                                    else
                                    {
                                        sb.AppendFormat("0x{0:x2}", b);
                                    }
                                }

                                //Console.WriteLine($"Gelen Data :{sb}");

                                networkStream.Close();
                                tcpClient.Close();

                                return CreatedAtRoute(201, "ModBus Response: " + sb.ToString());
                            }
                        }
                    }
                }

                return CreatedAtRoute(403, "TCP Not Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
