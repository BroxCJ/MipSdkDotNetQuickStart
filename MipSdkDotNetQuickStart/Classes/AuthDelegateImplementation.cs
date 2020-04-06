using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.InformationProtection;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MipSdkDotNetQuickStart
{
    public class AuthDelegateImplementation : IAuthDelegate
    {
        private ApplicationInfo _appInfo;
        private string redirectUri = "mip-sdk-app://authorize";
        public AuthDelegateImplementation(ApplicationInfo appInfo)
        {
            _appInfo = appInfo;
        }

        public string AcquireToken(Identity identity, string authority, string resource, string claims)
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            var result = Task.Run(async () => await authContext.AcquireTokenAsync(resource, _appInfo.ApplicationId, new Uri(redirectUri), new PlatformParameters(PromptBehavior.Always))).Result;
            return result.AccessToken;
        }
    }
    
}
