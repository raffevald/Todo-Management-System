using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.Todo {
    public class TodoDTO {
        public int Id { get; set; }

        public int? TodoListId { get; set; }

        [Display(Name = "Todo Item")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(128, ErrorMessage = "{0} cant no be more then {1} characters.")]
        public string TodoItem { get; set; }

        [Display(Name = "Create On")]
        [Column(TypeName = "datetime")]
        public DateTime CreateOn { get; set; }

        [Display(Name = "Due Date")]
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Reminder Date")]
        [Column(TypeName = "datetime")]
        public DateTime? ReminderDate { get; set; }

        [StringLength(32, ErrorMessage = "{0} cant no be more then {1} characters.")]
        public string Repeat { get; set; }

        public Boolean Important { get; set; }

        public Boolean Completed { get; set; }
    }
}
