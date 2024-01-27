namespace BookerToDo.Services.SettingsManager
{
    public interface ISettingsManager
    {
        bool IsAuthorized { get; set; }

        string SelectedAppLanguage { get; set; }

        void ClearSettings();
    }
}
