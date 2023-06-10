using AutoMapper;
using WorkoutApp.DataTransferObjects.Responses;
using WorkoutApp.Infrastructure.Repositories;

namespace WorkoutApp.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IMapper _mapper;
    private readonly IWorkoutRepository _workoutRepository;
    public WorkoutService(IMapper mapper, IWorkoutRepository workoutRepository)
    {
        _mapper = mapper;
        _workoutRepository = workoutRepository;
    }
    
    public IEnumerable<WorkoutDisplayResponse> GetWorkoutDisplayResponses()
    {
        var workouts = _workoutRepository.GetAll();
        return _mapper.Map<IEnumerable<WorkoutDisplayResponse>>(workouts);
    }
}