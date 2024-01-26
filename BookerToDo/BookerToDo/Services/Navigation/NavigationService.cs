using BookerToDo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookerToDo.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region -- INavigationService implementation --

        public Task<NavigationResult> NavigateAsync(Page page)
        {
            return NavigateAsync(page, new Dictionary<string, object>());
        }

        public async Task<NavigationResult> NavigateAsync(
            Page page,
            IDictionary<string, object> parameters)
        {
            var result = new NavigationResult();

            try
            {
                var currentPage = GetCurrentPage();

                if (currentPage != null)
                {
                    await OnInitializedAsync(page, parameters);
                    await OnNavigatedToAsync(page, parameters);

                    await currentPage.Navigation.PushAsync(page);

                    result.SetSuccess();
                }
                else
                {
                    result.SetError("Current page not found!");
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public Task<NavigationResult> AbsoluteNavigateAsync(Page page)
        {
            return AbsoluteNavigateAsync(page, new Dictionary<string, object>());
        }

        public async Task<NavigationResult> AbsoluteNavigateAsync(
            Page page,
            IDictionary<string, object> parameters)
        {
            var result = new NavigationResult();

            try
            {
                var currentPage = GetCurrentPage();
                await OnInitializedAsync(page, parameters);
                await OnNavigatedToAsync(page, parameters);

                if (currentPage != null)
                {
                    Application.Current.MainPage = new NavigationPage(page);
                    await currentPage.Navigation.PopToRootAsync();

                    result.SetSuccess();
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(page);
                    result.SetSuccess();
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public Task<NavigationResult> GoBackAsync()
        {
            return GoBackAsync(new Dictionary<string, object>());
        }

        public async Task<NavigationResult> GoBackAsync(IDictionary<string, object> parameters)
        {
            var result = new NavigationResult();

            try
            {
                var currentPage = GetCurrentPage();
                var previousPage = GetPreviousPage();

                if (currentPage != null && previousPage != null)
                {
                    await OnNavigatedToAsync(previousPage, parameters);
                    await currentPage.Navigation.PopAsync();
                }
                else
                {
                    result.SetError("Current or previous page not found!");
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        #endregion

        #region -- Private methods --

        private Page GetCurrentPage()
        {
            return Application.Current
                .MainPage?.Navigation?
                .NavigationStack?.LastOrDefault();
        }

        private Page GetPreviousPage()
        {
            var navigationStack = Application.Current.MainPage?.Navigation?.NavigationStack;

            return navigationStack != null
                ? navigationStack.ElementAtOrDefault(navigationStack.Count - 2)
                : null;
        }

        private static async Task OnInitializedAsync(Page page, IDictionary<string, object> parameters)
        {
            if (page.BindingContext is IInitialize viewModel)
            {
                viewModel.Initialize(parameters);
                await viewModel.InitializeAsync(parameters);
            }
        }

        private static async Task OnNavigatedToAsync(Page page, IDictionary<string, object> parameters)
        {
            if (page.BindingContext is INavigationAware viewModel)
            {
                viewModel.OnNavigatedTo(parameters);
                await viewModel.OnNavigatedToAsync(parameters);
            }
        }

        #endregion
    }
}
