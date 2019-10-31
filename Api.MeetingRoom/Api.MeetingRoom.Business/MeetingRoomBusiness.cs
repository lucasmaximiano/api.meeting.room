using Api.MeetingRoom.Business.Interface;
using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Business
{
    public class MeetingRoomBusiness : IMeetingRoomBusiness
    {
        private readonly IMeetingRoomRepository _meetingRoomRepository;
        public MeetingRoomBusiness(IMeetingRoomRepository meetingRoomRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
        }

        public async Task<MeetingRommModel> PostMeetingRomm(MeetingRommModel meetingRomm)
        {
            await CheckIfExistsMeetingRoom(null, meetingRomm.Number);

            try
            {
                return await _meetingRoomRepository.PostMeetingRomm(meetingRomm);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o nova sala de reunião");
            }
        }

        public async Task<IEnumerable<MeetingRommModel>> GetAllMeetingRomm(int page, int pageSize)
        {
            try
            {
                return await _meetingRoomRepository.GetAllMeetingRomm(page, pageSize);
            }
            catch (Exception)
            {
                throw new Exception("Não foi recuperar as salas de reunião");
            }
        }

        public async Task<MeetingRommModel> GetMeetingRoomById(int id)
        {
            try
            {
                return await _meetingRoomRepository.GetMeetingRoomById(id);
            }
            catch (Exception)
            {
                throw new Exception("Não foi recupera a sala de reunião");
            }
        }

        public async Task<int> GetAllMeetingRommCount()
        {
            try
            {
                return await _meetingRoomRepository.GetAllMeetingRommCount();
            }
            catch (Exception)
            {
                throw new Exception("Não foi recuperar a quantidade de salas de reunião");
            }
        }

        public async Task<MeetingRommModel> PutMeetingRomm(int id, MeetingRommModel meetingRomm)
        {
            await CheckIfExistsMeetingRoom(id, meetingRomm.Number);

            try
            {
                return await _meetingRoomRepository.PutMeetingRomm(id, meetingRomm);
            }
            catch (Exception)
            {
                throw new Exception("Não foi atualizar a sala de reunião");
            }
        }

        public async Task DeleteMeetingRoom(int id)
        {
            try
            {
                await _meetingRoomRepository.DeleteMeetingRoom(id);
            }
            catch (Exception)
            {
                throw new Exception("Não foi deletar a sala de reunião");
            }
        }


        private async Task CheckIfExistsMeetingRoom(int? id, int number)
        {
            var mettingRomm = await _meetingRoomRepository.GetMeetingRoomByNumer(number);

            if (mettingRomm != null)
                if (id == null || id != mettingRomm.Id)
                    throw new Exception("Já existe uma sala de reunião com esse numero");
        }

    }
}
