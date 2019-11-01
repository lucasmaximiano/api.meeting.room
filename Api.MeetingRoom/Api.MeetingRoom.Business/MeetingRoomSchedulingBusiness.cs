using Api.MeetingRoom.Business.CustomException;
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
            CheckIfIsValidHour(meetingRomm.Hour);

            try
            {
                return await _meetingRoomSchedulingRepository.PostMeetingRommScheduling(meetingRomm);
            }
            catch (Exception)
            {
                throw new BusinessException("Não foi possivel reservar a sala");
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
                throw new BusinessException("Não foi possivel recuperar as reservas");
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
                throw new BusinessException("Não foi possivel recuperar a reserva");
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
                throw new BusinessException("Não foi possivel recuperar a quantidade de reservas");
            }
        }

        public async Task<MeetingRoomSchedulingModel> PutMeetingRommScheduling(int id, MeetingRoomSchedulingModel meetingRomm)
        {
            await CheckIfMeetingRoomSchedulingExists(meetingRomm.Date, meetingRomm.Number, meetingRomm.Hour);
            CheckIfIsValidHour(meetingRomm.Hour);

            try
            {
                return await _meetingRoomSchedulingRepository.PutMeetingRommScheduling(id, meetingRomm);
            }
            catch (Exception)
            {
                throw new BusinessException("Não foi possivel atualizar a reserva");
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
                throw new BusinessException("Não foi possivel deletar a reserva");
            }
        }

        private async Task CheckIfMeetingRoomSchedulingExists(DateTime date, int numer, RangeOfHoursEnum Hour)
        {
            var meetingRoomScheduling = await _meetingRoomSchedulingRepository.GetMeetingRoomSchedulingByDateAndHourAndNumber(date, numer, Hour);

            if (meetingRoomScheduling != null)
                throw new BusinessException("Já existe uma reserva nesta sala");
        }

        private void CheckIfIsValidHour(RangeOfHoursEnum Hour)
        {
            if ((int)Hour < 8 || (int)Hour > 18)
                throw new BusinessException("Hora da reunião fora do horário comercial");
        }
    }
}
