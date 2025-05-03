namespace EduFlow.Shared.ApplicationEnums
{
    public enum LoginEnum : byte
    {
        AuthenticationFailed = 1,
        TrailExpired,
        RegisterationExpired,
        EmailNotVerified,
        NumberNotVerified,
        AccountDeactive,
        Invalidtoken,
        LoginSuccess
    }
    public enum AdminStatus : byte
    {
        SuperAdmin = 1
    }
    public enum OrganizationStatus : byte
    {
        Trail = 1,
        Registered
    }
    public enum OrganizationType : byte
    {
        University = 1,
        Secondary,
        Intermediate,
        Primary
    }
    public enum UserRoles : byte
    {
        SuperAdmin,
        Deen,
        Admin,
        HOD,
        Controller,
        Teacher,
        Student,
        Clerk
    }
    public enum Modules //Table Name : SYSADMIN.MODULE
    {
        SystemAdmin,
        Administration,
        Teacher,
        Student,
        HOD,
        ExamManagement,
        FinanceManagement,
        AttendanceManagement
    }
}
