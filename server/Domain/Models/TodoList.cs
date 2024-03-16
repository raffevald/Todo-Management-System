namespace Domain.Models {
    public class TodoList {
        public int Id { get; set; }
        public int? TodoGroupId { get; set; }
        public string ListName { get; set; }
        public DateTime CreateOn { get; set; }

        public virtual TodoGroup TodoGroup { get; set; }
    }
}
