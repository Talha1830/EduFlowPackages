using Microsoft.AspNetCore.Http;

namespace EduFlow.Shared.Dtos.AdminService.AdminDtos
{
    public class AdminInputDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? MobileNumber { get; set; }
        public string? ProfileImageBase64 { get; set; }
        public string? ImageName { get; set; }
    }
}
