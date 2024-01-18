using SQLite;

namespace BookerToDo.Models
{
    public class TaskModel : IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
