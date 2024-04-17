using PatientHistoryManagementMicrosevices.DTO;
using PatientHistoryManagementMicrosevices.Entity;
using PatientHistoryManagementMicrosevices.Repo;

namespace PatientHistoryManagementMicrosevices.Service
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _repository;

        public MedicalHistoryService(IMedicalHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> SaveMedicalHistoryAsync(SaveMedicalHistoryRequestModel request)
        {
            // Map request to entity
            var historyEntity = new MedicalHistoryEntity
            {
                PatientId = request.PatientId,
                Description = request.HistoryDetails,
                CreatedAt = DateTime.UtcNow // Set current timestamp
            };

            // Call repository method to save history
            return await _repository.SaveMedicalHistoryAsync(historyEntity);
        }

        public async Task<List<MedicalHistoryDTO>> GetMedicalHistoryAsync(int patientId)
        {
            // Call repository method to get history
            var historyEntities = await _repository.GetMedicalHistoryAsync(patientId);

            // Map entities to DTOs
            var historyDTOs = historyEntities.Select(e => new MedicalHistoryDTO
            {
                Id = e.Id,
                PatientId = e.PatientId,
                HistoryDetails = e.Description,
                CreatedAt = e.CreatedAt
            }).ToList();

            return historyDTOs;
        }
    }
}
