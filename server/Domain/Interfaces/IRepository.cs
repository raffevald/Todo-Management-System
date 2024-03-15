namespace Domain.Interfaces {
    public interface IRepository<TModel> where TModel : class {
        Task<List<TModel>> Get();
        Task<TModel> Get ( int id );
        void Create ( TModel model );
        void Update ( TModel model );
        void Delete ( TModel model );
        void CreateRange ( List<TModel> models );
        void UpdateRange ( List<TModel> models );
        void DeleteRange ( List<TModel> models );
    }
}
