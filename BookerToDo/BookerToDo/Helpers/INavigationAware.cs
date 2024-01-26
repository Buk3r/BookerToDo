using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookerToDo.Helpers
{
    public interface INavigationAware
    {
        void OnNavigatedTo(IDictionary<string, object> parameters);
        Task OnNavigatedToAsync(IDictionary<string, object> parameters);
    }
}
