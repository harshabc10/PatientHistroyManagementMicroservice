using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientHistoryManagementMicrosevices.DTO;
using PatientHistoryManagementMicrosevices.Service;

namespace PatientHistoryManagementMicrosevices.Controllers
{
    [ApiController]
    [Route("api/medicalhistory")]
    [Authorize(Roles = "Doctor")]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _service;

        public MedicalHistoryController(IMedicalHistoryService service)
        {
            _service = service;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveMedicalHistory(SaveMedicalHistoryRequestModel request)
        {
            try
            {
                var result = await _service.SaveMedicalHistoryAsync(request);
                return Ok(result); // Return the ID of the saved history
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("get/{patientId}")]
        public async Task<IActionResult> GetMedicalHistory(int patientId)
        {
            try
            {
                var history = await _service.GetMedicalHistoryAsync(patientId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}
