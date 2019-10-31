using Api.MeetingRoom.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// AutoMapper
        /// </summary>
        public readonly IMapper _mapper;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public BaseController(IMapper mapper)
            => _mapper = mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PaginationReponseDTO GetPagination(int count, int page, int pageSize)
        {
            var totalPages = (int)Math.Ceiling((double)count / pageSize);

            var prevPage = page > 1 ? page - 1 : 1;

            var nextPage = page < totalPages ? page + 1 : totalPages;

            return new PaginationReponseDTO
            {
                TotalCount = count,
                TotalPages = totalPages,
                PrevPage = prevPage,
                NextPage = nextPage
            };
        }
    }
}
