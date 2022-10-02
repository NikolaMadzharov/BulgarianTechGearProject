using AutoMapper;
using BulgarianTechGear.Models.MobilePhone;
using BulgarianTechGear.Models.MobilePhones;

namespace BulgarianTechGear.Models
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Data.Models.MobilePhone, AddMobilePhoneFromModel>();
            CreateMap<AddMobilePhoneFromModel,Data.Models.MobilePhone>();
            CreateMap<Data.Models.MobilePhone, MobilePhoneListingViewModel>()
                .ForMember(b => b.MobilePhoneBrand, o=> o.MapFrom(s => s.Brand.Brand));
        }
    }
}