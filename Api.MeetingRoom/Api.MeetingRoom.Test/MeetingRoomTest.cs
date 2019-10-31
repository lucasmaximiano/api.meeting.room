using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pagesize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase(0, 10)]
        public async Task GetMeetingRoomWithInvalidPageAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pagesize={pageSize}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("A página é um campo obrigatório e deve ser diferente de 0", response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(1, 0)]
        public async Task GetMeetingRoomWithInvalidPageSizeAndBadRequest(int page, int pageSize)
        {
            var response = await _httpClient.GetAsync($"/meetingroom?page={page}&pagesize={pageSize}");

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
        [TestCase(-1)]
        public async Task GetMeetingRoomByIdWithNotFound(int id)
        {
            var response = await _httpClient.GetAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task PostMeetingRoomWithSucess()
        {

            var meetingRoom = new MeetingRommDTO
            {
                Name = "Las Vegas",
                Number = 1
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task PostMeetingRoomWithoutNameAndBadRequest()
        {
            var meetingRoom = new MeetingRommDTO
            {
                Name = null,
                Number = 1
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

            var meetingRoom = new MeetingRommDTO
            {
                Name = "Dalas"
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PostAsync($"/meetingroom", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O numero da sala é um campo obrigatório", response.Content.ReadAsStringAsync());
        }



        [TestCase(1)]
        public async Task PutMeetingRoomWithSucess(int id)
        {

            var meetingRoom = new MeetingRommDTO
            {
                Name = "Las Vegas",
                Number = 1,
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PutAsync($"/meetingroom/{id}", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCase(1)]
        public async Task PutMeetingRoomWithoutNameAndBadRequest(int id)
        {
            var meetingRoom = new MeetingRommDTO
            {
                Name = null,
                Number = 1
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PutAsync($"/meetingroom/{id}", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O nome da sala é um campo obrigatório", response.Content.ReadAsStringAsync());
        }

        [TestCase(1)]
        public async Task PutMeetingRoomWithoutNumberAndBadRequest(int id)
        {

            var meetingRoom = new MeetingRommDTO
            {
                Name = "Dalas"
            };

            var json = new StringContent(JsonConvert.SerializeObject(meetingRoom));

            var response = await _httpClient.PutAsync($"/meetingroom/{id}", json);

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("O numero da sala é um campo obrigatório", response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(1)]
        public async Task DeleteMeetingRoomByIdWithSucess(int id)
        {
            var response = await _httpClient.DeleteAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase(-1)]
        public async Task DeleteMeetingRoomByIdNotFound(int id)
        {
            var response = await _httpClient.DeleteAsync($"/meetingroom/{id}");

            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
