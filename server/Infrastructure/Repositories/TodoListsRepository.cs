using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories {
    public class TodoListsRepository : Repository<TodoList>, ITodoListsRepository {
        public TodoListsRepository ( ApplicationDbContext applicationDbContext ) : base ( applicationDbContext ) { }

        public Task<TodoList> GetDuplicate ( TodoList model ) {
            return _applicationDbContext
                .TodoLists
                .FirstOrDefaultAsync ( 
                    i => i.ListName.Equals ( model.ListName, StringComparison.CurrentCultureIgnoreCase ) 
                 );
        }
    }
}
