using AutoMapper;
using WorkoutApp.DataTransferObjects.Requests;
using WorkoutApp.DataTransferObjects.Responses;
using WorkoutApp.Entities;
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
    
    public IEnumerable<WorkoutDisplayResponse> GetWorkoutDisplayResponsesByCategoryId(int categoryId)
    {
        var workouts = _workoutRepository.GetWorkoutsByCategory(categoryId);
        return _mapper.Map<IEnumerable<WorkoutDisplayResponse>>(workouts);
    }
    
    public WorkoutDisplayResponse GetWorkoutDisplayResponseById(int id)
    {
        var workout = _workoutRepository.GetByIdAsync(id).Result;
        return _mapper.Map<WorkoutDisplayResponse>(workout);
    }
    
    public async Task CreateWorkoutAsync(CreateNewWorkoutRequest request)
    {
        var workout = _mapper.Map<Workout>(request);
        await _workoutRepository.AddAsync(workout);
    }
}