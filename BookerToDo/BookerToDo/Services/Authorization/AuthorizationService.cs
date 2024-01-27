using BookerToDo.Services.SettingsManager;

namespace BookerToDo.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ISettingsManager _settingsManager;

        public AuthorizationService()
        {
            _settingsManager = new SettingsManager.SettingsManager();
        }

        public bool IsAuthorized
        {
            get
            {
                return _settingsManager.IsAuthorized;
            }
        } 

        public void LogIn()
        {
            _settingsManager.IsAuthorized = true;
        }

        public void LogOut()
        {
            _settingsManager.ClearSettings();
        }
    }
}