using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration {
    internal class TodosConfiguration : IEntityTypeConfiguration<Todo> {
        public void Configure ( EntityTypeBuilder<Todo> entity ) {
            entity.HasKey ( e => e.Id ).HasName ( "pk_todos" );

            entity.ToTable ( "todos" );

            entity.Property ( e => e.Id ).HasColumnName ( "id" );
            entity.Property ( e => e.TodoListId ).HasColumnName ( "todo_list_id" );
            entity.Property ( e => e.TodoItem )
                .HasMaxLength ( 512 )
                .HasColumnName ( "todo_item" );
            entity.Property ( e => e.CreateOn ).HasColumnName ( "create_on" );
            entity.Property ( e => e.DueDate ).HasColumnName ( "due_date" );
            entity.Property ( e => e.ReminderDate ).HasColumnName ( "reminder_date" );
            entity.Property ( e => e.Repeat )
                .HasMaxLength ( 32 )
                .HasColumnName ( "repeat" );
            entity.Property ( e => e.Important ).HasColumnName ( "important" );
            entity.Property ( e => e.Completed ).HasColumnName ( "completed" );
        }
    }
}