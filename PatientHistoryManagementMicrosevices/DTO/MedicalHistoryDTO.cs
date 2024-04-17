namespace PatientHistoryManagementMicrosevices.DTO
{
    public class MedicalHistoryDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string HistoryDetails { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
