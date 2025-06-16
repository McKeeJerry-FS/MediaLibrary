using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MediaLibrary.Contracts;

namespace MediaLibrary.Shared
{
    public class SharedMapperProfile : Profile
    {
        public SharedMapperProfile()
        {
            // Add your mapping configurations here
            // For example:
            // CreateMap<SourceModel, DestinationModel>();
            CreateMap<DateTime, Timestamp>()
            .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));

            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<Person, Model.PersonModel>().ReverseMap();
        }
    }
    
}
