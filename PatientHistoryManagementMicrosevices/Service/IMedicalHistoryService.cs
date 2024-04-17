using PatientHistoryManagementMicrosevices.DTO;
using PatientHistoryManagementMicrosevices.Entity;

namespace PatientHistoryManagementMicrosevices.Service
{
    public interface IMedicalHistoryService
    {
        public Task<int> SaveMedicalHistoryAsync(SaveMedicalHistoryRequestModel request);
        public Task<List<MedicalHistoryDTO>> GetMedicalHistoryAsync(int patientId);
    }
}
