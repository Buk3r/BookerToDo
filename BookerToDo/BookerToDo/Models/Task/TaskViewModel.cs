using BookerToDo.Helpers;
using System.Windows.Input;

namespace BookerToDo.Models.Task
{
    public class TaskViewModel : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set { SetProperty(ref _isDone, value); }
        }

        private ICommand _deleteTapCommand;
        public ICommand DeleteTapCommand
        {
            get { return _deleteTapCommand; }
            set { SetProperty(ref _deleteTapCommand, value); }
        }

        private ICommand _editTapCommand;
        public ICommand EditTapCommand
        {
            get { return _editTapCommand; }
            set { SetProperty(ref _editTapCommand, value); }
        }
    }
}
