using Dapper;
using PatientHistoryManagementMicrosevices.Context;
using PatientHistoryManagementMicrosevices.Entity;
using System.Data;

namespace PatientHistoryManagementMicrosevices.Repo
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly DapperContext _dapperContext;

        public MedicalHistoryRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> SaveMedicalHistoryAsync(MedicalHistoryEntity history)
        {
            string query = @"
        INSERT INTO MedicalHistory (PatientId, Description, Date)
        VALUES (@PatientId, @Description, @Date);
        SELECT SCOPE_IDENTITY();
    ";

            using var connection = _dapperContext.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query, new
            {
                PatientId = history.PatientId,
                Description = history.Description,
                Date = history.CreatedAt
            });
        }

        public async Task<List<MedicalHistoryEntity>> GetMedicalHistoryAsync(int patientId)
        {
            string query = @"
                SELECT *
                FROM MedicalHistory
                WHERE PatientId = @PatientId;
            ";

            using var connection = _dapperContext.CreateConnection();
            var result = await connection.QueryAsync<MedicalHistoryEntity>(query, new { PatientId = patientId });
            foreach (var entity in result) {
                await Console.Out.WriteLineAsync(entity.Description);
            }
            return result.ToList(); // Explicitly convert to List
        }
    }
}
