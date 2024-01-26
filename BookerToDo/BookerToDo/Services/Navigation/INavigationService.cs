using BookerToDo.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookerToDo.Services.Navigation
{
    public interface INavigationService
    {
        Task<NavigationResult> NavigateAsync(Page page);
        Task<NavigationResult> NavigateAsync(Page page, IDictionary<string, object> parameters);
        Task<NavigationResult> AbsoluteNavigateAsync(Page page);
        Task<NavigationResult> AbsoluteNavigateAsync(Page page, IDictionary<string, object> parameters);
        Task<NavigationResult> GoBackAsync();
        Task<NavigationResult> GoBackAsync(IDictionary<string, object> parameters);
    }
}
