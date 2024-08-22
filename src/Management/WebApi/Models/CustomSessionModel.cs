

namespace DespachoWorkspace.Management.WebApi.Models
{
    public class CustomSessionModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomSessionModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Dictionary<string, string> Attributes
        {
            get => GetValue<Dictionary<string, string>>("sattr", new Dictionary<string, string>());
            set => SetValue("sattr", value);
        }

        public Guid GuidID
        {
            get => GetValue<Guid>("GuidId", Guid.Empty);
            set => SetValue("GuidId", value);
        }

        public Guid IdentityID
        {
            get => GetValue<Guid>("IdentityID", Guid.Empty);
            set => SetValue("IdentityID", value);
        }

        public string? AuthorizationHeader
        {
            get => GetValue<string>("AuthorizationHeader", string.Empty);
            set => SetValue("AuthorizationHeader", value);
        }

        public Guid InstanceID
        {
            get => GetValue<Guid>("InstanceID", Guid.Empty);
            set => SetValue("InstanceID", value);
        }

        public Guid? LicenseServiceID
        {
            get => GetValue<Guid>("LicenseServiceID", Guid.Empty);
            set => SetValue("LicenseServiceID", value);
        }

        public Guid LicenseID
        {
            get => GetValue<Guid>("LicenseID", Guid.Empty);
            set => SetValue("LicenseID", value);
        }

        public Guid ServiceID
        {
            get => GetValue<Guid>("ServiceID", Guid.Empty);
            set => SetValue("ServiceID", value);
        }

        public Guid AppID
        {
            get => GetValue<Guid>("AppID", Guid.Empty);
            set => SetValue("AppID", value);
        }

        public string? LicenseCode
        {
            get => GetValue<string>("LicenseCode", string.Empty);
            set => SetValue("LicenseCode", value);
        }

        public string? RFC
        {
            get => GetValue<string>("RFC", string.Empty);
            set => SetValue("RFC", value);
        }

        public bool? IsOwner
        {
            get => GetValue<bool>("IsOwner", false);
            set => SetValue("IsOwner", value);
        }

        public bool? HasManagerRole
        {
            get => GetValue<bool>("HasManagerRole", false);
            set => SetValue("HasManagerRole", value);
        }

        public bool IsOwnerOrManager => IsOwner == true || HasManagerRole == true;

        public List<RoleResult>? Roles
        {
            get => GetValue<List<RoleResult>>("Roles", new List<RoleResult>());
            set => SetValue("Roles", value);
        }

        public string Culture
        {
            get => GetValue<string>("Culture", "es-MX");
            set => SetValue("Culture", value);
        }

        private T GetValue<T>(string key, T defaultValue)
        {
            var context = _httpContextAccessor.HttpContext;

            if (context != null && context.Items.ContainsKey(key))
            {
                var value = context.Items[key];

                if (value is T typedValue)
                {
                    return typedValue;
                }
                else {
                    //login error?
                    throw new InvalidOperationException("No active HttpContext to set the value.");
                }
            }

            return defaultValue;
        }

        private void SetValue<T>(string key, T value)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.Items[key] = value;
            }
            else
            {
                //login 
                throw new InvalidOperationException("No active HttpContext to set the value.");
            }
        }
    }
}
