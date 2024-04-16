using churchApp.Models;
using churchApp.Models.Tables;

namespace churchApp.Interface
{
    public interface IHome
    {
        Task<bool> PostPrayerRequest(PrayerModel model);
        Task<bool> PostMeeting(MeetingModel model);
        Task<PrayerModel?> GetPrayers(int userId);
        Task<IEnumerable<PrayerTable>> GetAllPrayers();
        Task<IEnumerable<MeetingTable>> GetAllMeetings();

    }
}