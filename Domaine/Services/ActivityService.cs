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
            if (activityDto.Price == null)
                throw new ArgumentNullException(nameof(activityDto.Price), "Le prix est obligatoire");

            if (activityDto.DestinationId == null)
                throw new ArgumentNullException(nameof(activityDto.DestinationId), "L'ID de destination est obligatoire");

            Activity newActivity = new Activity(            
                title:activityDto.Title ?? string.Empty,
                description:activityDto.Description ?? string.Empty,
                price: activityDto.Price.Value,
                destinationId: activityDto.DestinationId.Value
           );

            await _iactivityRepository.AddAsync(newActivity);
        }




    }
}

