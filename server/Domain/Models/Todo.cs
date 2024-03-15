namespace Domain.Models {
    public class Todo {
        public int Id { get; set; }
        public int? TodoListId { get; set; }
        public string TodoItem { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Repeat { get; set; }
        public Boolean Important { get; set; }
        public Boolean Completed { get; set; }

        public virtual TodoList TodoList { get; set; }
    }
}
