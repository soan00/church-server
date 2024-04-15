using AutoMapper;
using churchApp.Models;
using churchApp.Models.Tables;

namespace churchApp.AutoMapperProfiles
{
    public class AutoMaper:Profile
    {
        public AutoMaper()
        {
            CreateMap<PrayerTable,PrayerModel>();
            CreateMap<PrayerModel,PrayerTable>();
        }
    }
}
