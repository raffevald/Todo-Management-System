using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.TodoList {
    public class TodoListDTO {
        public int Id { get; set; }

        public int? TodoGroupId { get; set; }

        [Display(Name = "List Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(128, ErrorMessage = "{0} cant no be more then {1} characters.")]
        public string ListName { get; set; }

        [Display(Name = "Create On")]
        [Column(TypeName = "datetime")]
        public DateTime CreateOn { get; set; }
    }
}
