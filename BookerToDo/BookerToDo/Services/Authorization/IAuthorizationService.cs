namespace BookerToDo.Services.Authorization
{
    public interface IAuthorizationService
    {
        bool IsAuthorized { get; }
        void LogIn();
        void LogOut();
    }
}
