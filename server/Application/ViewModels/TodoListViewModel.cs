namespace Application.ViewModels {
    public class TodoListViewModel {
        public int Id { get; set; }
        public int? TodoGroupId { get; set; }
        public string ListName { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
