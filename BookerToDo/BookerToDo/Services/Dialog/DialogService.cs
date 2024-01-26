using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookerToDo.Services.Dialog
{
    public class DialogService : IDialogService
    {
        #region -- IDialogService implementation --

        public Task DisplayAlert(string title, string message, string cancel)
        {
            var currentPage = GetCurrentPage();

            return currentPage?.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var currentPage = GetCurrentPage();

            return currentPage?.DisplayAlert(title, message, accept, cancel);
        }

        #endregion

        #region -- Private methods -- 

        private Page GetCurrentPage()
        {
            return Application.Current
                .MainPage?.Navigation?
                .NavigationStack?.LastOrDefault();
        }

        #endregion
    }
}