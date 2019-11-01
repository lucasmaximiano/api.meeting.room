using Api.MeetingRoom.Business.Interface;
using Api.MeetingRoom.Domain;
using Api.MeetingRoom.DTO;
using Api.MeetingRoom.Filters;
//using Api.MeetingRoom.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Controllers
{
    /// <summary>
    /// MeetingRoomController
    /// </summary>
    [Route("meetingroom")]
    public class MeetingRoomController : BaseController
    {

        private readonly IMeetingRoomBusiness _meetingRoomBusiness;
        /// <summary>
        /// AutoMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// MeetingRoomController
        /// </summary>
        /// <param name="meetingRoomBusiness"></param>
        /// <param name="mapper"></param>
        public MeetingRoomController(IMeetingRoomBusiness
            meetingRoomBusiness, IMapper mapper) : base(mapper)
        {
            _meetingRoomBusiness = meetingRoomBusiness;
            _mapper = mapper;
        }


        /// <summary>
        /// Insere uma sala
        /// </summary>
        /// <param name="meetiingRomm">Objeto de entrada de dados</param>
        [HttpPost]
        [ValidateModel]
        [Produces(typeof(MeetingRommDTO))]
        [SwaggerResponse(HttpStatusCode.Created, "Inserido com sucesso", typeof(MeetingRommDTO))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Requisição mal-formatada", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Conflito", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> Post([FromBody]MeetingRommDTO meetiingRomm)
        {
            var meetingRomm = _mapper.Map<MeetingRommModel>(meetiingRomm);
            var newMeetingRomm = await _meetingRoomBusiness.PostMeetingRomm(meetingRomm);
            return CreatedAtAction(nameof(GetMeetingRoomById), new { id = newMeetingRomm.Id }, _mapper.Map<MeetingRommDTO>(newMeetingRomm));
        }


        /// <summary>
        /// Retorna todas as salas de acordo com seus filtros
        /// </summary>
        /// <param name="pagination">Paginação</param>
        [HttpGet]
        [ValidateModel]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(MeetingRommPaginationDTO))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> Get([FromQuery]PaginationDTO pagination)
        {
            var meetingRomms = await _meetingRoomBusiness.GetAllMeetingRomm(pagination.Page, pagination.PageSize);
            var count = await _meetingRoomBusiness.GetAllMeetingRommCount();

            var meetingRommPaginationDTO = new MeetingRommPaginationDTO
            {
                List = _mapper.Map<List<MeetingRommDTO>>(meetingRomms),
                Pagination = GetPagination(count, pagination.Page, pagination.PageSize)
            };

            return Ok(meetingRommPaginationDTO);
        }

        /// <summary>
        /// Retorna a sala pelo seu id
        /// </summary>
        /// <param name="id">Id da sala</param>
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(MeetingRommDTO))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> GetMeetingRoomById(int id)
        {
            var meetingRomm = await _meetingRoomBusiness.GetMeetingRoomById(id);

            if(meetingRomm == null)
                return NotFound();

            return Ok(_mapper.Map<MeetingRommDTO>(meetingRomm));
        }

        /// <summary>
        /// Atualiza uma sala pelo seu id
        /// </summary>
        /// <param name="id">Id da sala</param>
        /// <param name="meetiingRomm">Objeto de entrada de dados</param>
        [HttpPut("{id}")]
        [ValidateModel]
        [Produces(typeof(MeetingRommDTO))]
        [SwaggerResponse(HttpStatusCode.Created, "Atualizado com sucesso", typeof(MeetingRommDTO))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Requisição mal-formatada", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Conflito", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> Put(int id, [FromBody]MeetingRommDTO meetiingRomm)
        {
            var meetingRomm = _mapper.Map<MeetingRommModel>(meetiingRomm);
            var newMeetingRomm = await _meetingRoomBusiness.PutMeetingRomm(id, meetingRomm);
            return CreatedAtAction(nameof(GetMeetingRoomById), new { id = newMeetingRomm.Id }, _mapper.Map<MeetingRommDTO>(newMeetingRomm));
        }

        /// <summary>
        /// Deleta uma sala pelo seu id
        /// </summary>
        /// <param name="id">Id da sala</param>
        [HttpDelete("{id}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse(HttpStatusCode.OK, "Removido com sucesso", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            await _meetingRoomBusiness.DeleteMeetingRoom(id);
            return Ok();
        }

        /// <summary>
        /// Retorna todas as salas de reunião e suas reservas de acordo com seus filtros
        /// </summary>
        /// <param name="pagination">Paginação</param>
        [HttpGet("reserve")]
        [ValidateModel]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(ReservePaginationDTO))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> GetAllReserve([FromQuery]PaginationDTO pagination)
        {
            var reserves = await _meetingRoomBusiness.GetAllReserve(pagination.Page, pagination.PageSize);
            var count = await _meetingRoomBusiness.GetAllMeetingRommCount();

            var reservePaginationDTO = new ReservePaginationDTO
            {
                List = _mapper.Map<List<ReserveResponseDTO>>(reserves),
                Pagination = GetPagination(count, pagination.Page, pagination.PageSize)
            };

            return Ok(reservePaginationDTO);
        }
    }
}
