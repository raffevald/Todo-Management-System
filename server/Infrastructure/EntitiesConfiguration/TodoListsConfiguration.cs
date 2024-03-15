using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesConfiguration {
    internal class TodoListsConfiguration : IEntityTypeConfiguration<TodoList> {
        public void Configure ( EntityTypeBuilder<TodoList> entity ) {
            entity.HasKey ( e => e.Id ).HasName ( "pk_todo_lists" );

            entity.ToTable ( "todo_lists" );

            entity.Property ( e => e.Id ).HasColumnName ( "id" );
            entity.Property ( e => e.TodoGroupId ).HasColumnName ( "todo_group_id" );
            entity.Property ( e => e.ListName )
                .HasMaxLength ( 128 )
                .HasColumnName ( "list_name" );
            entity.Property ( e => e.CreateOn ).HasColumnName ( "create_on" );
        }
    }
}
