using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class Repository<TModel> : IRepository<TModel> where TModel : class {
        protected readonly ApplicationDbContext _applicationDbContext;

        public Repository ( ApplicationDbContext applicationDbContext ) {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<TModel>> Get ( ) {
            return _applicationDbContext
                .Set<TModel> ()
                .ToListAsync ();
        }

        public Task<TModel> Get ( int id ) {
            return _applicationDbContext
                .Set<TModel> ()
                .FindAsync ( id ).AsTask ();
        }

        public void Create ( TModel model ) {
            _applicationDbContext
                .Set<TModel> ()
                .Add ( model );
        }

        public void Update ( TModel model ) {
            _applicationDbContext
                .Set<TModel> ()
                .Update ( model );
        }

        public void Delete ( TModel model ) {
            _applicationDbContext
                .Set<TModel> ()
                .Remove ( model );
        }

        public void CreateRange ( List<TModel> models ) {
            _applicationDbContext
                .Set<TModel> ()
                .AddRange ( models );
        }

        public void UpdateRange ( List<TModel> models ) {
            _applicationDbContext
                .Set<TModel> ()
                .UpdateRange ( models );
        }

        public void DeleteRange ( List<TModel> models ) {
            _applicationDbContext
                .Set<TModel> ()
                .RemoveRange ( models );
        }
    }
}
