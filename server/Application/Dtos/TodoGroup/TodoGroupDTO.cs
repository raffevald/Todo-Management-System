using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.TodoGroup
{
    public class TodoGroupDTO {
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(128, ErrorMessage = "{0} cant no be more then {1} characters.")]
        public string GroupName { get; set; }

        [Display(Name = "Create On")]
        [Column(TypeName = "datetime")]
        public DateTime CreateOn { get; set; }
    }
}
