using EduFlow.Shared.Dtos.AdminService.AdminDtos;
using EduFlow.Shared.Dtos.AdminService.OrganizationDtos;

namespace EduFlow.Shared.Dtos.AdminService.AdminOrganizationDtos
{
    public class AdminOrganizationDto
    {
        public AdminOrganizationDto()
        {
            Admin = new();
            Organization = new();
        }

        public ushort AdminOrganizationId { get; set; }
        public ushort AdminId { get; set; }
        public AdminDto Admin { get; set; }

        public ushort OrganizationId { get; set; }
        public OrganizationDto Organization { get; set; }
    }
}
