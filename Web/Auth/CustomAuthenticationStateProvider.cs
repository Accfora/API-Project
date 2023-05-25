using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Web.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        readonly ProtectedSessionStorage _sessionStorage;
        readonly ProtectedLocalStorage _localStorage;
        ClaimsPrincipal _anon = new ClaimsPrincipal(new ClaimsIdentity());
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anon));
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, userSession.Id),
                    new Claim(ClaimTypes.Name, userSession.FirstName),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                try
                {
                    var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                    var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                    if (userSession == null)
                    {
                        return await Task.FromResult(new AuthenticationState(_anon));
                    }
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Sid,userSession.Id),
                    new Claim(ClaimTypes.Name,userSession.FirstName),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Role,userSession.Role),
                }, "CustomAuth"));

                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
                catch
                {
                    return await Task.FromResult(new AuthenticationState(_anon));
                }
            }
        }
        public async Task UpdateAuthenticationStateAsync(UserSession userSession) 
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                await _localStorage.SetAsync("LocalUserSession", userSession);

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, userSession.Id),
                    new Claim(ClaimTypes.Name, userSession.FirstName),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anon;
            }
            
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public CustomAuthenticationStateProvider(ProtectedSessionStorage ss, ProtectedLocalStorage ls)
        {
            _sessionStorage= ss;
            _localStorage= ls;
        }
    }
}
