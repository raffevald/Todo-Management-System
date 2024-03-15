using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesConfiguration {
    internal class TodoGroupsConfiguration : IEntityTypeConfiguration<TodoGroup> {
        public void Configure ( EntityTypeBuilder<TodoGroup> entity ) {
            entity.HasKey ( e => e.Id ).HasName ( "pk_todo_groups" );

            entity.ToTable ( "todo_groups" );

            entity.Property ( e => e.Id ).HasColumnName ( "id" );
            entity.Property ( e => e.GroupName )
                .HasMaxLength ( 128 )
                .HasColumnName ( "group_name" );
            entity.Property ( e => e.CreateOn ).HasColumnName ( "create_on" );
        }
    }
}
