using EduFlow.Shared.Dtos.AdminService.AdminOrganizationDtos;

namespace EduFlow.Shared.Dtos.AdminService.AdminDtos
{
    public record AdminDto
    {
        public AdminDto()
        {
            AdminOrganizations = [];
        }


        public ushort AdminId { get; set; }
        public Guid AdminGuid { get; set; }

        public string? FirstName { get; set; }//Front End prop

        public string? LastName { get; set; }//Front End prop


        public string? Email { get; set; }//Front End prop

        public string? Password { get; set; }//Front End prop
        public bool IsEmailverified { get; set; }
        public byte OTP { get; set; }
        public DateTime? OTPExpiredAt { get; set; }
        public bool IsNumberVerified { get; set; }

        public string? MobileNumber { get; set; }//Front End prop
        public byte Status { get; set; }
        public string? ProfileImage { get; set; }//Front End prop

        public bool IsSuperAdmin { get; set; }
        public ICollection<AdminOrganizationDto> AdminOrganizations { get; set; }
    }
}
