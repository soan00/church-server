using AutoMapper;
using churchApp.Interface;
using churchApp.Models;
using churchApp.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace churchApp.Repo
{
    public class HomeRepo : IHome
    {
        private readonly ContexClass _contex;
        private readonly IMapper mapper;

        public HomeRepo(ContexClass contex, IMapper mapper)
        {
            _contex = contex;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MeetingTable>> GetAllMeetings()
        {
            return await _contex.Meeting.ToListAsync();
        }

        public async Task<IEnumerable<PrayerTable>> GetAllPrayers()
        {
            return await _contex.Prayer.Include(u=>u.Users).ToListAsync();
        }

        public async Task<PrayerTable?> GetPrayers(int userId)
        {
            var data = await _contex.Prayer.FirstOrDefaultAsync(x => x.userId == userId);
            if (data == null)
                return null;
            return data;
        }

        public async Task<bool> PostMeeting(MeetingModel model)
        {
            if (model!=null && model.name != "")   {
               var map=mapper.Map<MeetingTable>(model);
                _contex.Meeting.Add(map);
                await _contex.SaveChangesAsync();
                return true;


            }
            return false;
        }
        
        public async Task<bool> PostPrayerRequest(PrayerModel model)
        {
            if (model.requestFor != null && model.prayerRequest != null)
            {
                var userMap = mapper.Map<PrayerTable>(model);
                _contex.Prayer.Add(userMap);
                await _contex.SaveChangesAsync();
                return true;


            }
            return false;
        }

        Task<PrayerModel?> IHome.GetPrayers(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
