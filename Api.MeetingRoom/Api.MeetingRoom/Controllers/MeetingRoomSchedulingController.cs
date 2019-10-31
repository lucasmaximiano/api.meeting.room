using Api.MeetingRoom.Business.Interface;
using Api.MeetingRoom.Domain;
using Api.MeetingRoom.DTO;
using Api.MeetingRoom.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Controllers
{
    /// <summary>
    /// MeetingRoomSchedulingController
    /// </summary>
    [Route("meetingroomscheduling")]
    public class MeetingRoomSchedulingController : BaseController
    {
        private readonly IMeetingRoomSchedulingBusiness _meetingRoomSchedulingBusiness;
        /// <summary>
        /// AutoMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// MeetingRoomSchedulingController
        /// </summary>
        /// <param name="meetingRoomSchedulingBusiness"></param>
        /// <param name="mapper"></param>
        public MeetingRoomSchedulingController(IMeetingRoomSchedulingBusiness
            meetingRoomSchedulingBusiness, IMapper mapper) : base(mapper)
        {
            _meetingRoomSchedulingBusiness = meetingRoomSchedulingBusiness;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere uma reserva
        /// </summary>
        /// <param name="meetiingRommScheduling">Obeto de entrada de dados</param>
        [HttpPost]
        [ValidateModel]
        [Produces(typeof(MeetingRoomSchedulingDTO))]
        [SwaggerResponse(HttpStatusCode.Created, "Inserido com sucesso", typeof(MeetingRoomSchedulingDTO))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Requisição mal-formatada", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Conflito", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> PostMeetingRommScheduling([FromBody]MeetingRoomSchedulingDTO meetiingRommScheduling)
        {
            var meetingRommScheduling = _mapper.Map<MeetingRoomSchedulingModel>(meetiingRommScheduling);
            var newMeetingRommScheduling = await _meetingRoomSchedulingBusiness.PostMeetingRommScheduling(meetingRommScheduling);
            return CreatedAtAction(nameof(GetMeetingRoomSchedulingById), new { id = meetingRommScheduling.Id }, _mapper.Map<MeetingRoomSchedulingDTO>(newMeetingRommScheduling));
        }

        /// <summary>
        /// Retorna todas reservas de acordo com seus filtros
        /// </summary>
        /// <param name="pagination">Paginação</param>
        [HttpGet]
        [ValidateModel]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(IEnumerable<MeetingRoomSchedulingDTO>))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> GetAllMeetingRommScheduling([FromQuery] PaginationDTO pagination)
        {
            var meetingRommScheduling = await _meetingRoomSchedulingBusiness.GetAllMeetingRommScheduling(pagination.Page, pagination.PageSize);
            var count = await _meetingRoomSchedulingBusiness.GetAllMeetingRommSchedulingCount();

            if (!meetingRommScheduling.Any())
                return Ok(meetingRommScheduling);

            var meetingRommPaginationDTO = new MeetingRoomSchedulingPaginationDTO
            {
                List = _mapper.Map<List<MeetingRoomSchedulingDTO>>(meetingRommScheduling),
                Pagination = GetPagination(count, pagination.Page, pagination.PageSize)
            };

            return Ok(meetingRommPaginationDTO);
        }

        /// <summary>
        /// Retorna uma reserva pelo seu id
        /// </summary>
        /// <param name="id">Id da reserva</param>
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(MeetingRoomSchedulingDTO))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> GetMeetingRoomSchedulingById(int id)
        {
            var meetingRoomScheduling = await _meetingRoomSchedulingBusiness.GetMeetingRoomSchedulingById(id);

            if (meetingRoomScheduling == null)
                return NotFound();

            return Ok(_mapper.Map<MeetingRoomSchedulingDTO>(meetingRoomScheduling));
        }

        /// <summary>
        /// Atualizar uma reserva pelo seu id
        /// </summary>
        /// <param name="id">Id da reserva</param>
        /// <param name="meetiingRomm">Objeto de entrada de dados</param>
        [HttpPut("{id}")]
        [ValidateModel]
        [Produces(typeof(MeetingRoomSchedulingDTO))]
        [SwaggerResponse(HttpStatusCode.Created, "Atualizado com sucesso", typeof(MeetingRoomSchedulingDTO))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Requisição mal-formatada", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Conflito", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> PutMeetingRommScheduling(int id, [FromBody]MeetingRoomSchedulingDTO meetiingRomm)
        {
            var meetingRommScheduling = _mapper.Map<MeetingRoomSchedulingModel>(meetiingRomm);
            var newMeetingRommScheduling = await _meetingRoomSchedulingBusiness.PutMeetingRommScheduling(id, meetingRommScheduling);
            return CreatedAtAction(nameof(GetMeetingRoomSchedulingById), new { id = newMeetingRommScheduling.Id }, _mapper.Map<MeetingRoomSchedulingDTO>(newMeetingRommScheduling));
        }

        /// <summary>
        /// Deleta uma reserva pelo seu id
        /// </summary>
        /// <param name="id">Id da reserva</param>
        [HttpDelete("{id}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse(HttpStatusCode.OK, "Removido com sucesso", null)]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Erro de Autenticação", null)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Recurso não encontrado", null)]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro na API", null)]
        public async Task<IActionResult> DeleteMeetingRoomScheduling(int id)
        {
            await _meetingRoomSchedulingBusiness.DeleteMeetingRoomScheduling(id);
            return Ok();
        }
    }
}
