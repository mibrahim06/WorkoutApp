using AutoMapper;
using WorkoutApp.DataTransferObjects.Responses;
using WorkoutApp.Entities;

namespace WorkoutApp.Services.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Workout, WorkoutDisplayResponse>();
    }
    
}