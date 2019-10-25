using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Api.MeetingRoom.DTO;

namespace Api.MeetingRoom.Test
{
    [TestFixture]
    public class MeetingRoomTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _httpClient;

        public MeetingRoomTest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _httpClient = _server.CreateClient();
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        public async Task GetMeetingRoomWithSucess(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pageSize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase(0, 10)]
        public async Task GetMeetingRoomWithInvalidPageAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pageSize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("A página é um campo obrigatório e deve ser diferente de 0", response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(1, 0)]
        public async Task GetMeetingRoomWithInvalidPageSizeAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pageSize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("A quantidade de itens por página é um campo obrigatório e deve ser diferente de 0", response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(1)]
        public async Task GetMeetingRoomByIdWithSucess(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase(0)]
        public async Task GetMeetingRoomByIdWithInvalidIdAndBadRequest(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O Id e um campo obrigatório e deve ser diferente de 0", response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(9999)]
        public async Task GetMeetingRoomByIdWithNotFound(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task PostMeetingRoomWithSucess()
        {

            var meetingRoom = new MeetiingRommDTO
            {
                Name = "Las Vegas",
                Number = 1,
                Date = DateTime.UtcNow,
                Hour = RangeOfHoursEnumDTO.EightOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task PostMeetingRoomWithoutNameAndBadRequest()
        {
            var meetingRoom = new MeetiingRommDTO
            {
                Name = null,
                Number = 1,
                Date = DateTime.UtcNow,
                Hour = RangeOfHoursEnumDTO.EightOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O nome da sala é um campo obrigatório", response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task PostMeetingRoomWithoutNumberAndBadRequest()
        {

            var meetingRoom = new MeetiingRommDTO
            {
                Name = "Dalas",
                Date = DateTime.UtcNow,
                Hour = RangeOfHoursEnumDTO.NinetOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O numero da sala é um campo obrigatório", response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task PostMeetingRoomWithoutDateAndBadRequest()
        {
            var meetingRoom = new MeetiingRommDTO
            {
                Name = "Tucson",
                Number = 2,
                Hour = RangeOfHoursEnumDTO.TenOclockAM
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("A data da reunião é um campo obrigatório", response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task PostMeetingRoomWithoutHourAndBadRequest()
        {
            var meetingRoom = new MeetiingRommDTO
            {
                Name = "Tucson",
                Number = 2,
                Date = DateTime.UtcNow
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("A hora da reunião é um campo obrigatório", response.Content.ReadAsStringAsync());
        }
    }
}
