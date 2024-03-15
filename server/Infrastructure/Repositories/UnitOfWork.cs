using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories {
    public class UnitOfWork : IUnitOfWork {
        protected readonly ApplicationDbContext _applicationDbContext;
        public ITodoGroupsRepository TodoGroupsRepository { get; }
        public ITodoListsRepository TodoListsRepository { get; }
        public ITodosRepository TodosRepository { get; }

        public UnitOfWork ( ApplicationDbContext applicationDbContext ) {
            _applicationDbContext = applicationDbContext;

            TodoGroupsRepository = new TodoGroupsRepository ( _applicationDbContext );
            TodoListsRepository = new TodoListsRepository ( _applicationDbContext );
            TodosRepository = new TodosRepository ( _applicationDbContext );
        }

        public void Dispose ( ) {
            _applicationDbContext
                .Dispose ();
        }

        public Task<int> SaveChanges ( ) {
            return _applicationDbContext
                .SaveChangesAsync ();
        }
    }
}
