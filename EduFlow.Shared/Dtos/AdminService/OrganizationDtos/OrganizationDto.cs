using EduFlow.Shared.Dtos.AdminService.AdminOrganizationDtos;

namespace EduFlow.Shared.Dtos.AdminService.OrganizationDtos
{
    public class OrganizationDto
    {
        public OrganizationDto()
        {
            AdminOrganizations = [];
        }

        public ushort OrganizationId { get; set; }
        public Guid OrganizationGuid { get; set; }

        public string? Name { get; set; }//Front End prop

        public string? Location { get; set; }//Front End prop

        public string? City { get; set; }//Front End prop

        public string? Province { get; set; }//Front End prop

        public DateTime RegisteredAt { get; set; }
        public DateTime RegisterationExpiredAt { get; set; }
        public byte OrganizationType { get; set; }//Front End prop ddl

        public DateTime? TrialStart { get; set; }
        public DateTime? TrialEnd { get; set; }
        public string? Logo { get; set; }//Front End prop
        public byte Status { get; set; }
        public ICollection<AdminOrganizationDto> AdminOrganizations { get; set; }

        #region Formatted Properties
        public string TrialEndFormatted
        {
            get
            {
                return TrialEnd.HasValue ? TrialEnd.Value.ToString("d MMM yyyy") : string.Empty;
            }
        }
        public string TrialStartFormatted
        {
            get
            {
                return TrialStart.HasValue ? TrialStart.Value.ToString("d MMM yyyy") : string.Empty;
            }
        }

        public bool IsTrialExpired { get { return TrialEnd.HasValue ? TrialEnd.Value.Date >= DateTime.Now.Date : false; } }
        public bool IsRegisteredExpired { get { return RegisterationExpiredAt.Date >= DateTime.Now.Date; } }
        #endregion
    }
}
