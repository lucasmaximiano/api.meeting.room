using Api.MeetingRoom.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Test
{
    [TestFixture]
    public class MeetingRoomScheduling
    {

        private readonly TestServer _server;
        private readonly HttpClient _httpClient;

        public MeetingRoomScheduling()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _httpClient = _server.CreateClient();
        }


        [Test]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        public async Task GetMeetingRoomSchedulingWithSucess(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroomscheduling?page={page}&pagesize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase(0, 10)]
        public async Task GetMeetingRoomSchedulingWithInvalidPageAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroomscheduling?page={page}&pagesize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Test]
        [TestCase(1, 0)]
        public async Task GetMeetingRoomSchedulingWithInvalidPageSizeAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroomscheduling?page={page}&pagesize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }



        [Test]
        [TestCase(0)]
        public async Task GetMeetingRoomSchedulingByIdWithInvalidIdAndBadRequest(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroomscheduling/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Test]
        [TestCase(-1)]
        public async Task GetMeetingRoomSchedulingByIdWithNotFound(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroomscheduling/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }



        [Test]
        public async Task PostMeetingRoomSchedulingWithoutNumberAndBadRequest()
        {

            var meetingRoomScheduling = new MeetingRoomSchedulingDTO
            {
                Date = DateTime.UtcNow,
                Hour = RangeOfHoursEnum.NinetOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoomScheduling), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/meetingroomscheduling", json);

            Assert.IsNotNull(response.Content);

        }


        [TestCase(1)]
        public async Task PutMeetingRoomSchedulingWithoutNumberAndBadRequest(int id)
        {

            var meetingRoomScheduling = new MeetingRoomSchedulingDTO
            {
                Date = DateTime.UtcNow,
                Hour = RangeOfHoursEnum.NinetOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoomScheduling), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/meetingroomscheduling/{id}", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        [TestCase(-1)]
        public async Task DeleteMeetingRoomSchedulingByIdNotFound(int id)
        {
            var response = await _httpClient.DeleteAsync($"/meetingroomscheduling/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
