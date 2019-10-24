using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Api.MeetingRoom.Test
{
    [TestFixture]
    public class MeetingRoomTest
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public MeetingRoomTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
       
        [Test]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        public async Task GetMusicRecordByFilterWithSucess(int page, int pageSize)
        {
            try
            {
                var response = await _client.GetAsync($"/meetingroom?page={page}&pageSize={pageSize}");

                Assert.IsNotNull(response.Content);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
