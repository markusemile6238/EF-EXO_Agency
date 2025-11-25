using Domaine.Interfaces;
using Domaine.Model;

namespace Domaine.Services
{
    public class DestinationService
    {
        private readonly IDestinationRepository _idestinationRepository;

        public DestinationService(IDestinationRepository IdestinationRepository)
        {
            _idestinationRepository = IdestinationRepository;
        }

        public async Task<IEnumerable<Destination>> GetAlldestinationAsync()
        {
            return await _idestinationRepository.GetAllAsync();
        }


        public async Task AddAsync(Destination destination)
        {
            await _idestinationRepository.AddAsync(destination);
        }

    }
}
