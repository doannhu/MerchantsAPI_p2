using AutoMapper;
using MerchantsAPI.DTOs;
using MerchantsAPI.Entities;

namespace MerchantsAPI.Profiles
{
    public class MerchantProfile: Profile
    {
        public MerchantProfile() 
        {
            CreateMap<Merchant, MerchantDto>();
            CreateMap<MerchantForCreationDto, Merchant>();
            CreateMap<MerchantForUpdatePaymentDto, Merchant>();
        }
    }
}
