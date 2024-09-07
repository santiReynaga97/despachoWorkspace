using System.Globalization;
using System.Text;
using System.Text.Json;
using ContpaqiNube.Despachos.Management.Api.Abstractions;
using ContpaqiNube.Despachos.Management.Api.Models;
using Microsoft.Extensions.Primitives;

namespace ContpaqiNube.Despachos.Management.Api.Services;

public class SessionService : ISessionService
{
    private readonly CustomSessionModel _customSession;
    private readonly IHttpContextAccessor _httpContextAccesor;
    private readonly ILogger<SessionService> _logger;
    private readonly IEncryptionService _encryptionService;
    public SessionService(CustomSessionModel customSessionModel,
     IHttpContextAccessor httpContext,     
     ILogger<SessionService> logger,
    IEncryptionService encryptionService)
    {
        _customSession = customSessionModel;
        _httpContextAccesor = httpContext;
        _logger = logger;
        _encryptionService = encryptionService;
    }

    public void Initialize()
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

    public void InitializeDelegates()
    {        
        _customSession.AuthorizationHeader = _httpContextAccesor.HttpContext!.Request.Headers["Authorization"];
    }

    private void ValidateRequiredHeaders(bool isCreateCompanyRequest)
    {
        StringValues gId = _httpContextAccesor.HttpContext!.Request.Headers["gid"];
        StringValues identityId = _httpContextAccesor.HttpContext.Request.Headers["iid"];
        StringValues instanceId = _httpContextAccesor.HttpContext.Request.Headers["inid"];

        bool invalidMandatoryHeaders = string.IsNullOrEmpty(gId) || string.IsNullOrEmpty(identityId);

        if (invalidMandatoryHeaders || (!isCreateCompanyRequest && string.IsNullOrEmpty(instanceId)))
        {
            throw new UnauthorizedAccessException("Invalid session.");
        }
    }

    private Guid DecryptHeaderValue(string header, string userAgent, string decryptionKey, bool isBase64Encoded = false)
    {
        if (!_httpContextAccesor.HttpContext!.Request.Headers.TryGetValue(header, out StringValues value) || string.IsNullOrEmpty(value))
        {
            return Guid.Empty;
        }

        if (isBase64Encoded)
        {
            return new Guid(Encoding.UTF8.GetString(Convert.FromBase64String(value.ToString())));
        }
        
        return new Guid(_encryptionService.Decrypt(value!, userAgent, decryptionKey));
    }
}