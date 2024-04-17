namespace PatientHistoryManagementMicrosevices.Entity
{
    public class MedicalHistoryEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
