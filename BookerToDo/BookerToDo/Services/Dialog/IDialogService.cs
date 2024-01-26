﻿using System.Threading.Tasks;

namespace BookerToDo.Services.Dialog
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
