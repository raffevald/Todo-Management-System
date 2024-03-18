using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class TodosRepository : Repository<Todo>, ITodosRepository {
        public TodosRepository ( ApplicationDbContext applicationDbContext ) : base ( applicationDbContext ) { }


        public Task<Todo> GetDuplicate ( Todo model ) {
            return _applicationDbContext
                .Todos
                .FirstOrDefaultAsync ( 
                    i => i.TodoItem.Equals ( model.TodoItem, StringComparison.CurrentCultureIgnoreCase ) 
                 );
        }

        public void ChangeCompletedOrNot ( Todo model ) {
            _applicationDbContext
                 .Set<Todo> ()
                 .Update ( model );
        }
    }
}
