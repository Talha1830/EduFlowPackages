using Microsoft.AspNetCore.Http;

namespace EduFlow.Shared.Dtos.AdminService.OrganizationDtos
{
    public class OrganizationInputDto
    {

        public string? Name { get; set; }//Front End prop
        public string? Location { get; set; }//Front End prop
        public string? City { get; set; }//Front End prop
        public string? Province { get; set; }//Front End prop
        public int OrganizationType { get; set; }//Front End prop ddl
        public string? Logo { get; set; }//Front End prop
        public IFormFile? LogoFile { get; set; }//Front End prop

    }
}
