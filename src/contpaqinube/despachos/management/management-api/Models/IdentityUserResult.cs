namespace DespachoWorkspace.Management.WebApi.Models;

public class IdentityUserResult
{
    public Guid LicenseId { get; set; }
    public Guid LicenseIdentityId { get; set; }
    public Guid InstaceId { get; set; }
    public Guid LicenseServiceId { get; set; }
    public string? Name { get; set; }
    public string? Rfc { get; set; }
    public string? Alias { get; set; }
    public string? Code { get; set; }
    public bool IsOwner { get; set; } = false;
    public bool HasManagerRole { get; set; } = false;
    public int UserStatusID { get; set; }
    public List<RoleResult> Roles { get; set; } = new List<RoleResult>();
    public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
}

public class RoleResult
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public int UserRoleStatusID { get; set; }
    public int? InternalId { get; set; }
}