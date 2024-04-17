using PatientHistoryManagementMicrosevices.DTO;
using PatientHistoryManagementMicrosevices.Entity;

namespace PatientHistoryManagementMicrosevices.Repo
{
    public interface IMedicalHistoryRepository
    {
        public Task<int> SaveMedicalHistoryAsync(MedicalHistoryEntity history);
        public Task<List<MedicalHistoryEntity>> GetMedicalHistoryAsync(int patientId);
    }
}
