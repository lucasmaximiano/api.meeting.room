using Api.MeetingRoom.Business.Interface;
using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Domain.Enum;
using Api.MeetingRoom.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Business
{
    public class MeetingRoomSchedulingBusiness : IMeetingRoomSchedulingBusiness
    {
        private readonly IMeetingRoomSchedulingRepository _meetingRoomSchedulingRepository;
        public MeetingRoomSchedulingBusiness(IMeetingRoomSchedulingRepository meetingRoomSchedulingRepository)
        {
            _meetingRoomSchedulingRepository = meetingRoomSchedulingRepository;
        }

        public async Task<MeetingRoomSchedulingModel> PostMeetingRommScheduling(MeetingRoomSchedulingModel meetingRomm)
        {
            await CheckIfMeetingRoomSchedulingExists(meetingRomm.Date, meetingRomm.Number, meetingRomm.Hour);

            try
            {
                return await _meetingRoomSchedulingRepository.PostMeetingRommScheduling(meetingRomm);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel reservar a sala");
            }
        }
        public async Task<IEnumerable<MeetingRoomSchedulingModel>> GetAllMeetingRommScheduling(int page, int pageSize)
        {
            try
            {
                return await _meetingRoomSchedulingRepository.GetAllMeetingRommScheduling(page, pageSize);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel recuperar as reservas");
            }
        }

        public async Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingById(int id)
        {
            try
            {
               return await _meetingRoomSchedulingRepository.GetMeetingRoomSchedulingById(id);
            }
            catch (Exception)
            {
                throw new Exception("Não foi recupera a reserva");
            }
        }

        public async Task<int> GetAllMeetingRommSchedulingCount()
        {
            try
            {
                return await _meetingRoomSchedulingRepository.GetAllMeetingRommSchedulingCount();
            }
            catch (Exception)
            {
                throw new Exception("Não foi recuperar a quantidade de reservas");
            }
        }

        public async Task<MeetingRoomSchedulingModel> PutMeetingRommScheduling(int id, MeetingRoomSchedulingModel meetingRomm)
        {
            await CheckIfMeetingRoomSchedulingExists(meetingRomm.Date, meetingRomm.Number, meetingRomm.Hour);

            try
            {
                return await _meetingRoomSchedulingRepository.PutMeetingRommScheduling(id, meetingRomm);
            }
            catch (Exception)
            {
                throw new Exception("Não foi atualizar a reserva");
            }
        }

        public async Task DeleteMeetingRoomScheduling(int id)
        {
            try
            {
                await _meetingRoomSchedulingRepository.DeleteMeetingRoomScheduling(id);
            }
            catch (Exception)
            {
                throw new Exception("Não foi deletar a reserva");
            }
        }

        private async Task CheckIfMeetingRoomSchedulingExists(DateTime date, int numer, RangeOfHoursEnum Hour)
        {
            var meetingRoomScheduling = await _meetingRoomSchedulingRepository.GetMeetingRoomSchedulingByDateAndHourAndNumber(date, numer, Hour);

            if (meetingRoomScheduling != null)
                throw new Exception("Já existe uma reserva nesta sala");
        }
    }
}
