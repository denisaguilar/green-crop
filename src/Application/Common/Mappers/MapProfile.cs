using AutoMapper;
using GreenCrop.Application.Common.Models;
using GreenCrop.Domain.Entities;

namespace GreenCrop.Application.Common.Mappers {
    public class MapProfile : Profile{
        public MapProfile() {
            CreateMap<Customer, CustomerDetails>();
            CreateMap<Account, AccountDetails>();
            CreateMap<Transaction, TransactionDetails>();
        }
    }
}
