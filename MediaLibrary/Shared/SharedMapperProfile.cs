using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Shared
{
    public class SharedMapperProfile : Profile
    {
        public SharedMapperProfile()
        {
            CreateMap<DateTime, Timestamp>()
           .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));

            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<Contracts.Person, Models.PersonModel>().ReverseMap();
        }
    }
}
