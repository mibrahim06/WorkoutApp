using AutoMapper;
using WorkoutApp.DataTransferObjects.Requests;
using WorkoutApp.DataTransferObjects.Responses;
using WorkoutApp.Entities;

namespace WorkoutApp.Services.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Workout, WorkoutDisplayResponse>();
        CreateMap<Category, CategoryDisplayResponse>();
        CreateMap<CreateNewWorkoutRequest, Workout>();
    }
    
}