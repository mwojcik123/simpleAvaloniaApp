using System;

namespace ToDoList.DataModel
{
    public class ToDoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = String.Empty;
        public bool IsChecked { get; set; }
    }
}
