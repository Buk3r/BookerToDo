using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookerToDo.Helpers
{
    public interface IInitialize
    {
        void Initialize(IDictionary<string, object> parameters);
        Task InitializeAsync(IDictionary<string, object> parameters);
    }
}
