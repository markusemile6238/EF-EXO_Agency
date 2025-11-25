using Domaine.Interfaces;
using Domaine.Model;
using Domaine.Model.DTO;

namespace Domaine.Services
{
    public class ActivityService 
    {
        private readonly IActivityRepository _iactivityRepository;



        public ActivityService(IActivityRepository activityRepository)
        {
            _iactivityRepository = activityRepository;
        }




        public async Task<IEnumerable<Activity>> GetActivitiesAsync()
        {
            return await _iactivityRepository.GetAllAsync();
        }


        public async Task<IEnumerable<Activity>> GetAllByDestinationId(int key)
        {
            return await _iactivityRepository.GetAllByDestinationId(key);   
        }


        public async Task AddAsync(ActivityDto activityDto)
        {
            Activity newActivity = new Activity(            
                title:activityDto.Title,
                description:activityDto.Description,
                price:(decimal) activityDto.Price,
                destinationId:(int) activityDto.DestinationId
           );

            await _iactivityRepository.AddAsync(newActivity);
        }




    }
}

