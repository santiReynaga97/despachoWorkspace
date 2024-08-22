using System.Globalization;
using System.Text;
using System.Text.Json;
using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Models;
using Microsoft.Extensions.Primitives;

namespace DespachoWorkspace.Management.WebApi.Services;

public class SessionService : ISessionService
{
    private readonly CustomSessionModel _customSession;
    private readonly IHttpContextAccessor _httpContextAccesor;
    private readonly IEncryptionService _encryptionService;
    public SessionService(CustomSessionModel customSessionModel,
     IHttpContextAccessor httpContext,
     IEncryptionService encryptionService)
    {
        _customSession = customSessionModel;
        _httpContextAccesor = httpContext;
        _encryptionService = encryptionService;
    }

    public void Initialize()
    {
        if (IsHttpContextNull())
        {
            var currentPath = _httpContextAccesor.HttpContext.Request.Path.ToString().ToLower();
            bool isCreateCompanyRequest = currentPath.Contains("companyassistant");

            var userAgent = _httpContextAccesor.HttpContext.Request.Headers["User-Agent"].ToString();

            ValidateRequiredHeaders(isCreateCompanyRequest);

            string securitySalt = DecryptHeaderValue("gid", userAgent, "").ToString();

            _customSession.GuidID = new Guid(securitySalt);
            _customSession.LicenseID = DecryptHeaderValue("lid", userAgent, securitySalt);
            _customSession.InstanceID = DecryptHeaderValue("inid", userAgent, securitySalt);
            _customSession.ServiceID = DecryptHeaderValue("srId", userAgent, securitySalt);
            _customSession.IdentityID = DecryptHeaderValue("iId", userAgent, securitySalt, !isCreateCompanyRequest);
            _customSession.LicenseServiceID = DecryptHeaderValue("lsid", userAgent, securitySalt);

            if (_httpContextAccesor.HttpContext.Request.Headers.TryGetValue("inac", out StringValues inac) && !string.IsNullOrEmpty(inac))
            {
                string jsonString = _encryptionService.Decrypt(inac, userAgent, securitySalt);
                var instanceAccess = JsonSerializer.Deserialize<IdentityUserResult>(jsonString);

                _customSession.LicenseServiceID = instanceAccess?.LicenseServiceId;
                _customSession.LicenseCode = instanceAccess?.Code;
                _customSession.IsOwner = instanceAccess?.IsOwner;
                _customSession.HasManagerRole = instanceAccess?.HasManagerRole;
                _customSession.Roles = instanceAccess?.Roles;
            }

            _customSession.AuthorizationHeader = _httpContextAccesor.HttpContext.Request.Headers["Authorization"];

            Thread.CurrentThread.CurrentCulture = new CultureInfo(_customSession.Culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_customSession.Culture);
        }
        else
        {
            throw new InvalidOperationException("No active HttpContext to set the value.");
        }

    }

    public void InitializeDelegates()
    {
        if (IsHttpContextNull())
        {
            _customSession.AuthorizationHeader = _httpContextAccesor.HttpContext.Request.Headers["Authorization"];
        }
        else
        {
            throw new InvalidOperationException("No active HttpContext to set the value.");
        }
    }

    private void ValidateRequiredHeaders(bool isCreateCompanyRequest)
    {
        StringValues gId = _httpContextAccesor.HttpContext.Request.Headers["gid"];
        StringValues identityId = _httpContextAccesor.HttpContext.Request.Headers["iid"];
        StringValues instanceId = _httpContextAccesor.HttpContext.Request.Headers["inid"];

        bool invalidMandatoryHeaders = string.IsNullOrEmpty(gId) || string.IsNullOrEmpty(identityId);

        if (invalidMandatoryHeaders || (!isCreateCompanyRequest && string.IsNullOrEmpty(instanceId)))
        {
            throw new UnauthorizedAccessException("Invalid session.");
        }
    }

    private Guid DecryptHeaderValue(string header, string decryptionKey, string userAgent, bool isBase64Encoded = false)
    {
        if (!_httpContextAccesor.HttpContext.Request.Headers.TryGetValue(header, out StringValues value) || string.IsNullOrEmpty(value))
        {
            return Guid.Empty;
        }

        if (isBase64Encoded)
        {
            return new Guid(Encoding.UTF8.GetString(Convert.FromBase64String(value.ToString())));
        }

        return new Guid(_encryptionService.Decrypt(value, userAgent, decryptionKey));
    }

    private bool IsHttpContextNull()
    {
        return _httpContextAccesor.HttpContext is not null;
    }
}