using System.Globalization;

namespace ISWeb.Client
{
    public class UserAgent
    {
       // HttpContext httpContext;
        private string _userAgent;

        private ClientBrowser _browser;
        public ClientBrowser Browser
        {
            get
            {
                if (_browser == null)
                {
                    _browser = new ClientBrowser(_userAgent);
                }
                return _browser;
            }
        }

        private ClientOS _os;
        public ClientOS OS
        {
            get
            {
                if (_os == null)
                {
                    _os = new ClientOS(_userAgent);
                }
                return _os;
            }
        }

        public CultureInfo Language {
            get {
                string lang = ISHttpContext.Current.Request.Headers["Accept-Language"].ToString();
                var languages = lang.Split(',');
                string language = languages[0].ToLowerInvariant().Trim();
                return CultureInfo.CreateSpecificCulture(language);
            }
        }

        public UserAgent(string userAgent)
        {
            _userAgent = userAgent;
        }
    }
}
